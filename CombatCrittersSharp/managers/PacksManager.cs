using System.Net;
using System.Net.Http.Json;
using CombatCrittersSharp.exception;
using CombatCrittersSharp.managers.interfaces;
using CombatCrittersSharp.objects.card.Interfaces;
using CombatCrittersSharp.objects.pack;
using CombatCrittersSharp.objects.user;
using CombatCrittersSharp.objects.userpack;
using CombatCrittersSharp.rest.payloads;
using CombatCrittersSharp.rest.routes;

namespace CombatCrittersSharp.managers
{
    public class PacksManager : IPackManager
    {
        private readonly IUser _user;
        private readonly IClient _client;

        public PacksManager(IClient client, IUser user)
        {
            _client = client;
            _user = user;
        }

        /// <summary>
        /// Reteives all packs in the game
        /// </summary>
        /// <returns></returns>

        public async Task<List<Pack>> GetAllPacksAsync()
        {
            try
            {
                var response = await _client.Rest.Get(PackRoutes.Packs());

                //Deserialize to PackDetailsPayload
                PackPayload[]? payload = await response.Content.ReadFromJsonAsync<PackPayload[]>();

                var packs = new List<Pack>();

                if (payload != null)
                {
                    foreach (PackPayload pack in payload)
                    {
                        packs.Add(Pack.FromPackPayload(pack, _client.Rest));

                    }
                }

                return packs;
            }
            catch (RestException e)
            {
                throw new AuthException("Failed to get Packs", e);
            }
        }

        /// <summary>
        /// Retrieves a pack by its ID
        /// </summary>
        /// <param name="packId">The ID of the pack to retrieve</param>
        /// <returns></returns>
        /// <exception cref="AuthException"></exception>
        public async Task<Pack> GetPackByIdAsync(int packId)
        {
            try
            {
                var response = await _client.Rest.Get(PackRoutes.Pack(packId));


                //Deserialize the response to a PackDetailsPayload
                PackPayload? payload = await response.Content.ReadFromJsonAsync<PackPayload>();

                if (payload == null)
                {
                    throw new RestException("Pack details not found for the given ID", response.StatusCode, response);
                }

                return Pack.FromPackPayload(payload, _client.Rest);
            }
            catch (RestException e) when (e.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new AuthException("Access denied, Failed to get decks", e);
            }
            catch (RestException)
            {
                throw;
            }
        }

        public async Task<List<UserPack>> GetUserPacksAsync(int userId)
        {
            try
            {
                var response = await _client.Rest.Get(PackRoutes.UserPacks(userId));

                UserPackPayload[]? payload = await response.Content.ReadFromJsonAsync<UserPackPayload[]>();

                var userPacks = new List<UserPack>();

                if (payload != null)
                {
                    foreach (var UserPackPayload in payload)
                    {
                        //Create a pack instance from the pack details in UserPackPayload
                        var pack = Pack.FromPackPayload(UserPackPayload.Item, _client.Rest);

                        //Add the pack and count to the 
                        userPacks.Add(new UserPack(pack, UserPackPayload.Count));
                    }
                }
                return userPacks;
            }
            catch (RestException e) when (e.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new AuthException("Access denied, Failed to get decks", e);
            }
            catch (RestException)
            {
                throw;
            }
        }

        //Fixed Limit of 5 slots. It will only vary depending on the pack type (Basic Pack: 3, Advanced Pack: 4, Premium Pack: 5)
        public async Task<Pack> CreatePackAsync(List<int> cardIds, Dictionary<int, int> rarityProbabilities, string packName, string packImage, int slotCount)
        {
            try
            {
                //Ensure slot count does not exceed 5
                slotCount = Math.Min(slotCount, 5);

                //Convert the rarity probabilities dictionaly int PackCardSlotItems
                var rarityWeightItems = rarityProbabilities
                    .Select(rp => new PackCardSlotItem(rarity: rp.Key, weight: rp.Value))
                    .ToArray();

                var slots = Enumerable.Repeat(new PackCardSlotPayload(rarityWeights: rarityWeightItems), slotCount).ToArray();

                //Prepare the payload with slot weights and card contents
                var payload = new PackCreatorPayload(
                    slots: slots,
                    contents: cardIds.Take(slotCount).ToArray(), //Ensure card count matches slot (Basic Pack: 3, Advanced: 4, Premium: 5)
                    pack_details: new PackPayload(name: packName, image: packImage, packid: -1)
                );

                return await CreatePackOnServerAsync(payload);
            }
            catch (RestException e) when (e.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new AuthException("Access denied. Failed to create pack due to insufficient permissions.", e);
            }
            catch (RestException e)
            {
                // Rethrow RestException with detailed message
                throw new RestException($"Failed to create pack. Server returned {e.StatusCode}: {e.ResponseContent}",
                                        e.StatusCode, e.ResponseMessage);
            }
        }

        //Helper method to send the creation request to the server
        private async Task<Pack> CreatePackOnServerAsync(PackCreatorPayload payload)
        {
            var response = await _client.Rest.Post(PackRoutes.Packs(), payload);
            var createdPack = await response.Content.ReadFromJsonAsync<PackPayload>();

            if (createdPack == null)
            {
                throw new Exception("Pack creation failed.");
            }
            return Pack.FromPackPayload(createdPack, _client.Rest); //conver payload to pack and return
        }

    }
}
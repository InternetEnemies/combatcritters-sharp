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
            catch (RestException e) when (e.StatusCode == HttpStatusCode.Forbidden)
            {
                // Handle forbidden access specifically
                GeneralExceptionHandler.HandleException(e, "Access denied. Failed to retrieve packs in PacksManager.");
                return new List<Pack>(); // Return empty list to indicate restricted access
            }
            catch (RestException e)
            {
                // Log other REST-related errors and return an empty list
                GeneralExceptionHandler.HandleException(e, "REST error while retrieving all packs in PacksManager.");
                return new List<Pack>();
            }
            catch (Exception ex)
            {
                // Log any unexpected errors and return an empty list
                GeneralExceptionHandler.HandleException(ex, "Unexpected error while retrieving all packs in PacksManager.");
                return new List<Pack>();
            }
        }

        /// <summary>
        /// Retrieves a pack by its ID
        /// </summary>
        /// <param name="packId">The ID of the pack to retrieve</param>
        /// <returns></returns>
        /// <exception cref="AuthException"></exception>
        public async Task<Pack?> GetPackByIdAsync(int packId)
        {
            try
            {
                var response = await _client.Rest.Get(PackRoutes.Pack(packId));


                //Deserialize the response to a PackDetailsPayload
                PackPayload? payload = await response.Content.ReadFromJsonAsync<PackPayload>();

                if (payload == null)
                {
                    GeneralExceptionHandler.HandleException(
                        new RestException("Pack details not found for the given ID", response.StatusCode, response),
                        "Pack payload was null after deserialization."
                    );
                    return null; // Return null to indicate the pack was not found
                }

                return Pack.FromPackPayload(payload, _client.Rest);
            }
            catch (RestException e) when (e.StatusCode == HttpStatusCode.Forbidden)
            {
                // Log the forbidden access and return null
                GeneralExceptionHandler.HandleException(e, "Access denied. Failed to retrieve pack by ID in PacksManager.");
                return null;
            }
            catch (RestException e)
            {
                // Log any other REST errors and return null
                GeneralExceptionHandler.HandleException(e, "REST error while retrieving pack by ID in PacksManager.");
                return null;
            }
            catch (Exception ex)
            {
                // Log unexpected errors and return null
                GeneralExceptionHandler.HandleException(ex, "Unexpected error while retrieving pack by ID in PacksManager.");
                return null;
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
                // Log the forbidden access and return null
                GeneralExceptionHandler.HandleException(e, "Access denied. Failed to retrieve pack by ID in PacksManager.");
                return new List<UserPack>();
            }
            catch (RestException e)
            {
                GeneralExceptionHandler.HandleException(e, "Failed to retrieve user packs in PacksManager.");
                return new List<UserPack>();
            }
            catch (Exception ex)
            {
                GeneralExceptionHandler.HandleException(ex, "Unexpected error while retrieving user packs in PacksManager.");
                return new List<UserPack>();
            }
        }

        //Fixed Limit of 5 slots. It will only vary depending on the pack type (Basic Pack: 3, Advanced Pack: 4, Premium Pack: 5)
        public async Task<Pack?> CreatePackAsync(List<int> cardIds, Dictionary<int, int> rarityProbabilities, string packName, string packImage, int slotCount)
        {
            try
            {
                //Input validation 
                if (cardIds == null || cardIds.Count == 0)
                    throw new ArgumentException("Card IDs cannot be null or empty.", nameof(cardIds));

                if (rarityProbabilities == null || rarityProbabilities.Count == 0)
                    throw new ArgumentException("Rarity probabilities cannot be null or empty.", nameof(rarityProbabilities));

                if (string.IsNullOrWhiteSpace(packName))
                    throw new ArgumentException("Pack name cannot be null or whitespace.", nameof(packName));

                if (string.IsNullOrWhiteSpace(packImage))
                    throw new ArgumentException("Pack image cannot be null or whitespace.", nameof(packImage));

                slotCount = 5;

                //Convert the rarity probabilities dictionaly int PackCardSlotItems
                var rarityWeightItems = rarityProbabilities
                    .Select(rp => new PackCardSlotItem(rarity: rp.Key, weight: rp.Value))
                    .ToArray();

                var slots = Enumerable.Repeat(new PackCardSlotPayload(rarityWeights: rarityWeightItems), slotCount).ToArray();

                //Prepare the payload with slot weights and card contents
                var payload = new PackCreatorPayload(
                    slots: slots,
                    contents: cardIds.Take(10).ToArray(), //Ensure card count matches slot (Basic Pack: 3, Advanced: 4, Premium: 5)
                    pack_details: new PackPayload(name: packName, image: packImage, packid: -1)
                );

                return await CreatePackOnServerAsync(payload);
            }
            catch (ArgumentException ex)
            {
                GeneralExceptionHandler.HandleException(ex, "Invalid argument provided while creating pack in PacksManager.");
                return null;
            }
            catch (RestException e) when (e.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new AuthException("Access denied. Failed to create pack.", e);
            }
            catch (RestException e)
            {
                GeneralExceptionHandler.HandleException(e, "REST error while creating pack in PacksManager.");
                return null;
            }
            catch (Exception ex)
            {
                GeneralExceptionHandler.HandleException(ex, "Unexpected error while creating pack in PacksManager.");
                return null;
            }
        }

        //Helper method to send the creation request to the server
        private async Task<Pack> CreatePackOnServerAsync(PackCreatorPayload payload)
        {
            var response = await _client.Rest.Post(PackRoutes.PacksCreate(), payload);
            var createdPack = await response.Content.ReadFromJsonAsync<PackPayload>();

            if (createdPack == null)
            {
                throw new Exception("Pack creation failed.");
            }
            return Pack.FromPackPayload(createdPack, _client.Rest); //conver payload to pack and return
        }

    }
}
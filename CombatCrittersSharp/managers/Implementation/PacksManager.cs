using System.Net;
using System.Net.Http.Json;
using CombatCrittersSharp.exception;
using CombatCrittersSharp.managers.interfaces;
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
        /// Get a list of all game pack
        /// </summary>
        /// <returns></returns>
        public async Task<List<Pack>> GetAllPacksAsync()
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

            //Return either an empty pack list of a populated one
            return packs;
        }

        /// <summary>
        /// This fetches a pack by its id
        /// </summary>
        /// <param name="packId">The id of the pack to be fetched</param>
        /// <returns>The pack if it exists</returns>
        public async Task<Pack?> GetPackByIdAsync(int packId)
        {
            var response = await _client.Rest.Get(PackRoutes.Pack(packId));

            //Deserialize the response to a PackDetailsPayload
            PackPayload? payload = await response.Content.ReadFromJsonAsync<PackPayload>();
            if (payload == null)
            {
                return null;
            }
            return Pack.FromPackPayload(payload, _client.Rest);
        }

        /// <summary>
        /// The gets a User's packs list
        /// </summary>
        /// <param name="userId">The of the user</param>
        /// <returns>a user pack list</returns>
        public async Task<List<UserPack>> GetUserPacksAsync(int userId)
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

            //Either return an empty list or a list of packs
            return userPacks;
        }

        /// <summary>
        /// Send request to create a new pack
        /// </summary>
        /// <param name="name"> pack name</param>
        /// <param name="image">pack image</param>
        /// <param name="cardIds">pack card ids</param>
        /// <param name="slotRarityProbabilities">A list of dictionaries, each representing one slot's rarity weights</param>
        /// <returns></returns>
        public async Task<Pack?> CreatePackAsync(string name, string image, int[] cardIds, List<Dictionary<int, int>> slotRarityProbabilities)
        {
            //Construct the pack payload
            var packPayload = new PackPayload(
                name: name,
                image: image,
                packid: -1
            );

            //Convert slot data
            PackCardSlotPayload?[] slots = slotRarityProbabilities
                .Select(slotRarities =>
                    new PackCardSlotPayload(
                        slotRarities.Select(kvp => new PackCardSlotItem(kvp.Key, kvp.Value)).ToArray()
                    )
                ).ToArray();

            //Construct pack Creator payload
            var packCreatorPayload = new PackCreatorPayload(
                contents: cardIds,
                pack_details: packPayload,
                slots: slots
            );

            var response = await _client.Rest.Post(PackRoutes.PacksCreate(), packCreatorPayload);
            var createdPack = await response.Content.ReadFromJsonAsync<PackPayload>();

            if (createdPack != null)
            {
                return Pack.FromPackPayload(createdPack, _client.Rest); //conver payload to pack and return
            }
            return null;
        }
    }
}
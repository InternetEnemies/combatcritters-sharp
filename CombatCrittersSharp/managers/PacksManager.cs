using System.Net.Http.Json;
using CombatCrittersSharp.managers.interfaces;
using CombatCrittersSharp.objects.pack;
using CombatCrittersSharp.objects.user;
using CombatCrittersSharp.rest;
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


        public async Task<List<Pack>> GetAllPacksAsync()
        {
            var response = await _client.Rest.Get(PackRoutes.Packs());

            //Deserialize to PackDetailsPayload
            PackDetailsPayload[]? payload = await response.Content.ReadFromJsonAsync<PackDetailsPayload[]>();

            var packs = new List<Pack>();

            if (payload != null)
            {
                foreach (PackDetailsPayload pack in payload)
                {
                    packs.Add(Pack.FromPackDetailsPayload(pack, _client.Rest));

                }
            }

            return packs;
        }


    }
}
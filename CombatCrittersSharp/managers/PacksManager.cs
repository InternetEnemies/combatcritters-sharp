using System.Net.Http.Json;
using System.Reflection;
using CombatCrittersSharp.exception;
using CombatCrittersSharp.managers.interfaces;
using CombatCrittersSharp.objects.card.Interfaces;
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
            catch (RestException e)
            {
                throw new AuthException("Failed to get Packs", e);
            }


        }

        /// <summary>
        /// Retrieves the content cards by a specific packID
        /// </summary>
        /// <param name="packId">The ID of the pack</param>
        /// <returns></returns>
        /// <exception cref="AuthException"></exception>
        public async Task<List<ICard>> GetPackContentsAsync(int packId)
        {
            try
            {
                var response = await _client.Rest.Get(PackRoutes.PackCards(packId));

                //Desetialize the response into a list of cards
                CardPayload[]? payload = await response.Content.ReadFromJsonAsync<CardPayload[]>();

                var cards = new List<ICard>();

                if (payload != null)
                {
                    foreach (var cardPayload in payload)
                    {
                        cards.Add(cardPayload.ToCard());
                    }
                }

                return cards;
            }
            catch (RestException e)
            {
                throw new AuthException("Failed to get packs by id", e);
            }
        }




    }
}
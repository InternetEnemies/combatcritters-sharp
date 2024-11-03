using System.Net.Http.Json;
using CombatCrittersSharp.objects.card.Interfaces;
using CombatCrittersSharp.rest;
using CombatCrittersSharp.rest.payloads;
using CombatCrittersSharp.rest.routes;

namespace CombatCrittersSharp.objects.pack
{
    public class Pack : IPack
    {
        public string Image { get; private set; }
        public string Name { get; private set; }
        public int PackId { get; private set; }

        public List<ICard>? Contents { get; set; }
        private readonly IRest _rest;



        public Pack(string image, string name, int packId, IRest rest)
        {
            Image = image;
            Name = name;
            PackId = packId;
            _rest = rest;
            Contents = null;
        }

        //Static methos for instantiation from payloads
        public static Pack FromPackPayload(PackPayload payload, IRest rest)
        {
            return new Pack(payload.image, payload.name, payload.packid, rest);
        }

        /// <summary>
        /// Sets the contents of this pack. This will be used during PACK CREATION
        /// </summary>
        /// <param name="contents"> The list of cards to set as content</param>
        public void SetContents(List<ICard> contents)
        {
            Contents = contents;
        }

        /// <summary>
        /// Retrieves pack content.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ICard>> GetPackContentsAsync()
        {
            var response = await _rest.Get(PackRoutes.PackCards(PackId));

            PackContentsPayload? contentsPayload = await response.Content.ReadFromJsonAsync<PackContentsPayload>();

            var cards = new List<ICard>();

            if (contentsPayload?.cards != null)
            {
                foreach (var cardPayload in contentsPayload.cards)
                {
                    cards.Add(cardPayload.ToCard());
                }
            }

            //Set the contents after retrieval
            Contents = cards;
            return cards;
        }
    }
}
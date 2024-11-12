using CombatCrittersSharp.objects.MarketPlace.Interfaces;
using CombatCrittersSharp.rest.payloads;

namespace CombatCrittersSharp.objects.MarketPlace.Implementations
{
    public class OfferItem : IOfferItem
    {
        public string Type { get; set; }
        public int Count { get; set; }
        public int ItemId { get; set; }

        public OfferItem(OfferItemPayload payload)
        {
            Type = payload.type;
            Count = payload.count;
            ItemId = payload.item_id;
        }
    }
}
using CombatCrittersSharp.objects.MarketPlace.Interfaces;
using CombatCrittersSharp.rest.payloads;

namespace CombatCrittersSharp.objects.MarketPlace.Implementations
{
    public class OfferCreationItem : IOfferCreationItem
    {
        public int Count { get; set; }
        public int? ItemId { get; set; }
        public string Type { get; set; }

        public OfferCreationItem(int count, int? itemId, string type)
        {
            Count = count;
            ItemId = itemId;
            Type = type;
        }

        public static OfferCreationItem FromOfferCreationItemPayload(OfferCreationItemPayload payload)
        {
            return new OfferCreationItem(payload.count, payload.id, payload.type);
        }
    }
}
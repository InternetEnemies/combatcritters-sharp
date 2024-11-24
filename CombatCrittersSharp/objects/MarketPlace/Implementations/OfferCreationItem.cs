using CombatCrittersSharp.objects.MarketPlace.Interfaces;
using CombatCrittersSharp.rest.payloads;

namespace CombatCrittersSharp.objects.MarketPlace.Implementations
{
    public class OfferCreationItem : IOfferCreationItem
    {
        public int Count { get; set; }
        public int? ItemId { get; set; }
        public OfferItemType Type { get; set; }

        public OfferCreationItem(int count, int? itemId, OfferItemType type)
        {
            Count = count;
            ItemId = itemId;
            Type = type;
        }

        public static OfferCreationItem FromOfferCreationItemPayload(OfferCreationItemPayload payload)
        {
            return new OfferCreationItem(payload.count, payload.itemid, payload.type);
        }
    }
}
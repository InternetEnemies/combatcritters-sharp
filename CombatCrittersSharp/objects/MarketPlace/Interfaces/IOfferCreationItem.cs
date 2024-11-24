using CombatCrittersSharp.rest.payloads;

namespace CombatCrittersSharp.objects.MarketPlace.Interfaces
{
    public interface IOfferCreationItem
    {
        int Count { get; set; }
        int? ItemId { get; set; }
        OfferItemType Type { get; set; }
    }
}
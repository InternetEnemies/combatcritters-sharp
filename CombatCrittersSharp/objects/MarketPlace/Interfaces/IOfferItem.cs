namespace CombatCrittersSharp.objects.MarketPlace.Interfaces
{
    public interface IOfferItem
    {
        string Type { get; set; }
        int Count { get; set; }
        int ItemId { get; set; }
    }
}
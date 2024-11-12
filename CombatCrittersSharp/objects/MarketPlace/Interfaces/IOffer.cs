namespace CombatCrittersSharp.objects.MarketPlace.Interfaces
{
    public interface IOffer
    {
        int Id { get; set; }
        List<IOfferItem> Give { get; set; }
        IOfferItem Receive { get; set; }
    }
}
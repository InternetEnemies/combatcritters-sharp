namespace CombatCrittersSharp.objects.MarketPlace.Interfaces
{
    public interface IOfferCreator
    {
        int Level { get; set; }

        List<IOfferCreationItem> SendItems { get; set; }
        IOfferCreationItem RecvItem { get; set; }

    }
}
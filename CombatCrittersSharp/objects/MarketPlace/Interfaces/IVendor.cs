namespace CombatCrittersSharp.objects.MarketPlace.Interfaces
{
    public interface IVendor
    {
        int Id { get; }
        string Name { get; }
        string Image { get; }
        string RefreshTime { get; }

        IVendorReputation Reputation { get; }
    }
}
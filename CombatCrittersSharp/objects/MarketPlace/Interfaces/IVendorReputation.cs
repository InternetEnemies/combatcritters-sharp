namespace CombatCrittersSharp.objects.MarketPlace.Interfaces
{
    public interface IVendorReputation
    {
        int Level { get; }
        int CurrentXp { get; }
        int NextLevelXp { get; }
        int PrevLevelXp { get; }
    }

}
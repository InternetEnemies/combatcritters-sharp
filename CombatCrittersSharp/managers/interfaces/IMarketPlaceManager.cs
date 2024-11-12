using CombatCrittersSharp.objects.MarketPlace.Implementations;

namespace CombatCrittersSharp.managers.interfaces
{
    public interface IMarketPlaceManager
    {
        /// <summary>
        /// Retrives all vendors in the game
        /// </summary>
        /// <returns></returns>
        Task<List<Vendor>> GetVendorsAsync();

    }
}
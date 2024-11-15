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

        /// <summary>
        /// Retries a vendor offer
        /// </summary>
        /// <param name="id">Vendor id</param>
        /// <returns>A Vendor offer</returns>
        Task<List<Offer>> GetVendorOfferAsync(int id);

        Task<string> GetVendorOfferJsonAsync(int id);

    }
}
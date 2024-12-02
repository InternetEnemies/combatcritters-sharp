using CombatCrittersSharp.objects.MarketPlace.Implementations;
using CombatCrittersSharp.rest.payloads;

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

        Task<Offer?> CreateOfferAsync(int vendorId, int newLevel, List<OfferCreationItem> collectItems, OfferCreationItem receiveItem);

    }
}
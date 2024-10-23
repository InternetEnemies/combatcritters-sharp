namespace CombatCrittersSharp.rest.routes;

public static class MarketRoutes
{
    /// <summary>
    /// - GET
    /// </summary>
    /// <returns> route for the vendors</returns>
    public static string Vendors()
    {
        return "/vendors";
    }

    /// <summary>
    /// - GET
    /// - POST
    /// </summary>
    /// <param name="vendorId"></param>
    /// <returns> route for a vendor offers</returns>
    /// <returns> route for creating a vendor offer</returns>
    public static string VendorOffers(int vendorId)
    {
        return $"/vendors/{vendorId}/offers";
    }

    /// <summary>
    /// - GET
    /// - POST 
    /// </summary>
    /// <param name="vendorId"></param>
    /// <returns> route for a vendor special offer</returns>
    /// <returns> route for creating a vendor special offer</returns>
    public static string VendorSpecialOffer(int vendorId)
    {
        return $"/vendors/{vendorId}/specials";
    }

    /// <summary>
    /// - GET
    /// - POST
    /// </summary>
    /// <param name="vendorId"></param>
    /// <returns> route for a vendor discount offer</returns>
    /// <returns> route for creating a vendor discount offer</returns>
    public static string VendorDiscountOffer(int vendorId)
    {
        return $"/vendors/{vendorId}/discounts";
    }
}
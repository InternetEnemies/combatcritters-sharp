namespace CombatCrittersSharp.rest.routes;

public static class PackRoutes
{
    /// <summary>
    /// - GET
    /// - POST
    /// </summary>\
    /// <returns> route for packs</returns>
    /// <returns> route for creating packs</returns>
    public static string Packs()
    {
        return "/packs";
    }

    public static string PacksCreate()
    {
        return "/admin/packs";
    }

    /// <summary>
    /// - GET
    /// </summary>
    /// <param name="packId"></param>
    /// <returns> route for a pack</returns>
    public static string Pack(int packId)
    {
        return $"/packs/{packId}";
    }

    /// <summary>
    /// - GET
    /// </summary>
    /// <param name="packId"></param>
    /// <returns> route for the contents of a pack</returns>
    public static string PackCards(int packId)
    {
        return $"/packs/{packId}/contents";
    }

    /// <summary>
    /// - GET
    /// </summary>
    /// <param name="userId"></param>
    /// <returns> route for a users packs</returns>
    public static string UserPacks(int userId)
    {
        return $"/users/{userId}/packs";
    }
}
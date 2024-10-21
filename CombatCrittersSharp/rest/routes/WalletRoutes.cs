namespace CombatCrittersSharp.rest.routes;

public static class WalletRoutes
{
    /// <summary>
    /// - GET
    /// </summary>
    /// <param name="userId"></param>
    /// <returns> route for a users wallet</returns>
    public static string Wallet(int userId)
    {
        return $"/users/{userId}/wallet";
    }
}
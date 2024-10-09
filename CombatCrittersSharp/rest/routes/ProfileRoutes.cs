namespace CombatCrittersSharp.rest.routes;

public static class ProfileRoutes
{
    /// <summary>
    /// - GET
    /// - PUT
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static string Profile(int userId){
        return $"/users/${userId}/profile";
    }
}
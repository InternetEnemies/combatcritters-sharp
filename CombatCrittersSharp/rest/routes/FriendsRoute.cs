namespace CombatCrittersSharp.rest.routes;

public static class FriendsRoutes
{
    /// <summary>
    /// - GET
    /// </summary>
    /// <param name="userId"></param>
    public static string Friends(int userId)
    {
        return $"/users/{userId}/friends";
    }
}
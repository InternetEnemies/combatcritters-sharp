namespace CombatCrittersSharp.rest.routes;

public class AuthRoutes
{
    public static string Register()
    {
        return "/users/auth/register";
    }

    public static string Login()
    {
        return "/users/auth/login";
    }
}
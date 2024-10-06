using CombatCrittersSharp.rest;
using CombatCrittersSharp.rest.exception;
using CombatCrittersSharp.rest.payloads;
using CombatCrittersSharp.rest.routes;

namespace CombatCrittersSharp;

public class Client(string apiUri) : IClient
{
    public IRest Rest { get; } = new Rest(apiUri);


    public async Task Login(string username, string password)
    {
        try
        {
            await Rest.Post(AuthRoutes.Login(), new LoginPayload(username, password));
        }
        catch (RestException e)
        {
            throw new AuthException("Failed to log in user", e);
        }
        Console.WriteLine($"logged in as {username}");
    }

    public async Task Register(string username, string password)
    {
        try
        {
            await Rest.Post(AuthRoutes.Login(),new RegisterPayload(username,password));
        }
        catch (RestException e)
        { 
            throw new AuthException("Failed to register user", e);
        }
        
        Console.WriteLine($"register new user: {username}");
    }
}
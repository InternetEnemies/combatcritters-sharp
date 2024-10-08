using System.Net.Http.Json;
using CombatCrittersSharp.exception;
using CombatCrittersSharp.objects.user;
using CombatCrittersSharp.rest;
using CombatCrittersSharp.rest.payloads;
using CombatCrittersSharp.rest.routes;

namespace CombatCrittersSharp;

public class Client(string apiUri) : IClient
{
    public IRest Rest { get; } = new Rest(apiUri);
    public IUser? User { get; private set; }


    public async Task Login(string username, string password)
    {
        try
        {
            UserPayload? payload = await (await Rest.Post(AuthRoutes.Login(), new LoginPayload(username, password))).Content.ReadFromJsonAsync<UserPayload>();
            if (payload == null)
            {
                throw new Exception("200 success but no payload was provided... how? something is bronk");// If this happens the api is being silly
            }
            this.User = objects.user.User.From(payload);
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
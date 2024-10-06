using CombatCrittersSharp.rest;
using CombatCrittersSharp.rest.payloads;

namespace CombatCrittersSharp;

public class Client(string apiUri) : IClient
{
    public IRest Rest { get; } = new Rest(apiUri);


    public async Task Login(string username, string password)
    {
        var res = await Rest.Post("/users/auth/login",new LoginPayload(username,password));
        Console.WriteLine(res);
        Console.WriteLine($"logged in as {username}");
    }

    public Task Register(string username, string password)
    {
        throw new NotImplementedException();
    }
}
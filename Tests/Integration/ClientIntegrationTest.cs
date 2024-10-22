using CombatCrittersSharp;
using CombatCrittersSharp.objects.user;

namespace Tests.Integration;

/// <summary>
/// provide integration test environment with premade client and test user registered/logged in
/// </summary>
public class ClientIntegrationTest : IntegrationTest
{
    private readonly string Username = "user";
    private readonly string Password = "pass";
    
    protected IClient _client;

    [SetUp]
    public override async Task Setup()
    {
        await base.Setup();
        this._client = new Client(ApiUrl);
        await this._client.Register(Username, Password);
        await this._client.Login(Username, Password);
    }

}
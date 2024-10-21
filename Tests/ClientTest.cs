using CombatCrittersSharp;
using Tests.Integration;

namespace Tests;

public class Tests : IntegrationTest
{
    IClient _client;
    [SetUp]
    public override async Task Setup()
    {
        await base.Setup();
        _client = new Client(ApiUrl);
    }

    [Test]
    public async Task test_login()
    {
        await _client.Login("jackal","jackal");
        Assert.That(_client.User.Username, Is.EqualTo("jackal"));
        var res = await _client.Rest.Get("/ping");
        Console.WriteLine(res);
    }
}
using CombatCrittersSharp;

namespace Tests;

public class Tests
{
    IClient _client;
    [SetUp]
    public void Setup()
    {
        _client = new Client(TestUtils.ApiRoot);
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
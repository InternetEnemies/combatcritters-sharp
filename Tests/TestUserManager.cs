using CombatCrittersSharp;
using CombatCrittersSharp.objects.card;
using CombatCrittersSharp.objects.card.Interfaces;

namespace Tests;

public class TestUserManager
{
    
    IClient _client;
    [SetUp]
    public async Task Setup()
    {
        _client = new Client(TestUtils.ApiRoot);
        await _client.Login("jackal", "jackal");
    }

    [Test]
    public async Task Test_GetUserCards()
    {
        ICardQuery query = new CardQueryBuilder().Build();
        Console.WriteLine(query);
        List<IItemStack<ICard>> cards = await _client.User.Cards.GetCards(query);
        Assert.That(cards.Count,Is.GreaterThan(0));
    }
}
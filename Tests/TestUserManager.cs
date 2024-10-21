using CombatCrittersSharp;
using CombatCrittersSharp.objects.card;
using CombatCrittersSharp.objects.card.Interfaces;
using Tests.Integration;

namespace Tests;

public class TestUserManager:ClientIntegrationTest
{
    
    [SetUp]
    public override async Task Setup()
    {
        await base.Setup();
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
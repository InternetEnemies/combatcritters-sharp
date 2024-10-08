using CombatCrittersSharp.managers;

namespace CombatCrittersSharp.objects.user;

public class User(IDeckManager decks, ICardsManager cards, string username, string id)
    : IUser
{
    public IDeckManager Decks { get; } = decks;
    public ICardsManager Cards { get; } = cards;
    public string Username { get; } = username;
    public string Id { get; } = id;
}
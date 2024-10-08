using CombatCrittersSharp.managers;
using CombatCrittersSharp.managers.interfaces;
using CombatCrittersSharp.rest.payloads;

namespace CombatCrittersSharp.objects.user;

/// <summary>
/// represents a user
/// </summary>
/// <param name="decks"></param>
/// <param name="cards"></param>
/// <param name="username"></param>
/// <param name="id"></param>
public class User(IDeckManager decks, IUserCardsManager cards, string username, int id)
    : IUser
{
    public IDeckManager Decks { get; } = decks;
    public IUserCardsManager Cards { get; } = cards;
    public string Username { get; } = username;
    public int Id { get; } = id;

    public User(string username, int id): this (
            new DeckManager(),
            new UserCardsManager(),
            username,
            id
        )
    {
        
    }
}
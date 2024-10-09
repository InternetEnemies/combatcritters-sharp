using CombatCrittersSharp.managers.interfaces;
using CombatCrittersSharp.objects.deck;
using CombatCrittersSharp.objects.user;

namespace CombatCrittersSharp.managers;

/// <summary>
/// manage a users decks
/// </summary>
public class DeckManager(IClient client, IUser user): IDeckManager
{
    private readonly IClient _client = client;
    private readonly IUser _user = user;
    public Task<List<IDeck>> GetDecks()
    {
        throw new NotImplementedException();
    }

    public Task<IDeck> CreateDeck(string name)
    {
        throw new NotImplementedException();
    }

    public Task DeleteDeck(IDeck deck)
    {
        throw new NotImplementedException();
    }
}
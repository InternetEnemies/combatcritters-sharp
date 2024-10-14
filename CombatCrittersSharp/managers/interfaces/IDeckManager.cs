using CombatCrittersSharp.objects.deck;

namespace CombatCrittersSharp.managers.interfaces;

/// <summary>
/// provide interface for a users decks
/// </summary>
public interface IDeckManager
{
    /// <summary>
    /// get the users decks
    /// </summary>
    Task<List<IDeck>> GetDecks();
    /// <summary>
    /// create a new deck with the given name
    /// </summary>
    /// <param name="name">name for the new deck</param>
    /// <returns>the newly created deck</returns>
    Task<IDeck> CreateDeck(string name);
    /// <summary>
    /// delete a deck
    /// </summary>
    /// <param name="deck">deck to delete</param>
    Task DeleteDeck(IDeck deck);
}
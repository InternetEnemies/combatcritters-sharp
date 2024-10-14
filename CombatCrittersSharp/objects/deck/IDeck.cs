using CombatCrittersSharp.objects.card;
using CombatCrittersSharp.objects.card.Interfaces;
using CombatCrittersSharp.objects.user;

namespace CombatCrittersSharp.objects.deck;

/// <summary>
/// represents a players deck
/// </summary>
public interface IDeck
{
    int DeckId { get; } // id of the deck
    string Name { get; } // name of the deck
    
    /// <summary>
    /// get the cards in the deck
    /// </summary>
    Task<List<ICard>> Cards { get; }
}
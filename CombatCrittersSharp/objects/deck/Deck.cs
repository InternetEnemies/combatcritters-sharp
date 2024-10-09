using CombatCrittersSharp.objects.card;

namespace CombatCrittersSharp.objects.deck;

/// <summary>
/// represents a players deck
/// </summary>
public class Deck: IDeck
{
    public int DeckId { get; }
    public string Name { get; }
    public Task<List<ICard>> Cards { get; }

    public Deck(int deckId, string name)
    {
        DeckId = deckId;
        Name = name;
    }

    public async Task<List<ICard>> GetCards()
    {   
        throw new NotImplementedException();
    }
}
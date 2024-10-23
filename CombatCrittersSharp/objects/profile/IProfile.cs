using CombatCrittersSharp.objects.deck;

namespace CombatCrittersSharp.objects.profile;

public interface IProfile
{
    /// <summary>
    /// Get the featured deck 
    /// </summary>
    /// <returns></returns>
    Task<IDeck?> GetDeck();

    /// <summary>
    /// Set the featured deck
    /// </summary>
    /// <param name="deck"></param>
    /// <returns></returns>
    Task SetDeck(IDeck deck);
}
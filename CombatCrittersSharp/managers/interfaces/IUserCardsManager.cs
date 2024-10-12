using CombatCrittersSharp.objects.card;

namespace CombatCrittersSharp.managers.interfaces;


/// <summary>
/// provide interface for a users cards
/// </summary>
public interface IUserCardsManager
{
    /// <summary>
    /// get the users decks
    /// </summary>
    Task<List<ICard>> GetUserCards();
}
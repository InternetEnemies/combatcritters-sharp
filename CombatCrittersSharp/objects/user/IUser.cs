using CombatCrittersSharp.managers;
using CombatCrittersSharp.managers.interfaces;

namespace CombatCrittersSharp.objects.user;

/// <summary>
/// provide an interface for users routes
/// </summary>
public interface IUser
{
    IDeckManager Decks { get; }
    IUserCardsManager Cards { get; }
    string Username { get; }
    int Id { get; }
}
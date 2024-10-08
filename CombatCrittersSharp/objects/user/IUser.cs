using CombatCrittersSharp.managers;
using CombatCrittersSharp.managers.interfaces;
using CombatCrittersSharp.objects.profile;

namespace CombatCrittersSharp.objects.user;

/// <summary>
/// provide an interface for users routes
/// </summary>
public interface IUser
{
    IDeckManager Decks { get; }
    IUserCardsManager Cards { get; }
    IProfile Profile { get; }
    string Username { get; }
    int Id { get; }
}
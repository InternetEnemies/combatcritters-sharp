using CombatCrittersSharp.managers;

namespace CombatCrittersSharp.objects.user;

/// <summary>
/// provide an interface for users routes
/// </summary>
public interface IUser
{
    IDeckManager Decks { get; }
    ICardsManager Cards { get; }
    string Username { get; }
    string Id { get; }
}
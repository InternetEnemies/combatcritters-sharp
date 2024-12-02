
using CombatCrittersSharp.managers.interfaces;
using CombatCrittersSharp.objects.deck;
using CombatCrittersSharp.objects.profile;
namespace CombatCrittersSharp.objects.user;

/// <summary>
/// provide an interface for users routes
/// </summary>
public interface IUser
{
    IUserCardsManager Cards { get; }
    IProfile Profile { get; }

    IPackManager Packs { get; }

    IMarketPlaceManager MarketPlace { get; }
    string Username { get; }
    int Id { get; }

    IDeck? ProfileDeck { get; set; }
}
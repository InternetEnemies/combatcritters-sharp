using CombatCrittersSharp.managers;
using CombatCrittersSharp.managers.interfaces;
using CombatCrittersSharp.objects.deck;
using CombatCrittersSharp.objects.profile;
using CombatCrittersSharp.rest.payloads;

namespace CombatCrittersSharp.objects.user;

/// <summary>
/// represents a user
/// </summary>
/// <param name="decks"></param>
/// <param name="cards"></param>
/// <param name="username"></param>
/// <param name="id"></param>
public class User
    : IUser
{
    private readonly IClient _client;
    public IDeckManager Decks { get; }
    public IUserCardsManager Cards { get; }
    public IProfile Profile { get; }

    public IPackManager Packs { get; }
    public string Username { get; }
    public int Id { get; }

    //Property to hold user's featured deck
    public IDeck? ProfileDeck { get; set; }

    public User(IClient client, string username, int id)
    {
        this._client = client;
        this.Id = id;
        this.Username = username;

        this.Decks = new DeckManager(client, this);
        this.Cards = new UserCardsManager(client, this);
        this.Profile = new Profile(client, this);
        this.Packs = new PacksManager(client, this);
    }


    public static User From(IClient client, UserPayload payload)
    {
        return new User(client, payload.username, payload.id);
    }
}
using CombatCrittersSharp.objects.deck;
using CombatCrittersSharp.objects.user;
using CombatCrittersSharp.rest.payloads;
using CombatCrittersSharp.rest.routes;
using System.Net.Http.Json;
using CombatCrittersSharp.exception;

namespace CombatCrittersSharp.objects.profile;

public class Profile : IProfile
{
    private readonly IClient _client;
    private readonly IUser _user;
    public Task<IDeck> featured_deck { get; }

    public Profile(IClient client, IUser user){
        this._client = client;
        this._user = user;
    }
    public async Task<IDeck> GetDeck()
    {
        try{
            ProfilePayload? payload = await (await _client.Rest.Get(ProfileRoutes.Profile(_user.Id))).Content.ReadFromJsonAsync<ProfilePayload>();
            if (payload == null)
            {
                throw new Exception("200 success but no payload was provided... how? something is bronk");// If this happens the api is being silly
            }
            return new Deck(_client, _user, payload.featured_deck.deckid, payload.featured_deck.name);
        }
        catch (RestException e)
        {
            throw new AuthException("Error getting featured deck", e);
        }
    }
}
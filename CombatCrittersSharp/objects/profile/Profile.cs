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


    public Profile(IClient client, IUser user)
    {
        this._client = client;
        this._user = user;
    }

    /// <summary>
    /// Get the profile of the user, which is the featured deck.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    /// <exception cref="AuthException"></exception>
    public async Task<IDeck?> GetDeck()
    {
        try
        {
            ProfilePayload? payload = await (await _client.Rest.Get(ProfileRoutes.Profile(_user.Id))).Content.ReadFromJsonAsync<ProfilePayload>();
            if (payload == null)
            {
                throw new Exception("200 success but no payload was provided... how? something is bronk");// If this happens the api is being silly
            }
            if (payload.featured_deck == null)
            {
                return null; //Return null if no deck has been featured
            }

            return new Deck(_client, _user, payload.featured_deck.deckid, payload.featured_deck.name);
        }
        catch (RestException e)
        {
            throw new AuthException("Error getting featured deck", e);
        }
    }

    /// <summary>
    /// Set the profile of the user, which is the featured deck.
    /// </summary>
    /// <param name="deck"></param>
    /// <returns></returns>
    /// <exception cref="AuthException"></exception>
    public async Task SetDeck(IDeck deck)
    {
        try
        {
            // Create the deck details payload from the passed deck
            var deckPayload = new DeckDetailsPayload(
                deck.DeckId,
                deck.Name
            );

            //Create the profile payload with the deck details
            var profilePayload = new ProfilePayload(
                featured_deck: deckPayload
            );

            //Send a PUT request to the backend to update the user's featured deck
            await _client.Rest.Put(ProfileRoutes.Profile(_user.Id), profilePayload);

        }
        catch (RestException e)
        {
            throw new AuthException("Error setting featured deck", e);
        }
    }
}
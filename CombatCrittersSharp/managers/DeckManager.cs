using System.Net.Http.Json;
using CombatCrittersSharp.exception;
using CombatCrittersSharp.managers.interfaces;
using CombatCrittersSharp.objects.deck;
using CombatCrittersSharp.objects.user;
using CombatCrittersSharp.rest;
using CombatCrittersSharp.rest.payloads;
using CombatCrittersSharp.rest.routes;

namespace CombatCrittersSharp.managers;

/// <summary>
/// manage a users decks
/// </summary>
public class DeckManager(IClient client, IUser user): IDeckManager
{
    private readonly IClient _client = client;
    private readonly IUser _user = user;
    public async Task<List<IDeck>> GetDecks()
    {
        try{
            DeckDetailsPayload[]? payload = await (await _client.Rest.Get(DeckRoutes.Decks(_user.Id))).Content.ReadFromJsonAsync<DeckDetailsPayload[]>();
            if (payload == null)
            {
                //copied from Eric's code, word for word, bar for bar
                throw new Exception("200 success but no payload was provided... how? something is bronk");// If this happens the api is being silly
            }
            List<IDeck> decks = new List<IDeck>();
            foreach (DeckDetailsPayload deck in payload)
            {
                decks.Add(new Deck(_client, _user, deck.deckid, deck.name));
            }
            return decks;
        }
        catch (RestException e)
        {
            throw new AuthException("Failed to get decks", e);
        }
    }

    public Task<IDeck> CreateDeck(string name)
    {
        throw new NotImplementedException();
    }

    public Task DeleteDeck(IDeck deck)
    {
        throw new NotImplementedException();
    }
}
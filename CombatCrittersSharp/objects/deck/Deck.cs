using CombatCrittersSharp.objects.card;
using CombatCrittersSharp.exception;
using CombatCrittersSharp.rest.payloads;
using CombatCrittersSharp.rest.routes;
using CombatCrittersSharp.rest;
using CombatCrittersSharp.objects.user;
using System.Net.Http.Json;
using CombatCrittersSharp.objects.card.Interfaces;

namespace CombatCrittersSharp.objects.deck;

/// <summary>
/// represents a players deck
/// </summary>
public class Deck : IDeck
{
    private IUser _user;
    private IClient _client;
    public int DeckId { get; }
    public string Name { get; }


    public Deck(IClient client, IUser user, int deckId, string name)
    {
        _client = client;
        _user = user;
        DeckId = deckId;
        Name = name;
    }

    public async Task<List<ICard>> GetCards()
    {
        try
        {
            CardPayload[]? payload = await (await _client.Rest.Get(DeckRoutes.DeckCards(_user.Id, DeckId))).Content.ReadFromJsonAsync<CardPayload[]>();
            if (payload == null)
            {
                throw new Exception("200 success but no payload was provided... how? something is bronk");// If this happens the api is being silly
            }
            List<ICard> cards = new List<ICard>();
            foreach (CardPayload card in payload)
            {
                cards.Add(card.ToCard());
            }
            return cards;
        }
        catch (RestException e)
        {
            throw new AuthException("Error getting cards from deck", e);
        }
    }
}
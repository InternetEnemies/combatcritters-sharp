namespace CombatCrittersSharp.rest.routes;

public static class DeckRoutes
{
    /// <summary>
    /// - GET
    /// </summary>
    /// <returns> route for validity rules</returns>
    public static string Validity()
    {
        return "/decks/validity";
    }

    /// <summary>
    /// - POST
    /// - GET
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>route for a users decks</returns>
    public static string Decks(int userId)
    {
        return $"/users/{userId}/decks";
    }

    /// <summary>
    /// - DELETE
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="deckId"></param>
    /// <returns> route for a users deck</returns>
    public static string SingleDeck(int userId, int deckId)
    {
        return $"/users/{userId}/decks/{deckId}";
    }

    /// <summary>
    /// - GET
    /// - PUT
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="deckId"></param>
    /// <returns> route for the cards in a users deck</returns>
    public static string DeckCards(int userId, int deckId)
    {
        return $"/users/{userId}/decks/{deckId}/cards";
    }

    /// <summary>
    /// - GET
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="deckId"></param>
    /// <returns>route for the validity of a users deck</returns>
    public static string DeckValidity(int userId, int deckId)
    {
        return $"/users/{userId}/decks/{deckId}/validity";
    }
}
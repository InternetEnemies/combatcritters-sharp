namespace CombatCrittersSharp.rest.routes;

public class CardsRoutes
{
    /// <summary>
    /// - GET
    /// </summary>
    /// <param name="query">query parameters for card search</param>
    public static string Cards(string query)
    {
        var queryString = query.Length > 0 ? "?" + query : "";
        return $"/cards${queryString}";
    }

    /// <summary>
    /// - GET
    /// </summary>
    /// <param name="cardId">id of the card</param>
    public static string SingleCard(int cardId)
    {
        return $"/cards/{cardId}";
    }

    /// <summary>
    /// - GET
    /// </summary>
    /// <param name="userId">userid related to the cards</param>
    /// <param name="query">query string for card search</param>
    /// <returns></returns>
    public static string UserCards(int userId, string query)
    {
        var queryString = query.Length > 0 ? "?" + query : "";
        return $"/users/{userId}/cards{queryString}";
    }
}
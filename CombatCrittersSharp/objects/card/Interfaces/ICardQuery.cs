namespace CombatCrittersSharp.objects.card.Interfaces
{
    public interface ICardQuery
    {
        /// <summary>
        /// Get the query string used for the request
        /// </summary>
        /// <returns></returns>
        string GetQueryString(); // Return the query string

        public enum CardOrder
        {
            NONE, // will map to ""
            ID, // will map to "ID"
            NAME, // will map to "NAME"
            PLAYCOST, // will map to "PLAY_COST
            RARITY // will map to "RARITY"
        }

    }
}
using CombatCrittersSharp.objects.card.Interfaces;

namespace CombatCrittersSharp.objects.card
{
    public class CardQuery : ICardQuery
    {
        private readonly string _queryString;
        public CardQuery(string queryString)
        {
            _queryString = queryString;
        }

        public string GetQueryString()
        {
            return _queryString;
        }
    }
}
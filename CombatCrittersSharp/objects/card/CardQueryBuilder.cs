using CombatCrittersSharp.objects.card.Interfaces;

namespace CombatCrittersSharp.objects.card
{
    public class CardQueryBuilder : ICardQueryBuilder
    {
        private Dictionary<string, string> _queryParameters = new();

        public ICardQueryBuilder ByType(string type)
        {
            _queryParameters["type"] = type;
            return this;
        }

        public ICardQueryBuilder ByRarity(int rarity)
        {
            _queryParameters["rarity"] = rarity.ToString();
            return this;
        }

        public string GetQueryString()
        {
            //if no parameters are added, return an empty string (this mean "get all cards)
            if (_queryParameters.Count == 0)
            {
                return string.Empty;
            }
            return string.Join("&", _queryParameters.Select(kvp => $"{kvp.Key}={kvp.Value}"));
        }

        public ICardQuery Build()
        {
            return new CardQuery(GetQueryString());  //Return an instance of the ICardQuery
        }
    }
}
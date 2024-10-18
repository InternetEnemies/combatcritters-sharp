using CombatCrittersSharp.objects.card.Interfaces;

namespace CombatCrittersSharp.objects.card
{
    public class CardQuery : ICardQuery
    {
        private readonly int _cost;
        private readonly bool _costLess;
        private readonly List<int> _ids;
        private readonly CardOrder _order;
        private readonly bool  _owned;
        private readonly List<Rarity> _rarities;
        private readonly bool _raritiesInclude;

        public CardQuery(int cost, bool costLess, List<int> ids, CardOrder order, bool owned, List<Rarity> rarities, bool rarityInclude)
        {
            _cost = cost;
            _costLess = costLess;
            _ids = ids;
            _order = order;
            _owned = owned;
            _rarities = rarities;
            _raritiesInclude = rarityInclude;
        }        
        public string GetQueryString()
        {

            //Intialize an List to hold query strings
            List<string> queryStrings = [];

            if (_cost > 0) queryStrings.Add($"cost={_cost}");
            if (_costLess) queryStrings.Add($"costLess={_costLess}");
            if (_ids.Count != 0) queryStrings.Add($"ids={string.Join(",", _ids)}");

            var orderString = _order == CardOrder.NONE? "" : _order.ToString(); 
            if (!string.IsNullOrEmpty(orderString)) queryStrings.Add($"order={orderString}");


            if (_owned) queryStrings.Add($"owned={_owned}");


            if (_rarities.Count != 0)
            {
                var raritiesString = string.Join(",", _rarities.Select(r => r.ToString())); //Convert each rarity enum value to its string
                queryStrings.Add($"rarities={raritiesString}");
            } 
                
            if (_raritiesInclude) queryStrings.Add($"rarityInclude={_raritiesInclude}");

            return string.Join("&", queryStrings);
        }
    }
}
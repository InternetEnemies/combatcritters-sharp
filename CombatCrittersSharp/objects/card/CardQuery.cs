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
        private readonly List<int> _rarities;
        private readonly bool _raritiesInclude;

        public CardQuery(int cost, bool costLess, List<int> ids, CardOrder order, bool owned, List<int> rarities, bool rarityInclude)
        {
            _cost = cost;
            _costLess = costLess;
            _ids = ids;
            _order = order;
            _owned = owned;
            _rarities = rarities;
            _raritiesInclude = rarityInclude;
        }

        /// <summary>
        /// This maps each CardOder enum value to its corresponding string.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private static string MapOrderToString(CardOrder order)
        {
            return order switch
            {
                CardOrder.NONE => "",
                CardOrder.ID => "ID",
                CardOrder.NAME => "NAME",
                CardOrder.PLAYCOST => "PLAY_COST",
                CardOrder.RARITY => "RARITY",
                _ => throw new ArgumentOutOfRangeException(nameof(order), order, null)
        
            };
        }
        
        public string GetQueryString()
        {

            //Intialize an List to hold query strings
            List<string> queryStrings = [];

            if (_cost > 0) queryStrings.Add($"cost={_cost}");
            if (_costLess) queryStrings.Add($"costLess={_costLess}");
            if (_ids.Count != 0) queryStrings.Add($"ids={string.Join(",", _ids)}");

            string orderString = MapOrderToString(_order);
            if (!string.IsNullOrEmpty(orderString)) queryStrings.Add($"order={orderString}");


            if (_owned) queryStrings.Add($"owned={_owned}");
            if (_rarities.Count != 0) queryStrings.Add($"rarities={string.Join(",", _rarities)}");
            if (_raritiesInclude) queryStrings.Add($"rarityInclude={_raritiesInclude}");

            return string.Join("&", queryStrings);
        }
    }
}
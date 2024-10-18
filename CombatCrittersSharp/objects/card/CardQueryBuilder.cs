using CombatCrittersSharp.objects.card.Interfaces;
using static CombatCrittersSharp.objects.card.Interfaces.ICardQuery;

namespace CombatCrittersSharp.objects.card
{
    public class CardQueryBuilder : ICardQueryBuilder
    {
        private int _cost;
        private bool _costLess;
        private List<int> _ids;
        private CardOrder _order;
        private bool _owned;
        private List<Rarity> _rarities;
        private bool _raritiesInclude;
        

        //constructor
        public CardQueryBuilder()
        {
            //Reset the values
            Reset();
        }

        //Builds the final query object
        public ICardQuery Build()
        {
            return new CardQuery(
                _cost,
                _costLess,
                _ids,
                _order,
                _owned,
                _rarities,
                _raritiesInclude
            );
        }

        public void Reset()
        {
            _cost = 0;
            _costLess = false;
            _ids = new List<int>();
            _order = CardOrder.NONE;
            _owned = false;
            _rarities = new List<Rarity>();
            _raritiesInclude = false;
        }
        public void SetCost(int cost)
        {
            _cost = cost;
        }
        public void SetCostLess(bool costLess)
        {
            _costLess = costLess;
        }

        public void SetIds(List<int> ids)
        {
            _ids = ids;
        }

        public void SetOrder(CardOrder order)
        {
            _order = order;
        }

        public void SetOwned(bool owned)
        {
            _owned = owned;
        }

        public void SetRarities(List<Rarity> rarities)
        {
            _rarities = rarities;
        }

        public void SetRaritiesInclude(bool include)
        {
            _raritiesInclude = include;
        }
    }
}
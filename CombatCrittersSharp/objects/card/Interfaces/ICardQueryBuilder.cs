using static CombatCrittersSharp.objects.card.Interfaces.ICardQuery;

namespace CombatCrittersSharp.objects.card.Interfaces
{
    // This is a builder to consttruct custom card queries
    public interface ICardQueryBuilder
    {
         ICardQuery Build(); //Builds and return the ICardQuery
        void Reset(); //Reset the Builder

        void SetCost(int cost);
        void SetCostLess(bool less);
        void SetIds(List<int> ids);
        void SetOrder(CardOrder order);
        void SetOwned(bool owned);
        void SetRarities(List<Rarity> rarities);
        void SetRaritiesInclude(bool include);
       
    }
}
namespace CombatCrittersSharp.objects.card.Interfaces
{
    // This is a builder to consttruct custom card queries
    public interface ICardQueryBuilder
    {
        ICardQueryBuilder ByType(string type);
        ICardQueryBuilder ByRarity(int rarity);
        string GetQueryString();
        ICardQuery Build();
    }
}
//This interface represents the final query structure build by ICardQueryBuilder
namespace CombatCrittersSharp.objects.card.Interfaces
{
    public interface ICardQuery
    {
        string GetQueryString(); // Return the query string
    }
}
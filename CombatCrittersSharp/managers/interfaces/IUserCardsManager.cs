using CombatCrittersSharp.objects;
using CombatCrittersSharp.objects.card;
using CombatCrittersSharp.objects.card.Interfaces;

namespace CombatCrittersSharp.managers.interfaces
{
    public interface IUserCardsManager
    {
        /// <summary>
        /// Get the cards of the user based on a query.
        /// </summary>
        /// <param name="query"> The query to get the cards. </param>
        /// <returs> Task<List<ItemStack<ICard>>> The cards of the user in item stacks.</returns>
         Task<List<IItemStack<ICard>>> GetCards(ICardQuery query);


        /// <summary>
        /// Get the query builder for the cards.
        /// </summary>
        /// <returns>CardQueryBuilder the query builder for the cards.</returns>

        ICardQueryBuilder GetBuilder();
    }
}



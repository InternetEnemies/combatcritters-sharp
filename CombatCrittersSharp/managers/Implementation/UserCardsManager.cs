using System.Net.Http.Json;
using CombatCrittersSharp.managers.interfaces;
using CombatCrittersSharp.objects;
using CombatCrittersSharp.objects.card.Interfaces;
using CombatCrittersSharp.objects.user;
using CombatCrittersSharp.rest.payloads;
using CombatCrittersSharp.rest.routes;

namespace CombatCrittersSharp.managers
{
    public class UserCardsManager : IUserCardsManager
    {
        private readonly IClient _client;
        private readonly IUser _user;

        //Constructor to initialize with client and user
        public UserCardsManager(IClient client, IUser user)
        {
            _client = client;
            _user = user;
        }

        /// <summary>
        /// Fetch user cards based on a query.
        /// </summary>
        /// <param name="query"> The card query used to filter the cards </param>
        /// <returnd> A list of item stacks containing the user's cards</returns>
        public async Task<List<IItemStack<ICard>>> GetCards(ICardQuery query)
        {
            //Throw exception if query is null
            ArgumentNullException.ThrowIfNull(query);

            //Fetch user-specific card payload using the client and user ID
            CardQueryPayload[]? cardPayloads = await (await _client.Rest.Get(CardsRoutes.UserCards(_user.Id, query.GetQueryString()))).
                Content.ReadFromJsonAsync<CardQueryPayload[]>();

            var cardStacks = new List<IItemStack<ICard>>();
            if (cardPayloads != null)
            {
                foreach (var cardPayload in cardPayloads)
                {
                    //Convert each payload to a card and store it as an ItemStack with a count
                    cardStacks.Add(new ItemStack<ICard>(cardPayload.item.ToCard(), cardPayload.count));
                }
            }
            //Return either an empty list or a populated list
            return cardStacks;
        }
    }


}



using System.Net.Http.Json;
using CombatCrittersSharp.exception;
using CombatCrittersSharp.managers.interfaces;
using CombatCrittersSharp.objects.user;
using CombatCrittersSharp.rest.payloads;
using CombatCrittersSharp.rest.routes;

namespace CombatCrittersSharp.managers
{
    public class UserManager : IUserManager
    {
        private readonly IClient _client;
        private readonly IUser _user;

        public UserManager(IClient client, IUser user)
        {
            _client = client;
            _user = user;
        }

        public async Task<List<IUser>> GetAllUsersWithProfiles()
        {
            try
            {
                //Send GET request to retrieve all users
                var response = await _client.Rest.Get(UsersRoutes.GetAllUsers());

                //Deserialize the response content to a list of UserPayload objects
                List<UserPayload>? userPayloads = await response.Content.ReadFromJsonAsync<List<UserPayload>>();


                if (userPayloads == null)
                {
                    throw new Exception("No users received from the server.");
                }

                var users = new List<IUser>();

                //For each user payload, create a User instance and load the profile deck
                foreach (var payload in userPayloads)
                {
                    var user = User.From(_client, payload);

                    //Load and set the featured deck for the user's profile
                    var profileDeck = await user.Profile.GetDeck();
                    user.ProfileDeck = profileDeck;

                    users.Add(user);
                }

                return users;
            }
            catch (RestException e)
            {
                throw new AuthException("Failed to get users", e);
            }
        }
    }
}
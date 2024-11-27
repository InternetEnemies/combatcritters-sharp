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

        /// <summary>
        /// Get all Users and set their profiles
        /// </summary>
        /// <returns>A list of Users</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<List<IUser>> GetAllUsersWithProfiles()
        {

            //Send GET request to retrieve all users
            var response = await _client.Rest.Get(UsersRoutes.GetAllUsers());

            //Deserialize the response content to a list of UserPayload objects
            List<UserPayload>? userPayloads = await response.Content.ReadFromJsonAsync<List<UserPayload>>();

            var users = new List<IUser>();
            if (userPayloads != null)
            {
                //For each user payload, create a User instance and load the profile deck
                foreach (var payload in userPayloads)
                {
                    var user = User.From(_client, payload);
                    //Load and set the featured deck for the user's profile
                    var profileDeck = await user.Profile.GetDeck();
                    user.ProfileDeck = profileDeck;
                    users.Add(user);
                }
            }

            //Return either an empty list or a populated list
            return users;
        }

        /// <summary>
        /// Delete a User from the game
        /// </summary>
        /// <param name="userId">The id of the user to be deleted</param>
        /// <returns></returns>
        /// <exception cref="AuthException"></exception>
        public async Task DeleteUser(int userId)
        {
            await _client.Rest.Delete(UsersRoutes.DeleteUser(userId));
        }
    }
}
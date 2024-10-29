using CombatCrittersSharp.objects.user;
using CombatCrittersSharp.rest.payloads;

namespace CombatCrittersSharp.managers.interfaces
{
    public interface IUserManager
    {
        /// <summary>
        /// Fetches all uses from the server
        /// </summary>
        /// <returns></returns>
        Task<List<IUser>> GetAllUsersWithProfiles();

        /// <summary>
        /// Delete a user by ID
        /// </summary>
        /// <param name="userId">The ID of the user to delete</param>
        /// <returns></returns>
        Task DeleteUser(int userId);

    }
}
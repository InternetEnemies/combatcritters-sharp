using CombatCrittersSharp.rest.payloads;

namespace CombatCrittersSharp.managers.interfaces
{
    public interface IUserManager
    {
        /// <summary>
        /// Fetches all uses from the server
        /// </summary>
        /// <returns></returns>
        Task<List<UserPayload>> GetAllUsers();
    }
}
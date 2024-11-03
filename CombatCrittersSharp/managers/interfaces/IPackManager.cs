using CombatCrittersSharp.objects.card.Interfaces;
using CombatCrittersSharp.objects.pack;
using CombatCrittersSharp.objects.userpack;

namespace CombatCrittersSharp.managers.interfaces
{
    public interface IPackManager
    {
        /// <summary>
        /// Retrieves all packs available in the game
        /// </summary>
        /// <returns></returns>
        Task<List<Pack>> GetAllPacksAsync();

        /// <summary>
        /// Retrieces a pack by its ID
        /// </summary>
        /// <param name="packId"></param>
        /// <returns></returns>
        Task<Pack> GetPackByIdAsync(int packId);

        /// <summary>
        /// Retrieves the packs in the user's inventory
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<UserPack>> GetUserPacksAsync(int userId);
    }
}
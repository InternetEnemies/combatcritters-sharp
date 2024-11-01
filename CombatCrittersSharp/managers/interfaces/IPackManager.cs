using CombatCrittersSharp.objects.pack;

namespace CombatCrittersSharp.managers.interfaces
{
    public interface IPackManager
    {
        /// <summary>
        /// Retrieves all packs available in the game
        /// </summary>
        /// <returns></returns>
        Task<List<Pack>> GetAllPacksAsync();
    }
}
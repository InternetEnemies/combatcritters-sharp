using CombatCrittersSharp.objects.card.Interfaces;
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

        /// <summary>
        /// Retrieves the contents (cards) of a specific pack by its ID.
        /// </summary>
        /// <param name="packId"></param>
        /// <returns></returns>
        Task<List<ICard>> GetPackContentsAsync(int packId);
    }
}
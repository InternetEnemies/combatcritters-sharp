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
        Task<Pack?> GetPackByIdAsync(int packId);

        /// <summary>
        /// Retrieves the packs in the user's inventory
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<UserPack>> GetUserPacksAsync(int userId);

        /// <summary>
        /// Create a new Pack
        /// </summary>
        /// <param name="cardIds"></param>
        /// <param name="rarityProbabilities">the likelyhood of obtaining cards of different rarity levels within each pack type.</param>
        /// <param name="packName">Pack Name</param>
        /// <param name="packImage">Pack Image</param>
        /// <param name="slotCount">The number of card slots in each pack, dictating how many cards a user will receive when opening a pack</param>
        /// <returns>Return created Pack</returns>
        /// <exception cref="AuthException"></exception>
        Task<Pack?> CreatePackAsync(string name, string image, int[] cardIds, List<Dictionary<int, int>> slotRarityProbabilities);
    }
}
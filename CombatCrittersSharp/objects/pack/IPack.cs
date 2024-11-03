using CombatCrittersSharp.objects.card;
using CombatCrittersSharp.objects.card.Interfaces;

namespace CombatCrittersSharp.objects.pack
{
    public interface IPack
    {
        string Image { get; }
        string Name { get; }
        int PackId { get; }

        List<ICard>? Contents { get; set; }


        /// <summary>
        /// Retrievs the list of cards in this pack.
        /// </summary>
        /// <returns></returns>
        Task<List<ICard>> GetPackContentsAsync();

        /// <summary>
        /// Sets the content of the pack, allowing PackManager to populate the contents
        /// </summary>
        /// <param name="contents"> the list of carfd to set as contents.</param>
        void SetContents(List<ICard> contents);

    }
}
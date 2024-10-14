namespace CombatCrittersSharp.objects.card.Interfaces
{
    /// <summary>
    /// Interface for an item stack, which contains an item and the amount of that item.
    /// </summary>
    public interface IItemStack<T>
    {
        /// <summary>
        /// Gets the item in the stack.
        /// </summary>
        T Item { get; }

        /// <summary>
        /// Gets the amount or count of the item in the stack.
        /// </summary>
        int Amount { get; }
    }
}
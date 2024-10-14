using CombatCrittersSharp.objects.card.Interfaces;

namespace CombatCrittersSharp.objects
{
    /// <summary>
    /// represents a stack of items
    /// </summary>
    public class ItemStack<T> : IItemStack<T>
    {
        public T Item { get; }
        public int Amount { get; }

        public ItemStack (T item, int count)
        {
            Item = item;
            Amount = count;
        }
    }
}


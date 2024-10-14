namespace CombatCrittersSharp.objects;

/// <summary>
/// represents a stack of items
/// </summary>
/// <typeparam name="T"> type of item in the stack</typeparam>
public class ItemStack<T>(T item, int amount)
{
    public T Item { get; init; } = item;
    public int Amount { get; init; } = amount;
}
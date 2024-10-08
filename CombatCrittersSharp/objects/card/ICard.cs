namespace CombatCrittersSharp.objects.card;

/// <summary>
/// interface common to all cards
/// </summary>
public interface ICard
{
    int CardId { get; }
    string Name { get; }
    int PlayCOst { get; }
    Rarity Rarity { get; }
    string Image { get; }
    string Description { get; }
    void Accept(ICardVisitor visitor);
}
using CombatCrittersSharp.objects.visitor;

namespace CombatCrittersSharp.objects.card.Interfaces
{
    /// <summary>
    /// interface common to all cards
    /// </summary>
    public interface ICard
    {
        int CardId { get; }
        string Name { get; }
        int PlayCost { get; }
        Rarity Rarity { get; }
        string Image { get; }
        string Description { get; }
        void Accept(ICardVisitor visitor); //This methos is part of the visitor patterd which allows different operations to be performed on cards without modifying their structure.
        void Accept(IItemVisitor visitor);
    }
}

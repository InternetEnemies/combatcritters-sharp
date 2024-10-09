namespace CombatCrittersSharp.objects.card;

public abstract class Card(int cardId, string name, int playCOst, Rarity rarity, string image, string description)
    : ICard
{
    public int CardId { get; } = cardId;
    public string Name { get; } = name;
    public int PlayCOst { get; } = playCOst;
    public Rarity Rarity { get; } = rarity;
    public string Image { get; } = image;
    public string Description { get; } = description;
    public abstract void Accept(ICardVisitor visitor);
}
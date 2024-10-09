namespace CombatCrittersSharp.objects.card;

public class CardCritter(int cardId, string name, int playCOst, Rarity rarity, string image, string description, int damage, int health, int[] abilities) : Card(cardId, name, playCOst, rarity, image, description), ICardCritter
{
    public override void Accept(ICardVisitor visitor)
    {
        visitor.VisitCritterCard(this);
    }

    public int Damage { get; } = damage;
    public int Health { get; } = health;
    public int[] Abilities { get; } = abilities;
}
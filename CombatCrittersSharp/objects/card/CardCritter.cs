namespace CombatCrittersSharp.objects.card;

/// <summary>
/// card implementation for critter cards
/// </summary>
/// <param name="cardId"></param>
/// <param name="name"></param>
/// <param name="playCOst"></param>
/// <param name="rarity"></param>
/// <param name="image"></param>
/// <param name="description"></param>
/// <param name="damage"></param>
/// <param name="health"></param>
/// <param name="abilities"></param>
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
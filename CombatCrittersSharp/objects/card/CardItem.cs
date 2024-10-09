namespace CombatCrittersSharp.objects.card;

public class CardItem(int cardId, string name, int playCOst, Rarity rarity, string image, string description, int abilityId) : Card(cardId, name, playCOst, rarity, image, description), ICardItem
{
    public override void Accept(ICardVisitor visitor)
    {
        visitor.VisitItemCard(this);
    }

    public int AbilityId { get; } = abilityId;
}
namespace CombatCrittersSharp.objects.card;

/// <summary>
/// card implementation for Item cards
/// </summary>
/// <param name="cardId"></param>
/// <param name="name"></param>
/// <param name="playCOst"></param>
/// <param name="rarity"></param>
/// <param name="image"></param>
/// <param name="description"></param>
/// <param name="abilityId"></param>
public class CardItem(int cardId, string name, int playCOst, Rarity rarity, string image, string description, int abilityId) : Card(cardId, name, playCOst, rarity, image, description), ICardItem
{
    public override void Accept(ICardVisitor visitor)
    {
        visitor.VisitItemCard(this);
    }

    public int AbilityId { get; } = abilityId;
}
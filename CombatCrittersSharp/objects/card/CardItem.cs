using CombatCrittersSharp.objects.card.Interfaces;
using CombatCrittersSharp.rest.payloads;

namespace CombatCrittersSharp.objects.card
{
    /// <summary>
    /// CartItem class extends Card but had properties specific to items
    /// </summary>

    public class CardItem : Card, ICardItem
    {
        public int AbilityId { get; private set; }

        public CardItem(int cardId, string name, int playCost, Rarity rarity, string image, string description, int abilityID)
            :base(cardId, name, playCost, rarity, image, description)
        {
            AbilityId = abilityID;
        }
        public override void Accept(ICardVisitor visitor)
        {
            visitor.VisitItemCard(this);
        }        
    } 
}


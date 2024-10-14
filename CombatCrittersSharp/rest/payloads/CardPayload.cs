using CombatCrittersSharp.objects.card;
using CombatCrittersSharp.objects.card.Interfaces;

namespace CombatCrittersSharp.rest.payloads
{
    public record CardPayload(
        int cardid,
        string name,
        int playcost,
        int rarity,
        string image,
        string type,
        Object type_specific, //This is either a CardCritterPayload or CardItemPayload
        string description)
    {
        public const string TypeCritter = "critter";
        public const string TypeItem = "item";
        
        public ICard ToCard()
        {
            switch (this.type)
            {
                case TypeCritter:
                    CardCritterPayload critter = (CardCritterPayload)this.type_specific;
                    return new CardCritter(cardid, name, playcost, (Rarity)rarity, image, description, critter.damage,
                        critter.health, critter.abilities);
                case TypeItem:
                    CardItemPayload item = (CardItemPayload)this.type_specific;
                    return new CardItem(cardid,name,playcost,(Rarity)rarity,image,type,item.abilityid);
                default:
                    throw new Exception("Unknown card type");
            }
        }
    };
}


using System.Text.Json;
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
        JsonElement type_specific, //This is either a CardCritterPayload or CardItemPayload
        string description
        )
    {
        public const string TypeCritter = "critter";
        public const string TypeItem = "item";

        public ICard ToCard()
        {
            switch (this.type)
            {
                case TypeCritter:
                    CardCritterPayload? critter = type_specific.Deserialize<CardCritterPayload>();
                    if (critter == null)
                    {
                        throw new JsonException("Invalid Card Payload");
                    }

                    return new CardCritter(cardid, name, playcost, (Rarity)rarity, image, description, critter.damage,
                        critter.health, critter.abilities);
                case TypeItem:
                    CardItemPayload? item = type_specific.Deserialize<CardItemPayload>();
                    if (item == null)
                    {
                        throw new JsonException("Invalid Card Payload");
                    }
                    return new CardItem(cardid, name, playcost, (Rarity)rarity, image, type, item.abilityid);
                default:
                    throw new Exception("Unknown card type");
            }
        }
    };
}


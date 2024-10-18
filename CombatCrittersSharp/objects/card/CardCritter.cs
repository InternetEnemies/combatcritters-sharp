using CombatCrittersSharp.objects.card.Interfaces;
using CombatCrittersSharp.rest.payloads;

namespace CombatCrittersSharp.objects.card
{
    /// <summary>
    /// CardCritters class inherits from Card and extends it with specific properties related to critters
    /// </summary>
    public class CardCritter : Card, ICardCritter
    {

        public int Damage { get; private init;} 
        public int Health { get; private init;} 
        public List<int> Abilities { get; private init; }

        //Constructor that calls the base constructor and set critter-specific fields
        public CardCritter(int cardId, string name, int playCost, Rarity rarity, string image, string description,
                           int damage, int health, List<int> abilities) : base(cardId, name, playCost, rarity, image, description)
        {
            Damage = damage;
            Health = health;
            Abilities = abilities;
        }

        //Critters will accept visitors differently
        public override void Accept(ICardVisitor visitor)
        {
            visitor.VisitCritterCard(this);
        }
    }
}


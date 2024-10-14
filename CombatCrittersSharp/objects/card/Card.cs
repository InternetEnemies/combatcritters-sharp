using CombatCrittersSharp.objects.card.Interfaces;

namespace CombatCrittersSharp.objects.card
{
    /// <summary>
    /// abstract parent to all card types
    /// </summary>
    /// <param name="cardId"></param>
    /// <param name="name"></param>
    /// <param name="playCOst"></param>
    /// <param name="rarity"></param>
    /// <param name="image"></param>
    /// <param name="description"></param>
    public abstract class Card : ICard
    {
        public int CardId { get; protected set;}
        public string Name { get; protected set;}
        public int PlayCost { get; protected set; }
        public Rarity Rarity { get;protected set; }
        public string Image { get;protected set; }
        public string Description { get;protected set; }

        //Constructor to initialize shard properties
        protected Card(int cardId, string name, int playCost, Rarity rarity, string image, string description)
        {
            CardId = cardId;
            Name = name;
            PlayCost = playCost;
            Rarity =  rarity;
            Image = image;
            Description = description;

        }
        public abstract void Accept(ICardVisitor visitor); //Each card can define how they accept visitors 
    }
}


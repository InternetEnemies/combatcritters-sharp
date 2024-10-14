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
        public int CardId { get; private init;}
        public string Name { get; private init;}
        public int PlayCost { get; private init; }
        public Rarity Rarity { get;private init; }
        public string Image { get; private init; }
        public string Description { get; private init; }

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


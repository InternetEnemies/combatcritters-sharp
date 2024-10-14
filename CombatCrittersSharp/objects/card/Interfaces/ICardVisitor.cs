namespace CombatCrittersSharp.objects.card.Interfaces
{
    /// <summary>
    /// visitor for cards
    /// </summary>
    public interface ICardVisitor
    {
        void VisitCritterCard(ICardCritter card);
        void VisitItemCard(ICardItem card);

    } 
}


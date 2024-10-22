using CombatCrittersSharp.objects.card.Interfaces;
using CombatCrittersSharp.objects.pack;

namespace CombatCrittersSharp.objects.visitor;

public interface IItemVisitor
{
    void VisitCardCritter(ICardCritter card);
    void VisitCardItem(ICardItem card);
    void VisitPack(IPack pack);
}
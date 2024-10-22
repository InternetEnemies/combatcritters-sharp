using CombatCrittersSharp.objects.card.Interfaces;
using CombatCrittersSharp.objects.currency;
using CombatCrittersSharp.objects.pack;

namespace CombatCrittersSharp.objects.offer;

public interface IOffer
{
    int OfferId { get; } // id of the offer
    IItemStack<Object> ReceiveItem { get; } // item to receive
    List<IItemStack<Object>> GiveItem { get; } // item to give
}
using CombatCrittersSharp.objects.card.Interfaces;

namespace CombatCrittersSharp.objects.offer;

public class Offer : IOffer
{
    public int OfferId { get; }
    public IItemStack<object> ReceiveItem { get; }
    public List<IItemStack<object>> GiveItem { get; }
    public Offer(int offerId, IItemStack<object> receiveItem, List<IItemStack<object>> giveItem)
    {
        this.OfferId = offerId;
        this.ReceiveItem = receiveItem;
        this.GiveItem = giveItem;
    }
}
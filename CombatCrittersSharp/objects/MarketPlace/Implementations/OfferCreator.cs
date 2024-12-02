
using CombatCrittersSharp.objects.MarketPlace.Interfaces;
using CombatCrittersSharp.rest.payloads;

namespace CombatCrittersSharp.objects.MarketPlace.Implementations
{
    public class OfferCreator : IOfferCreator
    {
        public int Level { get; set; }
        public List<IOfferCreationItem> SendItems { get; set; }
        public IOfferCreationItem RecvItem { get; set; }

        public OfferCreator(int level, List<IOfferCreationItem> sendItems, IOfferCreationItem recvItems)
        {
            Level = level;
            SendItems = sendItems;
            RecvItem = recvItems;
        }

        public static OfferCreator FromOfferCreatorPayload(OfferCreatorPayload payload)
        {
            List<IOfferCreationItem> sends = new List<IOfferCreationItem>();
            foreach (var item in payload.send_items)
            {
                sends.Add(OfferCreationItem.FromOfferCreationItemPayload(item));
            }
            return new OfferCreator(payload.level, sends, OfferCreationItem.FromOfferCreationItemPayload(payload.recv_item));
        }


    }
}
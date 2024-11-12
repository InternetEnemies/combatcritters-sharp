using CombatCrittersSharp.objects.MarketPlace.Interfaces;
using CombatCrittersSharp.rest.payloads;

namespace CombatCrittersSharp.objects.MarketPlace.Implementations
{
    public class Offer : IOffer
    {
        public int Id { get; set; }
        public List<IOfferItem> Give { get; set; }
        public IOfferItem Receive { get; set; }

        public Offer(OfferPayload payload)
        {
            Id = payload.id;
            Give = payload.give.Select(itemPayload => (IOfferItem)new OfferItem(itemPayload)).ToList();
            Receive = new OfferItem(payload.receive);
        }
    }
}
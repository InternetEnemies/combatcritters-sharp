using CombatCrittersSharp.objects.MarketPlace.Interfaces;
using CombatCrittersSharp.rest.payloads;

namespace CombatCrittersSharp.objects.MarketPlace.Implementations
{
    public class Offer : IOffer
    {
        public int Id { get; set; }
        public List<IOfferItem> Give { get; set; }
        public IOfferItem Receive { get; set; }

        public Offer(int id, List<IOfferItem> give, IOfferItem receive)
        {
            Id = id;
            Give = give;
            Receive = receive;
        }

        /// <summary>
        /// This returns a new offer from an offer payload
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public static Offer FromOfferPayload(OfferPayload payload)
        {
            List<IOfferItem> gives = new List<IOfferItem>();
            foreach (var item in payload.give)
            {
                gives.Add(OfferItem.FromOfferItemPayload(item));
            }

            return new Offer(payload.id, gives, OfferItem.FromOfferItemPayload(payload.receive));
        }
    }
}
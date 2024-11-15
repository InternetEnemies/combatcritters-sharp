using CombatCrittersSharp.objects.MarketPlace.Interfaces;
using CombatCrittersSharp.rest.payloads;

namespace CombatCrittersSharp.objects.MarketPlace.Implementations
{
    public class Offer : IOffer
    {
        public int Id { get; set; }
        public List<IOfferItem> Give { get; set; }
        public IOfferItem Receive { get; set; }

        public Offer(int id, List<OfferItem> give, OfferItem receive)
        {
            Id = id;
            Give = give?.Cast<IOfferItem>().ToList() ?? throw new ArgumentNullException(nameof(give));
            Receive = receive ?? throw new ArgumentNullException(nameof(receive));
        }

        public Offer(OfferPayload payload)
        {
            if (payload == null) throw new ArgumentNullException(nameof(payload));

            Id = payload.id;

            // Deserialize 'give' items
            Give = payload.give
                .Select(itemPayload =>
                {
                    var offerItem = new OfferItem(itemPayload);
                    offerItem.DeserializeItem(); // Parse the item based on type
                    return offerItem;
                })
                .Cast<IOfferItem>()
                .ToList();

            // Deserialize 'receive' item
            var receiveItem = new OfferItem(payload.receive);
            receiveItem.DeserializeItem(); // Parse the item based on type
            Receive = receiveItem;
        }
    }
}
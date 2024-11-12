using CombatCrittersSharp.objects.MarketPlace.Interfaces;
using CombatCrittersSharp.rest.payloads;

namespace CombatCrittersSharp.objects.MarketPlace.Implementations
{
    public class Vendor : IVendor
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Image { get; private set; }
        public string RefreshTime { get; private set; }

        public IVendorReputation Reputation { get; private set; }

        public Vendor(VendorPayload payload)
        {
            Id = payload.id;
            Name = payload.name;
            Image = payload.image;
            RefreshTime = payload.refresh_time;
            Reputation = new VendorReputation(payload.reputation);
        }
    }
}
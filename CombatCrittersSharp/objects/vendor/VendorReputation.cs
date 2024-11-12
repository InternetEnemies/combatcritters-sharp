using CombatCrittersSharp.rest.payloads;

namespace CombatCrittersSharp.objects.vendor
{
    public class VendorReputation : IVendorReputation
    {
        public int Level { get; private set; }
        public int CurrentXp { get; private set; }
        public int NextLevelXp { get; private set; }
        public int PrevLevelXp { get; private set; }

        public VendorReputation(VendorReputationPayload payload)
        {
            Level = payload.level;
            CurrentXp = payload.current_xp;
            NextLevelXp = payload.next_level_xp;
            PrevLevelXp = payload.prev_level_xp;
        }
    }
}
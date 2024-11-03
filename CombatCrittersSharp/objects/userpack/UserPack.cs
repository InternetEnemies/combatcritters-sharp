using CombatCrittersSharp.objects.pack;

namespace CombatCrittersSharp.objects.userpack
{
    public class UserPack : IUserPack
    {
        public Pack Pack { get; }
        public int Count { get; }

        public UserPack(Pack pack, int count)
        {
            Pack = pack;
            Count = count;
        }
    }
}
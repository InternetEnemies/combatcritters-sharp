using CombatCrittersSharp.objects.pack;

namespace CombatCrittersSharp.objects.userpack
{
    public interface IUserPack
    {
        /// <summary>
        /// The pack instance associated with this user's inventory.
        /// </summary>
        Pack Pack { get; }

        /// <summary>
        /// The count of this pack in the user's inventory.
        /// </summary>
        int Count { get; }
    }
}
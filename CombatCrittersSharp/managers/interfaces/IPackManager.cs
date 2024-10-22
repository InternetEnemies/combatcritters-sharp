using System.Dynamic;
using CombatCrittersSharp.objects.pack;

namespace CombatCrittersSharp.managers.interfaces;

public interface IPackManager
{
    Task<IPack> GetPack(int packId); // get a pack by its id

    Task<List<IPack>> GetPacks(); // get all packs

    Task<IPack> CreatePack(IPack buildPack); // create a pack
}
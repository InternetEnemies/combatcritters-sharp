using CombatCrittersSharp.managers.interfaces;
using CombatCrittersSharp.objects.pack;
using CombatCrittersSharp.rest;

namespace CombatCrittersSharp.managers;

public class PackManager : IPackManager
{
    public Task<IPack> CreatePack(IPack buildPack)
    {
        throw new NotImplementedException();
    }

    public Task<IPack> GetPack(int packId)
    {
        throw new NotImplementedException();
    }

    public Task<List<IPack>> GetPacks()
    {
        throw new NotImplementedException();
    }
}
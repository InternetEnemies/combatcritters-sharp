using CombatCrittersSharp.objects.card.Interfaces;

namespace CombatCrittersSharp.objects.pack;

public class Pack : IPack
{
    public string name { get; }

    public int packId { get; }

    public string image { get; }

    public Dictionary<int, int> probabilites { get; }

    public Pack(string name, string image, Dictionary<int, int> probabilites)
    {
        this.name = name;
        this.image = image;
        this.probabilites = probabilites;
    }

    public Pack(string name, int packId, string image, Dictionary<int, int> probabilites)
    {
        this.name = name;
        this.packId = packId;
        this.image = image;
        this.probabilites = probabilites;
    }

    public Task<List<ICard>> GetSetList()
    {
        throw new NotImplementedException();
    }

    public Task setList(List<ICard> cards)
    {
        throw new NotImplementedException();
    }
}
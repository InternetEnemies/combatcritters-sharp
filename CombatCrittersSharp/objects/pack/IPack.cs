using System.Data;
using CombatCrittersSharp.objects.card.Interfaces;

namespace CombatCrittersSharp.objects.pack;

public interface IPack
{
    string name { get; } // name of the pack
    int packId { get; } // id of the pack
    string image { get; } // image of the pack
    Dictionary<int, int> probabilites { get; } // dict for rarity and its weight

    Task<List<ICard>> GetSetList(); // get the cards in the pack pool
    Task setList(List<ICard> cards); // set the cards in the pack pool
}
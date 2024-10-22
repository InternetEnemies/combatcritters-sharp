using CombatCrittersSharp.objects.card.Interfaces;
using CombatCrittersSharp.objects.pack;

namespace CombatCrittersSharp.objects.packBuilder;

public interface IPackBuilder
{
    void SetName(string name); // set the name of the pack
    void SetImage(string image); // set the image of the pack
    void SetProbabilites(Dictionary<int, int> probabilites); // set the rarity and its weight
    void SetSetList(List<ICard> cards); // set the cards in the pack pool
    IPack Build(); // build the pack
    void Reset(); // reset the packBuilder
}
using CombatCrittersSharp.objects.card.Interfaces;
using CombatCrittersSharp.objects.pack;

namespace CombatCrittersSharp.objects.packBuilder;
// TODO: THIS CLASS IS NOT IMPLEMENTED
public class PackBuilder : IPackBuilder
{
    private string name;
    private string image;
    private Dictionary<int, int> probabilites;
    private List<ICard> setList;

    public PackBuilder()
    {
        this.name = "";
        this.image = "";
        this.probabilites = new Dictionary<int, int>();
        this.setList = new List<ICard>();
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public void SetImage(string image)
    {
        this.image = image;
    }

    public void SetProbabilites(Dictionary<int, int> probabilites)
    {
        this.probabilites = probabilites;
    }

    public void SetSetList(List<ICard> cards)
    {
        this.setList = cards;
    }

    public IPack Build()
    {
        // TODO: Implement this method, need tp check if the pack has all the required fields
        return new Pack(name, image, probabilites);
    }

    public void Reset()
    {
        this.name = "";
        this.image = "";
        this.probabilites = new Dictionary<int, int>();
        this.setList = new List<ICard>();
    }
}
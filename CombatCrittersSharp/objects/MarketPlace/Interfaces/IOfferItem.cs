using System.Text.Json;

namespace CombatCrittersSharp.objects.MarketPlace.Interfaces
{
    public interface IOfferItem
    {
        string Type { get; set; }
        int Count { get; set; }
        JsonElement Item { get; set; }

        object? ParsedItem { get; }
    }
}
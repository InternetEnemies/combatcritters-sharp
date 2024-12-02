using System.Text.Json;
using CombatCrittersSharp.rest.payloads;

namespace CombatCrittersSharp.objects.MarketPlace.Interfaces
{
    public interface IOfferItem
    {
        string Type { get; set; }
        int Count { get; set; }
        object Item { get; set; }
    }
}
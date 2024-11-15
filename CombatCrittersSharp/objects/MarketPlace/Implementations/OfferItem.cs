using System.Text.Json;
using CombatCrittersSharp.objects.card;
using CombatCrittersSharp.objects.MarketPlace.Interfaces;
using CombatCrittersSharp.rest.payloads;

namespace CombatCrittersSharp.objects.MarketPlace.Implementations
{
    public class OfferItem : IOfferItem
    {
        public string Type { get; set; }
        public int Count { get; set; }
        public JsonElement Item { get; set; }

        // Parsed item details
        public object? ParsedItem { get; private set; }
        public OfferItem(OfferItemPayload payload)
        {
            Type = payload.type;
            Count = payload.count;
            Item = payload.item;
        }

        public void DeserializeItem()
        {
            try
            {
                switch (Type)
                {
                    case "currency":
                        // Use count as coins for currency
                        ParsedItem = new WalletPayload(Count);
                        break;

                    case "pack":
                        // Deserialize into PackPayload
                        if (Item.ValueKind == JsonValueKind.Object)
                        {
                            ParsedItem = JsonSerializer.Deserialize<PackPayload>(Item.GetRawText());
                        }
                        break;

                    case "card":
                        // Deserialize into CardPayload and convert to Card object
                        if (Item.ValueKind == JsonValueKind.Object)
                        {
                            var cardPayload = JsonSerializer.Deserialize<CardPayload>(Item.GetRawText());
                            ParsedItem = cardPayload?.ToCard();
                        }
                        break;

                    default:
                        throw new Exception($"Unknown item type: {Type}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deserializing item of type '{Type}': {ex.Message}");
                ParsedItem = null;
            }
        }

    }
}
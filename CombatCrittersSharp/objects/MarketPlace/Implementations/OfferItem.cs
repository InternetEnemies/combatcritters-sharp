using System.Text.Json;
using CombatCrittersSharp.objects.card;
using CombatCrittersSharp.objects.currency;
using CombatCrittersSharp.objects.MarketPlace.Interfaces;
using CombatCrittersSharp.objects.pack;
using CombatCrittersSharp.rest.payloads;

namespace CombatCrittersSharp.objects.MarketPlace.Implementations
{
    public class OfferItem : IOfferItem
    {
        public string Type { get; set; }
        public int Count { get; set; }
        public object Item { get; set; }

        public OfferItem(string type, int count, object item)
        {
            Type = type;
            Count = count;
            Item = item;

            DeserializeItem();
        }
        public void DeserializeItem()
        {
            if (Type == "currency")
            {
                var walletPayload = new WalletPayload(coins: Count);

                Item = Currency.FromWalletPayload(walletPayload);
            }
            else if (Item is JsonElement jsonElement)
            {
                Item = Type switch
                {
                    "card" => JsonSerializer.Deserialize<CardPayload>(jsonElement.GetRawText())
                                 ?.ToCard() ?? throw new JsonException("Invalid CardPayload in OfferItem"),

                    "pack" => Pack.FromPackPayload(
                                  JsonSerializer.Deserialize<PackPayload>(jsonElement.GetRawText())
                                  ?? throw new JsonException("Invalid PackPayload in OfferItem"),
                                  null
                              ),
                    _ => throw new InvalidOperationException($"Unsupported item type: {Type}")
                };
            }
            else
            {
                throw new InvalidOperationException($"Unsupported item type or missing payload: {Type}");
            }
        }

        public static OfferItem FromOfferItemPayload(OfferItemPayload payload)
        {
            return new OfferItem(payload.type, payload.count, payload.item);
        }
    }
}
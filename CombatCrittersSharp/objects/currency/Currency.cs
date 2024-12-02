using CombatCrittersSharp.rest.payloads;

namespace CombatCrittersSharp.objects.currency
{
    public class Currency : ICurrency
    {

        public int _coins { get; set; }
        public Currency(int coins)
        {
            _coins = coins;
        }

        public static Currency FromWalletPayload(WalletPayload payload)
        {
            return new Currency(payload.coins);
        }
    }
}
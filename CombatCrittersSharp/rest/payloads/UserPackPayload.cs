namespace CombatCrittersSharp.rest.payloads
{
    public record UserPackPayload(
        PackDetailsPayload Item,   // The pack details as a payload
        int Count           // The count of this pack in the user's inventory
    );
}
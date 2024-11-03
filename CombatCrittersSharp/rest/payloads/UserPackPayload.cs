namespace CombatCrittersSharp.rest.payloads
{
    public record UserPackPayload(
        PackPayload Item,   // The pack details as a payload
        int Count           // The count of this pack in the user's inventory
    );
}
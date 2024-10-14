namespace CombatCrittersSharp.rest.payloads
{
    public record CardQueryPayload(
        CardPayload item, //The card information
        int count // the number of instances of this card
    );
}
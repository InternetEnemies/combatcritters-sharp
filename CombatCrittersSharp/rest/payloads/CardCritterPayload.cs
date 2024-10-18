namespace CombatCrittersSharp.rest.payloads
{
    public record CardCritterPayload(
        int damage,
        int health,
        List<int> abilities
    );
}

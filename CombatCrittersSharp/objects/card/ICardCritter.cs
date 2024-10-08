namespace CombatCrittersSharp.objects.card;

/// <summary>
/// interface for critter cards
/// </summary>
public interface ICardCritter: ICard
{
    int Damage { get; }
    int Health { get; }
    int[] Abilities { get; }
}
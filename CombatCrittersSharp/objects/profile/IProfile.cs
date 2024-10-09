using CombatCrittersSharp.objects.deck;

namespace CombatCrittersSharp.objects.profile;

public interface IProfile
{
    Task<IDeck> featured_deck { get; }
}
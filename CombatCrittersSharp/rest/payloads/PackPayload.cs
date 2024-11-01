
using CombatCrittersSharp.objects.card;

namespace CombatCrittersSharp.rest.payloads;

public record PackDetailsPayload(
    string Name, //Name of pack
    string Image, //Pack Image
    int Packid //Pack Id
);

public record PackContentsPayload(
    Card[] Cards //Array of cards within the pack
);

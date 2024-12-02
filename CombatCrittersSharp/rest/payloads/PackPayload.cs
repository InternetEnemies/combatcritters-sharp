

using CombatCrittersSharp.objects.pack;

namespace CombatCrittersSharp.rest.payloads;

public record PackPayload(
    string name, //Name of pack
    string image, //Pack Image
    int packid //Pack Id
);

public record PackContentsPayload(
    CardPayload[] cards
);

public record PackCardSlotItem(
    int rarity,
    int weight
);

public record PackCardSlotPayload(
    PackCardSlotItem[] rarityWeights
);

public record PackCreatorPayload(
    int[] contents,
    PackPayload? pack_details, //can be null
    PackCardSlotPayload?[] slots //can be null
);




namespace CombatCrittersSharp.rest.payloads;

public record PackPayload(
    string name, //Name of pack
    string image, //Pack Image
    int packid //Pack Id
);

public record PackContentsPayload(
    CardPayload[] cards
);

public record PackCreatorPayload(
    PackCardSlotPayload slot,
    int[] contents,
    PackPayload pack_details
);

public record PackCardSlotPayload(
    PackCardSlotItem[] rarityWeights // array of weights for rarities in this slot
);

public record PackCardSlotItem(
    int rarity, // rarity id
    int weight // weights for each rarity will be summed, 
               //the proportion of the total will be the probablity of getting a card with that rarity missing rarities will assume a weight of 0
);
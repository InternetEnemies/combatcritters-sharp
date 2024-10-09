using CombatCrittersSharp.objects.card;

namespace CombatCrittersSharp.rest.payloads;

public record DeckDetailsPayload(
    int deckid,
    string name
);

public record DeckPayload(
    int[] cards
);

public record DeckValidityPayload(
    bool isValid,
    string[] issues
);

public record DeckRulesPayload(
    int min_cards,
    int max_cards,
    int limit_legend,
    int limit_epic,
    int limit_rare,
    int limit_item
);
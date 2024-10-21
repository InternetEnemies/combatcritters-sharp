namespace CombatCrittersSharp.rest.payloads;

public record OfferPayload(
    int id,
    OfferItemPayload[] give,
    OfferItemPayload receive
);

public record OfferItemPayload(
    string type,
    int count,
    int item_id
);

public record VendorPayload(
    int id,
    string name,
    string image,
    VendorReputationPayload reputataion,
    string refresh_time
);

public record OfferDiscountPayload(
    int discount,
    int discountid,
    OfferPayload parent_offer,
    OfferItemPayload[] give
);

public record VendorReputationPayload(
    int level,
    int current_xp,
    int next_level_xp,
    int prev_level_xp
);

public record OfferDiscountCreatePayload(
    int offerid,
    int discount,
    OfferItemPayload[] disconted_give
);
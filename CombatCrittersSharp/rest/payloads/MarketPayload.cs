using System.Text.Json;

namespace CombatCrittersSharp.rest.payloads;

//The VendorPayload and the Vendor reputation payload will be 
public record VendorPayload(
    int id,
    string name,
    string image,
    VendorReputationPayload reputation,
    string refresh_time
);
public record VendorReputationPayload(
    int level,
    int current_xp,
    int next_level_xp,
    int prev_level_xp
);

public record OfferPayload(
    int id,
    OfferItemPayload[] give,
    OfferItemPayload receive
);

public record OfferItemPayload(
    string type,
    int count,
    JsonElement item //Store raw item data, will be processed in constructor
);

public record OfferCreatorPayload(
    int level,
    OfferCreationItemPayload recv_item,
    OfferCreationItemPayload send_items
);

public record OfferCreationItemPayload(
    int count,
    int? itemid,
    OfferItemType type
);

public enum OfferItemType
{
    Card,
    Pack,
    Currency
}

public record OfferDiscountPayload(
    int discount,
    int discountid,
    OfferPayload parent_offer,
    OfferItemPayload[] give
);



public record OfferDiscountCreatePayload(
    int offerid,
    int discount,
    OfferItemPayload[] disconted_give
);
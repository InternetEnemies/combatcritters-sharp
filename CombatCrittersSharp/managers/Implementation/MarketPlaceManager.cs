using System.Net;
using System.Net.Http.Json;
using CombatCrittersSharp.exception;
using CombatCrittersSharp.managers.interfaces;
using CombatCrittersSharp.objects.MarketPlace.Implementations;
using CombatCrittersSharp.objects.user;
using CombatCrittersSharp.rest.payloads;
using CombatCrittersSharp.rest.routes;

namespace CombatCrittersSharp.managers.Implementation
{
    public class MarketPlaceManager : IMarketPlaceManager
    {
        private readonly IUser _user;
        private readonly IClient _client;

        public MarketPlaceManager(IClient client, IUser user)
        {
            _user = user;
            _client = client;
        }

        public async Task<List<Vendor>> GetVendorsAsync()
        {
            try
            {
                //Send request to get vendors
                var response = await _client.Rest.Get(MarketRoutes.Vendors());

                //Deserialize response to vendor payload
                VendorPayload[]? payloads = await response.Content.ReadFromJsonAsync<VendorPayload[]>();

                var vendors = new List<Vendor>();
                if (payloads != null)
                {
                    foreach (VendorPayload payload in payloads)
                    {
                        vendors.Add(new Vendor(payload));
                    }
                }
                return vendors;
            }
            catch (RestException e) when (e.StatusCode == HttpStatusCode.Forbidden)
            {
                // Handle forbidden access specifically
                GeneralExceptionHandler.HandleException(e, "Access denied. Failed to retrieve vendors in vendors manager.");
                return new List<Vendor>(); // Return empty list to indicate restricted access
            }
            catch (RestException e)
            {
                // Log other REST-related errors and return an empty list
                GeneralExceptionHandler.HandleException(e, "REST error while retrieving all vendors in PacksManager.");
                return new List<Vendor>();
            }
            catch (Exception ex)
            {
                // Log any unexpected errors and return an empty list
                GeneralExceptionHandler.HandleException(ex, "Unexpected error while retrieving all packs in PacksManager.");
                return new List<Vendor>();
            }
        }

        //Debug
        public async Task<string> GetVendorOfferJsonAsync(int id)
        {
            try
            {
                var response = await _client.Rest.Get(MarketRoutes.VendorOffers(id));
                return await response.Content.ReadAsStringAsync(); // Return JSON as string
            }
            catch (Exception ex)
            {
                GeneralExceptionHandler.HandleException(ex, "Error retrieving raw JSON for vendor offer");
                return string.Empty;
            }
        }
        public async Task<List<Offer>> GetVendorOfferAsync(int id)
        {
            try
            {
                //Send request to get vendor offers by id
                var response = await _client.Rest.Get(MarketRoutes.VendorOffers(id));

                //Deserialize response
                OfferPayload[]? payloads = await response.Content.ReadFromJsonAsync<OfferPayload[]>();

                if (payloads != null)
                {
                    return payloads.Select(payload =>
                    {
                        //Deserialize give items
                        var deserializedGiveItems = payload.give
                        .Select(OfferItemPayload =>
                        {
                            var offerItem = new OfferItem(OfferItemPayload);
                            offerItem.DeserializeItem();
                            return offerItem;
                        }).ToList();

                        //Deserialize 'receive' item
                        var deserializedReceiveItem = new OfferItem(payload.receive);
                        deserializedReceiveItem.DeserializeItem();

                        //Create an return the Offer Object
                        return new Offer(payload.id, deserializedGiveItems, deserializedReceiveItem);
                    }).ToList();
                }
                //Return an empty list if no payloads
                return new List<Offer>();
            }
            catch (RestException e) when (e.StatusCode == HttpStatusCode.Forbidden)
            {
                // Handle forbidden access specifically
                GeneralExceptionHandler.HandleException(e, "Access denied. Failed to offers from MarketManager");
                return new List<Offer>();
            }
            catch (RestException e)
            {
                // Log other REST-related errors and return an empty list
                GeneralExceptionHandler.HandleException(e, "REST error while retrieving vendor offer");
                return new List<Offer>();
            }
            catch (Exception ex)
            {
                // Log any unexpected errors and return an empty list
                GeneralExceptionHandler.HandleException(ex, "Unexpected error while retrieving vendor offer");
                return new List<Offer>();
            }


        }

        public async Task<Offer?> CreateOfferAsync(int vendorId)
        {
            try
            {
                var recvItem = new OfferCreationItemPayload(
                        count: 5,
                        itemid: 123, // Nullable, can be null if no item ID is required
                        type: OfferItemType.Card // Specify the type from the enum
                    );

                var sendItem = new OfferCreationItemPayload(
                    count: 3,
                    itemid: 456,
                    type: OfferItemType.Pack
                );

                var offerCreatorPayload = new OfferCreatorPayload(
                    level: 1, // Specify the level
                    recv_item: recvItem,
                    send_items: sendItem
                );

                //Send POST request with payload
                var response = await _client.Rest.Post(MarketRoutes.VendorOffers(vendorId), offerCreatorPayload);

                //Response returns an Offer Payload
                OfferPayload? offerPayload = await response.Content.ReadFromJsonAsync<OfferPayload>();

                if (offerPayload != null)
                {
                    // This offer constructor takes in the OfferPayload
                    var offer = new Offer(offerPayload);
                    return offer;
                }
                else
                {
                    //Return null of no new offer was created
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
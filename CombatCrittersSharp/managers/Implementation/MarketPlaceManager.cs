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

        //Debug
        public async Task<string> GetVendorOfferJsonAsync(int id)
        {

            var response = await _client.Rest.Get(MarketRoutes.VendorOffers(id));
            return await response.Content.ReadAsStringAsync(); // Return JSON as string


        }
        public async Task<List<Offer>> GetVendorOfferAsync(int id)
        {

            //Send request to get vendor offers by id
            var response = await _client.Rest.Get(MarketRoutes.VendorOffers(id));

            //Deserialize response
            OfferPayload[]? payloads = await response.Content.ReadFromJsonAsync<OfferPayload[]>();

            List<Offer> offers = new List<Offer>();
            if (payloads != null)
            {
                foreach (var payload in payloads)
                {
                    offers.Add(Offer.FromOfferPayload(payload));
                }
                return offers;
            }
            //Return an empty list if no payloads
            return offers;

        }

        public async Task<Offer?> CreateOfferAsync(int vendorId, int newLevel, List<OfferCreationItem> collectItems, OfferCreationItem receiveItem)
        {


            // convert items into payloads
            List<OfferCreationItemPayload> sendItems = new List<OfferCreationItemPayload>();

            foreach (var item in collectItems)
            {
                sendItems.Add(new OfferCreationItemPayload(
                    count: item.Count,
                    id: item.ItemId,
                    type: item.Type
                ));
            }

            OfferCreationItemPayload recvItems = new OfferCreationItemPayload(
                count: receiveItem.Count,
                id: receiveItem.ItemId,
                type: receiveItem.Type
            );

            OfferCreatorPayload offerCreatorPayload = new OfferCreatorPayload(
                level: newLevel,
                recv_item: recvItems,
                send_items: sendItems.ToArray()
            );


            var response = await _client.Rest.Post(MarketRoutes.VendorOffers(vendorId), offerCreatorPayload);

            OfferPayload? offerPayload = await response.Content.ReadFromJsonAsync<OfferPayload>();

            Offer? createdOffer = null;
            if (offerPayload != null)
            {
                createdOffer = Offer.FromOfferPayload(offerPayload);
            }
            return createdOffer;


        }
    }
}
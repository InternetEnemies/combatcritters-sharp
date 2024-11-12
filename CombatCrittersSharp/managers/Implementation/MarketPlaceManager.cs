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
    }
}
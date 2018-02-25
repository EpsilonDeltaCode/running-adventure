using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Base;
using Backend.Base.RouteInfo;
using Osrm.Client;
using Osrm.Client.Models.Responses;

namespace Backend.RouteRequest
{
    public class OsrmRouteRequester : IRouteRequester
    {
        private const string OsrmServerBaseUrl = "http://router.project-osrm.org/";
        private const string AcceptingStatusCode = "Ok";

        public OsrmRouteRequester()
        {
            RequestSuccessful = false;
            RequestedResponse = null;
        }

        public IList<IGeoCoordinate> Coordinates { get; set; }

        public bool CalculateAlternativeRoutes { get; set; }

        public RouteInfoResponse RequestedResponse { get; private set; }

        public string RequestUrl { get; private set; }

        public bool RequestSuccessful { get; private set; }

        public bool TryExecuteRequest()
        {
            RouteResponse response = TryRequestRouteResponse();

            if (response == null || response.Code != AcceptingStatusCode)
                return false;

            RequestSuccessful = true;
            RequestedResponse = OsrmConverter.ConvertRouteResponseToRouteInfoResponse(response);
            return true;
        }

        private RouteResponse TryRequestRouteResponse()
        {
            Osrm5x osrm = new Osrm5x(OsrmServerBaseUrl);
            RouteResponse response = null;

            try
            {
                Osrm.Client.Models.Requests.RouteRequest request = new Osrm.Client.Models.Requests.RouteRequest()
                {
                    Coordinates = OsrmConverter.ConvertGeocoordinatesToLocations(Coordinates).ToArray(),
                    Steps = true,
                    Alternative = CalculateAlternativeRoutes
                };
                response = osrm.Route(request);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                if (response != null)
                    Console.WriteLine("Status Code of RouteRequest: " + response.Code);
            }

            return response;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Base.RouteInfo;
using Backend.PointGeneration;
using Osrm.Client;
using Osrm.Client.Base;
using Osrm.Client.Models;
using Osrm.Client.Models.Requests;
using Osrm.Client.Models.Responses;

namespace Backend.Base
{
    public class OsrmRouteRequester : IRouteRequester
    {
        private const string OsrmServerBaseUrl = "http://router.project-osrm.org/";
        private const string AcceptingStatusCode = "Ok";

        public OsrmRouteRequester()
        {
            Coordinates = new List<GeoCoordinate>();
            RequestSuccessful = false;
            RequestedResponse = null;
        }

        public List<GeoCoordinate> Coordinates { get; set; }

        public bool CalculateAlternativeRoutes { get; set; }

        public RouteInfoResponse RequestedResponse { get; private set; }

        public string RequestUrl { get; private set; }

        public bool RequestSuccessful { get; private set; }

        public void TryExecuteRequest()
        {
            RouteResponse response = TryRequestRouteResponse();

            if (response != null && response.Code == AcceptingStatusCode)
            {
                RequestSuccessful = true;
                RequestedResponse = OsrmConverter.ConvertRouteResponseToRouteInfoResponse(response);
            }
        }

        private RouteResponse TryRequestRouteResponse()
        {
            Osrm5x osrm = new Osrm5x(OsrmServerBaseUrl);
            RouteResponse response = null;

            try
            {
                RouteRequest request = new RouteRequest()
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
                if (response != null) Console.WriteLine("Status Code of RouteRequest: " + response.Code);
            }

            return response;
        }
    }
}

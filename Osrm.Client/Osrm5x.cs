using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using Osrm.Client.Base;
using Osrm.Client.Models.Requests;
using Osrm.Client.Models.Responses;

namespace Osrm.Client
{
    public class Osrm5x
    {
        public string Url { get; set; }

        /// <summary>
        /// Version of the protocol implemented by the service.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Mode of transportation, is determined by the profile that is used to prepare the data
        /// </summary>
        public string Profile { get; set; }

        /// <summary>
        /// Timeout for web request. If not specified default value will be used.
        /// </summary>
        public int? Timeout { get; set; }

        protected readonly string RouteServiceName = "route";
        protected readonly string NearestServiceName = "nearest";
        protected readonly string TableServiceName = "table";
        protected readonly string MatchServiceName = "match";
        protected readonly string TripServiceName = "trip";
        protected readonly string TileServiceName = "tile";

        public Osrm5x(string url, string version = "v1", string profile = "driving")
        {
            Url = url;
            Version = version;
            Profile = profile;
        }

        /// <summary>
        /// This service provides shortest path queries with multiple via locations.
        /// It supports the computation of alternative paths as well as giving turn instructions.
        /// </summary>
        /// <param name="locs"></param>
        /// <returns></returns>
        public RouteResponse Route(Location[] locs)
        {
            return Route(new RouteRequest()
            {
                Coordinates = locs
            });
        }

        /// <summary>
        /// This service provides shortest path queries with multiple via locations.
        /// It supports the computation of alternative paths as well as giving turn instructions.
        /// </summary>
        /// <param name="requestParams"></param>
        /// <returns></returns>
        public RouteResponse Route(RouteRequest requestParams)
        {
            return Send<RouteResponse>(RouteServiceName, requestParams);
        }

        public NearestResponse Nearest(params Location[] locs)
        {
            return Nearest(new NearestRequest()
            {
                Coordinates = locs
            });
        }

        public NearestResponse Nearest(NearestRequest requestParams)
        {
            return Send<NearestResponse>(NearestServiceName, requestParams);
        }

        public TableResponse Table(params Location[] locs)
        {
            return Table(new TableRequest()
            {
                Coordinates = locs
            });
        }

        public TableResponse Table(TableRequest requestParams)
        {
            return Send<TableResponse>(TableServiceName, requestParams);
        }

        public MatchResponse Match(params Location[] locs)
        {
            return Match(new MatchRequest()
            {
                Coordinates = locs
            });
        }

        public MatchResponse Match(MatchRequest requestParams)
        {
            return Send<MatchResponse>(MatchServiceName, requestParams);
        }

        public TripResponse Trip(params Location[] locs)
        {
            return Trip(new TripRequest()
            {
                Coordinates = locs
            });
        }

        public TripResponse Trip(TripRequest requestParams)
        {
            return Send<TripResponse>(TripServiceName, requestParams);
        }

        protected T Send<T>(string service, BaseRequest request) //string coordinatesStr, List<Tuple<string, string>> urlParams)
        {
            var coordinatesStr = request.CoordinatesUrlPart;
            List<Tuple<string, string>> urlParams = request.UrlParams;
            var fullUrl = OsrmRequestBuilder.GetUrl(Url, service, Version, Profile, coordinatesStr, urlParams);
            string json = null;
            using (var client = new OsrmWebClient(Timeout))
            {
                json = client.DownloadString(new Uri(fullUrl));
            }

            return JsonConvert.DeserializeObject<T>(json); ;
        }

        private class OsrmWebClient : WebClient
        {
            private readonly int? _specificTimeout;

            public OsrmWebClient(int? timeout = null)
            {
                _specificTimeout = timeout;
            }

            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest request = base.GetWebRequest(address);

                if (request != null && _specificTimeout.HasValue)
                    request.Timeout = _specificTimeout.Value;

                return request;
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osrm.Client;
using Osrm.Client.Base;
using Osrm.Client.Models;

namespace Backend.Base.RouteInfo
{
    public class RouteInfoRoute
    {
        public double Distance { get; set; }

        public double Duration { get; set; }

        public IList<GeoCoordinate> Geometry { get; set; }

        public List<RouteInfoLeg> Legs { get; set; }

        public float? Confidence { get; set; }


        public enum RouteInfoRouteType
        {
            Undefined = 0,
            LineString = 1
        }
    }
}

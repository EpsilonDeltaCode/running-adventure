using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osrm.Client.Base;

namespace Backend.Base.RouteInfo
{
    public class RouteInfoManeuver
    {
        public int BearingAfter { get; set; }

        public int BearingBefore { get; set; }

        public int Exit { get; set; }

        public GeoCoordinate Coordinate { get; set; }

        public string Type { get; set; }

        public string Modifier { get; set; }
    }
}

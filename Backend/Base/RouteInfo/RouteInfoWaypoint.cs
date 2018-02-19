using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osrm.Client.Base;

namespace Backend.Base.RouteInfo
{
    public class RouteInfoWaypoint
    {
        public double Distance { get; set; }

        public string Hint { get; set; }

        public GeoCoordinate Coordinate { get; set; }

        public string Name { get; set; }

        public int? MatchingsIndex { get; set; }

        public int? TripsIndex { get; set; }

        public int? WaypointIndex { get; set; }
    }
}

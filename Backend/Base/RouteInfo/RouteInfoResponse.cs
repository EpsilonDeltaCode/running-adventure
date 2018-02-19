using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osrm.Client.Models;

namespace Backend.Base.RouteInfo
{
    public class RouteInfoResponse
    {
        public List<RouteInfoWaypoint> Waypoints { get; set; }

        public List<RouteInfoRoute> Routes { get; set; }
    }
}

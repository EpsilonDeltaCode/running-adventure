using System.Collections.Generic;
using System.Linq;

namespace Backend.Base.RouteInfo
{
    public class RouteInfoResponse
    {
        public RouteInfoResponse()
        {
        }

        public RouteInfoResponse(IEnumerable<RouteInfoWaypoint> waypoints, IEnumerable<RouteInfoRoute> routes)
        {
            Waypoints = waypoints.ToList();
            Routes = routes.ToList();
        }

        public IList<RouteInfoWaypoint> Waypoints { get; set; }

        public IList<RouteInfoRoute> Routes { get; set; }
    }
}

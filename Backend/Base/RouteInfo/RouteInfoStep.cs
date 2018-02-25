using System.Collections.Generic;
using System.Linq;

namespace Backend.Base.RouteInfo
{
    public class RouteInfoStep
    {
        public List<RouteInfoIntersection> Intersections { get; set; }

        public double Distance { get; set; }

        public double Duration { get; set; }

        public IList<GeoCoordinate> Geometry { get; set; }

        public RouteInfoManeuver Maneuver { get; set; }

        public string Mode { get; set; }

        public string Name { get; set; }
    }
}

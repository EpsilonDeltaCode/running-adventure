using System.Collections.Generic;
using System.Linq;

namespace Backend.Base.RouteInfo
{
    public class RouteInfoStep
    {
        public double Distance { get; set; }

        public double Duration { get; set; }

        public List<GeoCoordinate> Geometry { get; set; }

        public RouteInfoManeuver Maneuver { get; set; }

        public string Mode { get; set; }

        public string Name { get; set; }
    }
}

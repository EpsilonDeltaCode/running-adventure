using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osrm.Client.Base;

namespace Backend.Base.RouteInfo
{
    public class RouteInfoIntersection
    {
        public int OutAngle { get; set; }

        public int InAngle { get; set; }

        public bool[] Entries { get; set; }

        public int[] Bearings { get; set; }

        public GeoCoordinate Coordinate { get; set; }
    }
}

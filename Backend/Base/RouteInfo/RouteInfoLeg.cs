using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Base.RouteInfo
{
    public class RouteInfoLeg
    {
        public double Distance { get; set; }

        public double Duration { get; set; }

        public List<RouteInfoStep> Steps { get; set; }

        public string Summary { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Base.JourneyArea
{
    interface IJourney
    {
        IList<IGeoCoordinate> WayPoints { get; set; }

        IList<IJourneyMarker> Marker { get; }

        bool isCircularJourney { get; set; }
    }
}

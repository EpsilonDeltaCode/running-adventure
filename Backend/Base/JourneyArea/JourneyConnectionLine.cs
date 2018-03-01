using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Base.JourneyArea
{
    public class JourneyConnectionLine : IJourneyConnectionLine
    {
        public IList<IGeoCoordinate> Geometry { get; set; }
        public double GetDistance()
        {
            double totalDistance = 0.0;
            for (int i = 0; i < (Geometry.Count - 1); i++)
            {
                totalDistance += Geography.CalculateDistance(Geometry[i], Geometry[i + 1]);
            }

            return totalDistance;
        }
    }
}

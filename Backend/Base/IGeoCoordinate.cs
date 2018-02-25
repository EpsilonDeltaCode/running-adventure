using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Base
{
    public interface IGeoCoordinate
    {
        double Latitude { get; set; }

        double Longitude { get; set; }

        string LatitudeString();

        string LongitudeString();
    }
}

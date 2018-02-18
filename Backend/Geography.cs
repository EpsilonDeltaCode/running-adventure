using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    public static class Geography
    {
        public static double LatitudeRadianPerMeter = 0.000008998; // 0.000014000
        public static double LongitudeRadianPerMeter = 0.000014000; // 0.000008998
        public static GeoCoordinate Berlin = new GeoCoordinate(52.519312, 13.405842);
    }
}
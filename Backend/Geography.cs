using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Base;

namespace Backend
{
    public static class Geography
    {
        public static double LatitudeRadianPerMeter = 0.000008998; // 0.000014000
        public static double LongitudeRadianPerMeter = 0.000014000; // 0.000008998
        public static GeoCoordinate Berlin = new GeoCoordinate(52.519312, 13.405842);
        public static GeoCoordinate Dortmund = new GeoCoordinate(51.554052, 7.456588);

        public static double MetricDistance(IGeoCoordinate aCoordinate, IGeoCoordinate bCoordinate)
        {
            var latitudeDistance = Math.Abs(aCoordinate.Latitude - bCoordinate.Latitude) / LatitudeRadianPerMeter;
            var longitudeDistance = Math.Abs(aCoordinate.Longitude - bCoordinate.Longitude) / LongitudeRadianPerMeter;
            return Math.Sqrt(Math.Pow(latitudeDistance, 2) + Math.Pow(longitudeDistance, 2));
        }
    }
}
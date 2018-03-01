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

        public static double CalculateDistance(IGeoCoordinate x, IGeoCoordinate y)
        {
            // haversine
            int radius = 6371000;

            double fi1 = DegreeToRadian(x.Latitude);
            double fi2 = DegreeToRadian(y.Latitude);

            double deltafi = DegreeToRadian(x.Latitude - y.Latitude);
            double deltalambda = DegreeToRadian(x.Longitude - y.Longitude);

            double value1 = Math.Sin(deltafi / 2) * Math.Sin(deltafi / 2) +
                       Math.Cos(fi1) * Math.Cos(fi2) *
                       Math.Sin(deltalambda / 2) * Math.Sin(deltalambda / 2);

            double value2 = 2 * Math.Atan2(Math.Sqrt(value1), Math.Sqrt(1 - value1));

            return radius * value2;
        }

        private static double DegreeToRadian(double degree)
        {
            return (degree * Math.PI / 180.0);
        }
    }
}
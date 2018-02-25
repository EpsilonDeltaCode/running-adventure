using System;
using Osrm.Client.Base;

namespace Backend.Base
{
    public class GeoCoordinate :IGeoCoordinate
    {
        private double _latitude;
        private double _longitude;


        public GeoCoordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public GeoCoordinate(IGeoCoordinate value)
        {
            Latitude = value.Latitude;
            Longitude = value.Longitude;
        }



        public double Latitude
        {
            get => _latitude;
            set => _latitude = CleanToRadian(value);
        }

        public double Longitude
        {
            get => _longitude;
            set => _longitude = CleanToRadian(value);
        }



        public string LatitudeString()
        {
            return _latitude.ToString("F6").Replace(",", ".");
        }

        public string LongitudeString()
        {
            return _longitude.ToString("F6").Replace(",", ".");
        }


        public static int GetMetricDistance(IGeoCoordinate a, IGeoCoordinate b)
        {
            double latitudeDistance = Math.Abs(a.Latitude - b.Latitude);
            double longitudeDistance = Math.Abs(a.Longitude - b.Longitude);
            int metricLatitudeDistance = Convert.ToInt32(latitudeDistance / Geography.LatitudeRadianPerMeter);
            int metricLongitudeDistance = Convert.ToInt32(longitudeDistance / Geography.LongitudeRadianPerMeter);
            int metricDistance = Convert.ToInt32(Math.Sqrt(
                metricLatitudeDistance * metricLatitudeDistance +
                metricLongitudeDistance * metricLongitudeDistance));
            return metricDistance;
        }

        public static GeoCoordinate AddMetricDistance(IGeoCoordinate a, double additionalMetricLatitude, double additionalMetricLongitude)
        {
            GeoCoordinate ret = new GeoCoordinate(a);
            ret.Latitude += (additionalMetricLatitude * Geography.LatitudeRadianPerMeter);
            ret.Longitude += (additionalMetricLongitude * Geography.LongitudeRadianPerMeter);
            return ret;
        }

        public Location ToLocation()
        {
            return new Location(_latitude, _longitude);
        }

        private static double CleanToRadian(double unclean)
        {
            return Math.Round(unclean, 6, MidpointRounding.ToEven);
        }

    }
}
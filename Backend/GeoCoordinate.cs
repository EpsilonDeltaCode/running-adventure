using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Osrm.Client;
using Osrm.Client.Base;

namespace Backend
{
    public class GeoCoordinate
    {
        private double _latitude;
        private double _longitude;


        public GeoCoordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public GeoCoordinate(GeoCoordinate value)
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



        public string GetLatitudeString()
        {
            return _latitude.ToString("F6").Replace(",", ".");
        }

        public string GetLongitudeString()
        {
            return _longitude.ToString("F6").Replace(",", ".");
        }


        public static int GetMetricDistance(GeoCoordinate a, GeoCoordinate b)
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

        [Obsolete("Use AddMetricDistance instead")]
        public static GeoCoordinate AddLatitude(GeoCoordinate a, int meters)
        {
            GeoCoordinate ret = new GeoCoordinate(a.Latitude, a.Longitude);
            ret.Latitude += (meters * Geography.LatitudeRadianPerMeter);
            return ret;
        }

        [Obsolete("Use AddMetricDistance instead")]
        public static GeoCoordinate AddLongitude(GeoCoordinate a, int meters)
        {
            GeoCoordinate ret = new GeoCoordinate(a.Latitude, a.Longitude);
            ret.Longitude += (meters * Geography.LongitudeRadianPerMeter);
            return ret;
        }

        public static GeoCoordinate AddMetricDistance(GeoCoordinate a, double additionalMetricLatitude, double additionalMetricLongitude)
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
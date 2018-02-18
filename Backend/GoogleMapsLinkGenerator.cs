using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    public static class GoogleMapsLinkGenerator
    {
        private static string _websiteStartAdress = "https://www.google.de/maps/dir/";

        public static string GenerateLinkWithPoints(List<GeoCoordinate> points)
        {
            string endString = _websiteStartAdress;
            foreach (GeoCoordinate geoCoordinate in points)
            {
                endString += "" + geoCoordinate.Latitude.ToString("F6").Replace(',', '.') + ",+" +
                             geoCoordinate.Longitude.ToString("F6").Replace(',', '.') + "/";
            }

            return endString;
        }
    }
}
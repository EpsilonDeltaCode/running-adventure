using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Base;

namespace Backend.RouteImage
{
    public  class GoogleMapsUrlGenerator : IObservableUrlGenerator
    {
        private const string WebsiteStartAdress = "https://www.google.de/maps/dir/";
        private const string Seperator = "/";

        public IList<IGeoCoordinate> Coordinates { get; set; }

        public GoogleMapsUrlGenerator()
        {
        }

        public Uri GenerateFullUrl()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(WebsiteStartAdress);
            builder.Append(AllCoordinateStrings());
            builder.Append(Seperator);
            return new Uri(builder.ToString());
        }

        private static string GenerateGeoCoordinateToString(IGeoCoordinate coordinate)
            => coordinate.Latitude.ToString("F6").Replace(',', '.') + ",+" + coordinate.Longitude.ToString("F6").Replace(',', '.');

        private string AllCoordinateStrings()
        {
            return string.Join(Seperator, Coordinates.Select(GenerateGeoCoordinateToString).ToArray());
        }
    }
}
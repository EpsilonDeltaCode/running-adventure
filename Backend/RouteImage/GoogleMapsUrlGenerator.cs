using System.Collections.Generic;
using System.Text;
using Backend.Base;

namespace Backend.RouteImage
{
    public  class GoogleMapsUrlGenerator : IObservableUrlGenerator
    {
        private static string _websiteStartAdress = "https://www.google.de/maps/dir/";

        public List<GeoCoordinate> Coordinates;

        public GoogleMapsUrlGenerator()
        {
            Coordinates = new List<GeoCoordinate>();
        }

        public string GenerateFullUrl()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(_websiteStartAdress);
            AppendCoordinateStrings(builder);
            return builder.ToString();
        }

        private void AppendCoordinateStrings(StringBuilder builder)
        {
            foreach (GeoCoordinate geoCoordinate in Coordinates)
            {
                builder.Append("" + geoCoordinate.Latitude.ToString("F6").Replace(',', '.') + ",+" +
                               geoCoordinate.Longitude.ToString("F6").Replace(',', '.') + "/");
            }
        }
    }
}
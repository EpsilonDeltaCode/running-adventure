using System.Collections.Generic;
using System.Text;
using Backend.Base;

namespace Backend.RouteImage
{
    public class ProjectOsrmUrlGenerator : IObservableUrlGenerator
    {
        private const string BaseLink = "http://map.project-osrm.org/";

        private const string Seperator = "&";

        public ProjectOsrmUrlGenerator()
        {
            Coordinates = new List<GeoCoordinate>();
            Zoom = 8;
            LanguageString = "en";
            AlternativeRoutes = false;
        }

        public List<GeoCoordinate> Coordinates { get; set; }

        public int Zoom { get; set; }

        public string LanguageString { get; set; }

        public bool AlternativeRoutes { get; set; }


        private string GenerateZoomString() => "?z?" + Zoom;

        private string GenerateLanguageString() => "hl=" + LanguageString;

        private string GenerateAlternativeRoutesString() => "alt=" + (AlternativeRoutes ? "1" : "0");

        private static string GenerateGeoCoordinateToString(GeoCoordinate coordinate) => "loc=" + coordinate.GetLatitudeString() + "%2C" + coordinate.GetLongitudeString() + Seperator;


        public string GenerateFullUrl()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(BaseLink + GenerateZoomString() + Seperator);
            builder = AppendCoordinateStrings(builder);
            builder.Append(GenerateLanguageString() + Seperator + GenerateAlternativeRoutesString());
            return builder.ToString();
        }

        private StringBuilder AppendCoordinateStrings(StringBuilder builder)
        {
            foreach (GeoCoordinate geoCoordinate in Coordinates)
            {
                builder.Append("" + GenerateGeoCoordinateToString(geoCoordinate));
            }

            return builder;
        }
    }
}

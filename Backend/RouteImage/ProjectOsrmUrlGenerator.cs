using System;
using System.Collections.Generic;
using System.Linq;
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
            Zoom = 8;
            LanguageString = "en";
            AlternativeRoutes = false;
        }

        public IList<IGeoCoordinate> Coordinates { get; set; }

        public int Zoom { get; set; }

        public string LanguageString { get; set; }

        public bool AlternativeRoutes { get; set; }

        public Uri GenerateFullUrl()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(BaseLink);
            builder.Append(GenerateZoomString());
            builder.Append(Seperator);
            builder.Append(AllCoordinateStrings());
            builder.Append(Seperator);
            builder.Append(GenerateLanguageString());
            builder.Append(Seperator);
            builder.Append(GenerateAlternativeRoutesString());
            return new Uri(builder.ToString());
        }

        private string GenerateZoomString() => "?z?" + Zoom;

        private string GenerateLanguageString() => "hl=" + LanguageString;

        private string GenerateAlternativeRoutesString() => "alt=" + (AlternativeRoutes ? "1" : "0");

        private static string GenerateGeoCoordinateToString(IGeoCoordinate coordinate) 
            => "loc=" + coordinate.LatitudeString() + "%2C" + coordinate.LongitudeString();

        private string AllCoordinateStrings()
        {
            return string.Join(Seperator, Coordinates.Select(GenerateGeoCoordinateToString).ToArray());
        }
    }
}

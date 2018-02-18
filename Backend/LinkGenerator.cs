using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend;

namespace Backend
{
    public class LinkGenerator
    {
        private string _baseLink = "http://map.project-osrm.org/";
        private string _seperator = "&";


        public int Zoom { get; set; }

        public string LanguageString { get; set; }

        public bool AlternativeRoutes { get; set; }


        private string GenerateZoomString()
        {
            return "?z?" + Zoom;
        }

        private string GenerateLanguageString()
        {
            return "hl=" + LanguageString;
        }

        private string GenerateAlternativeRoutesString()
        {
            return "alt=" + (AlternativeRoutes ? "1" : "0");
        }

        private string GeoCoordinateToString(GeoCoordinate coordinate)
        {
            return "loc=" + coordinate.GetLatitudeString() + "%2C" + coordinate.GetLongitudeString() + _seperator;
        }


        public string GenerateFullLink(List<GeoCoordinate> points)
        {
            string fullLink = _baseLink + GenerateZoomString() + _seperator;
            foreach (GeoCoordinate geoCoordinate in points)
            {
                fullLink += ("" + GeoCoordinateToString(geoCoordinate));
            }

            fullLink += (GenerateLanguageString() + _seperator + GenerateAlternativeRoutesString());
            return fullLink;
        }
    }
}

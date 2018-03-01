using System.Collections.Generic;
using System.Linq;
using Backend;
using Backend.Base;
using Backend.Base.RouteInfo;
using Backend.CoordinateGeneration;
using Backend.RouteImage;
using Backend.Services;
using Logging;
using Osrm.Client;
using Osrm.Client.Base;
using Osrm.Client.Models.Responses;

namespace Frontend.TestArea
{
    public static class TestingFunctions
    {
        public static IList<IGeoCoordinate> CalculateRandomCoordinatesAndMatchToStreetGrid()
        {
            OnCircleRandomCoordinatesGenerator generator = new OnCircleRandomCoordinatesGenerator()
            {
                MetricCircumFerence = 2000.0,
                CircleDirection = 0,
                HomeCoordinate = Geography.Dortmund,
                NumberOfCoordinates = 10
            };


            IList<IGeoCoordinate> randomCoordinates = generator.GenerateCoordinates();

            Osrm5x osrm = new Osrm5x("http://router.project-osrm.org/");

            return randomCoordinates
                .Select(geoCoordinate => osrm.Nearest(((GeoCoordinate) geoCoordinate).ToLocation()))
                .Select(nearestResponse => new GeoCoordinate(nearestResponse.Waypoints[0].Location.Latitude, nearestResponse.Waypoints[0].Location.Longitude))
                .Cast<IGeoCoordinate>().ToList();
        }

        public static string GetOrsmObservableUrl(IList<IGeoCoordinate> coordinates)
        {
            IObservableUrlGenerator urlGenerator = new ProjectOsrmUrlGenerator()
            {
                Coordinates = coordinates
            };

            return urlGenerator.GenerateFullUrl().AbsoluteUri;
        }
    }
}

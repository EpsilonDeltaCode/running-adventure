using System.Collections.Generic;
using System.Linq;
using Backend;
using Backend.Base;
using Backend.Base.RouteInfo;
using Backend.PointGeneration;
using Backend.RouteImage;
using Backend.RouteRequest;
using Logging;
using Osrm.Client;
using Osrm.Client.Base;
using Osrm.Client.Models.Responses;

namespace Frontend.TestArea
{
    public static class TestingFunctions
    {

        public static void TestFunctionForDetailedCoordinationGeneration()
        {
            IGeoCoordinate a = new GeoCoordinate(51.089449, 6.824763); 
            IGeoCoordinate b = new GeoCoordinate(51.073520, 6.816915);

            var coordinateList = new List<IGeoCoordinate>() {a, b};

            IRouteRequester requester = new OsrmRouteRequester()
            {
                Coordinates = coordinateList,
                CalculateAlternativeRoutes = false
            };
            requester.TryExecuteRequest();

            IObservableUrlGenerator urlGeneratorRAW = new ProjectOsrmUrlGenerator()
            {
                Coordinates = coordinateList
            };

            BlueLogger.GetInstance().AddLogEntry("URL1:", urlGeneratorRAW.GenerateFullUrl().AbsoluteUri);


            List<IGeoCoordinate> fineCoordinates = new List<IGeoCoordinate>();

            foreach (var step in requester.RequestedResponse.Routes[0].Legs[0].Steps)
            {
                foreach (var geoCoordinate in step.Geometry.Cast<IGeoCoordinate>().ToList())
                {
                    fineCoordinates.Add(geoCoordinate);
                }
            }

            IObservableUrlGenerator urlGenerator = new ProjectOsrmUrlGenerator()
            {
                Coordinates = fineCoordinates
            };

            BlueLogger.GetInstance().AddLogEntry("URL2:", urlGenerator.GenerateFullUrl().AbsoluteUri);

        }

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

        public static IRouteRequester RequestARoute(IList<IGeoCoordinate> coordinates)
        {
            IRouteRequester requester = new OsrmRouteRequester()
            {
                Coordinates = coordinates,
                CalculateAlternativeRoutes = false,
            };

            requester.TryExecuteRequest();

            return requester;

        }

        public static string GetOrsmObservableUrl(IList<IGeoCoordinate> coordinates)
        {
            IObservableUrlGenerator urlGenerator = new ProjectOsrmUrlGenerator()
            {
                Coordinates = coordinates
            };

            return urlGenerator.GenerateFullUrl().AbsoluteUri;
        }

        public static string GetOrsmObservableUrlForFineCoordinates(IRouteRequester requester)
        {
            IList<IGeoCoordinate> fineCoordinates = new List<IGeoCoordinate>();
            foreach (RouteInfoLeg leg in requester.RequestedResponse.Routes[0].Legs)
            {
                foreach (RouteInfoStep step in leg.Steps)
                {
                    foreach (RouteInfoIntersection intersection in step.Intersections)
                    {
                        fineCoordinates.Add(intersection.Coordinate);
                    }
                }
            }

            IObservableUrlGenerator urlGenerator = new ProjectOsrmUrlGenerator()
            {
                Coordinates = fineCoordinates,
                Zoom = 8,
                LanguageString = "en",
                AlternativeRoutes = false
            };

            return urlGenerator.GenerateFullUrl().AbsoluteUri;
        }

        public static string GetOrsmObservableUrlForPolylineTest(IRouteRequester requester)
        {
            return new ProjectOsrmUrlGenerator()
            {
                Coordinates = requester.RequestedResponse.Routes[0].Legs[0].Steps[0].Geometry.Cast<IGeoCoordinate>().ToList(),
                Zoom = 8,
                LanguageString = "en",
                AlternativeRoutes = false
            }.GenerateFullUrl().AbsoluteUri;          
        }
    }
}

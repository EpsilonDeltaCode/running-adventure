using System.Collections.Generic;
using Backend.Base;
using Backend.Base.RouteInfo;
using Backend.PointGeneration;
using Backend.RouteImage;
using Backend.RouteRequest;
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
                MetricCircumFerence = 5000.0,
                CircleDirection = 0,
                HomeCoordinate = new GeoCoordinate(50.116883, 8.660157),
                NumberOfCoordinates = 10
            };


            IList<IGeoCoordinate> randomCoordinates = generator.GenerateCoordinates();
            IList<IGeoCoordinate> cleanedCoordinates = new List<IGeoCoordinate>();

            Osrm5x osrm = new Osrm5x("http://router.project-osrm.org/");

            foreach (GeoCoordinate geoCoordinate in randomCoordinates)
            {
                NearestResponse nearestResponse = osrm.Nearest(new Location[] { geoCoordinate.ToLocation() });
                cleanedCoordinates.Add(new GeoCoordinate(nearestResponse.Waypoints[0].Location.Latitude, nearestResponse.Waypoints[0].Location.Longitude));
            }

            return cleanedCoordinates;
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
    }
}

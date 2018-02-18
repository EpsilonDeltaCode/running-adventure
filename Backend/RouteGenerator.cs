using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    public class RouteGenerator
    {
        public GeoCoordinate StartPoint;
        public List<GeoCoordinate> Points;

        public RouteGenerator(GeoCoordinate startPoint, List<GeoCoordinate> points)
        {
            if (startPoint == null) throw new ArgumentNullException(nameof(startPoint));
            if (points == null) throw new ArgumentNullException(nameof(points));
            if (points.Count == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(points));

            StartPoint = startPoint;
            Points = points;
        }

        public Route GenerateOptimizedRouteWithStartEqualsEnd()
        {
            List<Route> allPossibleRoutes = new List<Route>();
            AddRoutesIfPossible(allPossibleRoutes, Points, new Route(StartPoint));

            Console.WriteLine("Number of Possible Routes:" + allPossibleRoutes.Count);

            foreach (Route route in allPossibleRoutes)
            {
                route.AddPoint(StartPoint);
            }

            int bestDistance = allPossibleRoutes[0].TotalMetricLength;
            Route bestRoute = allPossibleRoutes[0];

            foreach (Route route in allPossibleRoutes)
            {
                if (route.TotalMetricLength < bestDistance)
                {
                    bestDistance = route.TotalMetricLength;
                    bestRoute = route;
                }
            }

            return bestRoute;
        }

        private void AddRoutesIfPossible(List<Route> CollectionList, List<GeoCoordinate> restPoints, Route untilNow)
        {
            if (restPoints.Count == 0)
            {
                CollectionList.Add(untilNow);
            }
            else
            {
                for (int i = 0; i < restPoints.Count; i++)
                {
                    List<GeoCoordinate> nextRestPoints = new List<GeoCoordinate>(restPoints);
                    nextRestPoints.RemoveAt(i);
                    Route nextUntilNow = new Route(untilNow);
                    nextUntilNow.AddPoint(restPoints[i]);
                    AddRoutesIfPossible(CollectionList, nextRestPoints, nextUntilNow);
                }
            }
        }
    }
}
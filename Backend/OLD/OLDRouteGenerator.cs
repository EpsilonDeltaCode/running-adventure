using System;
using System.Collections.Generic;
using Backend.Base;

namespace Backend.OLD
{
    public class OLDRouteGenerator
    {
        public GeoCoordinate StartPoint;
        public List<GeoCoordinate> Points;

        public OLDRouteGenerator(GeoCoordinate startPoint, List<GeoCoordinate> points)
        {
            if (startPoint == null) throw new ArgumentNullException(nameof(startPoint));
            if (points == null) throw new ArgumentNullException(nameof(points));
            if (points.Count == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(points));

            StartPoint = startPoint;
            Points = points;
        }

        public OLDRoute GenerateOptimizedRouteWithStartEqualsEnd()
        {
            List<OLDRoute> allPossibleRoutes = new List<OLDRoute>();
            AddRoutesIfPossible(allPossibleRoutes, Points, new OLDRoute(StartPoint));

            Console.WriteLine("Number of Possible Routes:" + allPossibleRoutes.Count);

            foreach (OLDRoute route in allPossibleRoutes)
            {
                route.AddPoint(StartPoint);
            }

            int bestDistance = allPossibleRoutes[0].TotalMetricLength;
            OLDRoute bestRoute = allPossibleRoutes[0];

            foreach (OLDRoute route in allPossibleRoutes)
            {
                if (route.TotalMetricLength < bestDistance)
                {
                    bestDistance = route.TotalMetricLength;
                    bestRoute = route;
                }
            }

            return bestRoute;
        }

        private void AddRoutesIfPossible(List<OLDRoute> CollectionList, List<GeoCoordinate> restPoints, OLDRoute untilNow)
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
                    OLDRoute nextUntilNow = new OLDRoute(untilNow);
                    nextUntilNow.AddPoint(restPoints[i]);
                    AddRoutesIfPossible(CollectionList, nextRestPoints, nextUntilNow);
                }
            }
        }
    }
}
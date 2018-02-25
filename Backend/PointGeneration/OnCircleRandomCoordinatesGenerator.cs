using System;
using System.Collections.Generic;
using Backend.Base;

namespace Backend.PointGeneration
{
    public class OnCircleRandomCoordinatesGenerator : ICoordinatesGenerator
    {
        private readonly Random _random;


        public OnCircleRandomCoordinatesGenerator()
        {
            _random = new Random();
        }



        public double MetricCircumFerence { get; set; }

        public IGeoCoordinate HomeCoordinate { get; set; }

        public int NumberOfCoordinates { get; set; }

        public double CircleDirection { get; set; }


        public IList<IGeoCoordinate> GenerateCoordinates()
        {
            IList<IGeoCoordinate> ret = new List<IGeoCoordinate>() { HomeCoordinate };

            double radius = MetricCircumFerence / (2 * Math.PI);
            double interval = 360.0 / NumberOfCoordinates;
            double startAngle = interval / 2;

            double centerAdditionalMetricLatitude = radius * Math.Sin(Common.DegreeToRadian(CircleDirection));
            double centerAdditionalMetricLongitude = radius * Math.Cos(Common.DegreeToRadian(CircleDirection));
            GeoCoordinate circleCenter = GeoCoordinate.AddMetricDistance(HomeCoordinate, centerAdditionalMetricLatitude, centerAdditionalMetricLongitude);

            for (int i = 0; i < (NumberOfCoordinates - 1); i++)
            {
                ret.Add(AddNewCoordinate(startAngle, i, interval, radius, circleCenter));
            }

            return ret;
        }

        private GeoCoordinate AddNewCoordinate(double startAngle, int i, double interval, double radius, IGeoCoordinate circleCenter)
        {
            int angleMin = (int) (((CircleDirection + 180) + startAngle + (i * interval)) % 360);
            int randomAngle = angleMin + _random.Next(0, (int) interval);
            double metricLatitude = radius * Math.Sin(Common.DegreeToRadian(randomAngle));
            double metricLongitude = radius * Math.Cos(Common.DegreeToRadian(randomAngle));
            GeoCoordinate newCoordinate = GeoCoordinate.AddMetricDistance(circleCenter, metricLatitude, metricLongitude);
            return newCoordinate;
        }
    }
}
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

        public GeoCoordinate HomeCoordinate { get; set; }

        public int NumberOfCoordinates { get; set; }

        public double CircleDirection { get; set; }


        public List<GeoCoordinate> GenerateCoordinates()
        {
            List<GeoCoordinate> ret = new List<GeoCoordinate>() { HomeCoordinate };

            double radius = MetricCircumFerence / (2 * Math.PI);
            double interval = 360.0 / NumberOfCoordinates;
            double startAngle = interval / 2;

            double centerAdditionalMetricLatitude = radius * Math.Sin(Common.DegreeToRadian(CircleDirection));
            double centerAdditionalMetricLongitude = radius * Math.Cos(Common.DegreeToRadian(CircleDirection));
            GeoCoordinate circleCenter = GeoCoordinate.AddMetricDistance(HomeCoordinate, centerAdditionalMetricLatitude, centerAdditionalMetricLongitude);

            for (int i = 0; i < (NumberOfCoordinates - 1); i++)
            {
                int angleMin = (int)(((CircleDirection + 180) + startAngle + (i * interval)) % 360);
                //int angleMax = (int)(((CircleDirection + 180) + startAngle + ((i + 1) * interval)) % 360);
                int randomAngle = angleMin + _random.Next(0, (int) interval);

                double metricLatitude = radius * Math.Sin(Common.DegreeToRadian(randomAngle));
                double metricLongitude = radius * Math.Cos(Common.DegreeToRadian(randomAngle));

                GeoCoordinate newPoint = GeoCoordinate.AddMetricDistance(circleCenter, metricLatitude, metricLongitude);
                ret.Add(newPoint);
            }

            return ret;
        }
    }
}
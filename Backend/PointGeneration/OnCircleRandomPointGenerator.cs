using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend;
using Backend.Base;

namespace Backend.PointGeneration
{
    public class OnCircleRandomPointGenerator : IPointsGenerator
    {
        private readonly Random _random;


        public OnCircleRandomPointGenerator()
        {
            _random = new Random();
        }



        public double MetricCircumFerence { get; set; }

        public GeoCoordinate HomePoint { get; set; }

        public int NumberOfPoints { get; set; }

        public double CircleDirection { get; set; }


        public List<GeoCoordinate> GeneratePoints()
        {
            List<GeoCoordinate> ret = new List<GeoCoordinate>() { HomePoint };

            double radius = MetricCircumFerence / (2 * Math.PI);
            double interval = 360.0 / NumberOfPoints;
            double startAngle = interval / 2;

            double centerAdditionalMetricLatitude = radius * Math.Sin(Common.DegreeToRadian(CircleDirection));
            double centerAdditionalMetricLongitude = radius * Math.Cos(Common.DegreeToRadian(CircleDirection));
            GeoCoordinate circleCenter = GeoCoordinate.AddMetricDistance(HomePoint, centerAdditionalMetricLatitude, centerAdditionalMetricLongitude);

            for (int i = 0; i < (NumberOfPoints - 1); i++)
            {
                int angleMin = (int)(((CircleDirection + 180) + startAngle + (i * interval)) % 360);
                int angleMax = (int)(((CircleDirection + 180) + startAngle + ((i + 1) * interval)) % 360);

                double metricLatitude = radius * Math.Sin(Common.DegreeToRadian(angleMin + _random.Next(0, (int)interval)));
                double metricLongitude = radius * Math.Cos(Common.DegreeToRadian(angleMin + _random.Next(0, (int)interval)));

                GeoCoordinate newPoint = GeoCoordinate.AddMetricDistance(circleCenter, metricLatitude, metricLongitude);
                ret.Add(newPoint);

                //Log.Debug("Info","Lat: " + newPoint.GetLatitudeString() + " - Lng: " + newPoint.GetLongitudeString());
            }

            int a = 0;

            return ret;
        }
    }
}
using System;
using System.Collections.Generic;
using Backend.Base;

namespace Backend.PointGeneration
{
    public class SpecialRandomCoordinatesGenerator : ICoordinatesGenerator
    {
        private readonly Random _random;

        public SpecialRandomCoordinatesGenerator()
        {
            _random = new Random();
        }


        public double MetricCircumFerence { get; set; }

        public double MetricRadius => MetricCircumFerence / (2 * Math.PI);

        public GeoCoordinate HomeCoordinate { get; set; }

        public int NumberOfCoordinates { get; set; }



        public List<GeoCoordinate> GenerateRandomSurroundingPoints()
        {
            List<GeoCoordinate> points = new List<GeoCoordinate>();
            Random random = new Random();

            for (int i = 0; i < 100; i++) { random.Next(); }

            for (int i = 0; i < NumberOfCoordinates; i++)
            {
                double nextLatitude = HomeCoordinate.Latitude + Geography.LatitudeRadianPerMeter *
                                      (random.Next((int)MetricRadius * 2) - (int)MetricRadius);
                double nextLongitude = HomeCoordinate.Longitude + Geography.LongitudeRadianPerMeter *
                                      (random.Next((int)MetricRadius * 2) -(int)MetricRadius);

                points.Add(new GeoCoordinate(nextLatitude, nextLongitude));
            }

            return points;
        }

        public List<GeoCoordinate> GenerateRandomCirclePoints()
        {
            List<GeoCoordinate> Points = new List<GeoCoordinate>();
            int[] XValues = new int[NumberOfCoordinates];
            int[] YValues = new int[NumberOfCoordinates];

            int Radius = Convert.ToInt32(MetricRadius / (2 * Math.PI));
            int DegreePerPoint = 360 / NumberOfCoordinates;

            Random random = new Random();

            for (int i = 0; i < 100; i++) { random.Next(); }


            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < (NumberOfCoordinates / 4); j++)
                {
                    double DegreePointMinimum = j * DegreePerPoint;
                    double DegreePointMaximum = (j + 1) * DegreePerPoint;
                    double XMaximum = Math.Cos(DegreePointMinimum) * Radius;
                    //double YMaximumAA = Math.Sin(DegreePointMaximum) * Radius;


                    int XValue = random.Next(0, (int)XMaximum);

                    double YMaximum;
                    if (XValue > (int)(Math.Cos(DegreePointMaximum) * Radius))
                    {
                        YMaximum = Math.Sin(DegreePointMaximum) * Radius;
                    }
                    else
                    {
                        YMaximum = Math.Tan(DegreePointMaximum) * XValue;
                    }

                    double YMinimum = Math.Tan(DegreePointMinimum) * XValue;


                    int YValue = random.Next((int)YMinimum, (int)YMaximum);

                    if (i == 1 || i == 2)
                    {
                        YValue = YValue * (-1);
                    }
                    if (i > 1)
                    {
                        XValue = XValue * (-1);
                    }

                    Points.Add(GeoCoordinate.AddMetricDistance(HomeCoordinate, YValue, XValue));
                }
            }

            return Points;
        }

        public List<GeoCoordinate> GenerateCoordinates()
        {
            return GenerateRandomSurroundingPoints();
        }
    }
}
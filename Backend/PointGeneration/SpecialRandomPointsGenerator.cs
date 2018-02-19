using System;
using System.Collections.Generic;
using Backend.Base;

namespace Backend.PointGeneration
{
    public static class SpecialRandomPointsGenerator
    {
        public static List<GeoCoordinate> GenerateRandomSurroundingPoints(
            int maxMetricDistance, int numberOfPoints, GeoCoordinate startPoint)
        {
            List<GeoCoordinate> points = new List<GeoCoordinate>();
            Random random = new Random();

            for (int i = 0; i < 100; i++) { random.Next(); }

            for (int i = 0; i < numberOfPoints; i++)
            {
                double nextLatitude = startPoint.Latitude + Geography.LatitudeRadianPerMeter *
                                      (random.Next(maxMetricDistance * 2) - maxMetricDistance);
                double nextLongitude = startPoint.Longitude + Geography.LongitudeRadianPerMeter *
                                      (random.Next(maxMetricDistance * 2) - maxMetricDistance);

                points.Add(new GeoCoordinate(nextLatitude, nextLongitude));
            }

            return points;
        }

        public static List<GeoCoordinate> GenerateRandomCirclePoints(
            int maxMetricDistance, int numberOfPoints, GeoCoordinate startPoint)
        {
            List<GeoCoordinate> Points = new List<GeoCoordinate>();
            int[] XValues = new int[numberOfPoints];
            int[] YValues = new int[numberOfPoints];

            int Radius = Convert.ToInt32(maxMetricDistance / (2 * Math.PI));
            int DegreePerPoint = 360 / numberOfPoints;

            Random random = new Random();

            for (int i = 0; i < 100; i++) { random.Next(); }


            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < (numberOfPoints / 4); j++)
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

                    Points.Add(GeoCoordinate.AddLatitude(GeoCoordinate.AddLongitude(startPoint, YValue), XValue));
                }
            }

            return Points;
        }
    }
}
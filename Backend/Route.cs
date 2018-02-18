using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    public class Route
    {
        public List<GeoCoordinate> Points;

        public Route(Route value) : this(new List<GeoCoordinate>(value.Points))
        {
        }

        public Route(GeoCoordinate coordinate) : this(new List<GeoCoordinate>() { coordinate })
        {
        }

        public Route(List<GeoCoordinate> points)
        {
            if (points == null) throw new ArgumentNullException(nameof(points));
            if (points.Count == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(points));

            Points = points;
            CalculateTotalLength();
        }


        public int TotalMetricLength { get; private set; }
        public int NumberOfPoints => Points.Count;

        public GeoCoordinate GetStart()
        {
            return Points[0];
        }

        public GeoCoordinate GetEnd()
        {
            return Points[Points.Count - 1];
        }

        public void AddPoint(GeoCoordinate newPoint)
        {
            if (newPoint == null) throw new ArgumentNullException(nameof(newPoint));

            Points.Add(newPoint);
            CalculateTotalLength();
        }

        private void CalculateTotalLength()
        {
            //if (Points == null) throw new Exception("Empty List " + nameof(Points));

            if (Points.Count == 1)
            {
                TotalMetricLength = 0;
            }
            else
            {
                for (int i = 0; i < Points.Count - 1; i++)
                {
                    TotalMetricLength += GeoCoordinate.GetMetricDistance(Points[i], Points[i + 1]);
                }
            }
        }

    }
}
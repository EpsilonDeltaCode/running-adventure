using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.PointGeneration
{
    public interface IPointsGenerator
    {
        List<GeoCoordinate> GeneratePoints();
    }
}
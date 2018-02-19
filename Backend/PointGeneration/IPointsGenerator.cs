using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Base;

namespace Backend.PointGeneration
{
    public interface IPointsGenerator
    {
        List<GeoCoordinate> GeneratePoints();
    }
}
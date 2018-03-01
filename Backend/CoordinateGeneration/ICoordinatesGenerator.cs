using System.Collections.Generic;
using Backend.Base;

namespace Backend.CoordinateGeneration
{
    public interface ICoordinatesGenerator
    {
        IList<IGeoCoordinate> GenerateCoordinates();
    }
}
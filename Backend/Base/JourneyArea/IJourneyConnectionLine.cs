using System.Collections.Generic;

namespace Backend.Base.JourneyArea
{
    public interface IJourneyConnectionLine
    {
        IList<IGeoCoordinate> Geometry { get; set; }
        // a line represented by a List of coodrinates, as good as possible having an equal distance
        double GetDistance();
    }
}
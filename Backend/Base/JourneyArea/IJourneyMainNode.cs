using System.Collections.Generic;

namespace Backend.Base.JourneyArea
{
    public interface IJourneyMainNode : IJourneyBaseNode
    {
        IList<IJourneyBaseNode> SubNodes { get; set; }

        double DistanceToNextMainNode();
    }
}
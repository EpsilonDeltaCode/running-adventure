using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Base.JourneyArea
{
    public class JourneyMainNode : IJourneyBaseNode
    {
        public IGeoCoordinate Position { get; set; }
        public IJourneyTurn Turn { get; set; }
        public IJourneyConnectionLine NextLine { get; set; }
        public IJourneyConnectionLine PreviousLine { get; set; }
        public IBearing BearingIn { get; set; }
        public IBearing BearingOut { get; set; }
        public IList<IJourneyBaseNode> SubNodes { get; set; }
        public double DistanceToNextMainNode()
        {
            throw new NotImplementedException();
        }
    }
}

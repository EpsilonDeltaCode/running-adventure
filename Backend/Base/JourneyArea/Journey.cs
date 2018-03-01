using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Base.JourneyArea
{
    public class Journey : IJourney
    {
        public IList<IJourneyBaseNode> MainNodes { get; }
        public bool isCircularJourney { get; set; }
    }
}

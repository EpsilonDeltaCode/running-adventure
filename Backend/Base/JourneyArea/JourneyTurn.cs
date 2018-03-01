using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Base.JourneyArea
{
    public class JourneyTurn : IJourneyTurn
    {
        public JourneyTurn(TurnAction action, TurnDirection direction)
        {
            Action = action;
            Direction = direction;
        }

        public TurnAction Action { get; }
        public TurnDirection Direction { get; }
    }
}

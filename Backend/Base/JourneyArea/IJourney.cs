﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Base.JourneyArea
{
    public interface IJourney
    {
        IList<IJourneyBaseNode> MainNodes { get; }

        bool isCircularJourney { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public interface ILogger
    {
        void AddLogEntry(string tag, string entry);

        IList<Tuple<string, string>> Entries { get; }
    }
}

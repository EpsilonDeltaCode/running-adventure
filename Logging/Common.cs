using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public static class Common
    {
        public static ILogger GetCurrentLogger()
        {
            return BlueLogger.GetInstance();
        }
    }
}

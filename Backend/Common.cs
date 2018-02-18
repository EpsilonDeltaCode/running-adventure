using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    public static class Common
    {
        public static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}
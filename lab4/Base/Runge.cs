using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Base
{
    internal class Runge
    {
        public static double Run(double y1, double y2, double p)
        {
            return (y2 - y1) / (Math.Pow(2, p) - 1);
        }
    }
}

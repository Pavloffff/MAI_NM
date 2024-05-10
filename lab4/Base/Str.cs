using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Base
{
    internal class Str
    {
        public static string Parse(double value)
        {
            return Math.Round(value, 4).ToString("0.0000");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Matan
{
    internal class Diff
    {
        public Diff() { }

        public List<double> Run(List<double> f, List<double> x)
        {
            List<double> df = new List<double>(f);
            if (f.Count < 2)
            {
                df[0] = f[0];
            }
            if (f.Count == 2)
            {
                df[1] = df[0] = (f[1] - f[0]) / (x[1] - x[0]);
            }
            else
            {
                for (int i = 1; i < f.Count - 1; i++)
                {
                    df[i] = (f[i] - f[i - 1]) / (x[i] - x[i - 1]) +
                        (((f[i + 1] - f[i]) / (x[i + 1] - x[i]) - (f[i] - f[i - 1]) / 
                        (x[i] - x[i + 1])) / (x[i + 1] - x[i - 1])) * (2 * x[i] - x[i - 1] - x[i + 1]);
                }
                df[0] = df[1];
                df[df.Count - 1] = df[df.Count - 2];
            }
            return df;
        }
    }
}

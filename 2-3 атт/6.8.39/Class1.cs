using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._8._39
{
    class Class1
    {
        public void CacluationOfCoefficient(int k, double x, ref double c)
        {
            c = c * ((-1) * 2 * k * (1 - 2*(k - 1))) / (k * k * 4 * (1 - 2 * k));
        }
        public void Find_An(ref double a, int k,ref double c,double x)
        {
            CacluationOfCoefficient(k, x, ref c);
            a = a + Math.Pow(x, k) * c;
            Form1.label6.Text = a;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class Class1
    {
        static public T StrToValue<T>(string str)
        {

            return (T)Convert.ChangeType(str, typeof(T));

        }
        static public double[] StrToArray(string str)
        {
            return Array.ConvertAll
            (
                str.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries),
                (s) => StrToValue<double>(s)
            );

        }
        static public double FindNearestNumber(double [] arr, double R)
        {
            double s=arr[0];
            for(int i=1; i <= (arr.Length-1);i++)
            {
                if (Math.Abs(R - s) > Math.Abs(R - arr[i]))
                    s = arr[i];
            }
            return s;
        }
    }
}

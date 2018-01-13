using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
        public class ListSorter
        {
        static public int StrToInt(string str)
        {
            return Convert.ToInt32(str);
        }
            static public List<int> StrToList(string str)
            {
                List<int> weights = new List<int>();
                string[] strweights = str.Split(',');
            for (int i = 0; i < strweights.Length; i++)
            {
                weights.Add(StrToInt(strweights[i]));
            }
                return weights;
            }
            static public List<List<int>> RouteCounter(IList<int> weights, int sumWeights, int n)
            {
                int currentsum;
                List<List<int>> variants = new List<List<int>> ();
                for (int i = 0; i < Math.Pow(2, n) ; i++)
                {
                    currentsum = 0;
                    List<int> variant = VariantToBinList(i, n);
                    for(int z=0; z < n; z++)
                    {
                        if(variant[z]==1)
                        currentsum = currentsum + weights[z];
                    }
                    if (currentsum == sumWeights)
                        variants.Add(variant);
                }
                return variants;
            }
            static public List<int> VariantToBinList (int a, int n)
            {
            List<int> binlist = new List<int>();
            for (int i = 0; i < n; i++)
            {
                    binlist.Add(a % 2);
                    a = a / 2;
            }
            if(binlist.Count>binlist.Capacity)
            binlist.RemoveRange(n, binlist.Capacity - 1);
                  binlist.Reverse();
                return binlist;
            }
        }    
    }

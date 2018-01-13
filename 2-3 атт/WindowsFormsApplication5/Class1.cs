using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication5
{
    class Tor
    {
        public double x1 { get; set; }
        public double y1 { get; set; }
        public double x2 { get; set; }
        public double y2 { get; set; }
        public Tor (double ax1, double ax2, double ay1, double ay2)
        {
            if (ax1 > ax2)
            {
                x1 = ax1;
                x2 = ax2;
                
            }
            else
            {
                x1 = ax2;
                x2 = ax1;
               

            }

            if (ay1 > ay2)
            {
                y1 = ay1;
                y2 = ay2;
               
            }
            else
            {
                y1 = ay2;
                y2 = ay1;
                
            }
        }
        public static bool Comparsion(Tor a, Tor b) // в этой функции я отдельно рассматривал каждый из восьми случаев соотношения длинн и ширин двух выбранных прямоугольников 
        {
            if (a.x1 - a.x2 <= b.x1 - b.x2)// Ширина первого не больше ширины второго
            {
                if (a.y1 - a.y2 <= b.y1-b.y2)//
                    return ((((a.y1 >= b.y2) & (a.y1 <=b.y1)) | ((a.y2 >= b.y2) & (a.y2 <= b.y1))) & (((a.x1 >= b.x2) & (a.x1 <= b.x1)) | ((a.x2 >= b.x2) & (a.x2 <= b.x1))));
                else//
                    return ((((b.y1 >= a.y2) & (b.y1 <= a.y1)) | ((b.y2 >= a.y2) & (b.y2 <= a.y1))) & (((a.x1 >= b.x2) & (a.x1 <= b.x1)) | ((a.x2 >= b.x2) & (a.x2 <= b.x1))));
            }
            else                         
            {
            if (a.y1 - a.y2 <= b.y1 - b.y2)
            return ((((a.y1 >= b.y2) & (a.y1 <= b.y1)) | ((a.y2 >= b.y2) & (a.y2 <= b.y1))) & (((b.x1 >= a.x2) & (b.x1 <= a.x1)) | ((b.x2 >= a.x2) & (b.x2 <= a.x1))));
            else                           
            return ((((b.y1 >= a.y2) & (b.y1 <= a.y1)) | ((b.y2 >= a.y2) & (b.y2 <= a.y1))) & (((b.x1 >= a.x2) & (b.x1 <= a.x1)) | ((b.x2 >= a.x2) & (b.x2 <= a.x1))));
            }
        }
        static public List<Tor> ReadArray(string path)
        {

            StreamReader str = new StreamReader(path) ;
            string buffer;
            string[] bufferarr;
            Char delimiter = ' ';
            List<Tor> result = new List<Tor>();
            while (true)
            {
                try
                {
                    buffer = str.ReadLine();
                    bufferarr = buffer.Split(delimiter);
                    result.Add(new Tor(Convert.ToDouble(bufferarr[0]), Convert.ToDouble(bufferarr[1]), Convert.ToDouble(bufferarr[2]), Convert.ToDouble(bufferarr[3])));
                }
                catch (NullReferenceException)
                {
                    break;
                }
                
            }
            return result;
        }
        
        static public List<Tor> ChoosingTriangles (List<Tor> list, out int height)
        {
            height = list.Capacity;
            List<Tor> res = new List<Tor>();
            for(int z=0; z<list.Capacity; z++)
            {
                bool T = true;
                for (int r = 0; r < list.Capacity; r++)
                {   if (r == z)
                        continue;
                    else
                    {
                        if (Comparsion(list[z], list[r]))
                            T = false;
                    }
                }
                if (T == true)
                    res.Add(list[z]);
            }
            return res;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        static public List<int> VariantToBinList(int a, int n)
        {
            int s;
            List<int> binlist = new List<int>(n);
            for (int i = 0; i < n; i++)
            {
                s = a % 2;
                binlist.Add(s);
                a = a / 2;
            }
            binlist.Reverse();
            return binlist;
        }

    }
}

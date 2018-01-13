using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
private void button1_Click(object sender, EventArgs e)
        {
            int subWeight = ListSorter.StrToInt(textBox2.Text);
            List<int> weights = ListSorter.StrToList(textBox1.Text);
            List<List<int>> routes = ListSorter.RouteCounter(weights, subWeight, weights.Count);
            dataGridView1.RowHeadersWidth = 35;
            dataGridView1.ScrollBars = ScrollBars.Both;
            dataGridView1.ColumnHeadersHeight = 35;
            dataGridView1.ColumnCount = weights.Count;
            dataGridView1.RowCount = routes.Count;
            for(int z=0; z < routes.Count; z++)
            {
                List<int> currentroute = routes[z];
                for(int r=0; r < weights.Count; r++)
                {
                    dataGridView1[r, z].Value = currentroute[r];
                }
            }
        }
    }
}

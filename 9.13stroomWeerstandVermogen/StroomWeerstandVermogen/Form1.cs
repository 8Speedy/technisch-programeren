using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StroomWeerstandVermogen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Invoer
            decimal stroom = stroomInvoer.Value;
            decimal weerstand = weerstandInvoer.Value;

            //Verwerking
            decimal vermogen = (decimal)Math.Pow((double) stroom, 2) * weerstand;

            //Uitvoer
            VermogenOut.Text = vermogen.ToString("0.000") + " W";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

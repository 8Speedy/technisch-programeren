using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TestTP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeThisSide();
        }
        public double berekenOefening1(int getal1, int getal2, int getal3)
        {
            //1: uitwerking
            const int constwaarde = 9;

            getal1 = getal1 + constwaarde;
            getal2 = getal2 + constwaarde;
            getal3 = getal3 + constwaarde;

            double uitwerking = (double) getal1 / getal2;
            double wortel = Math.Sqrt(getal3);
            uitwerking = uitwerking * wortel;

            //2: Resultaat
            double resultaat = uitwerking;

            return resultaat;
        }

        public int berekenOefening2(int getal1, int getal2, int getal3)
        {
            //1: Uitwerking
            int uitwerking = 0;

            if ((getal1 / getal3) % 2 == 0 && (getal2 / getal3) % 2 == 0)
            {
                uitwerking = 2;
            }
            else if ((getal1 / getal3) % 2 == 0 || (getal2 / getal3) % 2 == 0)
            {
                uitwerking = 1;
            }
            else
            {
                uitwerking = 3;
            }

            //2: resultaat
            int resultaat = uitwerking;

            return resultaat;
        }

        public double berekenOefening3(int getal1, int getal2, int getal3)
        {
            //1: Definieeren
            const double budget = 2500;
            const double kost = 200;
            double uitwerking = 0;
            double volume = 0;

            //2: uitwerken
            volume = (double) getal1 * getal2 * getal3;

            uitwerking = volume * kost;

            if (uitwerking > budget) uitwerking = 2400;

            //3: resultaat
            double resultaat = uitwerking;

            return resultaat;
        }
    }
}

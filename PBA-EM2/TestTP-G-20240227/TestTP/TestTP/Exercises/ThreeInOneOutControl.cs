using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace TestTP.Exercises
{
    public partial class ThreeInOneOutControl : ExerciseControl
    {
        public ThreeInOneOutControl()
        {
            InitializeComponent();
        }






        public override void displayVector(object input, object output)
        {
            if (this.InvokeRequired) this.Invoke((Action)delegate { displayVector(input, output); });
            else
            {

                txtInput1.Text = ((string[])input)[0];
                txtInput2.Text = ((string[])input)[1];
                txtInput3.Text = ((string[])input)[2];

                txtOutput.Text = (string) output;
            }
        }

        public Func<int, int, int, double> calculateThreeInOneOutResult { get; set; }
        public override object calculateResult(object input)
        {
            int i1 = Int32.Parse(((string[])input)[0]);
            int i2 = Int32.Parse(((string[])input)[1]);
            int i3 = Int32.Parse(((string[])input)[2]);

            return calculateThreeInOneOutResult(i1, i2, i3);
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtInput1.Text)) txtInput1.Text = "0";
            if (String.IsNullOrEmpty(txtInput2.Text)) txtInput2.Text = "0";
            if (String.IsNullOrEmpty(txtInput3.Text)) txtInput3.Text = "0";

            string[] input = { txtInput1.Text, txtInput2.Text, txtInput3.Text };
            txtOutput.Text = calculateResult(input).ToString();
        }


    }
}

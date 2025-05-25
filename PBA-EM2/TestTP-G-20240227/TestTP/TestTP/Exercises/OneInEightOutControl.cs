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
    public partial class OneInEightOutControl : ExerciseControl
    {
        
        public OneInEightOutControl()
        {

            InitializeComponent();
        }

        public override void displayVector(object input, object output)
        {
            if (this.InvokeRequired) this.Invoke((Action)delegate { displayVector(input, output); });
            else
            {
                int i = 0;
                txtInput.Text = (string) input;

                TextBox[] txtOutput = { txtOutput1, txtOutput2, txtOutput3, txtOutput4, txtOutput5, txtOutput6, txtOutput7, txtOutput8 };
                string[] intOutput = (string[])output;

                for (i = 0; i < intOutput.Length && i < 8; i++) txtOutput[i].Text = intOutput[i];
                for (; i < 8; i++) txtOutput[i].Text = "";

                if (intOutput.Length > 8) MessageBox.Show("Het resultaat is te lang. Enkel de eerste 8 elementen worden getoond", "Waarschuwing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public Func<int, List<int>> calculateOneInEightOutResult { get; set; }
        public override object calculateResult(object input)
        {
            // turn string into int
            int intInput = Int32.Parse((string)input);

            List<int> output = calculateOneInEightOutResult(intInput);
            return output.ToArray();

            // turn List<int> into string[]
            List<string> result = new List<string>();
            foreach (int element in output) result.Add(element.ToString());
            return result.ToArray();
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            string input = "0";
            if (Int32.TryParse(txtInput.Text, out int result)) input = txtInput.Text;
            else txtInput.Text = input;

            int[] output = (int[]) calculateResult(input);

            TextBox[] txtOutput = { txtOutput1, txtOutput2, txtOutput3, txtOutput4, txtOutput5, txtOutput6, txtOutput7, txtOutput8 };
            int i = 0;
            for (; i < output.Length && i < 8; i++) txtOutput[i].Text = output[i].ToString();
            for (; i < 8; i++) txtOutput[i].Text = "";

            if (output.Length > 8) MessageBox.Show("Het resultaat is te lang. Enkel de eerste 8 elementen worden getoond", "Waarschuwing", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}

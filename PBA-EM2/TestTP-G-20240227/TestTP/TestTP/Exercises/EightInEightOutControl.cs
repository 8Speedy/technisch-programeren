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
    public partial class EightInEightOutControl : ExerciseControl
    {
        
        public EightInEightOutControl()
        {

            InitializeComponent();
        }

        public override void displayVector(object input, object output)
        {
            if (this.InvokeRequired) this.Invoke((Action)delegate { displayVector(input, output); });
            else
            {
                MaskedTextBox[] txtInput = { txtInput1, txtInput2, txtInput3, txtInput4, txtInput5, txtInput6, txtInput7, txtInput8 };

                string[] strInput = (string[])input;
                int i = 0;
                for (; i < strInput.Length; i++) txtInput[i].Text = strInput[i];
                for (; i < 8; i++) txtInput[i].Text = "";

                TextBox[] txtOutput = { txtOutput1, txtOutput2, txtOutput3, txtOutput4, txtOutput5, txtOutput6, txtOutput7, txtOutput8 };
                string[] strOutput = (string[])output;
                for (i = 0; i < strOutput.Length && i < 8; i++) txtOutput[i].Text = strOutput[i];
                for (; i < 8; i++) txtOutput[i].Text = "";

                if (strOutput.Length > 8) MessageBox.Show("Het resultaat is te lang. Enkel de eerste 8 elementen worden getoond", "Waarschuwing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public Func<List<int>, List<int>> calculateEightInEightOutResult { get; set; }
        public override object calculateResult(object input)
        {
            // turn string[] into List<int>
            string[] strInput = (string[])input;
            List<int> intInput = new List<int>();
            foreach (string element in strInput) intInput.Add(Int32.Parse(element));

            List<int> output = calculateEightInEightOutResult(intInput);
            return output.ToArray();
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            MaskedTextBox[] txtInput = { txtInput1, txtInput2, txtInput3, txtInput4, txtInput5, txtInput6, txtInput7, txtInput8 };
            List<string> input = new List<string>();

            int i;
            for (i = 0; i < 8 && Int32.TryParse(txtInput[i].Text, out int result); i++) input.Add(txtInput[i].Text);


            int[] output = (int[]) calculateResult(input.ToArray());
            TextBox[] txtOutput = { txtOutput1, txtOutput2, txtOutput3, txtOutput4, txtOutput5, txtOutput6, txtOutput7, txtOutput8 };
            i = 0;
            for (; i < output.Length && i < 8; i++) txtOutput[i].Text = output[i].ToString();
            for (; i < 8; i++) txtOutput[i].Text = "";

            if (output.Length > 8) MessageBox.Show("Het resultaat is te lang. Enkel de eerste 8 elementen worden getoond", "Waarschuwing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


    }
}

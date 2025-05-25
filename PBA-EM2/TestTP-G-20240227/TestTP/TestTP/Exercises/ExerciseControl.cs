using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTP.Exercises
{
    public partial class ExerciseControl : UserControl, Exercise
    {
        public ExerciseControl()
        {
            InitializeComponent();
        }

        public uint Id { get; set; }
        public string Description { get; set; }
        public uint Type { get; set; }
        public object Data { get; set; }
        public ThisSide ThisSide { get; set; }

        public virtual object calculateResult(object input)
        {
            throw new NotImplementedException();
        }

        public void displayOpgave()
        {
            txtOpgave.Rtf = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(Data.ToString()));
        }

        public virtual void displayVector(object input, object output)
        {
            throw new NotImplementedException();
        }

        protected void btnAuto_Click(object sender, EventArgs e)
        {
            btnAuto.Enabled = false;
            btnManual.Enabled = false;

            ThisSide.RequestTestVector(-1, Id, null);
        }

        public void displayScore(Score score)
        {
            if (this.InvokeRequired) this.Invoke((Action)delegate { displayScore(score); });
            else
            {
                if (score.score < 1)
                {
                    JObject data = (JObject)score.data;
                    JObject vector = JObject.Parse(data.Value<string>("data"));

                    object input = vector.Value<object>("input");
                    if (input is JArray) input = ((JArray)input).ToObject<string[]>();
                    else if (input is JValue) input = ((JValue)input).ToObject<string>();

                    object output = vector.Value<object>("output");
                    if (output is JArray) output = ((JArray)output).ToObject<string[]>();
                    else if (output is JValue) output = ((JValue)output).ToObject<string>();

                    displayVector(input, output);

                    MessageBox.Show(String.Format("Je hebt minstens 1 testvector verkeerd beantwoord. De vector en het correct antwoord staan afgebeeld. Klik op Manueel om te vergelijken met uw antwoord."), "Fout!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Proficiat! U hebt alle testvectoren voor deze oefening correct verwerkt.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!score.logged) MessageBox.Show("De test is afgelopen. Deze poging werd niet meer gelogd", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                btnAuto.Enabled = true;
                btnManual.Enabled = true;
            }
        }
    }
}

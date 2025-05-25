using System;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace SerialCommunication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string[] portNames = SerialPort.GetPortNames().Distinct().ToArray();
                comboBoxPoort.Items.Clear();
                comboBoxPoort.Items.AddRange(portNames);
                if (comboBoxPoort.Items.Count > 0) comboBoxPoort.SelectedIndex = 0;

                comboBoxBaudrate.SelectedIndex = comboBoxBaudrate.Items.IndexOf("115200");
            }
            catch (Exception)
            { }
        }

        private void cboPoort_DropDown(object sender, EventArgs e)
        {
            try
            {
                string selected = (string)comboBoxPoort.SelectedItem;
                string[] portNames = SerialPort.GetPortNames().Distinct().ToArray();

                comboBoxPoort.Items.Clear();
                comboBoxPoort.Items.AddRange(portNames);

                comboBoxPoort.SelectedIndex = comboBoxPoort.Items.IndexOf(selected);
            }
            catch (Exception)
            {
                if (comboBoxPoort.Items.Count > 0) comboBoxPoort.SelectedIndex = 0;
            }
        }

        private void buttonConnect_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPortArduino.IsOpen)
                {
                    // === Verbinding > gebruiker verbreken ===
                    serialPortArduino.Close();
                    radioButtonVerbonden.Checked = false;
                    buttonConnect.Text = "Connect";
                    labelStatus.Text = "Status: Disconnected";
                }
                else
                {
                    // === Geen verbinding > gebruiker wilt verbinding maken ===
                    serialPortArduino.PortName = (string) comboBoxPoort.SelectedItem;
                    serialPortArduino.BaudRate = Int32.Parse((string) comboBoxBaudrate.SelectedItem);
                    serialPortArduino.DataBits = (int) numericUpDownDatabits.Value;

                    if (radioButtonParityEven.Checked) serialPortArduino.Parity = Parity.Even;
                    else if (radioButtonParityOdd.Checked) serialPortArduino.Parity = Parity.Odd;
                    else if (radioButtonParityNone.Checked) serialPortArduino.Parity = Parity.None;
                    else if (radioButtonParityMark.Checked) serialPortArduino.Parity = Parity.Mark;
                    else if (radioButtonParitySpace.Checked) serialPortArduino.Parity = Parity.Space;

                    if (radioButtonStopbitsNone.Checked) serialPortArduino.StopBits = StopBits.None;
                    else if (radioButtonStopbitsOne.Checked) serialPortArduino.StopBits = StopBits.One;
                    else if (radioButtonStopbitsOnePointFive.Checked) serialPortArduino.StopBits = StopBits.OnePointFive;
                    else if (radioButtonStopbitsTwo.Checked) serialPortArduino.StopBits = StopBits.Two;

                    if (radioButtonHandshakeNone.Checked) serialPortArduino.Handshake = Handshake.None;
                    else if (radioButtonHandshakeRTS.Checked) serialPortArduino.Handshake = Handshake.RequestToSend;
                    else if (radioButtonHandshakeRTSXonXoff.Checked) serialPortArduino.Handshake = Handshake.RequestToSendXOnXOff;
                    else if (radioButtonHandshakeXonXoff.Checked) serialPortArduino.Handshake = Handshake.XOnXOff;

                    serialPortArduino.RtsEnable = checkBoxRtsEnable.Checked;
                    serialPortArduino.DtrEnable = checkBoxDtrEnable.Checked;

                    serialPortArduino.Open();
                    string commando = "ping";
                    serialPortArduino.WriteLine(commando);
                    string antwoord = serialPortArduino.ReadLine();
                    antwoord = antwoord.TrimEnd();

                    if (antwoord == "pong")
                    {
                        radioButtonVerbonden.Checked = true;
                        buttonConnect.Text = "Disconnect";
                        labelStatus.Text = "Status: Connected";
                    }
                    else
                    {
                        serialPortArduino.Close();
                        labelStatus.Text = "Error: wrong awnser";
                    }
                }
            }
            catch (Exception exception)
            {
                labelStatus.Text = "Error: " + exception.Message;
                serialPortArduino.Close();
                radioButtonVerbonden.Checked = false;
                buttonConnect.Text = "Connect";
            }
        }

        private void checkBoxDigital2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (serialPortArduino.IsOpen)
                {
                    string commando; //Set d2 high/low
                    if (checkBoxDigital2.Checked) commando = "set d2 high";
                    else commando = "set d2 low";
                    serialPortArduino.WriteLine(commando);
                }
            }
            catch (Exception exception)
            {
                labelStatus.Text = "Error: " + exception.Message;
                serialPortArduino.Close();
                radioButtonVerbonden.Checked = false;
                buttonConnect.Text = "Connect";
            }
        }

        private void checkBoxDigital3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (serialPortArduino.IsOpen)
                {
                    string commando; //Set d3 high/low
                    if (checkBoxDigital3.Checked) commando = "set d3 high";
                    else commando = "set d3 low";
                    serialPortArduino.WriteLine(commando);
                }
            }
            catch (Exception exception)
            {
                labelStatus.Text = "Error: " + exception.Message;
                serialPortArduino.Close();
                radioButtonVerbonden.Checked = false;
                buttonConnect.Text = "Connect";
            }
        }

        private void checkBoxDigital4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (serialPortArduino.IsOpen)
                {
                    string commando; //Set d4 high/low
                    if (checkBoxDigital4.Checked) commando = "set d4 high";
                    else commando = "set d4 low";
                    serialPortArduino.WriteLine(commando);
                }
            }
            catch (Exception exception)
            {
                labelStatus.Text = "Error: " + exception.Message;
                serialPortArduino.Close();
                radioButtonVerbonden.Checked = false;
                buttonConnect.Text = "Connect";
            }
        }

        private void trackBarPWM9_Scroll(object sender, EventArgs e)
        {
            try
            {
                if (serialPortArduino.IsOpen)
                {
                    string commando = String.Format("set pwm9 {0}", trackBarPWM9.Value); //Set pwm9 0-255
                    serialPortArduino.WriteLine(commando);
                }
            }
            catch (Exception exception)
            {
                labelStatus.Text = "Error: " + exception.Message;
                serialPortArduino.Close();
                radioButtonVerbonden.Checked = false;
                buttonConnect.Text = "Connect";
            }
        }

        private void trackBarPWM10_Scroll(object sender, EventArgs e)
        {
            try
            {
                if (serialPortArduino.IsOpen)
                {
                    string commando = String.Format("set pwm10 {0}", trackBarPWM10.Value); //Set pwm10 0-255
                    serialPortArduino.WriteLine(commando);
                }
            }
            catch (Exception exception)
            {
                labelStatus.Text = "Error: " + exception.Message;
                serialPortArduino.Close();
                radioButtonVerbonden.Checked = false;
                buttonConnect.Text = "Connect";
            }
        }

        private void trackBarPWM11_Scroll(object sender, EventArgs e)
        {
            try
            {
                if (serialPortArduino.IsOpen)
                {
                    string commando = String.Format("set pwm11 {0}", trackBarPWM11.Value); //Set pwm11 0-255
                    serialPortArduino.WriteLine(commando);
                }
            }
            catch (Exception exception)
            {
                labelStatus.Text = "Error: " + exception.Message;
                serialPortArduino.Close();
                radioButtonVerbonden.Checked = false;
                buttonConnect.Text = "Connect";
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerOefening3.Enabled = tabControl.SelectedIndex == 3;
            timerOefening4.Enabled = tabControl.SelectedIndex == 4;
            timerOefening5.Enabled = tabControl.SelectedIndex == 5;
            timerOefening6.Enabled = tabControl.SelectedIndex == 6;

        }

        private void timerOefening3_Tick(object sender, EventArgs e)
        {
            try
            {
                if (serialPortArduino.IsOpen)
                {
                    serialPortArduino.ReadExisting();
                    string commando = "get d5";
                    serialPortArduino.WriteLine(commando);
                    string antwoord = serialPortArduino.ReadLine();
                    antwoord = antwoord.TrimEnd();
                    antwoord = antwoord.Substring(4);
                    radioButtonDigital5.Checked = (antwoord == "1");

                    commando = "get d6";
                    serialPortArduino.WriteLine(commando);
                    antwoord = serialPortArduino.ReadLine();
                    antwoord = antwoord.TrimEnd();
                    antwoord = antwoord.Substring(4);
                    radioButtonDigital6.Checked = (antwoord == "1");

                    commando = "get d7";
                    serialPortArduino.WriteLine(commando);
                    antwoord = serialPortArduino.ReadLine();
                    antwoord = antwoord.TrimEnd();
                    antwoord = antwoord.Substring(4);
                    radioButtonDigital7.Checked = (antwoord == "1");
                }
            }
            catch (Exception exception)
            {
                labelStatus.Text = "Error: " + exception.Message;
                serialPortArduino.Close();
                radioButtonVerbonden.Checked = false;
                buttonConnect.Text = "Connect";
            }
        }

        private void timerOefening4_Tick(object sender, EventArgs e)
        {
            try
            {
                if (serialPortArduino.IsOpen)
                {
                    serialPortArduino.ReadExisting();
                    string commando = "get a0";
                    serialPortArduino.WriteLine(commando);

                    string antwoord = serialPortArduino.ReadLine();
                    antwoord = antwoord.TrimEnd();
                    antwoord = antwoord.Substring(4);
                    labelAnalog0.Text = antwoord;
                }
            }
            catch (Exception exception)
            {
                labelStatus.Text = "Error: " + exception.Message;
                serialPortArduino.Close();
                radioButtonVerbonden.Checked = false;
                buttonConnect.Text = "Connect";
            }
        }

        private void timerOefening5_Tick(object sender, EventArgs e)
        {
            try
            {
                if (serialPortArduino.IsOpen)
                {
                    serialPortArduino.ReadExisting();
                    string commando = "get a0";
                    serialPortArduino.WriteLine(commando);

                    string antwoord = serialPortArduino.ReadLine();
                    antwoord = antwoord.TrimEnd();
                    antwoord = antwoord.Substring(4);

                    //Herschaal: 0-1023 naar 5-45 °C
                    int rawValueGewenst = int.Parse(antwoord);

                    // Bereken de richtingscoëfficient en offset
                    double richtingscoefficientGewenst = (45.0 - 5.0) / 1023.0;
                    double offsetGewenst = 5.0;

                    //Gebruik de richtingscoëfficient en offset om de uitgelezen waarde te herschalen
                    double temperatuurGewenst = (rawValueGewenst * richtingscoefficientGewenst) + offsetGewenst;
                    temperatuurGewenst = Math.Round(temperatuurGewenst, 1);

                    //Toont altijd 1 cijfer na da comma in labelGewensteTemp
                    labelGewensteTemp.Text = temperatuurGewenst.ToString("F1") + " °C";

                    serialPortArduino.ReadExisting();
                    commando = "get a1";
                    serialPortArduino.WriteLine(commando);
                    antwoord = serialPortArduino.ReadLine();
                    antwoord = antwoord.TrimEnd();
                    antwoord = antwoord.Substring(4);

                    //Herschaal 0-1023 nara 0-500°C
                    int rawValueHuidig = int.Parse(antwoord);

                    //Bereken de richtingscoëfficient en offset
                    double richtingscoefficientHuidig = 500.0 / 1023.0;
                    double offsetHuidig = 0.0;

                    //Gebruik de richtingscoëfficient en offset om de uitgelezen waarde te herschalen
                    double temperatuurHuidig = (rawValueHuidig * richtingscoefficientHuidig) + offsetHuidig;

                    temperatuurHuidig = Math.Round(temperatuurHuidig, 1);
                    labelHuidigeTemp.Text = temperatuurHuidig.ToString("F1") + " °C";

                    //Vergelijk de huidige en gewenste temperatuur
                    if (temperatuurHuidig < temperatuurGewenst)
                    {
                        // Huidige temperatuur lager dan gewenste temperatuur LED AAN adners...
                        serialPortArduino.WriteLine("set d2 1");
                    }
                    else
                    {
                        serialPortArduino.WriteLine("set d2 0");
                    }
                }
            }
            catch (Exception exception)
            {
                labelStatus.Text = "Error: " + exception.Message;
                serialPortArduino.Close();
                radioButtonVerbonden.Checked = false;
                buttonConnect.Text = "Connect";
            }
        }

        private enum AlarmStatus
        {
            OK,
            ALARM,
            BEVESTIGD
        }

        private AlarmStatus huidigeStatus = AlarmStatus.OK;
        private bool knopIngedrukt = false;

        private void timerOefening6_Tick(object sender, EventArgs e)
        {
            try
            {
                if (serialPortArduino.IsOpen)
                {
                    // Altijd D2 aanzetten (originele LED)
                    serialPortArduino.WriteLine("set d2 1");

                    // Lees potentiometer uit voor alarmwaarde
                    try
                    {
                        serialPortArduino.ReadExisting();
                        string commando = "get a0";
                        serialPortArduino.WriteLine(commando);

                        string antwoord = serialPortArduino.ReadLine();
                        antwoord = antwoord.TrimEnd();
                        antwoord = antwoord.Substring(4);

                        //Herschaal: 0-1023 naar -10 tot +60°C
                        int rawValueAlarm = int.Parse(antwoord);

                        // Bereken de richtingscoëfficient en offset
                        double richtingscoefficientAlarm = (60.0 - (-10.0)) / 1023.0;
                        double offsetAlarm = -10.0;

                        //Gebruik de richtingscoëfficient en offset om de uitgelezen waarde te herschalen
                        double temperatuurAlarm = (rawValueAlarm * richtingscoefficientAlarm) + offsetAlarm;
                        temperatuurAlarm = Math.Round(temperatuurAlarm, 1);

                        //Toont altijd 1 cijfer na de komma
                        if (labelDifAlarmTemperatuur != null)
                        {
                            labelDifAlarmTemperatuur.Text = temperatuurAlarm.ToString("F1") + " °C";
                            // Zorg ervoor dat de UI wordt bijgewerkt
                            labelDifAlarmTemperatuur.Refresh();
                        }

                        serialPortArduino.ReadExisting();
                        commando = "get a1";
                        serialPortArduino.WriteLine(commando);
                        antwoord = serialPortArduino.ReadLine();
                        antwoord = antwoord.TrimEnd();
                        antwoord = antwoord.Substring(4);

                        //Herschaal 0-1023 naar 0-500°C
                        int rawValueHuidig = int.Parse(antwoord);

                        //Bereken de richtingscoëfficient en offset
                        double richtingscoefficientHuidig = 500.0 / 1023.0;
                        double offsetHuidig = 0.0;

                        //Gebruik de richtingscoëfficient en offset om de uitgelezen waarde te herschalen
                        double temperatuurHuidig = (rawValueHuidig * richtingscoefficientHuidig) + offsetHuidig;

                        temperatuurHuidig = Math.Round(temperatuurHuidig, 1);
                        if (labelDifHuidigeTemperatuur != null)
                        {
                            labelDifHuidigeTemperatuur.Text = temperatuurHuidig.ToString("F1") + " °C";
                            // Zorg ervoor dat de UI wordt bijgewerkt
                            labelDifHuidigeTemperatuur.Refresh();
                        }

                        // Lees de status van de drukknop
                        serialPortArduino.ReadExisting();
                        commando = "get d3"; // Verondersteld dat de drukknop op digitale pin 3 is aangesloten
                        serialPortArduino.WriteLine(commando);
                        antwoord = serialPortArduino.ReadLine();
                        antwoord = antwoord.TrimEnd();

                        bool isKnopIngedrukt = antwoord.EndsWith("1");
                        bool knopWerdIngedrukt = !knopIngedrukt && isKnopIngedrukt;
                        knopIngedrukt = isKnopIngedrukt;

                        // Bepaal overgangen tussen toestanden
                        switch (huidigeStatus)
                        {
                            case AlarmStatus.OK:
                                if (temperatuurHuidig > temperatuurAlarm)
                                {
                                    huidigeStatus = AlarmStatus.ALARM;
                                }
                                break;

                            case AlarmStatus.ALARM:
                                if (knopWerdIngedrukt)
                                {
                                    if (temperatuurHuidig <= temperatuurAlarm)
                                    {
                                        huidigeStatus = AlarmStatus.OK;
                                    }
                                    else
                                    {
                                        huidigeStatus = AlarmStatus.BEVESTIGD;
                                    }
                                }
                                break;

                            case AlarmStatus.BEVESTIGD:
                                if (temperatuurHuidig <= temperatuurAlarm)
                                {
                                    huidigeStatus = AlarmStatus.OK;
                                }
                                break;
                        }

                        // Zorg dat labelDifStatus altijd bestaat
                        if (labelDifStatus != null)
                        {
                            // Zet uitgangen volgens de huidige status
                            switch (huidigeStatus)
                            {
                                case AlarmStatus.OK:
                                    serialPortArduino.WriteLine("set d5 0"); // Tweede LED uit
                                    labelDifStatus.Text = "OK";
                                    break;

                                case AlarmStatus.ALARM:
                                    serialPortArduino.WriteLine("set d5 1"); // Tweede LED aan
                                    labelDifStatus.Text = "ALARM";
                                    break;

                                case AlarmStatus.BEVESTIGD:
                                    serialPortArduino.WriteLine("set d5 1"); // Tweede LED aan
                                    labelDifStatus.Text = "BEVESTIGD";
                                    break;
                            }

                            // Forceer UI refresh om zeker te zijn dat de tekst getoond wordt
                            labelDifStatus.Refresh();
                        }
                    }
                    catch (FormatException)
                    {
                        // Alleen het binnenste try-catch blok faalt, de verbinding blijft intact
                        // Stilzwijgend deze fout overslaan
                    }
                    catch (IndexOutOfRangeException)
                    {
                        // Stilzwijgend deze fout overslaan
                    }
                }
            }
            catch (Exception exception)
            {
                if (labelDifStatus != null)
                {
                    labelDifStatus.Text = "Error: " + exception.Message;
                    labelDifStatus.Refresh();
                }
                serialPortArduino.Close();
                radioButtonVerbonden.Checked = false;
                buttonConnect.Text = "Connect";
            }
        }
    }
}
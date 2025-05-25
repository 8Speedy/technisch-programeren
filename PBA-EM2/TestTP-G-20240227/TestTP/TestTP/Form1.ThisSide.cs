


using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestTP.Exercises;
using TestTP.Properties;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace TestTP
{
    [System.ComponentModel.DesignerCategory("")]
    public class Dummy { }

    partial class Form1
    {


        ThisSide thisSide = new ThisSide()
        {
            mqttBroker = new Uri(Resources.mqttBroker),
            mqttBaseTopic = Resources.mqttTopic + "/" + Resources.testId,
            testid = UInt32.Parse(Resources.testId)
        };

        Timer tmrConnect = new Timer();
        List<ExerciseControl> exercises = new List<ExerciseControl>();

        private void InitializeThisSide()
        {
            try
            {
                thisSide.ipAddress = new WebClient().DownloadString("http://icanhazip.com").Trim();
            }
            catch (Exception)
            {
                thisSide.ipAddress = "0.0.0.0";
            }

            try
            {
                //connect to mqtt server
                thisSide.mqttClient = new MqttClient(thisSide.mqttBroker.Host, thisSide.mqttBroker.Port, thisSide.mqttBroker.Scheme.Equals("mqtts"), null, null, MqttSslProtocols.TLSv1_2);
                thisSide.mqttClient.Connect(Guid.NewGuid().ToString(), "hogent", "elm2023");
                thisSide.mqttSubTopic = thisSide.mqttBaseTopic;
                thisSide.mqttClient.Subscribe(new string[] { thisSide.mqttSubTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
                thisSide.mqttClient.MqttMsgPublishReceived += mqttMessageReceived;

                cbxStudenten.Items.AddRange(new Student[] { new Student { id = 0, lastname = "DOE", firstname = "John" } });
                cbxStudenten.SelectedIndex = cbxStudenten.Items.Count - 1;

                this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onThisSideClosing);

                cbxStudenten.SelectedIndexChanged += onStudentChanged;
                nudCode.ValueChanged += onStudentChanged;
                pbxServer.Click += onStudentChanged;
                tmrConnect.Tick += onCheckServerTimer;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error initializing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void onCheckServerTimer(object sender, EventArgs e)
        {
            tmrConnect.Enabled = false;
            pbxServer.Image = Resources.close;
        }

        private void onStudentChanged(object sender, EventArgs e)
        {
            removeExercises();

            tmrConnect.Enabled = true;
            tmrConnect.Interval = 5000;
            pbxServer.Image = Resources.help;

            thisSide.mqttClient.Unsubscribe(new string[] { thisSide.mqttSubTopic });
            thisSide.studentid = ((Student) cbxStudenten.SelectedItem).id;
            thisSide.code = (uint) nudCode.Value;
            thisSide.mqttSubTopic = String.Format("{0}/{1}.{2}/TheOtherSide", thisSide.mqttBaseTopic, thisSide.studentid, thisSide.code);
            thisSide.mqttPubTopic = String.Format("{0}/{1}.{2}/ThisSide", thisSide.mqttBaseTopic, thisSide.studentid, thisSide.code);
            thisSide.mqttClient.Subscribe(new string[] { thisSide.mqttSubTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

            MqttMessage message = new MqttMessage(thisSide.studentid, thisSide.code, thisSide.testid, thisSide.ipAddress);
            message.type = 2;

            thisSide.mqttClient.Publish(thisSide.mqttPubTopic, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message)), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
        }

        private void onThisSideClosing(object sender, EventArgs e)
        {
            if (thisSide.mqttClient.IsConnected) thisSide.mqttClient.Disconnect();
        }

        private void mqttMessageReceived(object sender, MqttMsgPublishEventArgs args)
        {
            JArray list;
            JObject data;
            String txtMsg = System.Text.Encoding.UTF8.GetString(args.Message);
            MqttMessage message = JsonConvert.DeserializeObject<MqttMessage>(txtMsg);
            ExerciseControl oefening;
            MqttMessage response;
            switch (message.type)
            {
                case 0: //students
                    list = (JArray)message.data;
                    List<Student> students = new List<Student>();
                    foreach (JObject obj in list) students.Add(new Student() { firstname = obj.Value<String>("firstname"), lastname = obj.Value<String>("lastname"), sortname = obj.Value<String>("sortname"), email = obj.Value<String>("email"), id = obj.Value<UInt64>("id") });

                    addStudents(students.ToArray());
                    break;

                case 2: //exercises
                    Settings.Default.code = thisSide.code;
                    Settings.Default.studentid = thisSide.studentid;
                    Settings.Default.Save();

                    removeExercises();

                    list = (JArray)message.data;
                    

                    foreach (JObject obj in list)
                    {
                        switch (exercises.Count)
                        {
                            case 0:
                                oefening = new ThreeInOneOutControl() { Id = obj.Value<uint>("id"), Name = obj.Value<String>("name"), Description = obj.Value<String>("description"), Type = obj.Value<uint>("type"), Data = obj.Value<Object>("data") };
                                ((ThreeInOneOutControl)oefening).calculateThreeInOneOutResult = berekenOefening1;
                                oefening.ThisSide = thisSide;
                                addExercise(oefening);
                                exercises.Add(oefening);
                                break;

                            case 1:
                                oefening = new ThreeInOneOutControl() { Id = obj.Value<uint>("id"), Name = obj.Value<String>("name"), Description = obj.Value<String>("description"), Type = obj.Value<uint>("type"), Data = obj.Value<Object>("data") };
                                ((ThreeInOneOutControl)oefening).calculateThreeInOneOutResult = calculateOefening2;
                                oefening.ThisSide = thisSide;
                                addExercise(oefening);
                                exercises.Add(oefening);
                                break;

                            case 2:
                                oefening = new ThreeInOneOutControl() { Id = obj.Value<uint>("id"), Name = obj.Value<String>("name"), Description = obj.Value<String>("description"), Type = obj.Value<uint>("type"), Data = obj.Value<Object>("data") };
                                ((ThreeInOneOutControl)oefening).calculateThreeInOneOutResult = calculateOefening3;
                                oefening.ThisSide = thisSide;
                                addExercise(oefening);
                                exercises.Add(oefening);
                                break;

                        /*    case 3:
                                oefening = new ThreeInOneOutControl() { Id = obj.Value<uint>("id"), Name = obj.Value<String>("name"), Description = obj.Value<String>("description"), Type = obj.Value<uint>("type"), Data = obj.Value<Object>("data") };
                                ((ThreeInOneOutControl)oefening).calculateThreeInOneOutResult = calculateOefening4;
                                oefening.ThisSide = thisSide;
                                addExercise(oefening);
                                exercises.Add(oefening);
                                break;

                            /*
                            case 0:
                                oefening = new EightInOneOutControl() { Id = obj.Value<uint>("id"), Name = obj.Value<String>("name"), Description = obj.Value<String>("description"), Type = obj.Value<uint>("type"), Data = obj.Value<Object>("data") };
                                ((EightInOneOutControl) oefening).calculateEightInOneOutResult = berekenOefening1;
                                oefening.ThisSide = thisSide;
                                addExercise(oefening);
                                exercises.Add(oefening);
                                break;

                            case 1:
                                oefening = new EightInEightOutControl() { Id = obj.Value<uint>("id"), Name = obj.Value<String>("name"), Description = obj.Value<String>("description"), Type = obj.Value<uint>("type"), Data = obj.Value<Object>("data") };
                                ((EightInEightOutControl)oefening).calculateEightInEightOutResult = berekenOefening2;
                                oefening.ThisSide = thisSide;
                                addExercise(oefening);
                                exercises.Add(oefening);
                                break;

                            case 2:
                                oefening = new OneInEightOutControl() { Id = obj.Value<uint>("id"), Name = obj.Value<String>("name"), Description = obj.Value<String>("description"), Type = obj.Value<uint>("type"), Data = obj.Value<Object>("data") };
                                ((OneInEightOutControl)oefening).calculateOneInEightOutResult = berekenOefening3;
                                oefening.ThisSide = thisSide;
                                addExercise(oefening);
                                exercises.Add(oefening);
                                break;
                            */
                            default:
                                break;
                        }
                    }

                    tmrConnect.Enabled = false;
                    pbxServer.Image = Resources.ok;
                    break;

                case 3:
                    data = (JObject)message.data;
                    JArray vectors = (JArray)data.Value<JArray>("data");
                    JArray answers = new JArray();

                    foreach (JObject obj in vectors)
                    {
                        TestVector vector = new TestVector() { id = obj.Value<int>("id"), exerciseid = data.Value<uint>("exerciseid"), type = data.Value<uint>("type"), data = obj.Value<object>("data") };

                        // find exercise for vector.exerciseid;
                        oefening = exercises.Find(x => x.Id == vector.exerciseid);

                        // calculate
                        //object input = ((JArray)vector.data).ToObject<string[]>();
                        object input = vector.data;
                        if (input is JArray) input = ((JArray)input).ToObject<string[]>();
                        else if (input is JValue) input = ((JValue)input).ToObject<string>();

                        object output = oefening.calculateResult(input);

                        // answer
                        vector.data = output;
                        answers.Add(JObject.FromObject(vector));
                    }

                    response = new MqttMessage(thisSide.studentid, thisSide.code, thisSide.testid, thisSide.ipAddress);
                    response.type = 4;
                    response.data = answers;
                    thisSide.mqttClient.Publish(thisSide.mqttPubTopic, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response)), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);


                    /*
                    TestVector vector = new TestVector() { id = data.Value<int>("id"), exerciseid = data.Value<uint>("exerciseid"), type=data.Value<uint>("type"), data=data.Value<object>("data") };

                    // find exercise for vector.exerciseid;
                    oefening = exercises.Find(x => x.Id == vector.exerciseid);

                    // calculate
                    //object input = ((JArray)vector.data).ToObject<string[]>();
                    object input = vector.data;
                    if (input is JArray) input = ((JArray)input).ToObject<string[]>();
                    else if (input is JValue) input = ((JValue)input).ToObject<string>();

                    object output = oefening.calculateResult(input);

                    // display inputs
                    oefening.displayVector(input, output);

                    // send answer to TheOtherSide
                    vector.data = output;

                    response = new MqttMessage(thisSide.studentid, thisSide.code, thisSide.testid, thisSide.ipAddress);
                    response.type = 3;
                    response.data = vector;
                    string dummy = JsonConvert.SerializeObject(response);
                    thisSide.mqttClient.Publish(thisSide.mqttPubTopic, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response)), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
                    */

                    break;

                case 4:
                    //try
                    //{
                        data = (JObject)message.data;
                        Score score = new Score() { exerciseid = data.Value<uint>("exerciseid"), score = data.Value<float>("score"), logged = data.Value<uint>("logged") != 0, data = data.Value<object>("data") };

                        // find exercise for vector.exerciseid;
                        oefening = exercises.Find(x => x.Id == score.exerciseid);

                        // display score
                        oefening.displayScore(score);
                    //}
                    //catch (Exception) { }
                    break;
            }
        }

        private void addStudents(Student[] students)
        {
            try
            {
                if (this.InvokeRequired) this.Invoke((Action)delegate { addStudents(students); });
                else
                {
                    cbxStudenten.Items.Clear();
                    UInt64 studentid = Settings.Default.studentid;
                    if (studentid != 0) students = students.Where(x => x.id == studentid).ToArray();
                    if (students.Length == 0) students = new Student[] { new Student { id = 0, lastname = "DOE", firstname = "John" } };

                    cbxStudenten.Items.AddRange(students);
                    cbxStudenten.SelectedIndex = cbxStudenten.Items.Count - 1;

                    if (students.Length == 1) nudCode.Value = Settings.Default.code;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error - addStudents()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeExercises()
        {
            exercises.Clear();
            if (this.InvokeRequired) this.Invoke((Action)delegate { removeExercises(); });
            else
            {
                tabControl.SuspendLayout();
                while (tabControl.TabPages.Count > 1) tabControl.TabPages.RemoveAt(1);
                tabControl.ResumeLayout();
            }
        }

        private void addExercise(ExerciseControl exercise)
        {
            if (this.InvokeRequired) this.Invoke((Action) delegate { addExercise(exercise); });
            else
            {
                tabControl.SuspendLayout();
                TabPage page = new TabPage(exercise.Name);
                exercise.Dock = DockStyle.Fill;
                page.Controls.Add(exercise);
                ((ExerciseControl)exercise).displayOpgave();
                tabControl.TabPages.Add(page);
                tabControl.ResumeLayout();
            }
        }

        private double calculateOefening2(int in1, int in2, int in3)    // return int -> double
        {
            return berekenOefening2(in1, in2, in3);
        }

        private double calculateOefening3(int in1, int in2, int in3)    // return int -> double
        {
            return berekenOefening3(in1, in2, in3);
        }
    }
}

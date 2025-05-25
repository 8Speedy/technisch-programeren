using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace TestTP
{
    public class ThisSide
    {
        public Uri mqttBroker;
        public String mqttBaseTopic;
        public String mqttSubTopic;
        public String mqttPubTopic;
        public uint testid;
        public UInt64 studentid;
        public uint code;
        public String ipAddress;
        public MqttClient mqttClient;

        public void RequestTestVector(int id, uint exerciseId, object data)
        {
            MqttMessage request = new MqttMessage(studentid, code, testid, ipAddress);
            request.type = 3;
            request.data = new TestVector { id = id, exerciseid = exerciseId, data = data };
            mqttClient.Publish(mqttPubTopic, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(request)), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
        }
    }
}

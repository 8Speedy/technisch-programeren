using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTP
{
    class MqttMessage
    {
        public uint type { get; set; }
        public UInt64 studentid { get; set; }
        public uint code { get; set; }
        public string ipaddress { get; set; }
        public uint testid { get; set; }
        public object data { get; set; }

        public MqttMessage(UInt64 studentid, uint code, uint testid, string ipaddress)
        {
            this.studentid = studentid;
            this.code = code;
            this.testid = testid;
            this.ipaddress = ipaddress;
        }
    }
}

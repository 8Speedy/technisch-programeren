using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTP

{
    public class Score
    {
        public uint exerciseid { get; set; }
        public float score { get; set; }
        public bool logged { get; set; }
        public object data { get; set; }
    }
}

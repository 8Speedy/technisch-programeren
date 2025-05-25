using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTP
{
    class Student
    {
        public String firstname { get; set; }
        public String lastname { get; set; }
        public String sortname { get; set; }
        public String email { get; set; }
        public UInt64 id { get; set; }

        public override string ToString()
        {
            return String.Format("{0}, {1} ({2})", lastname, firstname, id);
        }
    }
}

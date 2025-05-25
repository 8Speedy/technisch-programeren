using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTP
{
    

    interface Exercise
    {

        uint Id { get; set; }
        string Description { get; set; }
        object Data { set; }
        string Name { get; set; }
        uint Type { get; set; }


    }
}

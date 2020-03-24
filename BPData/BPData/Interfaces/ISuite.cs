using System;
using System.Collections.Generic;
using System.Text;

namespace BPData.Interfaces
{
    interface ISuite
    {
        short ID { get; set; }
        string Name { get; set; }
        string NamePlural { get; set; }

        
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using BPData.Interfaces;

namespace BPData.Models
{
    public class Suite : ISuite
    {
        public short ID { get; set; }
        public string Name { get; set; }
        public string NamePlural { get; set; }

        //default ctr
        public Suite()
        {

        }

        //ctr to set all suite properties
        public Suite(short id, string name, string nameplural)
        {
            ID = id;
            Name = name;
            NamePlural = nameplural;
        }
    }
}

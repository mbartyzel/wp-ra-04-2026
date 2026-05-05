using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Lab1.bnsit.patterns.model
{
    public class Room
    {
        [XmlAttribute]
        public int Number { get; set; }

        public Room() { }
    }
}

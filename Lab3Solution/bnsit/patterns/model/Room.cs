using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Lab3Solution.bnsit.patterns.model
{
    public class Room
    {
        [XmlAttribute]
        public int Number { get; set; }

        public Room() { }

        public Room(int number)
        {
            this.Number = number;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Lab1.bnsit.patterns.model
{
    public class Elevation
    {
        [XmlAttribute]
        public int Number { get; set; }

        [XmlElement]
        public List<Room> Rooms { get; set;}

        public Elevation() {
            this.Rooms = new List<Room>();
        }
    }
}

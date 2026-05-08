using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Lab3Solution.bnsit.patterns.model
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

        public Elevation(int number) : this() 
        {
            this.Number = number;
        }

        public void AddRoom(Room room) {
            Rooms.Add(room);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Lab1.bnsit.patterns.model
{
    public class Building
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string Address { get; set; }

        [XmlElement]
        public List<Elevation> Elevations { get; set; }

        public Building()
        {
            this.Elevations = new List<Elevation>();
        }
    }
}

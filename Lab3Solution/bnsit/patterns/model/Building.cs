using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Lab3Solution.bnsit.patterns.model
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

        public Building(string name, string address) : this()
        {
            this.Name = name;
            this.Address = address;
        }

        public void AddElevation(Elevation elevation)
        {
            Elevations.Add(elevation);
        }

        public Elevation GetElevation(int elevationNo)
        {
            foreach (Elevation elevation in Elevations)
            {
                if (elevation.Number == elevationNo)
                {
                    return elevation;
                }
            }

            return default(Elevation);
        }
    }
}

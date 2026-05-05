using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Lab1.bnsit.patterns.model
{
    [XmlRoot]
    public class ApplicationModel
    {
        [XmlElement]
        public List<Building> Buildings;

        public ApplicationModel()
        {
            this.Buildings = new List<Building>();
        }

        public void AddBuilding(Building building)
        {
            Buildings.Add(building);
        }

        public void Save(String fileName)
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            Stream outputStream = CreateOutputStream(fileName);
            serializer.Serialize(outputStream, this);
            outputStream.Close();
        }

        public void Load(String fileName)
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            Stream inputStream = CreateInputStream(fileName);
            ApplicationModel model = (ApplicationModel) serializer.Deserialize(inputStream);
            Buildings = model.Buildings;

            inputStream.Close();
        }

        private Stream CreateOutputStream(String fileName)
        {
            Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);

            return stream;
        }

        private Stream CreateInputStream(String fileName)
        {
            Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);

            return stream;
        }

    }
}

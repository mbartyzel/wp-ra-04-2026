using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab3Solution.bnsit.patterns.model;

namespace Lab3Solution.bnsit.patterns.logic.report
{
    public abstract class BuildingsReportGenerator
    {
        protected List<Building> buildings = new List<Building>();

        public BuildingsReportGenerator(List<Building> buildings)
        {
            this.buildings = buildings;
        }

        public String Generate()
        {

            String report = "";

            report += FormatHeader();

            foreach (Building building in buildings)
            {
                report += FormatEntry(building.Name + " (" + building.Address + ")", 0);
                foreach (Elevation elevation in building.Elevations)
                {
                    report += FormatEntry("Elevation " + elevation.Number, 1);
                    foreach (Room room in elevation.Rooms)
                    {
                        report += FormatEntry("Room " + room.Number, 2);
                    }
                }
            }

            report += FormatFooter();

            return report;

        }

        public String FormatEntry(String entry, int indentationLevel)
        {
            String indentation = "";

            for (int i = 0; i < indentationLevel; ++i)
            {
                indentation += GetSeparator();
            }

            return (indentation + entry + "\n");
        }

        public abstract String GetSeparator();

        public abstract String FormatHeader();

        public abstract String FormatFooter();
    }
}

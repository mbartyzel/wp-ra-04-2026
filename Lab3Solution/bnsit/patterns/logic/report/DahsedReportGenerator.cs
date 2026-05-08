using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab3Solution.bnsit.patterns.model;

namespace Lab3Solution.bnsit.patterns.logic.report
{
    public class DahsedReportGenerator : BuildingsReportGenerator
    {
        public DahsedReportGenerator(List<Building> buildings) : base(buildings) { }

        public override string GetSeparator()
        {
            return "--";
        }

        public override string FormatHeader()
        {
            String header = "------------------------------------------------------\n";
            header += "                  Building report                     \n";
            header += "------------------------------------------------------\n";
            header += "Total buildings: " + buildings.Count + "\n";
            header += "------------------------------------------------------\n";
            return header;
        }

        public override string FormatFooter()
        {
            String footer = "------------------------------------------------------\n";
            footer += "------------------------------------------------------\n";
            return footer;
        }
    }
}

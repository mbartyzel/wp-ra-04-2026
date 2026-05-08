using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab3Solution.bnsit.patterns.model;

namespace Lab3Solution.bnsit.patterns.logic.report
{
    public class IndentedReportGenerator : BuildingsReportGenerator
    {
        public IndentedReportGenerator(List<Building> buildings) : base(buildings) { }

        public override string GetSeparator()
        {
            return "  ";
        }

        public override string FormatHeader()
        {
            String header = "Building report. (" + buildings.Count + " building/s)\n";
            header += "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n";
            return header;
        }

        public override string FormatFooter()
        {
            String date = DateTime.Now.ToString("dd/MM/yyyy");
            String footer = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n";
            footer += "Generated on: " + date + "\n";
            return footer;
        }
    }
}

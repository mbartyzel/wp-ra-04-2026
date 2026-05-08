using System;
using System.Collections.Generic;
using Lab3Solution.bnsit.patterns.model;

namespace Lab3Solution.bnsit.patterns.logic.report
{
	public class TreeReportGenerator : BuildingsReportGenerator
    {
        public TreeReportGenerator( List<Building> buildings ) : base(buildings)
        {
        }

        public override string GetSeparator()
        {
            return "|-";
        }

        public override string FormatHeader()
        {
            String header = "******************************************************\n";
            header += "                   Building report                    \n";
            header += "******************************************************\n";
            return header;
        }

        public override string FormatFooter()
        {
            String date = DateTime.Now.ToString("dd/MM/yyyy");
            String footer = "****************" + date + "*******************\n";
            return footer;
        }
    }
}

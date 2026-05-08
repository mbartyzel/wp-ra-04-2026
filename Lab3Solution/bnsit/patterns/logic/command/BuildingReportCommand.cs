using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab3Solution.bnsit.patterns.logic.report;
using Lab3Solution.bnsit.patterns.model;

namespace Lab3Solution.bnsit.patterns.logic.command
{
    public class BuildingReportCommand : Command
    {
        private ApplicationModel model;

        public BuildingReportCommand( ApplicationModel model )
        {
            this.model = model;
        }

        public string Name
        {
            get { return "building_report"; }
        }

        public void Execute(string param)
        {
            BuildingsReportGenerator generator = createGenerator(param);

            Console.WriteLine(generator.Generate());
        }

        public void PrintHelp()
        {
            Console.WriteLine("Prints buildings report. (params: reportType={dashed, indented, tree})");
        }

        private BuildingsReportGenerator createGenerator(string reportType)
        {
            switch (reportType)
            {
                case "tree": return new TreeReportGenerator(model.Buildings);
                case "dashed": return new DahsedReportGenerator(model.Buildings);
                case "indented": return new IndentedReportGenerator(model.Buildings);
            }

            return null;
        }
    }
}

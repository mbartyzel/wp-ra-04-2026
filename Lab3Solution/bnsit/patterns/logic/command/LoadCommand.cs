using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab3Solution.bnsit.patterns.model;

namespace Lab3Solution.bnsit.patterns.logic.command
{
    public class LoadCommand : Command
    {
        private ApplicationModel model;

        public string Name
        {
            get { return "load"; }
        }

        public LoadCommand(ApplicationModel model)
        {
            this.model = model;
        }

        public void Execute(string param)
        {
            model.Load(param);
        }

        public void PrintHelp()
        {
            Console.WriteLine("Loads data from file (params: filename)");
        }
    }
}

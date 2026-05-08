using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab3Solution.bnsit.patterns.model;

namespace Lab3Solution.bnsit.patterns.logic.command
{
    public class SaveCommand : Command
    {
        private ApplicationModel model;

        public string Name
        {
            get { return "save"; }
        }

        public SaveCommand(ApplicationModel model)
        {
            this.model = model;
        }
        
        public void Execute(string param)
        {
            model.Save(param);
        }

        public void PrintHelp()
        {
            Console.WriteLine("Saves data to file (params: filename)");
        }
    }
}

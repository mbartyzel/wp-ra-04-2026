using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3Solution.bnsit.patterns.logic.command
{
    public class ExitCommand : Command
    {
        private Application application;

        public ExitCommand( Application application )
        {
            this.application = application;
        }

        public string Name
        {
            get { return "exit"; }
        }

        public void Execute(string param)
        {
            application.Stop();
        }

        public void PrintHelp()
        {
            Console.WriteLine("Exits application");
        }
    }
}

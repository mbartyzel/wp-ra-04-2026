using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3Solution.bnsit.patterns.logic.command
{
    public class HelpCommand : Command
    {
        private Dictionary<string, Command> commands;

        public HelpCommand(Dictionary<string, Command> commands)
        {
            this.commands = commands;
        }
        
        public string Name
        {
            get { return "help"; }
        }

        public void Execute(string param)
        {
            if (param == null)
            {
                foreach (var entry in commands)
                {
                    entry.Value.PrintHelp();
                }
            }
            else
            {
                commands[param].PrintHelp();
            }
        }

        public void PrintHelp()
        {
            Console.WriteLine("Show commands help (params: [commandName])");
        }
    }
}

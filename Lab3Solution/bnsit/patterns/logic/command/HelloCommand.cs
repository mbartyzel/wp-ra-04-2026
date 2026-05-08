using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3Solution.bnsit.patterns.logic.command
{
    public class HelloCommand : Command
    {
        private const String HELLO_MESSAGE = "Welcome to Equipment Evidence System!";

        public string Name
        {
            get { return "hello"; }
        }

        public void Execute(string param)
        {
            Console.WriteLine(HELLO_MESSAGE);
        }

        public void PrintHelp()
        {
            Console.WriteLine("Prints hello message.");
        }
    }
}

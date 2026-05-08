using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3Solution.bnsit.patterns.logic.command
{
    public interface Command
    {
        string Name { get; }
        void Execute(string param);
        void PrintHelp();
    }
}

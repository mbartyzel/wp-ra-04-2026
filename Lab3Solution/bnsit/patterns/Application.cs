using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab3Solution.bnsit.patterns.model;
using Lab3Solution.bnsit.patterns.logic.report;
using Lab3Solution.bnsit.patterns.logic;
using Lab3Solution.bnsit.patterns.logic.command;


namespace Lab3Solution.bnsit.patterns
{
    public class Application
    {
        private const String PROMPT = "ees>";

        private ApplicationModel model = new ApplicationModel();

        private Dictionary<string, Command> commands = new Dictionary<string, Command>();

        private Boolean running = false;

        public void Init()
        {
            RegisterCommand(new HelloCommand());
            RegisterCommand(new SaveCommand(model));
            RegisterCommand(new LoadCommand(model));
            RegisterCommand(new AddBuildingCommand(model));
            RegisterCommand(new BuildingReportCommand(model));
            RegisterCommand(new ExitCommand(this));
            RegisterCommand(new HelpCommand(commands));
        }

        public void Stop()
        {
            running = false;   
        }

        public void Start()
        {
            running = true;

            new HelloCommand().Execute(null);

            while (running)
            {
                Console.Write(PROMPT);
                string userCommand = Console.ReadLine();

                string[] commandAndParam = userCommand.Split( ' ' );
                string commandName = commandAndParam[0];

                bool unknownCommand = (!commands.ContainsKey(commandName));
                if (unknownCommand) {
                    Console.WriteLine("There's no command '" + commandName + "'");
                    continue;
                }

                bool hasParam = (commandAndParam.Length > 1);
                string param = null;
                if (hasParam) {
                    param = commandAndParam[1];
                }

                commands[commandName].Execute(param);
            }
        }

        private void RegisterCommand(Command command)
        {
            commands.Add(command.Name, command);
        }

        static void Main(string[] args)
        {
            Application application = new Application();
            application.Init();
            application.Start();
        }
    }
}

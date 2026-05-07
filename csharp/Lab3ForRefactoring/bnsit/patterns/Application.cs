using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab3ForRefactoring.bnsit.patterns.model;
using Lab3ForRefactoring.bnsit.patterns.logic.report;
using Lab3ForRefactoring.bnsit.patterns.logic;


namespace Lab3ForRefactoring.bnsit.patterns
{
    class Application
    {
        private const String PROMPT = "ees>";
        private const String HELLO_MESSAGE = "Welcome to Equipment Evidence System!";

        private ApplicationModel model = new ApplicationModel();

        private HelpSystemManager helpSystemManager = new HelpSystemManager();

        private Boolean running = false;

        public void Stop()
        {
            running = false;
        }

        public void Start()
        {
            running = true;

            Console.WriteLine(HELLO_MESSAGE);

            while (running)
            {
                Console.Write(PROMPT);
                String command = Console.ReadLine();

                if (command.Equals("hello"))
                {
                    Console.WriteLine(HELLO_MESSAGE);
                }
                else if (command.StartsWith("save"))
                {
                    String fileName = command.Split(' ')[1];
                    model.Save(fileName);
                }
                else if (command.StartsWith("load"))
                {
                    String fileName = command.Split(' ')[1];
                    model.Load(fileName);
                }
                else if (command.Equals("add_building"))
                {
                    addBuilidng();
                }
                else if (command.StartsWith("building_report"))
                {
                    String reportType = command.Split( ' ' )[1];

                    BuildingsReportGenerator generator = createGenerator( reportType );

                    Console.WriteLine( generator.Generate() );
                }
                else if (command.StartsWith("help")) {
                    string[] commandAndParams = command.Split( ' ' );

                    if (commandAndParams.Length == 1)
                    {
                        helpSystemManager.PrintAllHelp();
                    }
                    else
                    {
                        helpSystemManager.PrintHelp( commandAndParams[1] );
                    }
                }
                else if (command.Equals("exit"))
                {
                    Stop();
                }
            }
        }

        private BuildingsReportGenerator createGenerator(string reportType)
        {
            switch (reportType) {
                case "tree": return new TreeReportGenerator( model.Buildings );
                case "dashed": return new DahsedReportGenerator(model.Buildings);
                case "indented": return new IndentedReportGenerator( model.Buildings );
            }

            return null;
        }

        private void addBuilidng() {
            Console.Write("Name: "); ;
            string name = Console.ReadLine(); 
           
            Console.Write( "Address: " );
            string address = Console.ReadLine();

            BuildingBuilder builder = new BuildingBuilder();
            builder.BuildNewBuilding(name, address);

            Console.Write("First elevation No: ");
            int firstElevationNo = int.Parse(Console.ReadLine());

            Console.Write("Last elevation No: ");
            int lastElevationNo = int.Parse(Console.ReadLine());

            builder.AddEvevations(firstElevationNo, lastElevationNo);

            for (int i = firstElevationNo; i <= lastElevationNo; ++i)
            {
                Console.Write("How many room on elevation " + i + "?: ");
                int roomsNumber = int.Parse(Console.ReadLine());

                List<int> roomsNumbers = new List<int>();
                for (int j = 0; j < roomsNumber; ++j )
                {
                    Console.Write("Number of " + j + " room " + " of " + i + " elevation: ");
                    roomsNumbers.Add(int.Parse(Console.ReadLine()));
                }

                builder.AddRooms(i, roomsNumbers);
            }

            model.AddBuilding(builder.FinalBuilding);
        }

        static void Main(string[] args)
        {
            Application application = new Application();
            application.Start();
        }

    }
}

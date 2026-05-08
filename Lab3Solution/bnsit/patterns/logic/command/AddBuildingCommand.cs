using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab3Solution.bnsit.patterns.model;

namespace Lab3Solution.bnsit.patterns.logic.command
{
    public class AddBuildingCommand : Command
    {
        private ApplicationModel model;

        public AddBuildingCommand(ApplicationModel model)
        {
            this.model = model;
        }

        public string Name
        {
            get { return "add_building"; }
        }

        public void Execute(string param)
        {
            Console.Write("Name: "); ;
            string name = Console.ReadLine();

            Console.Write("Address: ");
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
                for (int j = 0; j < roomsNumber; ++j)
                {
                    Console.Write("Number of " + j + " room " + " of " + i + " elevation: ");
                    roomsNumbers.Add(int.Parse(Console.ReadLine()));
                }

                builder.AddRooms(i, roomsNumbers);
            }

            model.AddBuilding(builder.FinalBuilding);
        }

        public void PrintHelp()
        {
            Console.WriteLine("Starts building wizard");
        }
    }
}

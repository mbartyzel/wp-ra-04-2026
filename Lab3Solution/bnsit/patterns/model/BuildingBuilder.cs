using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3Solution.bnsit.patterns.model
{
    class BuildingBuilder
    {
        private Building building;
        internal Building FinalBuilding { get { return building; } }

        internal void BuildNewBuilding(string name, string address) {
            building = new Building(name, address);
        }

        internal void AddEvevations(int first, int last) {
            for (int i = first; i <= last; ++i)
            {
                building.AddElevation(new Elevation(i));
            }
        }

        internal void AddRooms(int elevationNo, List<int> roomNumbers)
        {
            Elevation elevation = building.GetElevation(elevationNo);

            foreach (int roomNo in roomNumbers)
            {
                elevation.AddRoom(new Room(roomNo));
            }
        }
    }
}

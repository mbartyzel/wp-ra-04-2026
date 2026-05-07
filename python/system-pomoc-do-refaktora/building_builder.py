from model import Building, Floor, Room


class BuildingBuilder(object):

    def __init__(self):
        self._building = None

    def build_new_building(self, name, address):
        self._building = Building(name, address)

    def add_floors(self, first_floor_no, last_floor_no):
        for i in range(first_floor_no, last_floor_no + 1):
            self._building.floors.append(Floor(i))

    def add_rooms(self, floor_no, room_numbers):
        for floor in self._building.floors:
            if floor.number == floor_no:
                for room_number in room_numbers:
                    floor.rooms.append(Room(room_number))

    @property
    def final_building(self):
        return self._building

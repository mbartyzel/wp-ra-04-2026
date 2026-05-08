import pickle

class Building(object):
    def __init__(self, name, address):
        self.name = name
        self._address = address
        self.floors = []
        self._first_floor = None
        self._last_floor = None
        self._current_floor = None

# Builder Pattern
#---Odpowiedzialność metod tworzenie i budowanie Budynku-----
    def add_floor(self, floor):
        if isinstance(floor, Floor):
            self.floors.append(floor)
        else:
            raise ValueError

    def add_rooms(self, rooms_no, floor_no):
        for room in rooms_no:
            self.find_floor(floor_no).add_room(Room(int(room)))
        self._current_floor += 1

    def add_floors(self, floors):
        self.first_floor = floors[0]
        self.last_floor = floors[1]
        self._current_floor = self.first_floor
        for floor in range(floors[0], floors[1] + 1):
            self.add_floor(floor)

#----------------------------------------------

    @property
    def address(self):
        return self._address

# Iterator Pattern
#-------Iterują po wewnętrznej strukturze budynku-----------
    def has_next_floor(self):
        return self._current_floor <= self._last_floor

    @property
    def current_floor(self):
        return self._current_floor
#----------------------------------------------


class Floor(object):
    def __init__(self, number):
        self.number = number
        self.rooms = []

    def add_room(self, room):
        if isinstance(room, Room):
            self.rooms.append(room)
        else:
            raise ValueError


class Room(object):
    def __init__(self, number):
        self.number = number


class ApplicationModel(object):
    def __init__(self):
        self.buildings = []

    def save(self, filename):
        with open(filename, 'wb') as file:
            pickle.dump(self.buildings, file)

    def load(self, filename):
        with open(filename, 'rb') as file:
            self.buildings = pickle.load(file)

    def add_building(self, new_building):
        if isinstance(new_building, Building):
            self.buildings.append(new_building)
        else:
            raise ValueError

    @staticmethod
    def new_building_dialog():
        #pobieranie od uzytkowika nazwy i adresu
        name = input("Name: ")
        address = input("Address: ")
        floors_raw = input("Floors: ")

        new_building = Building(name, address)
        new_building.add_floors(floors_raw)
        while new_building.has_next_floor():
            rooms = int(input("Enter number of rooms for floor %s:" % floor_))  # To pytanie jest nieistotne
            rooms_no = input("Enter room numbers for floor %s:" % floor_).split()  # TODO: Walidacja
            new_building.add_rooms(new_building, rooms_no, floor_)

        return new_building


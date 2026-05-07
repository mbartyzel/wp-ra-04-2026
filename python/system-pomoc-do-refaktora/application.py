from model import ApplicationModel
from help_system import HelpSystemManager
from building_builder import BuildingBuilder
from reports import create_generator


class Application(object):
    PROMPT = "ees>"
    HELLO_MESSAGE = "Welcome to Equipment Evidence System."

    def __init__(self):
        self._running = False
        self._model = ApplicationModel()
        self._help_system = HelpSystemManager()

    def stop(self):
        self._running = False

    def run(self):
        self._running = True

        print(self.HELLO_MESSAGE)

        while self._running:
            command = input(self.PROMPT + " ")

            if command == "hello":
                print(self.HELLO_MESSAGE)

            elif command.startswith("save"):
                filename = command.split(" ")[1]
                self._model.save(filename)

            elif command.startswith("load"):
                filename = command.split(" ")[1]
                self._model.load(filename)

            elif command == "add_building":
                self._add_building()

            elif command.startswith("building_report"):
                report_type = command.split(" ")[1]
                generator = create_generator(report_type, self._model.buildings)
                print(generator.generate())

            elif command.startswith("help"):
                parts = command.split(" ")
                if len(parts) == 1:
                    self._help_system.print_all_help()
                else:
                    self._help_system.print_help(parts[1])

            elif command == "exit":
                self.stop()

    def _add_building(self):
        name = input("Name: ")
        address = input("Address: ")

        builder = BuildingBuilder()
        builder.build_new_building(name, address)

        first_floor_no = int(input("First elevation No: "))
        last_floor_no = int(input("Last elevation No: "))

        builder.add_floors(first_floor_no, last_floor_no)

        for i in range(first_floor_no, last_floor_no + 1):
            rooms_number = int(input("How many room on elevation " + str(i) + "?: "))
            room_numbers = []
            for j in range(rooms_number):
                room_no = int(input("Number of " + str(j) + " room of " + str(i) + " elevation: "))
                room_numbers.append(room_no)
            builder.add_rooms(i, room_numbers)

        self._model.add_building(builder.final_building)

class HelpSystemManager(object):

    def print_all_help(self):
        print("hello - Show invitation")
        print("exit - Exits application")
        print("save - Saves data to file")
        print("load - Loads data from file")
        print("add_building - Adds new building")
        print("building_report - Generates building report")
        print("help - Show commands help")

    def print_help(self, command_name):
        if command_name == "hello":
            print("Show invitation")
        elif command_name == "exit":
            print("Exits application")
        elif command_name == "save":
            print("Saves data to file (params: [fileName])")
        elif command_name == "load":
            print("Loads data from file (params: [fileName])")
        elif command_name == "add_building":
            print("Adds new building to the system")
        elif command_name == "building_report":
            print("Generates building report (params: [tree|dashed|indented])")
        elif command_name == "help":
            print("Show commands help (params: [commandName])")
        else:
            print("Unknown command: " + command_name)

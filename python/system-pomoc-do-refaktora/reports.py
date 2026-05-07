class BuildingsReportGenerator(object):

    def __init__(self, buildings):
        self.buildings = buildings

    def generate(self):
        raise NotImplementedError


class TreeReportGenerator(BuildingsReportGenerator):

    def generate(self):
        result = ""
        for building in self.buildings:
            result += "+ " + building.name + " (" + building.address + ")\n"
            for floor in building.floors:
                result += "  + Floor " + str(floor.number) + "\n"
                for room in floor.rooms:
                    result += "    + Room " + str(room.number) + "\n"
        return result


class DashedReportGenerator(BuildingsReportGenerator):

    def generate(self):
        result = ""
        for building in self.buildings:
            result += "--- " + building.name + " (" + building.address + ") ---\n"
            for floor in building.floors:
                result += "--- Floor " + str(floor.number) + " ---\n"
                for room in floor.rooms:
                    result += "--- Room " + str(room.number) + " ---\n"
        return result


class IndentedReportGenerator(BuildingsReportGenerator):

    def generate(self):
        result = ""
        for building in self.buildings:
            result += building.name + " (" + building.address + ")\n"
            for floor in building.floors:
                result += "    Floor " + str(floor.number) + "\n"
                for room in floor.rooms:
                    result += "        Room " + str(room.number) + "\n"
        return result


def create_generator(report_type, buildings):
    if report_type == "tree":
        return TreeReportGenerator(buildings)
    elif report_type == "dashed":
        return DashedReportGenerator(buildings)
    elif report_type == "indented":
        return IndentedReportGenerator(buildings)
    return None

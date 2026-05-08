from utils import println_
from commands import *
from model import ApplicationModel

class Stopable(ABC):
    @abstractmethod
    def stop(self):
        pass

class Application(Stopable):
    HELLO_MESSAGE = "Welcome to Equipment Evidence System."

    def __init__(self):
        self._running = False
        self._commands = dict()
        model = ApplicationModel()
        self._commands["save"] = SaveCommand(model)
        self._commands["load"] = LoadCommand(model)
        self._commands["exit"] = ExitCommand(self)
        self._commands["help"] = HelpCommand(self._commands)

    def stop(self):
        self._running = False

    def run(self):
        self._running = True

        println_(self.HELLO_MESSAGE)

        while self._running is True:
            command = input("ess > ")
            param = command.split(sep=" ")[1].strip()

            self._command_factory.create(command).execute(param)

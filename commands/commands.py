from abc import ABC, abstractmethod


class Command(ABC):
	def name(self):
		return self.__class__.__name__

	@abstractmethod
	def manual(self):
		pass

	@abstractmethod
	def execute(self, param):
		pass


class SaveCommand(Command):
	def __init__(self, app_model):
		self._model = app_model

	def execute(self, param):
		self._model.save(param)

	def manual(self):
		return "Save command"


class LoadCommand(Command):
	def __init__(self, app_model):
		self._model = app_model

	def execute(self, param):
		self._model.load(param)

	def manual(self):
		return "Load command"


class ExitCommand(Command):
	def __init__(self, stopable):
		self._stopable = stoppable

	def execute(self, param):
		self._stopable.stop()

	def manual(self):
		return "Exit command"


class HelpCommand(Command):
	def __init__(self, commands):
		self._commands = commands

	def execute(self, param):
		if param is None:
			for c in self._commands:
				print(c.manual())
		else:
			print(self._commands[param].manual())

	def manual(self):
		return "Help command"


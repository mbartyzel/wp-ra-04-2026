
from utils import print_, println_, readline_
from model import ApplicationModel

class Application(object):
	HELLO_MESSAGE = "Welcome to Equipment Evidence System."

	def __init__(self):
		self._running = False
		self.model = ApplicationModel() 

	def stop(self):
		self._running = False	

	def run(self):
		self._running = True

		println_(self.HELLO_MESSAGE)

		while self._running is True :
			command = input("ess > ")

			if command == "hello" :
				println_(self.HELLO_MESSAGE)

			elif command.startswith("save") :
				filename = command.split(sep = " ")[1].strip();
				self.model.save(filename)
				
			elif command.startswith("load") :
				filename = command.split(sep = " ")[1].strip();
				self.model.load(filename)

			elif command == "exit" :
				self.stop() 
				



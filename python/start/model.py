import marshal

class Building(object):
	def __init__(self, name, adress):
		self.name = name
		self.address = address
		self.floors = []

class Floor(object):
	def __init__(self, number):
		self.number = number
		self.rooms = []

class Room(object):
	def __init__(self, number):
		self.number = number

class ApplicationModel(object):
	def __init__(self):
		self.buildings = []

	def save(self, filename):
		with open(filename, 'wb') as file:
			marshal.dump(self.buildings, file)

	def load(self, filename):
		with open(filename, 'rb') as file:
			self.buildings = marshal.load(file)

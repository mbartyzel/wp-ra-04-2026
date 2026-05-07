from sys import stdin

def print_(*args):
	for a in args:
		print(a, end = "", flush = True)

def println_(*args):
	print_(args)
	print()

def readline_():
	return stdin.readline().strip()
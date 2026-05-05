using System;
using Lab1.bnsit.patterns.model;

namespace Lab1.bnsit.patterns
{
	class Application
	{
		private const String PROMPT = "ees>";
		private const String HELLO_MESSAGE = "Welcome to Equipment Evidence System!";

		private ApplicationModel model = new ApplicationModel();


		private Boolean running = false;

		public void Stop()
		{
			running = false;
		}

		public void Start()
		{
			running = true;

			System.Console.WriteLine(HELLO_MESSAGE);

			while (running)
			{
				System.Console.Write(PROMPT);
				String command = System.Console.ReadLine();

				if (command.Equals("hello"))
				{
					System.Console.WriteLine(HELLO_MESSAGE);
				}
				else if (command.StartsWith("save"))
				{
					String fileName = command.Split(' ')[1];
					model.Save(fileName);
				}
				else if (command.StartsWith("load"))
				{
					String fileName = command.Split(' ')[1];
					model.Load(fileName);
				}
				else if (command.Equals("exit"))
				{
					Stop();
				}
			}
		}

		static void Main(string[] args)
		{
			Application application = new Application();
			application.Start();
		}

	}
}

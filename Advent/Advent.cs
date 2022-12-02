using Advent.Day01;
using Advent.Day02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent
{
	public static class Advent
	{
		public static void Main(string[] args)
		{
			IList<IAdventTask> tasks = InitializeAllTasks();
			foreach (IAdventTask task in tasks)
			{
				Console.WriteLine($"Task: {task.TaskName}");
				task.Run();
				Console.WriteLine("********************************");
			}
		}

		private static IList<IAdventTask> InitializeAllTasks()
		{
			IList<IAdventTask> tasks = new List<IAdventTask>();
			var type = typeof(IAdventTask);
			var types = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes())
				.Where(p => type.IsAssignableFrom(p));

			foreach (var type1 in types)
			{
				if (type1.IsInterface)
					continue;
				var instance =Activator.CreateInstance(type1);
				if (instance == null)
					continue;
				var task = (IAdventTask)instance;
				if (task == null)
					continue;

				tasks.Add(task);
			}
			return tasks;
		}
	}
}

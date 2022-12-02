namespace Advent.Day01
{
	public class CalorieCounting : IAdventTask
	{
		string IAdventTask.TaskName => typeof(CalorieCounting).Name;
		public void Run()
		{
			IList<Elf> elves = new List<Elf>();
			var currentElf = new Elf(0);
			var totalElves = 1;
			foreach (string line in File.ReadLines("D:\\Projects\\Advent\\Advent\\Day01\\input.txt"))
			{
				if (string.IsNullOrEmpty(line))
				{
					currentElf = ProcessNewElf(currentElf);
					continue;
				}
				ProcessCalories(line, currentElf);

			}
			ProcessNewElf(currentElf);

			//Part 1
			var bestElf = FindBestElf();
			var bestThreeElves = FindBestThreeElves();

			Console.WriteLine($"Best elf: {bestElf.GetPosition()} Calories: {bestElf.GetCalories()}");
			Console.WriteLine($"Best three elves: {string.Join(", ", bestThreeElves.Select(x => x.GetPosition()))} " +
				$"TotalCalories: {bestThreeElves.Select(x => x.GetCalories()).Sum()}");
			IList<Elf> FindBestThreeElves()
			{
				var bestThreeElves = new List<Elf>();
				foreach (Elf elf in elves)
				{
					if (bestThreeElves.Count < 3)
					{
						bestThreeElves.Add(elf);
						continue;
					}
					ReplaceElfIfNeeded(elf);

				}
				return bestThreeElves;

				void ReplaceElfIfNeeded(Elf elf)
				{
					Elf weakestElf = bestThreeElves.Aggregate((curMin, x) => x.GetCalories() < curMin.GetCalories() ? x : curMin);
					if (weakestElf.GetCalories() <= elf.GetCalories())
					{
						bestThreeElves.Remove(weakestElf);
						bestThreeElves.Add(elf);
					}
				}

			}
			Elf FindBestElf()
			{
				int best = 0;
				foreach (Elf elf in elves)
				{
					if (elf.GetCalories() >= elves[best].GetCalories())
						best = elf.GetPosition();
				}
				return elves[best];
			}

			Elf ProcessNewElf(Elf currentElf)
			{
				elves.Add(currentElf);
				var newElf = new Elf(totalElves);
				totalElves++;
				return newElf;
			}
			void ProcessCalories(string line, Elf elf)
			{
				long calories = Convert.ToInt64(line);
				elf.AddCalories(calories);
			}
		}
	}

	public class Elf
	{
		public Elf(int position)
		{
			this.position = position;
			this.total = 0;
		}
		private long total;
		private int position;
		public void AddCalories(long total) => this.total += total;
		public long GetCalories() => total;
		public int GetPosition() => position;
	}
}
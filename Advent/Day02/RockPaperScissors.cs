using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.Day02
{
	public class RockPaperScissors : IAdventTask
	{
		string IAdventTask.TaskName => typeof(RockPaperScissors).Name;
		public void Run()
		{
			int totalPart1 = 0;
			int totalPart2 = 0;
			foreach (string line in File.ReadLines("D:\\Projects\\Advent\\Advent\\Day02\\input.txt"))
			{
				var splitted = line.Split(" ");
				var enemyChoice = splitted.First();
				var myChoice = splitted.Last();
				totalPart1 += SettlePart1(enemyChoice, myChoice);
				totalPart2 += SettlePart2(enemyChoice, myChoice);
			}
			Console.WriteLine($"Total points part1 gained: {totalPart1}");
			Console.WriteLine($"Total points part2 gained: {totalPart2}");

			int SettlePart2(string enemyChoice, string myChoice)
			{
				int roundPoints =
					myChoice == "X" ? 0 :
					myChoice == "Y" ? 3 :
					myChoice == "Z" ? 6 : 0;
				if (enemyChoice == "A")
				{
					if (myChoice == "X")
						roundPoints += 3;
					if (myChoice == "Y")
						roundPoints += 1;
					if (myChoice == "Z")
						roundPoints += 2;
				}

				if (enemyChoice == "B")
				{
					if (myChoice == "X")
						roundPoints += 1;
					if (myChoice == "Y")
						roundPoints += 2;
					if (myChoice == "Z")
						roundPoints += 3;
				}
				if (enemyChoice == "C")
				{
					if (myChoice == "X")
						roundPoints += 2;
					if (myChoice == "Y")
						roundPoints += 3;
					if (myChoice == "Z")
						roundPoints += 1;
				}

				return roundPoints;
			}
			int SettlePart1(string enemyChoice, string myChoice)
			{
				int roundPoints =
					myChoice == "X" ? 1 :
					myChoice == "Y" ? 2 :
					myChoice == "Z" ? 3 : 0;
				if(enemyChoice == "A")
				{
					if (myChoice == "X")
						roundPoints += 3;
					if (myChoice == "Y")
						roundPoints += 6;
					if (myChoice == "Z")
						roundPoints += 0;
				}

				if(enemyChoice == "B")
				{
					if (myChoice == "X")
						roundPoints += 0;
					if (myChoice == "Y")
						roundPoints += 3;
					if (myChoice == "Z")
						roundPoints += 6;
				}
				if(enemyChoice == "C")
				{
					if (myChoice == "X")
						roundPoints += 6;
					if (myChoice == "Y")
						roundPoints += 0;
					if (myChoice == "Z")
						roundPoints += 3;
				}

				return roundPoints;
			}
		}

		
	}
}

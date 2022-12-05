using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.Day03
{
	public class RucksackReorganization : IAdventTask
	{
		public string TaskName => typeof(RucksackReorganization).Name;

		public void Run()
		{
			var total = 0;

			foreach (string line in File.ReadLines("D:\\Projects\\Advent\\Advent\\Day03\\input.txt"))
			{
				var firstItem = line.Substring(0, (int)(line.Length / 2));
				var secondItem = line.Substring((int)(line.Length / 2), (int)(line.Length / 2));
				if (secondItem.Length != firstItem.Length)
					throw new Exception($"Length of first item and second item are not equals - {line}");

				var firstItemDist = firstItem.Distinct();
				var secondItemDist = secondItem.Distinct();
				foreach(var firstItemLetter  in firstItemDist)
				{
					foreach(var secondItemLetter in secondItemDist)
					{
						if (firstItemLetter.Equals(secondItemLetter))
							total += AddToTotal(firstItemLetter);
					}
				}
			}
			Console.WriteLine($"Sum of priorities is equal to : {total}");

			int AddToTotal(char letter)
			{
				if (Char.IsUpper(letter))
					return letter - 38;
				if (Char.IsLower(letter))
					return letter - 96;

				throw new Exception($"Illegal letter: {letter}");
			}
		}
	}
}

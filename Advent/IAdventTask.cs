using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent
{
	public interface IAdventTask
	{
		string TaskName { get; }
		void Run();
	}
}

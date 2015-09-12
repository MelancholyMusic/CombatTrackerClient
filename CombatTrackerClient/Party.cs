using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CombatTrackerClient
{
	class Party
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Category { get; set; }
	}
}

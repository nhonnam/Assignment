using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationship
{
	internal class Battery
	{
		public float Capacity { get; set; }
		public Battery(float capacity) => Capacity = capacity;
		public Battery() { }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationship
{
	internal class CellPhone
	{
		public string Brand { get; set; }
		public Battery PhoneBattery = new Battery();
		public CellPhone(string brand) => Brand = brand;
		public void PrintInfo()
		{
			Console.WriteLine($"Brand: {Brand}, Battery capacity: {PhoneBattery.Capacity}");
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
	internal class Item
	{
		public double ShippingWeight { get; set; }
		public string Description { get; set; }
		public double GetPriceForQuantity(int quantity, double price)
		{
			if (quantity < 100) 
				return price;
			else return price * 0.9;
		}
		public float GetWeight()
		{

		}
	}
}

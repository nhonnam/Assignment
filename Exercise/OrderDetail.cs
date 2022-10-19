using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
	internal class OrderDetail
	{
		public int Quantity { get; set; }
		public string TaxStatus { get; set; }
		Item Item;
		public double CalcSubtotal()
		{
			Console.WriteLine("Enter price:");
			double n = double.Parse(Console.ReadLine());
			return Item.GetPriceForQuantity(Quantity, n) * Quantity;
		}
		public double CalcWeight()
		{
			return Quantity * Item.ShippingWeight;
		}
	}
}

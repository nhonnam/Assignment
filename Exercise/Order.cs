using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
	internal class Order
	{
		public DateTime Date { get; set; }
		public string Status { get; set; }
		List<OrderDetail> Details { get; set; }
		public Order()
		{
			Details = new List<OrderDetail>();
		}
		public double CalcTax()
		{
			Console.WriteLine("Enter tax rate:");
			double r = double.Parse(Console.ReadLine());
			return Total() * r;
		}
		private double Total()
		{
			double sum=0;
			foreach (OrderDetail detail in Details)
			{
				sum += Item.CalcSubtotal();
			}
			return sum;
		}
		public double CalcTotal()
		{
			return CalcTax() + Total();
		}
		public double CalcTotalWeight()
		{

		}
	}
}

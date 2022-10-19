using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
	internal class Lecturer : Person, IIdentifiable
	{
		public string Id { get; set; }
		public decimal MonthlySalary { get; set; }
		public SwipeCard swipeCard = new SwipeCard();
		public List<Student> StudentList = new List<Student>();
		public Lecturer(string id, string firstName, string lastName, int age, decimal salary) 
			: base(firstName, lastName, age)
		{
			Id = id;
			MonthlySalary = salary;
		}
		public Lecturer() { }
		public override void ShowInfo()
		{
			Console.WriteLine($"Lecturer: {FirstName} {LastName} is {Age} years old.");
			Console.WriteLine($"ID: {Id}, Monthy salary: {MonthlySalary}");
		}
		public void Swipe() => Console.WriteLine(swipeCard.Scan());
		public void SalaryDecision(bool missonCompleted)
		{
			Mission.IsCompleted = missonCompleted;
			if (Mission.IsCompleted)
				Console.WriteLine($"Congratulations for completing the annual training misson!\n" +
				$"Your salary is {CalculateAnnualSalary((decimal)0.12)}");
			else
				Console.WriteLine("Looks like you have not done well this year.\n" +
				$"Your salary is {CalculateAnnualSalary()}");
		}
		public AnnualMission Mission = new AnnualMission();
		private decimal CalculateAnnualSalary()
		{ return MonthlySalary * 12; }
		private decimal CalculateAnnualSalary(decimal bonus)
		{ return (MonthlySalary + MonthlySalary * bonus) * 12; }
		
	}
}

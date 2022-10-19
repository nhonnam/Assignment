using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
	internal class Student : Person, IIdentifiable
	{
		public string Id { get; set; }
		private float grade;
		public float Grade
		{
			get { return grade; }
			set { if (value < 0 || value > 10)
					throw new ArgumentException("Grade must be between 0 and 10.");
				grade = value; }
		}
		public Student(string id, string firstName, string lastName, int age, float grade) 
		: base(firstName, lastName, age)
		{
			Id = id;
			Grade = grade;
		}
		public override void ShowInfo()
		{
			Console.WriteLine($"Student: {FirstName} {LastName} is {Age} years old.");
			Console.WriteLine($"ID: {Id}, Grade: {Math.Round(Grade,2)}");
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
	internal abstract class Person
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Person() { }
		private int age;
		public int Age
		{
			get { return age; }
			set { if (value < 0)
					throw new ArgumentException("Age cannot be negative.");
				age = value;
			}
		}
		public Person(string firstName, string lastName, int age)
		{
			FirstName = firstName;
			LastName = lastName;
			Age = age;
		}
		public abstract void ShowInfo();
	}
}

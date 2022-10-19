using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var lecturer = new Lecturer("FGW1001", "Jaden", "Smith", 40, (decimal)560.78);
			var student1 = new Student("GCD201381", "Nam", "Nguyen", 19, (float)9.8);
			var student2 = new Student("GCS190930", "Kha", "Doan", 22, (float)7.5);
			lecturer.StudentList.Add(student1);
			lecturer.StudentList.Add(student2);
			lecturer.ShowInfo();
			Console.WriteLine("List of students in charge of the lecturer:");
			foreach (var student in lecturer.StudentList)
				student.ShowInfo();
			Console.Read();
		}
	}
}

//var student1 = new Student("GCD201381", "Nam", "Nguyen", 19, (float)9.8);
//var student2 = new Student("GCS190930", "Kha", "Doan", 22, (float)7.5);
//var classGroup = new ClassGroup("GCD0901");
//classGroup.LecturerInCharge = lecturer;
//classGroup.Students.Add(student1);
//classGroup.Students.Add(student2);
//classGroup.ShowPeople();
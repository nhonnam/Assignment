using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
	internal class ClassGroup
	{
		public string ClassName { get; set; }
		public Lecturer LecturerInCharge { get; set; }
		public List<Student> Students = new List<Student>();
		public ClassGroup(string className) => ClassName = className;
		public void ShowPeople()
		{
			Console.WriteLine($"Class group name: {ClassName}");
			Console.WriteLine("Student list:");
			foreach (var student in Students)
				student.ShowInfo();
		}
	}
}
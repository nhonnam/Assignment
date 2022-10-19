using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2
{
	class BookLoan
	{
		public int BorrowingId { get; set; }
		public Student StudentBorrower = new Student();
		public Book BookOnLoan = new Book();
		public DateTime IssueDate {get; set; }
		public DateTime DueDate { get; set; }
		public DateTime ReturnDate { get; set; }
		public BookLoan() { }
		public BookLoan(Student studentBorrower, Book bookOnLoan)
		{
			StudentBorrower = studentBorrower;
			BookOnLoan = bookOnLoan;
		}
		public void InputIssueDate(Student student)
		{
			//IssueDate = DateTime.Now;
			Console.Write("Enter issue date (dd/MM/yyyy): ");
			string[] dateInput = Console.ReadLine().Split('/');
			IssueDate = new DateTime(int.Parse(dateInput[2]), int.Parse(dateInput[1]), int.Parse(dateInput[0]));
			if (student.BookLoans.Any())
			{
				while (IssueDate < student.BookLoans.Last().ReturnDate)
				{
					Console.Write("Issue date must not conflict with other previous borrowing time.\nPlease enter again: ");
					dateInput = Console.ReadLine().Split('/');
					IssueDate = new DateTime(int.Parse(dateInput[2]), int.Parse(dateInput[1]), int.Parse(dateInput[0]));
				}
			}
			Console.Write("Enter the loan term for the book (in days): ");
			uint duration = uint.Parse(Console.ReadLine());
			DueDate = IssueDate.AddDays(duration);
			Console.WriteLine($"Issue date: {IssueDate.ToString("dd/MM/yyyy")}");
			Console.WriteLine($"Due date: {DueDate.ToString("dd/MM/yyyy")}");
		}
		public void InputReturnDate()
		{
			Console.Write("Enter return date (dd/MM/yyyy): ");
			string[] dateInput = Console.ReadLine().Split('/');
			ReturnDate = new DateTime(int.Parse(dateInput[2]), int.Parse(dateInput[1]), int.Parse(dateInput[0]));
			while (ReturnDate < IssueDate)
			{
				Console.Write("The return date must not be before the issue data.\nPlease enter again: ");
				dateInput = Console.ReadLine().Split('/');
				ReturnDate = new DateTime(int.Parse(dateInput[2]), int.Parse(dateInput[1]), int.Parse(dateInput[0]));
			}
		}
		//public override string ToString()
		//{
		//	return $"Bookloan ID: {BorrowingId}, Issue date: {IssueDate.ToString("dd/MM/yyyy")}," +
		//		$" Due date: {DueDate.ToString("dd/MM/yyyy")}, Return date: NOT YET";
		//}
		public void ShowTimeLine()
		{
			if (ReturnDate == DateTime.MinValue)
				Console.WriteLine($"Borrowing ID: {BorrowingId}, Issue date: {IssueDate.ToString("dd/MM/yyyy")}," +
				$" Due date: {DueDate.ToString("dd/MM/yyyy")}, Return date: NOT YET");
			else
				Console.WriteLine($"Borrowing ID: {BorrowingId}, Issue date: {IssueDate.ToString("dd/MM/yyyy")}," +
				$" Due date: {DueDate.ToString("dd/MM/yyyy")}, Return date: {ReturnDate.ToString("dd/MM/yyyy")}");
		}
	}
}

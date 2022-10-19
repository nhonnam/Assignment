using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2
{
	class Library
	{
		public string LibraryName { get; set; }
		public List<Book> Books = new List<Book>();
		public List<Student> StudentBorrowers = new List<Student>();
		public List<BookLoan> BookLoans = new List<BookLoan>();
		public Library(string libraryName) => LibraryName = libraryName;
		public void Greeting()
		{
			Console.WriteLine("==============================================");
			Console.WriteLine($"WELCOME TO {LibraryName.ToUpper()} LIBRARY!!!");
			Console.WriteLine("==============================================");
		}
		public void ShowMenu()
		{
			Console.WriteLine("1. View current book list.");
			Console.WriteLine("2. Add a new book title.");
			Console.WriteLine("3. Search books by title.");
			Console.WriteLine("4. Update/Delete a book title by ID.");
			Console.WriteLine("5. Lend a book to a student.");
			Console.WriteLine("6. Receive a borrowed book from a student.");
			Console.WriteLine("7. Update information of student borrowers.");
			Console.WriteLine("8. View list of book loans.");
			Console.WriteLine("9. Find the student who borrows books the most often.");
			Console.WriteLine("10. Exit the program.");
			Console.Write("Enter your option: ");
		}
		public void AddBook()
		{
			try
			{
				Book newBook = new Book();
				if (Books.Any())
					newBook.BookId = Books.Last().BookId + 1;
				else newBook.BookId = 1;
				newBook.InputInfo();
				Books.Add(newBook);
				Console.WriteLine("Added successfully!");
				Console.WriteLine("---------------------------");
			}
			catch (FormatException ex)
			{
				Console.WriteLine("Please enter a number.\n" + ex.Message);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error " + ex.Message);
			}
		}
		public void ShowBookList()
		{
			if (Books.Any())
			{
				Console.WriteLine("List of books available:");
				foreach (Book book in Books)
					Console.WriteLine(book.ToString());
			}
			else Console.WriteLine("There are no books available.");
			Console.WriteLine("---------------------------");
		}
		public void ShowBookList(List<Book> books)
		{
			foreach (Book book in books)
				Console.WriteLine(book.ToString());
		}
		public List<Book> SearchBooksByTitle()
		{
			Console.WriteLine("Enter book title to be looked up.");
			string searchKeyWord = Console.ReadLine();
			return Books.Where(b => b.Title.ToLower().Contains(searchKeyWord.ToLower())).ToList();
		}
		private Book FindBookById()
		{
			Console.Write("Enter book ID: ");
			int bookId = int.Parse(Console.ReadLine());
			Book bookInList = Books.FirstOrDefault(b => b.BookId == bookId);
			while (bookId < 0 || bookInList == null || bookInList.Quantity == 0)
			{
				Console.WriteLine("This book does not exist or out of stock, please enter another book ID.");
				bookId = int.Parse(Console.ReadLine());
				bookInList = Books.FirstOrDefault(b => b.BookId == bookId);
			}
			return bookInList;
		}
		private bool IsBookExisted(int idToCheck)
		{
			Book bookInList = Books.FirstOrDefault(b => b.BookId == idToCheck);
			if (bookInList == null)
				return false;
			return true;
		}
		private bool IsStudentExisted(string idToCheck)
		{
			Student studentInList = StudentBorrowers.FirstOrDefault(b => b.StudentId.Equals(idToCheck));
			if (studentInList == null)
				return false;
			return true;
		}
		private void UpdateBook(Book bookToUpdate)
		{
			bookToUpdate.InputInfo();
			Console.WriteLine("Updated successfully!");
			Console.WriteLine("---------------------------");
		}
		private void DeleteBook(Book bookToDelete)
		{
			Books.Remove(bookToDelete);
			Console.WriteLine("Deleted successfully!");
			Console.WriteLine("---------------------------");
		}
		public void UpdateOrDeleteBook()
		{
			ShowBookList();
			Console.Write("Enter a book ID: ");
			int bookId = int.Parse(Console.ReadLine());
			while (!IsBookExisted(bookId))
			{
				Console.WriteLine("This book does not exist, please enter another ID.");
				bookId = int.Parse(Console.ReadLine());
			}
			Book bookInList = Books.FirstOrDefault(b => b.BookId == bookId);
			Console.WriteLine(bookInList.ToString());
			Console.WriteLine("Type 'u' for update, 'd' for delete.");
			string choice = Console.ReadLine();
			while (!choice.Equals("u", StringComparison.InvariantCultureIgnoreCase) 
				&& !choice.Equals("d", StringComparison.InvariantCultureIgnoreCase))
			{
				Console.WriteLine("Invalid command, please enter again.");
				choice = Console.ReadLine();
			}
			if (choice.Equals("u", StringComparison.InvariantCultureIgnoreCase))
				UpdateBook(bookInList);
			else DeleteBook(bookInList);
		}
		public void LendBook()
		{
			if (!Books.Any())
				Console.WriteLine("Currently there are no books to be lent to students.");
			else
			{
				Console.WriteLine("Enter student information.");
				Console.Write("Student ID: ");
				string studentId = Console.ReadLine();
				if (IsStudentExisted(studentId))
				{
					Console.WriteLine("Data about this student is already available:");
					Student studentInList = StudentBorrowers.FirstOrDefault(b => b.StudentId.Equals(studentId));
					Console.WriteLine(studentInList.ToString());
					if (studentInList.BookLoans.Last().ReturnDate == DateTime.MinValue)
					{
						Console.WriteLine($"This student has 1 unreturned book which has to be returned before " +
							$"{studentInList.BookLoans.Last().DueDate.AddDays(1).ToString("dd/MM/yyyy")}.");
						studentInList.BookLoans.Last().BookOnLoan.ShowBookOnLoan();
					}
					else
					{
						try
						{
							Book loanBook = FindBookById();
							Console.WriteLine(loanBook.ToString());
							loanBook.Quantity--;
							BookLoan newBookLoan = new BookLoan(studentInList, loanBook);
							newBookLoan.BorrowingId = BookLoans.Last().BorrowingId + 1;
							newBookLoan.InputIssueDate(studentInList);
							BookLoans.Add(newBookLoan);
							studentInList.BookLoans.Add(newBookLoan);
							Console.WriteLine("The book has been successfully lent.");
							Console.WriteLine("---------------------------");
						}
						catch (FormatException ex)
						{
							Console.WriteLine("Please enter a number.\n" + ex.Message);
						}
						catch (Exception ex)
						{
							Console.WriteLine("Error " + ex.Message);
						}
					}
				}
				else
				{
					Student newStudent = new Student(studentId);
					newStudent.InputInfo();
					try
					{
						StudentBorrowers.Add(newStudent);
						Book loanBook = FindBookById();
						Console.WriteLine(loanBook.ToString());
						loanBook.Quantity--;
						BookLoan newBookLoan = new BookLoan(newStudent, loanBook);
						if (BookLoans.Any())
							newBookLoan.BorrowingId = BookLoans.Last().BorrowingId + 1;
						else newBookLoan.BorrowingId = 1;
						newBookLoan.InputIssueDate(newStudent);
						BookLoans.Add(newBookLoan);
						newStudent.BookLoans.Add(newBookLoan);
						Console.WriteLine("The book has been successfully lent.");
						Console.WriteLine("---------------------------");
					}
					catch (FormatException ex)
					{
						Console.WriteLine("Please enter a number.\n" + ex.Message);
						StudentBorrowers.Remove(newStudent);
					}
					catch (Exception ex)
					{
						Console.WriteLine("Error " + ex.Message);
					}
				}
			}
		}
		public void ReceiveBook()
		{
			Console.WriteLine("Enter student information.");
			Console.Write("Student ID: ");
			string studentId = Console.ReadLine();
			Student studentInList = StudentBorrowers.FirstOrDefault(b => b.StudentId.Equals(studentId));
			while (studentInList == null || studentInList.BookLoans.Last().ReturnDate != DateTime.MinValue)
			{
				Console.Write("This student has returned or not borrowed a book before.\nPlease enter another ID: ");
				studentId = Console.ReadLine();
				studentInList = StudentBorrowers.FirstOrDefault(b => b.StudentId == studentId);
			}
			Console.WriteLine("This student has 1 unreturned book.");
			studentInList.BookLoans.Last().ShowTimeLine();
			//Console.WriteLine(studentInList.BookLoans.Last().ToString());
			Console.WriteLine(studentInList.ToString());
			studentInList.BookLoans.Last().BookOnLoan.ShowBookOnLoan();
			studentInList.BookLoans.Last().InputReturnDate();
			studentInList.BookLoans.Last().BookOnLoan.Quantity++;
			foreach (BookLoan bl in BookLoans)
			{
				if (bl.BorrowingId == studentInList.BookLoans.Last().BorrowingId)
				{
					bl.ReturnDate = studentInList.BookLoans.Last().ReturnDate;
					bl.BookOnLoan.Quantity = studentInList.BookLoans.Last().BookOnLoan.Quantity;
				}
			}
			foreach (Book b in Books)
			{
				if (b.BookId == studentInList.BookLoans.Last().BorrowingId)
					b.Quantity = studentInList.BookLoans.Last().BookOnLoan.Quantity;
			}
			if (studentInList.BookLoans.Last().ReturnDate > studentInList.BookLoans.Last().DueDate)
				Console.WriteLine($"This student has returned the book after the due date " +
					$"({studentInList.BookLoans.Last().DueDate.ToString("dd/MM/yyyy")}).\n" +
					$"The amount of the fine to be paid is 10000VND.");
			else Console.WriteLine("This student has returned the book on time.");
			Console.WriteLine("---------------------------");
		}
		public void UpdateStudent()
		{
			Console.WriteLine("Enter a student ID:");
			string studentId = Console.ReadLine();
			while (!IsStudentExisted(studentId))
			{
				Console.WriteLine("This student does not exist, please enter another ID.");
				studentId = Console.ReadLine();
			}
			Student studentInList = StudentBorrowers.FirstOrDefault(b => b.StudentId.Equals(studentId));
			Console.WriteLine(studentInList.ToString()); 
			studentInList.InputInfo();
			Console.WriteLine("Updated successfully!");
			Console.WriteLine("---------------------------");
		}
		public void ShowBookLoanList()
		{
			if (!BookLoans.Any())
				Console.WriteLine("No one has ever borrowed a book here.");
			else
			{
				Console.WriteLine("Information about books borrowing:");
				foreach (BookLoan bl in BookLoans)
				{
					//if (bl.ReturnDate == DateTime.MinValue)
					//	Console.WriteLine(bl.ToString());
					//else bl.ShowTimeLine();
					bl.ShowTimeLine();
					Console.WriteLine(bl.StudentBorrower.ToString());
					bl.BookOnLoan.ShowBookOnLoan();
					Console.WriteLine("---------------------------");
				}
			}
		}
		public void FindMostFrequentBorrower()
		{
			if (!StudentBorrowers.Any())
				Console.WriteLine("No one has ever borrowed a book here.");
			else
			{
				int maxBookLoans = 1;
				foreach (Student s in StudentBorrowers)
				{
					if (s.BookLoans.Count >= maxBookLoans)
						maxBookLoans = s.BookLoans.Count;
				}
				Console.WriteLine("The student(s) who borrow(s) books the most often is/are:");
				foreach (Student s in StudentBorrowers)
				{
					if (s.BookLoans.Count == maxBookLoans)
						Console.WriteLine(s.ToString());
				}
			}
		}
	}
}

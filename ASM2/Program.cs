using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter library name: ");
			string libName = Console.ReadLine();
			Console.Clear();
			Library univLib = new Library(libName);
			univLib.Greeting();
			Console.ReadKey();
			Console.Clear();
			univLib.ShowMenu();
			string option = Console.ReadLine();
			do
			{
				switch (option)
				{
					case "1":
						univLib.ShowBookList();
						break;
					case "2":
						univLib.AddBook();
						break;
					case "3":
						List<Book> searchedBooks = univLib.SearchBooksByTitle();
						univLib.ShowBookList(searchedBooks);
						break;
					case "4":
						univLib.UpdateOrDeleteBook();
						break;
					case "5":
						univLib.LendBook();
						break;
					case "6":
						univLib.ReceiveBook();
						break;
					case "7":
						univLib.UpdateStudent();
						break;
					case "8":
						univLib.ShowBookLoanList();
						break;
					case "9":
						univLib.FindMostFrequentBorrower();
						break;
					case "10":
						return;
					default:
						Console.WriteLine("Invalid option, please enter again.");
						break;
				}
				Console.WriteLine("Press any key to continue.");
				Console.ReadKey();
				Console.Clear();
				univLib.ShowMenu();
				option = Console.ReadLine();
			}
			while (true);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloGamesInternshipTask1
{
    public static class Program
    {
        static void Main()
        {
            Library library = new Library();

            do
            {
                Console.Clear();
                Console.WriteLine("---------------------------------");
                Console.WriteLine(" 1. Add Book");
                Console.WriteLine(" 2. Show All Books");
                Console.WriteLine(" 3. Search For Books");
                Console.WriteLine(" 4. Borrow a Book");
                Console.WriteLine(" 5. Return Book");
                Console.WriteLine(" 6. Show Overdue Books");
                Console.WriteLine(" 0. Exit");
                Console.WriteLine(" ");
                Console.Write(" Make your choice: ");                
                string choice = Console.ReadLine();
                Console.WriteLine("---------------------------------");
                int borrowIsbn;
                int valueToChangeIsbn;
                int valueToChange;
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("***** Add Book ******");
                        Console.Write(" Book Title: ");
                        string title = Console.ReadLine();
                        Console.Write(" Writer: ");
                        string writer = Console.ReadLine();
                        Console.Write(" ISBN: ");
                        int isbn = int.Parse(Console.ReadLine());
                        Console.Write(" Number of Copies: ");
                        int numberOfCopies = int.Parse(Console.ReadLine());
                        library.AddBook(new Book { Title = title, Writer = writer, ISBN = isbn, NumberOfCopies = numberOfCopies });
                        ShowContentAndBackOption();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("***** Get All Books ******");
                        library.GetAllBooks();
                        ShowContentAndBackOption();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("***** Search For Books ******");
                        Console.Write(" Book Title to Search: ");
                        string searchTitle = Console.ReadLine();
                        library.SearchForBooks(searchTitle);
                        ShowContentAndBackOption();
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("***** Borrow A Book ******");
                        Console.Write(" ISBN of the Book to Borrow: ");
                        string input = Console.ReadLine();
                        if (int.TryParse(input, out borrowIsbn))
                        {
                            library.BorrowABook(borrowIsbn);
                        }
                        else
                        {
                            Console.WriteLine("Error: You must enter a valid number.");
                        }
                        ShowContentAndBackOption();
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine("***** Return Back Book ******");
                        Console.Write(" ISBN of the Book to be Returned: ");
                        string returnIsbn = Console.ReadLine();
                        if (int.TryParse(returnIsbn, out borrowIsbn))
                        {
                            library.ReturnBackBook(borrowIsbn);
                        }
                        else
                        {
                            Console.WriteLine("Error: You must enter a valid number.");
                        }
                        ShowContentAndBackOption();
                        break;

                    case "6":
                        Console.Clear();
                        Console.WriteLine("***** View Overdue Books ******");
                        library.ViewOverdueBooks();
                        ShowContentAndBackOption();
                        break;

                    case "0":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine(" Invalid selection. Please try again.");
                        break;
                }

            } while (true);
        }
        
        private static void ShowContentAndBackOption()
        {
            Console.WriteLine("---------------------------------");
            Console.Write(" Press Enter Return To Menu <<");
            string backChoice = Console.ReadLine();            
        }

    }
}
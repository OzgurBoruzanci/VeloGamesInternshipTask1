using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace VeloGamesInternshipTask1
{
    public class Library
    {
        private List<Book> books;
        SanalDataBase dataBase = new SanalDataBase();

        public Library()
        {
            books = dataBase.GetAllBooks();
        }

        public void AddBook(Book newBook)
        {
            bool checkIsbn = true;
            for (int i = 0; i < books.Count; i++)
            {
                checkIsbn= books[i].ISBN != newBook.ISBN ? true : false;
            }
            if (checkIsbn)
            {
                books.Add(newBook);
                dataBase.UpdateData(books);
                Console.WriteLine(" Book Addition Successful");
            }
            else
            {
                Console.WriteLine(" The Book Already Exists. Try Adding Capacity");
            }
        }

        public void GetAllBooks()
        {
            Console.WriteLine("---------BOOKS--------");
            foreach (var book in books)
            {

                Console.WriteLine($" Title: {book.Title}");
                Console.WriteLine($" Writer: {book.Writer}");
                Console.WriteLine($" ISBN: {book.ISBN}");
                Console.WriteLine($" Number Of Copies: {book.NumberOfCopies}");
                Console.WriteLine($" Borrowed Time: {book.BorrowDate}");
                Console.WriteLine("**************************");
            }
        }

        public void SearchForBooks(string key)
        {
            var booksFound = books.FindAll(k => k.Title.Contains(key) || k.Writer.Contains(key));

            if (booksFound.Count > 0)
            {
                Console.WriteLine("--------Selected Book------");
                foreach (var book in booksFound)
                {
                    Console.WriteLine($" Title: {book.Title}");
                    Console.WriteLine($" Writer: {book.Writer}");
                    Console.WriteLine($" ISBN: {book.ISBN}");
                    Console.WriteLine($" Number Of Copies: {book.NumberOfCopies}");
                    Console.WriteLine($" Borrowed Time: {book.BorrowDate}");
                }
            }
            else
            {
                Console.WriteLine(" The book you were looking for was not found.");
            }
        }

        public void BorrowABook(int isbn)
        {
            var book = books.Find(b => b.ISBN == isbn);

            if (book != null)
            {
                if (book.NumberOfCopies > 0)
                {
                    book.NumberOfCopies--;
                    book.BorrowDate = DateTime.Now;
                    dataBase.UpdateData(books);
                    Console.WriteLine($" {book.Title} The book named was borrowed.");
                }
                else
                {
                    Console.WriteLine(" Not Enough Books.");
                }
            }
            else
            {
                Console.WriteLine(" Book not found.");
            }
        }

        public void ReturnBackBook(int isbn)
        {
            var book = books.Find(b => b.ISBN == isbn);

            if (book != null)
            {
                book.NumberOfCopies++;
                book.BorrowDate = null;
                dataBase.UpdateData(books);
                Console.WriteLine($" {book.Title} The book titled was returned.");
            }
            else
            {
                Console.WriteLine(" Book not found");
            }
        }

        public void ViewOverdueBooks()
        {
            var overdueBooks = books.FindAll(b => b.NumberOfCopies > 0);
            bool borrowedBook = false;
            foreach (var book in overdueBooks)
            {
                DateTime borrowDate = book.BorrowDate ?? DateTime.Now;

                if (DateTime.Now - borrowDate >= TimeSpan.FromDays(14))
                {
                    Console.WriteLine($" The book has expired: {book.Title}");
                    Console.WriteLine($" The book date borrowed: {book.BorrowDate}");
                    borrowedBook = true;
                }
            }
            if(!borrowedBook)
            {
                Console.WriteLine(" No Overdue Books.");
            }
        }
    }
}

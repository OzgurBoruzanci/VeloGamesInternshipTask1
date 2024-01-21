using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloGamesInternshipTask1
{
    public class Book
    {
        public int ISBN { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
        public int NumberOfCopies { get; set; }
        public DateTime? BorrowDate { get; set; }

        public Book()
        {
            BorrowDate = null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Classes
{
    public class Book
    {
        public Book(string bookName, string author, string description ,int year, string genre, int pagesCount) 
        {
            BookName = bookName;
            Author = author;
            Description = description;
            Year = year;
            Genre = genre;
            PagesCount = pagesCount;
        }
        public string BookName {  get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int PagesCount { get; set; }

    }
}
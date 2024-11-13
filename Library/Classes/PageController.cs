using Library.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Classes
{
    public class PageController
    {
        private static BookPage _bookPage { get; set; }
        private static LibraryPage _libraryPage { get; set; }

        public static BookPage BookPage
        {
            get
            {
                if (_bookPage == null)
                {
                    _bookPage = new BookPage();
                }

                return _bookPage;
            }
        }
        public static LibraryPage LibraryPage
        {
            get
            {
                if (_libraryPage == null)
                {
                    _libraryPage = new LibraryPage();
                }

                return _libraryPage;
            }
        }
    }
}

using Library.Classes;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Library.Pages
{
    public partial class BookPage : Page
    {

        public BookPage()
        {
            InitializeComponent();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            string bookName = BookName.Text;
            string author = Author.Text;
            string genre = Genre.Text;

            int year;
            int pagesCount;
            try
            {
                year = int.Parse(Year.Text);
                pagesCount = int.Parse(PagesCount.Text);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (bookName != string.Empty || author != string.Empty || year != 0 ||
                genre != string.Empty || pagesCount > 0)
            {
                LibraryPage.Instance.Books.Add(new Book(bookName, author, year, genre, pagesCount));
                ClearAll();
                NavigationService.GoBack();
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            ClearAll();
            NavigationService.GoBack();
        }

        private void ClearAll()
        {
            BookName.Clear();
            Author.Clear();
            Year.Clear();
            Genre.Clear();
            PagesCount.Clear();
        }

        public void EditBook(string bookName, string author, int year, string genre, int pagesCount)
        {
            BookName.Text = bookName;
            Author.Text = author;
            Year.Text = Convert.ToString(year);
            Genre.Text = genre;
            PagesCount.Text = Convert.ToString(pagesCount);
        }
    }
}

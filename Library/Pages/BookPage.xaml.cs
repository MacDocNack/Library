using Library.Classes;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Library.Pages
{
    public partial class BookPage : Page
    {
        private bool _isEditing = false;
        private int _bookIndex;

        public BookPage()
        {
            InitializeComponent();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            string bookName = BookName.Text.Trim();
            string author = Author.Text.Trim();
            string description = Description.Text.Trim();
            string genre = Genre.Text.Trim();

            int year = int.TryParse(Year.Text.Trim(), out year) ? year : -1;
            int pagesCount = int.TryParse(PagesCount.Text.Trim(), out pagesCount) ? pagesCount : -1; ;

            if (!string.IsNullOrEmpty(bookName) && !string.IsNullOrEmpty(author) && !string.IsNullOrEmpty(description) && 
                year > 0 && !string.IsNullOrEmpty(genre) && pagesCount > 0)
            {
                if (_isEditing)
                {
                    LibraryPage.Instance.Books[_bookIndex] = new Book(bookName, author, description ,year, genre, pagesCount);
                    _isEditing = false;
                    ClearAll();
                    NavigationService.GoBack();
                }
                else
                {
                    LibraryPage.Instance.Books.Add(new Book(bookName, author, description, year, genre, pagesCount));
                    ClearAll();
                    NavigationService.GoBack();
                }
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            _isEditing = false;
            ClearAll();
            NavigationService.GoBack();
        }

        private void ClearAll()
        {
            BookName.Clear();
            Author.Clear();
            Description.Clear();
            Year.Clear();
            Genre.Clear();
            PagesCount.Clear();
        }

        public void EditBook(string bookName, string author, string description ,int year, string genre, int pagesCount, int bookIndex)
        {
            BookName.Text = bookName;
            Author.Text = author;
            Description.Text = description;
            Year.Text = year.ToString();
            Genre.Text = genre;
            PagesCount.Text = pagesCount.ToString();
            _bookIndex = bookIndex;
            _isEditing = true;
        }
    }
}

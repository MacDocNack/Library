using Library.Classes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Library.Pages
{
    public partial class LibraryPage : Page
    {
        public static LibraryPage Instance { get; set; }

        public ObservableCollection<Book> Books = new ObservableCollection<Book>();
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Books)));
        }

        public LibraryPage()
        {
            InitializeComponent();
            Instance = this;
            BookHolder.SetBinding(ListView.ItemsSourceProperty, new Binding()
            {
                Source = Books
            });
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PageController.BookPage);
        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            if (BookHolder.SelectedItem != null)
            {
                string bookName = Books[BookHolder.SelectedIndex].BookName;
                string author = Books[BookHolder.SelectedIndex].Author;
                int year = Books[BookHolder.SelectedIndex].Year;
                string genre = Books[BookHolder.SelectedIndex].Genre;
                int pagesCount = Books[BookHolder.SelectedIndex].PagesCount;
                PageController.BookPage.EditBook(bookName, author, year, genre, pagesCount);
                NavigationService.Navigate(PageController.BookPage);
            }
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            if (BookHolder.SelectedItem != null)
            {
                Books.RemoveAt(BookHolder.SelectedIndex);
            }
        }
    }
}

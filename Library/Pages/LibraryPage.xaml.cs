using Library.Classes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace Library.Pages
{
    public partial class LibraryPage : INotifyPropertyChanged
    {
        public static LibraryPage Instance { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
        }

        private ObservableCollection<Book> _books = new ObservableCollection<Book>();
        public ObservableCollection<Book> Books
        {
            get
            {
                if (_books == null)
                    _books = new ObservableCollection<Book>();
                return _books;
            }
            set
            {
                _books = value;
                OnPropertyChanged(nameof(Books));
            }
        }

        public LibraryPage()
        {
            InitializeComponent();
            Instance = this;
            BookHolder.SetBinding(ListView.ItemsSourceProperty, new Binding()
            {
                Source = _books
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
                string descriprion = Books[BookHolder.SelectedIndex].Description;
                int year = Books[BookHolder.SelectedIndex].Year;
                string genre = Books[BookHolder.SelectedIndex].Genre;
                int pagesCount = Books[BookHolder.SelectedIndex].PagesCount;
                PageController.BookPage.EditBook(bookName, author, descriprion, year, genre, pagesCount, BookHolder.SelectedIndex);
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

        private void BookHolder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BookHolder.SelectedItem == null || BookHolder.SelectedItems.Count > 1) return;

            string bookName = Books[BookHolder.SelectedIndex].BookName;
            string author = Books[BookHolder.SelectedIndex].Author;
            string descriprion = Books[BookHolder.SelectedIndex].Description;
            PageController.BookDescription.ShowDetails(bookName, author, descriprion);
            PageController.BookDescription.Show();
        }
    }
}

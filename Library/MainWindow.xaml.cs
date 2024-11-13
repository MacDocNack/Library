using Library.Classes;
using Library.Pages;
using System.Windows;

namespace Library
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            AppFrame.Navigate(PageController.LibraryPage);
        }
    }
}

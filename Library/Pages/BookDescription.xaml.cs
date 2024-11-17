using Library.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Library.Pages
{
    public partial class BookDescription : Window
    {
        public BookDescription()
        {
            InitializeComponent();
        }

        public void ShowDetails(string bookName, string author, string description)
        {
            BookName.Text = bookName;
            Author.Text = author;
            Description.Text = description;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            BookName.Text = string.Empty;
            Author.Text = string.Empty;
            Description.Text = string.Empty;
            this.Hide();
        }
    }
}

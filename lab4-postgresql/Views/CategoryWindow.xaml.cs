using lab4_postgresql.Models;
using System.Windows;

namespace lab4_postgresql.Views
{
    public partial class CategoryWindow : Window
    {
        public Category Category { get; private set; }
        public CategoryWindow(Category category)
        {
            InitializeComponent();
            Category = category;
            DataContext = Category;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}

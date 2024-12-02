using lab4_postgresql.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Data;

namespace lab4_postgresql.Views
{
    public partial class ProductWindow : Window
    {
        public Product Product { get; private set; }
        public ProductWindow(Product product, StoreDbContext db)
        {
            InitializeComponent();
            Product = product;
            DataContext = Product;

            var categories = db.Categories.ToList();
            var categoriesSource = (CollectionViewSource)FindResource("CategoriesSource");
            categoriesSource.Source = categories;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}

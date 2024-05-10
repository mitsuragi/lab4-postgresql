using lab4_postgresql.Models;
using lab4_postgresql.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace lab4_postgresql.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private StoreDbContext db;
        private Product? selectedProduct;
        public Product? SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Product> products = null!;
        public ObservableCollection<Product> Products
        {
            get => products;
            set
            {
                products = value;
                OnPropertyChanged();
            }
        }

        public ProductViewModel(StoreDbContext db)
        {
            this.db = db;
            Products = db.Products.Local.ToObservableCollection();
            addProductCommand = new RelayCommand(addProductEntity, () => true);
            updateProductCommand = new RelayCommand(updateProductEntity, CanExecute);
            removeProductCommand = new RelayCommand(removeProductEntity, CanExecute);
        }
        public ICommand addProductCommand { get; }
        public ICommand updateProductCommand { get; }
        public ICommand removeProductCommand { get; }
        private async void addProductEntity()
        {
            ProductWindow win = new ProductWindow(new Product());
            if (win.ShowDialog() == true)
            {
                Product product = new Product
                {
                    ProductName = win.Product.ProductName,
                    Price = win.Product.Price,
                    Quantity = win.Product.Quantity,
                    CategoryId = win.Product.CategoryId
                };
                await db.Products.AddAsync(product);
                await db.SaveChangesAsync();
            }
        }

        private async void updateProductEntity()
        {
            Product product = new Product
            {
                ProductId = selectedProduct.ProductId,
                ProductName = selectedProduct.ProductName,
                Price = selectedProduct.Price,
                Quantity = selectedProduct.Quantity,
                CategoryId = selectedProduct.CategoryId
            };

            ProductWindow win = new ProductWindow(product);
            if (win.ShowDialog() == true)
            {
                selectedProduct.ProductName = win.Product.ProductName;
                selectedProduct.Price = win.Product.Price;
                selectedProduct.Quantity = win.Product.Quantity;
                selectedProduct.CategoryId = win.Product.CategoryId;
                db.Entry(selectedProduct).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
        }
        private async void removeProductEntity()
        {
            Product? product = selectedProduct;
            db.Products.Remove(product);
            await db.SaveChangesAsync();
        }
        private bool CanExecute() => selectedProduct != null;
    }
}

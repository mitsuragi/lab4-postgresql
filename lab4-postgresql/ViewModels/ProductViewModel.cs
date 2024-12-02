using lab4_postgresql.Models;
using lab4_postgresql.Views;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
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
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        private ObservableCollection<Product> products = null!;
        public ObservableCollection<Product> Products
        {
            get => products;
            set
            {
                products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public ProductViewModel(StoreDbContext db)
        {
            this.db = db;
            products = db.Products.Local.ToObservableCollection();
            AddProductCommand = new RelayCommand(addProductEntity, () => true);
            UpdateProductCommand = new RelayCommand(updateProductEntity, CanExecute);
            RemoveProductCommand = new RelayCommand(removeProductEntity, CanExecute);
        }
        public ICommand AddProductCommand { get; }
        public ICommand UpdateProductCommand { get; }
        public ICommand RemoveProductCommand { get; }
        private async void addProductEntity()
        {
            ProductWindow win = new ProductWindow(new Product(), db);
            if (win.ShowDialog() == true)
            {
                if (string.IsNullOrWhiteSpace(win.Product.ProductName) || win.Product.Price <= 0)
                {
                    ShowErrorMessage();
                    return;
                }
                Product product = win.Product;
                try
                {
                    await db.Products.AddAsync(product);
                    await db.SaveChangesAsync();
                    products = db.Products.Local.ToObservableCollection();
                    OnPropertyChanged(nameof(Products));
                }
                catch
                {
                    ShowErrorMessage();
                }
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

            ProductWindow win = new ProductWindow(product, db);
            if (win.ShowDialog() == true)
            {
                if (string.IsNullOrWhiteSpace(win.Product.ProductName) || win.Product.Price <= 0)
                {
                    ShowErrorMessage();
                    return;
                }
                selectedProduct.ProductName = win.Product.ProductName;
                selectedProduct.Price = win.Product.Price;
                selectedProduct.Quantity = win.Product.Quantity;
                selectedProduct.CategoryId = win.Product.CategoryId;
                db.Entry(selectedProduct).State = EntityState.Modified;
                try
                {
                    await db.SaveChangesAsync();
                }
                catch
                {
                    ShowErrorMessage();
                }
            }
        }
        private async void removeProductEntity()
        {
            Product? product = selectedProduct;
            if (ShowConfirmationWindow() == MessageBoxResult.Yes)
            {
                db.Products.Remove(product);
            }
            await db.SaveChangesAsync();
        }
        private bool CanExecute() => selectedProduct != null;
        private void ShowErrorMessage()
        {
            string messageBoxText = "Некорректные значения";

            string caption = "Ошибка";

            MessageBoxImage icon = MessageBoxImage.Error;

            MessageBox.Show(messageBoxText, caption, MessageBoxButton.OK, icon);
        }

        private MessageBoxResult ShowConfirmationWindow()
        {
            string messageBoxText = "Вы уверены? Действие нельзя будет отменить";

            string caption = "Подтвердите действие";

            MessageBoxImage icon = MessageBoxImage.Question;

            return MessageBox.Show(messageBoxText, caption, MessageBoxButton.YesNo, icon);
        }
    }
}

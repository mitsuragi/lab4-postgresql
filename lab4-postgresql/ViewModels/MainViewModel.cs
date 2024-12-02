using lab4_postgresql.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace lab4_postgresql.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public StoreDbContext StoreDbContext { get; private set; }
        public CategoryViewModel CategoryVM { get; private set; }
        public ProductViewModel ProductVM { get; private set; }

        private bool showStartupMessage;
        public bool ShowStartupMessage
        {
            get => showStartupMessage;
            set
            {
                showStartupMessage = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            showStartupMessage = Properties.Settings.Default.ShowStartupMessage;

            if (showStartupMessage)
            {
                showAbout();
            }

            try
            {
                StoreDbContext = new StoreDbContext();
                StoreDbContext.Products.Load();
                StoreDbContext.Categories.Load();
                CategoryVM = new CategoryViewModel(StoreDbContext);
                ProductVM = new ProductViewModel(StoreDbContext);
            }
            catch (Exception ex)
            {
                string messageBoxText = "Произошла ошибка при загрузке базы данных\n";

                string caption = "Ошибка";

                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, MessageBoxButton.OK, icon);

                return;
            }
            finally
            {
                FileSaveCommand = new RelayCommand(fileSave, canExecuteSave);
                ShowAboutCommand = new RelayCommand(showAbout, () => true);
                SwitchShowStartupCommand = new RelayCommand(switchShow, () => true);
            }
        }

        public ICommand FileSaveCommand { get; }
        public ICommand ShowAboutCommand { get; }
        public ICommand SwitchShowStartupCommand { get; }

        private void switchShow()
        {
            Properties.Settings.Default.ShowStartupMessage = showStartupMessage;
            Properties.Settings.Default.Save();
        }

        private void fileSave()
        {
            List<Product> products = StoreDbContext.Products.ToList();
            List<Category> categories = StoreDbContext.Categories.ToList();

            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Сущности";
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Текстовые документы (.txt)|*.txt";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                StreamWriter sw = new StreamWriter(dialog.FileName);
                sw.WriteLine("Products");
                foreach(var product in products)
                {
                    sw.WriteLine($"Id={product.ProductId}\tName={product.ProductName}\t" +
                        $"Price={product.Price}\tQuantity={product.Quantity}\tCategoryId={product.CategoryId}");
                }
                sw.WriteLine("\nCategories");
                foreach(var category in categories)
                {
                    sw.WriteLine($"Id={category.CategoryId}\tName={category.CategoryName}");
                }
                sw.Close();
            }
        }

        private bool canExecuteSave() => StoreDbContext.Products.Local.ToList().Count != 0 &&
                                         StoreDbContext.Categories.Local.ToList().Count != 0;

        private void showAbout()
        {
            string messageBoxText = "Задание выполнил студент группы №424 Губкин Максим.\n" +
                "Вариант №4\n\n" +
                "Текст задания: Необходимо написать программу хранения списка товаров в магазине.\n" +
                "Программа должна позволять добавлять новые сущности с использованием интерфейса и " +
                "редактировать существующие. Сущности, добавленные в программу должны сохраняться между запусками приложения";

            string caption = "Справка";

            MessageBoxImage icon = MessageBoxImage.Information;

            MessageBox.Show(messageBoxText, caption, MessageBoxButton.OK, icon);
        }
    }
}

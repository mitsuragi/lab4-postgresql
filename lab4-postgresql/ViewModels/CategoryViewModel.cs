using lab4_postgresql.Models;
using lab4_postgresql.Views;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace lab4_postgresql.ViewModels
{
    public class CategoryViewModel : ViewModelBase
    {
        private StoreDbContext db;
        private Category? selectedCategory;
        public Category? SelectedCategory
        {
            get => selectedCategory;
            set
            {
                selectedCategory = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Category> categories = null!;
        public ObservableCollection<Category> Categories
        {
            get => categories;
            set
            {
                categories = value;
                OnPropertyChanged();
            }
        }
        public CategoryViewModel(StoreDbContext db)
        {
            this.db = db;
            Categories = db.Categories.Local.ToObservableCollection();
            AddCategoryCommand = new RelayCommand(addCategoryEntity, () => true);
            UpdateCategoryCommand = new RelayCommand(updateCategoryEntity, CanExecute);
            RemoveCategoryCommand = new RelayCommand(removeCategoryEntity, CanExecute);
        }

        public ICommand AddCategoryCommand { get; }
        public ICommand UpdateCategoryCommand { get; }
        public ICommand RemoveCategoryCommand { get; }
        private async void addCategoryEntity()
        {
            CategoryWindow win = new CategoryWindow(new Category());
            if (win.ShowDialog() == true)
            {
                if (win.Category.CategoryName == null)
                {
                    ShowErrorMessage();
                    return;
                }
                Category category = win.Category;
                db.Categories.Add(category);
                await db.SaveChangesAsync();
                categories = db.Categories.Local.ToObservableCollection();
                OnPropertyChanged(nameof(Categories));
            }
        }
        private async void updateCategoryEntity()
        {
            Category category = new Category
            {
                CategoryId = selectedCategory.CategoryId,
                CategoryName = selectedCategory.CategoryName
            };

            CategoryWindow win = new CategoryWindow(category);
            if (win.ShowDialog() == true)
            {
                if (win.Category.CategoryName == null)
                {
                    ShowErrorMessage();
                    return;
                }
                selectedCategory.CategoryName = win.Category.CategoryName;
                db.Entry(selectedCategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
        }
        private async void removeCategoryEntity()
        {
            Category? category = selectedCategory;
            var products = (from p in db.Products.ToList() where p.Category == category select p).ToList();
            if (products.Count > 0)
            {
                string messageBoxText = "Имеются продукты этой категории. Перед удалением категории удалите все продукты, которые ей принадлежат";

                string caption = "Ошибка";

                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, MessageBoxButton.OK, icon);

                return;
            }

            if (ShowConfirmationWindow() == MessageBoxResult.Yes)
            {
                db.Categories.Remove(category);
            }

            await db.SaveChangesAsync();
        }
        private bool CanExecute() => selectedCategory != null;

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

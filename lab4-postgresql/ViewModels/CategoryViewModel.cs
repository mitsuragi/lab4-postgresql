﻿using lab4_postgresql.Models;
using lab4_postgresql.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lab4_postgresql.ViewModels
{
    public class CategoryViewModel : ViewModelBase
    {
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
        public CategoryViewModel()
        {
            db.Categories.Load();
            categories = db.Categories.Local.ToObservableCollection();
            addCategoryCommand = new RelayCommand(addCategoryEntity, () => true);
            updateCategoryCommand = new RelayCommand(updateCategoryEntity, CanExecute);
            removeCategoryCommand = new RelayCommand(removeCategoryEntity, CanExecute);
        }

        public ICommand addCategoryCommand { get; }
        public ICommand updateCategoryCommand { get; }
        public ICommand removeCategoryCommand { get; }
        private async void addCategoryEntity()
        {
            CategoryWindow win = new CategoryWindow(new Category());
            if (win.ShowDialog() == true)
            {
                Category category = win.Category;
                db.Categories.Add(category);
                await db.SaveChangesAsync();
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
                selectedCategory.CategoryName = win.Category.CategoryName;
                db.Entry(selectedCategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
        }
        private async void removeCategoryEntity()
        {
            Category? category = selectedCategory;
            db.Categories.Remove(category);
            await db.SaveChangesAsync();
        }
        private bool CanExecute() => selectedCategory != null;


    }
}
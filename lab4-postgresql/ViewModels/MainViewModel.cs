using lab4_postgresql.Models;
using lab4_postgresql.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lab4_postgresql.ViewModels
{
    public class MainViewModel
    {
        public StoreDbContext StoreDbContext { get; private set; }
        public CategoryViewModel CategoryVM { get; private set; }
        public ProductViewModel ProductVM { get; private set; }
        public MainViewModel()
        {
            StoreDbContext = new StoreDbContext();
            StoreDbContext.Products.Load();
            StoreDbContext.Categories.Load();
            CategoryVM = new CategoryViewModel(StoreDbContext);
            ProductVM = new ProductViewModel(StoreDbContext);
        }
    }
}

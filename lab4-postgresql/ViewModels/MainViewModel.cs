using lab4_postgresql.Models;
using Microsoft.EntityFrameworkCore;

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

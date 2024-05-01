using lab4_postgresql.Models;
using lab4_postgresql.Views;
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
        public CategoryViewModel CategoryVM { get; private set; }
        public ProductViewModel ProductVM { get; private set; }
        public MainViewModel()
        {
            CategoryVM = new CategoryViewModel();
            ProductVM = new ProductViewModel();
        }
    }
}

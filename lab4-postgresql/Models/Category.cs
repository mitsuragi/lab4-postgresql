using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace lab4_postgresql.Models;

public partial class Category : INotifyPropertyChanged
{
    private int categoryId;
    private string categoryName = null!;
    public int CategoryId
    {
        get => categoryId;
        set
        {
            categoryId = value;
            OnPropertyChanged();
        }
    }

    public string CategoryName
    {
        get => categoryName;
        set
        {
            categoryName = value;
            OnPropertyChanged();
        }
    }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

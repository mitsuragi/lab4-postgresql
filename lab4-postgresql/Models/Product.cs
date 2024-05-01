using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace lab4_postgresql.Models;

public partial class Product : INotifyPropertyChanged
{
    private int productId;
    private string productName = null!;
    private decimal price;
    private int quantity;
    private int categoryId;
    public int ProductId
    {
        get => productId;
        set
        {
            productId = value;
            OnPropertyChanged();
        }
    }

    public string ProductName
    {
        get => productName;
        set
        {
            productName = value;
            OnPropertyChanged();
        }
    }

    public decimal Price
    {
        get => price;
        set
        {
            price = value;
            OnPropertyChanged();
        }
    }

    public int Quantity
    {
        get => quantity;
        set
        {
            quantity = value;
            OnPropertyChanged();
        }
    }

    public int CategoryId
    {
        get => categoryId;
        set
        {
            categoryId = value;
            OnPropertyChanged();
        }
    }

    public virtual Category Category { get; set; } = null!;

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

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
            if (value < 0)
            {
                price = 0;
            }
            else
            {
                price = value;
            }
            OnPropertyChanged();
        }
    }

    public int Quantity
    {
        get => quantity;
        set
        {
            if (value < 0)
            {
                quantity = 0;
            }
            else
            {
                quantity = value;
            }
            OnPropertyChanged();
        }
    }

    public int CategoryId
    {
        get => categoryId;
        set
        {
            if (value < 0)
            {
                categoryId = 0;
            }
            else
            {
                categoryId = value;
            }
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
    public string Error => null;
}

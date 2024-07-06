
using System.Xml.Linq;
using System;

// інтерфейс
public interface IProduct
{
    public string _name { get; set; }
    public int _price { get; set; }
    public int _quantity { get; set; }
    public void IncrementQuant();
    public void DecrementQuant();
    public void Print();
}
// реалізація попереднього інтерфейсу разом з іншими
public class Product : IProduct, ICloneable, IComparable<Product>
{
    public string _name { get; set; }
    public int _price { get; set; }
    public int _quantity { get; set; }

    public Product(string name, int price, int quantity) 
    {
        _name = name;
        _price = price;
        _quantity = quantity;
    }
    public void IncrementQuant()
    {
        this._quantity++;
    }
    public void DecrementQuant()
    {
        this._quantity--;
    }
    public void Print()
    {
        Console.WriteLine($"{_name}, price: {_price}, quant: {_quantity}");
    }
    public object Clone()
    {
        return new Product(_name, _price, _quantity);
    }
    public int CompareTo(Product? other)
    {
        if (other == null)
        {
            throw new ArgumentException("Incorrect parameter's value");
        }
        return _price.CompareTo(other._price);
    }
}
// інтерфейз магазу
public interface IShop<T>
{
    public List<T> _list { get; set; }
    public void Add(T item);
    public void Remove(T item);
    public void Remove(int index);
    public void Sort();
}
// його реалізація
public class Shop : IShop<Product>
{
    public List<Product> _list { get ; set ; }
    public Shop(List<Product> list)
    {
        _list = list;
    }
    public Shop()
    {
        _list = new List<Product>();
    }

    public void Add(Product item)
    {
        _list.Add(item);
    }

    public void Remove(Product item)
    {
        _list.Remove(item);
    }

    public void Remove(int index)
    {
        _list.RemoveAt(index);
    }
    public void Sort()
    {
        try
        {
            _list.Sort();
        }
        catch (Exception err)
        {
            Console.WriteLine(err.Message);
        }
       
    }
    public void Print()
    {
        for(int i =  0; i < _list.Count; i++)
        {
            Console.Write($"{i+1}) ");
            _list[i].Print();
        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        // створення магазину
        Shop shop = new Shop();
        // добавляємо туди продукти
        shop.Add(new Product("Orange", 15, 2));
        shop.Add(new Product("Crisps", 30, 1));
        shop.Add(new Product("Cola", 25, 2));
        shop.Add(new Product("Beer", 30, 1));
        shop.Add(new Product("Bread", 15, 2));
        shop.Add(new Product("Apple", 10, 4));
        // виводим
        shop.Print();
        // сортуємо
        shop.Sort();
        Console.WriteLine(); // просто слеш
        // виводим відсортований
        shop.Print();

        Console.WriteLine(); // просто слеш
        // клонування працює
        Product product_1 = new Product("PRIME", 25, 1);
        product_1.Print();
        Product product_2 = (Product)product_1.Clone();
        product_2.Print();
    }
}
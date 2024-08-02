using System;

public class Play : IDisposable
{
    public string _name;
    public string _author;
    public string _ganre;
    public DateTime _year;
    private bool disposed = false;
    // constructor
    public Play(string name, string author, string ganre, DateTime year) 
    {  
        _name = name;
        _author = author;
        _ganre = ganre;
        _year = year;
    }
    // de-constructor
    ~Play() { Dispose(disposing: false); }
    // disposing
    public void Dispose()
    {
        Dispose(true); // not menaged resourses
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
        {
            return;
        }
        if (disposing)
        {
            // Звільняємо керовані ресурси
        }
        // звільняємо некеровані об'єкти
        disposed = true;
    }
    // print
    public void Print()
    {
        Console.WriteLine($"'{_name}', Author: {_author}, Ganre: {_ganre}, Year: {_year.Year}");
    }
}

public class Store : IDisposable
{
    public string _name;
    public string _address;
    public StoreType _type;
    private bool disposed = false;
    // constructor
    public Store(string name, string address, StoreType type)
    {
        _name = name;
        _address = address;
        _type = type;
    }
    // de-constructor
    ~Store() { Dispose(disposing: false); }
    // disposing
    public void Dispose()
    {
        Dispose(true); // not menaged resourses
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
        {
            return;
        }
        if (disposing)
        {
            // Звільняємо керовані ресурси
        }
        // звільняємо некеровані об'єкти
        disposed = true;
    }
    // print
    public void Print()
    {
        Console.WriteLine($"'{_name}', Address: {_address}, Type: {_type}");
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        // Task 1
        {
            Play play = new Play("Some Play Name", "John Doe", "Drama", new DateTime(2020,12,12));
            play.Print();
        }
        // Task 2
        {
            Store store = new Store("H&M", "Some Address", StoreType.Clothes);
            store.Print();
        }
    }
}

public enum StoreType
{
    Food,
    Clothes,
    Shoes,
    Jewellery
}
// абстрактний клас (батьківській)
public abstract class LibraryItem
{
    // змінні
    public string _title { get; set; }
    public string _author { get; set; }
    public string _description { get; set; }
    public bool _availability { get; set; }
    // конструктор (його потім будуть викликати дочірні класи)
    public LibraryItem(string title, string author, string description, bool availability)
    {
        _title = title;
        _author = author;
        _description = description;
        _availability = availability;
    }
    // методи (ну тіпа шаблони)
    public abstract void IsAvailable();
    public abstract string GetDescription();
} 
// дочірні класи
// книга
class Book : LibraryItem
{
    public Book(string title, string author, string description, bool availability) : base(title, author, description, availability) { }
    public override void IsAvailable()
    {
        Console.Write($"Title '{_title}' (Book) is {(_availability ? "avaible" : "unavaible")}");
        
    }
    public override string GetDescription()
    {
        return _description;
    }
}
// журнал
class Magazine : LibraryItem
{
    public Magazine(string title, string author, string description, bool availability) : base(title, author, description, availability) { }
    public override void IsAvailable()
    {
        Console.Write($"Title '{_title}' (Magazine) is {(_availability ? "avaible" : "unavaible")}");

    }
    public override string GetDescription()
    {
        return _description;
    }
}
// двд
class DVD : LibraryItem
{
    public DVD(string title, string author, string description, bool availability) : base(title, author, description, availability) { }
    public override void IsAvailable()
    {
        Console.Write($"Title: '{_title}' (DVD) is {(_availability ? "avaible" : "unavaible")}");

    }
    public override string GetDescription()
    {
        return _description;
    }
}

public class Library
{
    public List<LibraryItem> _library_list = [];
    // просто вивід
    public void printList()
    {
        for(int i = 0; i < _library_list.Count; i++)
        {
            Console.WriteLine($"{i+1}) '{_library_list[i]._title}', author: {_library_list[i]._author};");
        }
    }
    // пошук для користувача
    public void findByTitle()
    {
        Console.Write("Write title: ");
        string title = Console.ReadLine();
        // нагадую що я юзаю звичайений індекс
        int index = 0;
        LibraryItem item = null;
        for(int i = 0; i < _library_list.Count;i++)
        {
            if (_library_list[i]._title.ToLower() == title.ToLower())
            {
                index = i+1;
                item = _library_list[i];
            }
        }
        if (index != 0)
        {
            Console.WriteLine($"The item was found with the index of {index}.");
            item.IsAvailable();
            Console.WriteLine($"\nDescription: {item.GetDescription()}");
        }
        else 
        { 
            Console.WriteLine("The item was not found in list."); 
        }
    }
    // пошук для розробника
    private bool findByTitle(string title)
    {
        for (int i = 0; i < _library_list.Count; i++)
        {
            if (_library_list[i]._title.ToLower() == title.ToLower())
            {
                return true;
            }
        }
        return false;
    }
    // додавання
    public void addNewItem()
    {
        Console.Write("Choose item`s type (1-book, 2-magazine, 3-dvd): ");
        int type = Convert.ToInt32(Console.ReadLine());
        bool flag = true;
        string title = null;
        while (flag)
        {
            Console.Write("Write item`s name: ");
            title = Console.ReadLine();
            if(findByTitle(title) == true)
            {
                flag = true;
            }
            else { flag = false; }
        }
        Console.Write("Write item`s author: ");
        string author = Console.ReadLine();
        Console.Write("Write item`s description: ");
        string description = Console.ReadLine();
        Console.Write("Choose item`s availability (1-avaible, 2-unavaible): ");
        int availability_int = Convert.ToInt32(Console.ReadLine());
        bool availability = (availability_int == 1 ? true : false);
        switch (type)
        {
            case 1:
                _library_list.Add(new Book(title, author, description, availability));
                break;
            case 2:
                _library_list.Add(new Magazine(title, author, description, availability));
                break;
            case 3:
                _library_list.Add(new DVD(title, author, description, availability));
                break;
            default:
                Console.WriteLine("Oops, smth went wrong.");
                break;
        }
    }
    // видалення
    public void delItem()
    {
        Console.Write("Write item`s index(starting with 1): ");
        int index = (Convert.ToInt32(Console.ReadLine())) - 1;
        if(index < 0 || index > _library_list.Count())
        {
            Console.WriteLine("Oops, smth went wrong. Try again.");
            delItem();
        }
        else
        {
            _library_list.RemoveAt(index);
        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        // заготовка
        Library Library = new Library();
        Library._library_list = [new Book("Book title","Book author","Short description",true),
            new Magazine("Magazine title", "Magazine author", "Long description", true),
            new DVD("DVD title", "DVD author", "Large description", true),
        ];
        bool flag = true;
        // я тут всюди язав простий індекс якщо що, типу все починається не з 0 а з 1.
        // ПОПЕРЕДЖУЮ: я щось тупанув і не все зміг нормалько зв'язати один з одним, все хоть і працює, але дивно виглядає
        // зразу все написав і тільки в кінці запускав (як завжди)
        Console.Write("Task 1. Library:\n1)Print item list;" +
            "\n2)Find by title;" +
            "\n3)Add new item;" +
            // додав ще видалення
            "\n4)Delete item by index.");
        while (flag)
        {
            Console.Write("\n--> ");
            int action = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (action)
            {
                case 1:
                    Library.printList();
                    break;
                case 2:
                    Library.findByTitle();
                    break;
                case 3:
                    Library.addNewItem();
                    break;
                case 4:
                    Library.delItem();
                    break;
                default:
                    Console.Write("Something went wrong, try again.");
                    break;
            }
        }
    }
}
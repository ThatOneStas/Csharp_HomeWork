using System.Collections;

public class Product
{
    public string _name { get; set; }
    public int _price { get; set; }
    public Product(string name, int price)
    {
        _name = name;
        _price = price;
    }
    public void Print()
    {
        Console.WriteLine($"Name: '{_name}', Price: {_price}");
    }
}
public class Person
{
    public string _name { get; set; }
    public Person(string name) { _name = name;}
    public void Print() 
    {
        Console.WriteLine($"Person's name: {_name}");
    }
}
public class Order
{
    public int _order_id { get; set; }
    public Product _product { get; set; }
    public Person _person { get; set; }
    public Order(int order_id, Product product, Person person)
    {
        _order_id = order_id;
        _product = product;
        _person = person;
    }
    public void Print()
    {
        Console.WriteLine($"Order ID: {_order_id}");
        _product.Print();
        _person.Print();
    }
}
public class Document
{
    public int _document_id { get; set; }
    public Document(int document_id)
    {
        _document_id = document_id;
    }
    public void Print()
    {
        Console.WriteLine($"Doc. ID: {_document_id}");
    }
}
public class MyCollectionEnumerator : IEnumerator
{
    int[] _int_list;
    int position = -1;
    public object Current
    {
        get
        {
            if (position == -1 || position >= _int_list.Length)
            {
                throw new ArgumentException();
            }
            return _int_list[position];
        }
    }
    public MyCollectionEnumerator(int[] int_list)
    {
        _int_list = int_list;
    }
    public bool MoveNext()
    {
        if (position < _int_list.Length - 1)
        {
            position++;
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Reset() => position = -1;
}
public class MyCollection
{
    int[] _int_list;
    public MyCollection(int[] int_list)
    {
        _int_list = int_list;
    }
    public IEnumerator GetEnumerator() => new MyCollectionEnumerator(_int_list);
}
public class FibonacciSequence
{
    public IEnumerator<int> GetEnumerator()
    {
        int number = 0;
        for (int i = 1; i < 999;)
        {
            int temp_i = i;
            i += number;
            number = temp_i;
            yield return i;
        }
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        // task 1
        Console.WriteLine("===== TASK: 1 =====");
        {
            List<Product> products = [
                new Product("Apples", 20),
                new Product("Chocolate Bar", 50),
                new Product("Crisps", 35),
                new Product("Beer", 60),
                new Product("Mohito", 55),
                ];
            for(int i = 0; i < products.Capacity; i++)
            {
                products[i].Print();
            }

            Console.WriteLine(); // slash

            // finding average price of products
            int avarage_price = 0;
            for (int i = 0; i < products.Count; i++)
            {
                avarage_price += products[i]._price / products.Count;
            }
            Console.WriteLine($"Avarage price: {avarage_price}");

            Console.WriteLine(); // slash

            // selecting products over 50 price.
            products = (from i in products
                        where i._price >= 50
                        select i).ToList();

            for (int i = 0; i < products.Count; i++)
            {
                products[i].Print();
            }

            Console.WriteLine(); // slash

            // finding average price of products (AGAIN)
            avarage_price = 0;
            for (int i = 0; i < products.Count; i++)
            {
                avarage_price += products[i]._price / products.Count;
            }
            Console.WriteLine($"Avarage price: {avarage_price}");
        }
        Console.WriteLine(); // slash
        // 2
        Console.WriteLine("===== TASK: 2 =====");
        {
            Order order_1 = new Order(412, new Product("Mohito", 55), new Person("Jacob"));
            Order order_2 = new Order(124, new Product("Beer", 60), new Person("Mike"));
            Order order_3 = new Order(243, new Product("Cola", 45), new Person("Anna"));
            Order order_4 = new Order(255, new Product("Fries", 50), new Person("Walt"));
            Order order_5 = new Order(569, new Product("Burger", 65), new Person("Jane"));
            Queue<Order> queue = new Queue<Order>();
            queue.Enqueue(order_1);
            queue.Enqueue(order_2);
            queue.Enqueue(order_3);
            queue.Enqueue(order_4);
            queue.Enqueue(order_5);

            // printing first element
            // queue.First().Print(); // first method
            queue.Peek().Print(); // second method

            Console.WriteLine();

            // printing queue's lenght
            Console.WriteLine($"Queue's lenght: {queue.Count()}");

            Console.WriteLine();

            // getting first's element ID + deleting it in the queue
            Console.WriteLine($"Order's ID: {queue.Dequeue()._order_id}");

            Console.WriteLine();

            // printing queue's lengh after deleting first element
            Console.WriteLine($"Queue's lengh: {queue.Count()}");
        }
        // 3
        Console.WriteLine("===== TASK: 3 =====");
        {
            List<Document> _doc_list = [new Document(141),
                new Document(534),
                new Document(745),
                new Document(324),
                new Document(234)];
            Stack<Document> stack = new Stack<Document>(_doc_list);
            // printing first element without deleting
            stack.First().Print();
            // printing stack lengh
            Console.WriteLine($"Stack count: {stack.Count()}");
            // adding new element
            stack.Push(new Document(523));
            // printing stack lengh after adding new element
            Console.WriteLine($"Stack count: {stack.Count()}");
            // popping 3 first elements
            stack.Pop();
            stack.Pop();
            stack.Pop();
            // printing stack lengh after popping 3 elements
            Console.WriteLine($"Stack count: {stack.Count()}");
            // clearing stack
            stack.Clear();
            // printing stack lengh after clearing stack
            Console.WriteLine($"Stack count: {stack.Count()}");
        }
        // 4, ну по факту 5. 4 не робив бо не зрозумів суті, але принцик виглядав легко
        Console.WriteLine("===== TASK: 4 (5) =====");
        {
            MyCollection myCollection = new MyCollection([12,23,53,77,99]);
            // printing the collection using a class variable
            foreach(int i in myCollection)
            {
                Console.WriteLine(i);
            }
        }
        Console.WriteLine("===== TASK: 5 (6) =====");
        {
            FibonacciSequence seq = new FibonacciSequence();
            foreach(int i in seq)
            {
                Console.WriteLine($"{i}");
            }
        }
    }
}
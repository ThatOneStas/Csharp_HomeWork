using System;
using System.ComponentModel;

public class Utility
{
    // пару об'єктів для обміну
    public string Text;
    public int Number;
    // звичайний конструктор
    public Utility(string text, int num) 
    {
        Text = text;
        Number = num;
    }
    // передаю рефками щоб мінялись значення
    public static void Swap<T>(ref T item_1, ref T item_2) where T : Utility
    {
        // тимчасові змінні для зберігання дати першого айтему..
        string temp_string = item_1.Text;
        int temp_int = item_1.Number;
        // ..так як тут його дата замінюється
        item_1.Text = item_2.Text;
        item_1.Number = item_2.Number;
        item_2.Text = temp_string;
        item_2.Number = temp_int;
    }
    // прінт як прінт
    public void Print()
    {
        Console.WriteLine($"Str: {Text}, Int: {Number}");
    }
}

internal class Program
{
    // селектори 1-3
    public static Func<Tuple<int, int>, bool> selector_1 = delegate (Tuple<int, int> tuple)
    {
        if(tuple.Item1 > tuple.Item2)
        {
            return true;
        }
        return false;
    };
    public static Func<Tuple<int, int>, bool> selector_2 = delegate (Tuple<int, int> tuple)
    {
        if (tuple.Item1 < tuple.Item2)
        {
            return true;
        }
        return false;
    };
    public static Func<Tuple<int, int>, bool> selector_3 = delegate (Tuple<int, int> tuple)
    {
        if (tuple.Item1 == tuple.Item2)
        {
            return true;
        }
        return false;
    };
    // метод відбору та підрахунку
    public static void CountIf<T>(T[] arr) where T : Tuple<int, int> // predicate я вибераю всередині методу
    {
        Console.WriteLine("Choose the selection method:" +
            "\n1) num1 > num2;" +
            "\n2) num1 < num2;" +
            "\n3) num1 = num2.");
        Console.Write("\n--> ");
        int option = Convert.ToInt32(Console.ReadLine());
        int count = 0;
        Func<T, bool> selector = null;
        try
        {
            switch (option)
            {
                case 1:
                    selector = selector_1;
                    break;
                case 2:
                    selector = selector_2;
                    break;
                case 3:
                    selector = selector_3;
                    break;
                default:
                    throw new Exception("Wrong option. Try again.");
                    break;
            }
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); CountIf(arr); }
        for(int i = 0; i < arr.Length; i++)
        {
            if (selector(arr[i]))
            {
                // count + 1 це просто для нумерації 1) 2)..
                Console.WriteLine($"{count+1}) {arr[i].Item1}, {arr[i].Item2}");
                count++;
            }
        }
        if(count == 0) // умова якщо не знайшло нічого (я її не перевіряв но напевно працює)
        {
            Console.WriteLine("None of the items did match with your selection method.");
        }
        else
        {
            // виводим к-сть айтемів
            Console.WriteLine($"Cound of items: {count}");
        }
    }
    private static void Main(string[] args)
    {
        // список для відбору елементів
        Tuple<int, int>[] tuple_arr =
        [
            new Tuple<int, int>(212, 123),
            new Tuple<int, int>(7332, 1245),
            new Tuple<int, int>(254, 254),
            new Tuple<int, int>(124, 444),
            new Tuple<int, int>(11243, 23445),
            new Tuple<int, int>(45235, 73238),
            new Tuple<int, int>(64, 12),
            new Tuple<int, int>(123, 134),
            new Tuple<int, int>(122, 122),
            new Tuple<int, int>(1244, 15512),
            new Tuple<int, int>(1245, 1244),
            new Tuple<int, int>(34233, 7745),
            new Tuple<int, int>(1566, 2355)
        ];
        bool flag = true;
        Console.Write("Task 1. CountIf." +
            "\n1) Start selection;" +
            "\n2) Next task.");
        while (flag)
        {
            Console.Write("\n--> ");
            int action = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (action)
            {
                case 1:
                    CountIf(tuple_arr);
                    break;
                case 2:
                    flag = false;
                    break;
                default:
                    Console.Write("Something went wrong, try again.");
                    break;
            }
        }
        // рандомні значення прокинув
        Utility utility_1 = new Utility("First unique Text", 225055);
        Utility utility_2 = new Utility("Even more unique Text", 100500);
        flag = true;
        Console.Write("Task 2. Utility." +
            "\n1) Swap;" +
            "\n2) End.");
        while (flag)
        {
            Console.Write("\n--> ");
            int action = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (action)
            {
                case 1:
                    // до
                    Console.WriteLine("-- Before swapping: --");
                    utility_1.Print();
                    utility_2.Print();
                    Utility.Swap(ref utility_1,ref utility_2);
                    // після
                    Console.WriteLine("-- After swapping: --");
                    utility_1.Print();
                    utility_2.Print();
                    break;
                case 2:
                    flag = false;
                    break;
                default:
                    Console.Write("Something went wrong, try again.");
                    break;
            }
        }
    }
}
using Class_Library.Models;

public class Shedule
{
    private DayOfWeek? _day_of_week { get; set; } = null;
    
    public void setDay(DayOfWeek? day)
    {
        _day_of_week = day;
    }
    public DayOfWeek? getDay()
    {
        if (_day_of_week == null)
        {
            throw new Exception();
        }
        else
        {
            return _day_of_week;
        }
    }
}

public class Vector3D
{
    private const int _zero = 0;
    private int x = 0;
    private int y = 0;
    private int z = 0;
    public Vector3D()
    {
        x = 0; y = 0; z = 0;
    }
    public Vector3D(int x, int y, int z)
    {
        this.y = y/2; this.x = x/2; this.z = z/2;
    }
    public int calcLenght()
    {
        return Convert.ToInt32(Math.Sqrt((x*x)+(y*y)+(z*z)));
    }
} 

internal class Program
{
    private static void Main(string[] args)
    {
        bool flag = true;
        // доволі не зрозумілив опис таску, сподіваюсь правильно зрозумів
        Console.Write("Task 1. DayOfWeek (i used enum and exception for it too)\n1) Start LOOP;\n2) Next task.");
        Shedule shedule = new Shedule();
        while (flag)
        {
            Console.Write("\n--> ");
            int action = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            bool innerFlag = true;
            switch (action)
            {
                case 1:
                    while (innerFlag)
                    {
                        Console.Write("Write num 1-7, 0 - write current day, any number to exit: ");
                        switch (Convert.ToInt32(Console.ReadLine()))
                        {
                            case 1:
                                shedule.setDay((DayOfWeek?)1);
                                Console.WriteLine($"{shedule.getDay()}");
                                break;
                            case 2:
                                shedule.setDay((DayOfWeek?)2);
                                Console.WriteLine($"{shedule.getDay()}");
                                break;
                            case 3:
                                shedule.setDay((DayOfWeek?)3);
                                Console.WriteLine($"{shedule.getDay()}");
                                break;
                            case 4:
                                shedule.setDay((DayOfWeek?)4);
                                Console.WriteLine($"{shedule.getDay()}");
                                break;
                            case 5:
                                shedule.setDay((DayOfWeek?)5);
                                Console.WriteLine($"{shedule.getDay()}");
                                break;
                            case 6:
                                shedule.setDay((DayOfWeek?)6);
                                Console.WriteLine($"{shedule.getDay()}");
                                break;
                            case 7:
                                shedule.setDay((DayOfWeek?)7);
                                Console.WriteLine($"{shedule.getDay()}");
                                break;
                            case 0:
                                try
                                {
                                    Console.WriteLine($"{shedule.getDay()}");
                                }
                                catch (Exception err)
                                {
                                    Console.WriteLine("The currect day is null, try 1-7 to set day value.");
                                }
                                break;
                            default:
                                Console.WriteLine("\nYOU LEFT LOOP, write 1 - Continue loop, 2 - Next task.");
                                innerFlag = false;
                                break;
                        }
                    }
                    break;
                case 2:
                    flag = false;
                    break;
                default:
                    Console.Write("Something went wrong, try again.");
                    break;
            }
        }
        flag = true;
        // як я зрозумів, є клас вектор і в ньому є нульова константа (нульовий вектор)
        // і координати x y z які вписує користувач після чого маючи вектор з 2-ох точок
        // він обчислює його довжину.
        // там просилось зробити x y z лише читабельними але я не став цього робити, і напевно я не так виконав завдання
        Console.Write("Task 2. Vector3D.\n1) Start;\n2) Next task.");
        int x; int y; int z;
        Vector3D vector = new Vector3D();
        while (flag)
        {
            Console.Write("\n--> ");
            int action = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (action)
            {
                case 1:
                    Console.Write("Write X: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Write Y: ");
                    y = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Write Z: ");
                    z = Convert.ToInt32(Console.ReadLine());
                    vector = new Vector3D(x, y, z);
                    Console.WriteLine($"Vector Lenght: {vector.calcLenght()} (the lenght can be rounded by Convert.ToInt32)");
                    break;
                case 2:
                    flag = false;
                    break;
                default:
                    Console.Write("Something went wrong, try again.");
                    break;
            }
        }
        flag = true;
        // для цього потрібно створити бібліотеку класів, в якій
        // буде міститись один клас з одним методом для перетворення
        // температур один між одним.
        TemperatureConverter temp_conv = new TemperatureConverter();
        Console.Write("Task 3. TemperatureConverter.\n1) Start;\n2) End.");
        while (flag)
        {
            Console.Write("\n--> ");
            int action = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (action)
            {
                case 1:
                    temp_conv.ConvertTemp();
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

public enum DayOfWeek
{
    None = 0,
    Monday = 1,
    Tuesday = 2,
    Wednesday = 3,
    Thursday = 4,
    Friday = 5,
    Saturday = 6,
    Sunday = 7
}
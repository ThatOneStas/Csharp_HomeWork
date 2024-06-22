using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

// product class
public class Product(string product_name, int product_quantity)
{
    public string Product_name = product_name; // values
    public int Product_quantity = product_quantity;
}
// order class
public record Order(int Id, DateTime Date, List<Product> Products) // : IEquatable<Order>
{
    public int Order_id = Id; // values
    public DateTime Order_date = Date;
    public List<Product> Order_products = Products;
    public void PrintOrder()
    {
        Console.WriteLine($"Order ID: {Order_id};\nOrder data: {Order_date}\nProduct list:");
        for(int i = 0; i < Products.Count; i++)
        {
            Console.WriteLine($"- Product name: {Order_products[i].Product_name}, Product quantity: {Order_products[i].Product_quantity}");
        }
    }
    //public override bool Equals(Order order)
    //{
    //    return true;
    //}
    public int CompareOrderDates(Order other)
    {
        return DateTime.Compare(Order_date, other.Order_date); // менше нуля то перший настає швидше..
        // .. якщо нуль то вони одинакові, більше нуля то другий швидше
    }
    public bool CompareOrderProducts(Order other)
    {
        return Order_products == other.Order_products ? true : false;
    }
    // вирішив чуть запаритись з цим і зробив його більш красивим ніж просто true чи false
    public void CustomEquals(Order other)
    {
        
        Console.WriteLine($"\nIDs: 1) '{Order_id}', 2) '{other.Order_id}';\n---"); // показує айдішки
        // пише яка дата замовлення починається швидше
        if(this.CompareOrderDates(other) == 0)
        {
            // тут якщо одинакові
            Console.WriteLine($"DATEs: Match");
        }
        else
        {
            // тут якщо різні (запарився з ними, незнав що придумати)
            Console.WriteLine($"DATEs: order's '{(this.CompareOrderDates(other) < 0 ? this.Order_id : other.Order_id)})' " +
            $"date begins faster then " +
            $"(order's '{(this.CompareOrderDates(other) > 0 ? this.Order_id : other.Order_id)})' date)");
        }
        Console.WriteLine($"'{Order_id}' order: {Order_date}, '{other.Order_id}' order: {other.Order_date};\n---");
        // показує чи списки з продуктами співпадають
        Console.WriteLine($"LISTs: {(this.CompareOrderProducts(other) ? "Match" : "Don't Match")}.");
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        // lists for orders
        List<Product> product_list_1 = [
            new Product("Apple", 2),
            new Product("Orange", 4),
            new Product("Frozen Pizza", 1),
            new Product("Crisps", 2),
        ];
        List<Product> product_list_2 = [
            new Product("Banana", 6),
            new Product("Grapes", 4),
            new Product("Pepsi", 1),
            new Product("Eggs", 20),
        ];
        // orders
        Order order_1 = new Order(1244, new DateTime(2024, 07, 12), product_list_1);
        Order order_2 = new Order(2134, new DateTime(2024, 06, 20), product_list_1); // copied list of the first order's
        Order order_3 = new Order(3523, new DateTime(2024, 07, 12), product_list_2);

        bool flag = true;
        Console.Write("Task 1. Order (check equality)." +
            "\n1) Print orders (there are 3 orders);" +
            "\n2) Check equality (you will choose orders to check);" +
            "\n3) Next task.");

        while (flag)
        {
            Console.Write("\n--> ");
            int action = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (action)
            {
                case 1:
                    Console.WriteLine("---------- 1 ----------");
                    order_1.PrintOrder();
                    Console.WriteLine("---------- 2 ----------");
                    order_2.PrintOrder();
                    Console.WriteLine("---------- 3 ----------");
                    order_3.PrintOrder();
                    break;
                case 2:
                    // просто еквалс занадто простий, просто true або false
                    // Console.WriteLine(order_1.Equals(order_2));
                    Console.Write("Write orders to check(1, 2, 3): ");
                    Order first_order = null;
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            first_order = order_1;
                            break;
                        case 2:
                            first_order = order_2;
                            break;
                        case 3:
                            first_order = order_3;
                            break;
                        default:
                            break;
                    }
                    Console.Write("Write orders to check(1, 2, 3): ");
                    Order second_order = null;
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            second_order = order_1;
                            break;
                        case 2:
                            second_order = order_2;
                            break;
                        case 3:
                            second_order = order_3;
                            break;
                        default:
                            break;
                    }
                    first_order.CustomEquals(second_order);
                    break;
                case 3:
                    flag = false;
                    break;
                default:
                    Console.Write("Something went wrong, try again.");
                    break;
            }
        }
        Celsium celsium = new Celsium(0);
        Fahrenheit fahrenheit = new Fahrenheit(0);
        Kelvin kelvin = new Kelvin(0);
        flag = true;
        Console.Write("Task 2. Temperature(convertor)." +
            "\n1) Convert;" +
            "\n2) End.");
        while (flag)
        {
            Console.Write("\n--> ");
            int action = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (action)
            {
                case 1:
                    int current_type = 0;
                    int end_type = 0;
                    bool inner_flag = true;
                    while (inner_flag)
                    {
                        Console.Write("Write the current temp type(1=Cº; 2=Fº; 3=Kº): ");
                        current_type = Convert.ToInt32(Console.ReadLine());
                        if (current_type == 1 || current_type == 2 || current_type == 3)
                        {
                            inner_flag = false;
                        }
                        else { Console.WriteLine("Smth went wrong, try again."); inner_flag = true; }
                    }
                    Console.Write("Write the temp (any number): ");
                    double current_temp = Convert.ToInt32(Console.ReadLine());
                    double end_temp = 0;
                    inner_flag = true;
                    while (inner_flag)
                    {
                        Console.Write("Write the temp to convert in(1=Cº; 2=Fº; 3=Kº): ");
                        end_type = Convert.ToInt32(Console.ReadLine());
                        if (current_type == 1 || current_type == 2 || current_type == 3)
                        {
                            inner_flag = false;
                        }
                        else { Console.WriteLine("Smth went wrong, try again."); inner_flag = true; }
                    }
                    switch (current_type)
                    {
                        case 1:
                            if (end_type == 1)
                            {
                                end_temp = current_temp;
                                Console.WriteLine($"Converted from {current_temp}°C to {end_temp}°C");
                            }
                            else if (end_type == 2)
                            {
                                fahrenheit = (Fahrenheit)new Celsium(current_temp);
                                end_temp = (double)fahrenheit;
                                Console.WriteLine($"Converted from {current_temp}°C to {end_temp}°F");
                            }
                            else if (end_type == 3)
                            {
                                kelvin = (Kelvin)new Celsium(current_temp);
                                end_temp = (double)kelvin;
                                Console.WriteLine($"Converted from {current_temp}°C to {end_temp}°K");
                            }
                            break;
                        case 2:
                            if (end_type == 1)
                            {
                                celsium = (Celsium)new Fahrenheit(current_temp);
                                end_temp = (double)celsium;
                                Console.WriteLine($"Converted from {current_temp}°F to {end_temp}°C");
                            }
                            else if (end_type == 2)
                            {
                                end_temp = current_temp;
                                Console.WriteLine($"Converted from {current_temp}°F to {end_temp}°F");
                            }
                            else if (end_type == 3)
                            {
                                kelvin = (Kelvin)new Fahrenheit(current_temp);
                                end_temp = (double)kelvin;
                                Console.WriteLine($"Converted from {current_temp}°F to {end_temp}°K");
                            }
                            break;
                        case 3:
                            if (end_type == 1)
                            {
                                celsium = (Celsium)new Kelvin(current_temp);
                                end_temp = (double)celsium;
                                Console.WriteLine($"Converted from {current_temp}°K to {end_temp}°C");
                            }
                            else if (end_type == 2)
                            {
                                fahrenheit = (Fahrenheit)new Kelvin(current_temp);
                                end_temp = (double)fahrenheit;
                                Console.WriteLine($"Converted from {current_temp}°K to {end_temp}°F");
                            }
                            else if (end_type == 3)
                            {
                                end_temp = current_temp;
                                Console.WriteLine($"Converted from {current_temp}°K to {end_temp}°K");
                            }
                            break;
                        default:
                            break;
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
    }
}

public class Celsium
{
    public double Cel_temp { get; set; }
    public Celsium(double temp)
    {
        this.Cel_temp = temp;
    }
    public static explicit operator Celsium(Fahrenheit param)
    {
        return new Celsium((param.Fah_temp * 1.8) + 32);
    }
    public static explicit operator Celsium(Kelvin param)
    {
        return new Celsium ( param.Kel_temp - 273.15 );
    }
    public static explicit operator double(Celsium param)
    {
        return param.Cel_temp;
    }
}

public class Fahrenheit
{
    public double Fah_temp { get; set; }
    public Fahrenheit(double temp)
    {
        this.Fah_temp = temp;
    }
    public static explicit operator Fahrenheit(Celsium param)
    {
        return new Fahrenheit((param.Cel_temp - 32) * 5 / 9);
    }
    public static explicit operator Fahrenheit(Kelvin param)
    {
        return new Fahrenheit((param.Kel_temp -273.15) * 1.8 + 32);
    }
    public static explicit operator double(Fahrenheit param)
    {
        return param.Fah_temp;
    }
}

public class Kelvin
{
    public double Kel_temp { get; set; }
    public Kelvin(double temp)
    {
        this.Kel_temp = temp;
    }
    public static explicit operator Kelvin(Celsium param)
    {
        return new Kelvin(param.Cel_temp + 273.15);
    }
    public static explicit operator Kelvin(Fahrenheit param)
    {
        return new Kelvin((param.Fah_temp - 32) * 5 / 9 + 273.15);
    }
    public static explicit operator double(Kelvin param)
    {
        return param.Kel_temp;
    }
}
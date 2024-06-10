using System.Net;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    static public string lineBuilder(int line_quant)
    {
        var liner_text = new System.Text.StringBuilder();
        for (int i = 0; i < line_quant; i++)
        {
            liner_text.AppendLine(i.ToString());
        }
        return liner_text.ToString();
    }

    static public void emailChecker(string email)
    {
        Regex email_reg = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        string[] mails = ["gmail.com","ukr.net"];
        if (email_reg.IsMatch(email) && (email.Contains("gmail.com") || email.Contains("ukr.net")))
        {
            Console.WriteLine("Email is correct.");
        }
        else
        {
            Console.WriteLine("Email is incrrect or uses unknown mail form.");
        }
    }
    private static void Main(string[] args)
    {
        bool flag = true;
        Console.Write("Task 1. Email checker with regular expressions.\n1) Start checking;\n2) Next task.");
        while (flag)
        {
            Console.Write("\n--> ");
            int action = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (action)
            {
                case 1:
                    Console.Write("Write your email: ");
                    emailChecker(Console.ReadLine());
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
        Console.Write("Task 2. Line builder.\n1) Build lines;\n2) Next task.");
        while (flag)
        {
            Console.Write("\n--> ");
            int action = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (action)
            {
                case 1:
                    Console.Write("Write lines quantity: ");
                    int lines_quant =  Convert.ToInt32(Console.ReadLine());
                    string liner_text = lineBuilder(lines_quant);
                    Console.WriteLine($"=== Line quant: {lines_quant} ===");
                    Console.WriteLine(liner_text);
                    Console.WriteLine($"=== Line quant: {lines_quant} ===");
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
        Console.Write("Task 3. Transformation of text into array of words.\n1) Start;\n2) Next task.");
        while (flag)
        {
            Console.Write("\n--> ");
            int action = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (action)
            {
                case 1:
                    Console.Write("Write your text: ");
                    string text = Console.ReadLine();
                    Array words_arr = text.Split();
                    foreach (string word in words_arr)
                    {
                        Console.WriteLine(word);
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
        Console.Write("Task 4. 1-7 = day of week, using 'enum'.\n1) Start;\n2) End.");
        while (flag)
        {
            Console.Write("\n--> ");
            int action = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (action)
            {
                case 1:
                    Console.Write("Write your number: ");
                    Console.WriteLine($"Your day: {(Day)Convert.ToInt32(Console.ReadLine())}");
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

public enum Day
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

using System.Linq;
using System.Security.Cryptography.X509Certificates;

public class Magazine
{
    public string _name;
    public string _ganre;
    public int _page_count;
    public DateTime _release_date;
    public Magazine(string name, string ganre, int page_count, DateTime release_date)
    {
        _name = name;
        _ganre = ganre;
        _page_count = page_count;
        _release_date = release_date;
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        // Task 1
        {
            // surnames' list
            List<string> list = ["William", "Joseph", "Johny", "Orange", "Test123456789", "Test987654321", "Test"];
            Console.WriteLine("Task 1. LINQ surnames check.");

            // method All
            if (list.All(s => s.Count() >= 3)) // one condition
            {
                Console.WriteLine("1) All surnames' lenghts are over 3 symbols. (Method 'All')");
            }
            else
            {
                Console.WriteLine("1) Some surname's lenght is below 3 symbols. (Method 'All')");
            }

            if (list.All(s => (s.Count() >= 3) && s.Count() < 10)) // two conditions
            {
                Console.WriteLine("2) All surnames' lenghts are over 3 symbols and below 10 symbols. (Method 'All', 2 cond.)");
            }
            else // if false, we're checking it for 2 new conditions using method 'Any'
            {
                // method Any
                if (list.Any(s => s.Count() >= 10))
                {
                    Console.WriteLine("2+) Some surname's lenght is over 10 symbols. (Method 'Any')");
                }
                if (list.Any(s => s.Count() < 3))
                {
                    Console.WriteLine("2+) Some surname's lenght is below 3 symbols. (Method 'Any')");
                }
            }

            // method Any
            if (list.Any(s => s.ToLower()[0] == 'w'))
            {
                Console.WriteLine("3) Some surname starts with 'W'. (Method 'Any')");
            }
            else
            {
                Console.WriteLine("3) None of the surnames starts with 'W'. (Method 'All')");
            }

            if (list.Any(s => s.ToLower()[s.Count() - 1] == 'y'))
            {
                Console.WriteLine("3) Some surname ends with 'Y'. (Method 'Any')");
            }
            else
            {
                Console.WriteLine("3) None of the surnames ends with 'Y'. (Method 'All')");
            }

            // method Contains
            if (list.Contains("Orange")) // можна було використати Any де можливо було зменшити усі прізвища до..
                                       // ..нижнього кейсу, щоб пошук був більш вдалим, або просто зробити це саме у foreach
            {
                Console.WriteLine("4) List contains 'Orange'. (Method 'Contains')");
            }
            else
            {
                Console.WriteLine("4) List doesn't contain ''Orange. (Method 'Contains')");
            }

            // method LastOrDefault
            Console.WriteLine($"5) Last surname with less then 15 symbols: {list.LastOrDefault(s => s.Count() < 15)}");
        }

        Console.WriteLine();

        // Task 2
        {
            // magazine list
            List<Magazine> list = [new Magazine("World Tour", "Traveling", 100, new DateTime(2024, 5, 18)),
                new Magazine("History of Rome", "History", 185, new DateTime(2024, 6, 28)),
                new Magazine("Times", "News", 90, new DateTime(2023, 7, 6)),
                new Magazine("Your Garden", "Gardening", 76, new DateTime(2022, 7, 2)),
                new Magazine("Auto Racing", "Sports", 69, new DateTime(2022, 7, 2))];
            Console.WriteLine("Task 2. LINQ magazines (custom class) check");

            // method All
            if (list.All(s => s._page_count >= 30))
            {
                Console.WriteLine("1) All magazines' page counts are over 30. (Method 'All')");
            }
            else
            {
                Console.WriteLine("1) Some magazine's page counts is below 30. (Method 'All')");
            }

            if (list.All(s => (s._ganre == "Politics") || (s._ganre == "Sports") || (s._ganre == "Beauty"))) // three conditions
            {
                Console.WriteLine("2) All magazines' ganres are only 'Politics', 'Sports', 'Beauty'. (Method 'All')");
            }
            else
            {
                Console.WriteLine("2) Not all magazines' ganres are 'Politics', 'Sports', 'Beauty'. (Method 'All')");
            }

            // method Any
            if (list.Any(s => s._ganre == "Gardening"))
            {
                Console.WriteLine("3) Some magazine's ganre is 'Gardening'. (Method 'Any')");
            }
            else
            {
                Console.WriteLine("3) None of the magazines' ganres is 'Gardening'. (Method 'All')");
            }

            if (list.Any(s => s._ganre == "Fishing"))
            {
                Console.WriteLine("4) Some magazine's ganre is 'Fishing'. (Method 'Any')");
            }
            else
            {
                Console.WriteLine("4) None of the magazines' ganres is 'Fishing'. (Method 'All')");
            }

            // method Contains
            foreach(Magazine m in list)
            {
                if ("hunting".Contains(m._ganre.ToLower()))
                {
                    Console.WriteLine("5) Some magazine's ganre is 'Hunting'. (Method 'Contains')");
                    return;
                }
                if(m == list.Last())
                {
                    Console.WriteLine("5) None of the magazines' ganres is 'Hunting'. (Method 'Contains')");
                }
            }

            // method FirstOrDefault
            Console.WriteLine($"6) '{list.FirstOrDefault(m => m._release_date.Year == 2022)._name}' has 2022 date release.");

            // method LasttOrDefault
            Console.WriteLine($"7) '{list.LastOrDefault(m => m._name.ToLower().StartsWith("auto"))._name}' starts with 'Auto'.");
        }
    }
}
internal class Program
{
    public static void PrintList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine((i+1) + ") " + list[i]);
        }
    }
    private static void Main(string[] args)
    {
        bool flag = true;

        Console.Write("Task 1. MathOperation." +
            "\n1) Call the delegate methods;" +
            "\n2) Next task.");
        while (flag)
        {
            Console.Write("\n--> ");
            int action = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (action)
            {
                case 1:
                    Console.Write("Write the first num: ");
                    int first_num = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Write the second num: ");
                    int second_num = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine();
                    // додавання
                    MathOperation mathOperation = new _MathOperation().Addition;
                    Console.WriteLine($"Addition: {first_num} + {second_num} = {mathOperation(first_num, second_num)}");
                    // віднімання
                    mathOperation = new _MathOperation().Subtraction;
                    Console.WriteLine($"Subtraction: {first_num} - {second_num} = {mathOperation(first_num, second_num)}");
                    // множення
                    mathOperation = new _MathOperation().Multiply;
                    Console.WriteLine($"Multiply: {first_num} * {second_num} = {mathOperation(first_num, second_num)}");
                    // ділення
                    mathOperation = new _MathOperation().Division;
                    Console.WriteLine($"Division: {first_num} / {second_num} = {mathOperation(first_num, second_num)}");
                    break;
                case 2:
                    flag = false;
                    break;
                default:
                    Console.Write("Something went wrong, try again.");
                    break;
            }
        }
        // list to filter
        List<int> num_list = [234,23515,151,51556622,623,12,
            52135,644,2323,124,6344,8458,4223,1234,123,535,
            624,1,5,55,22,77,9845,35562,626,991,
            97,1022,121,2,-446,-22,-5,-12445,-950,-2350,-330];
        flag = true;
        // anonymous method (filtrations)
        Filtration filtration_above = delegate (int number, int limit)
        {
            if (number >= limit)
            {
                return true;
            }
            else { return false; }
        };
        Filtration filtration_belowe = delegate (int number, int limit)
        {
            if (number <= limit)
            {
                return true;
            }
            else { return false; }
        };
        Console.Write("Task 2. List filtration." +
            "\n1) Filtr list by numbers above the inputed limit;" +
            "\n2) Filtr list by numbers belowe the inputed limit;" +
            "\n3) Next task.");
        while (flag)
        {
            Console.Write("\n--> ");
            int action = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (action)
            {
                case 1:
                    Console.Write("Input the limit: ");
                    int limit = Convert.ToInt32(Console.ReadLine());
                    List<int> filtered_list = new List<int>();
                    for(int i = 0; i < num_list.Count; i++)
                    {
                        if (filtration_above(num_list[i], limit))
                        {
                            filtered_list.Add(num_list[i]);
                        }
                    }
                    PrintList(filtered_list);
                    break;
                case 2:
                    Console.Write("Input the limit: ");
                    limit = Convert.ToInt32(Console.ReadLine());
                    filtered_list = new List<int>();
                    for (int i = 0; i < num_list.Count; i++)
                    {
                        if (filtration_belowe(num_list[i], limit))
                        {
                            filtered_list.Add(num_list[i]);
                        }
                    }
                    PrintList(filtered_list);
                    break;
                case 3:
                    flag = false;
                    break;
                default:
                    Console.Write("Something went wrong, try again.");
                    break;
            }
        }

        flag = true;
        LambdaListFiltration lambda_filtration_above = (List<int> list, int limit) =>
        {
            List<int> filtered_list = (from i in list where i >= limit select i).ToList();
            return filtered_list;
        };
        LambdaListFiltration lambda_filtration_belowe = (List<int> list, int limit) =>
        {
            List<int> filtered_list = (from i in list where i <= limit select i).ToList();
            return filtered_list;
        };
        Console.Write("Task 3. List filtration with lambda." +
            "\n1) Filtr list by numbers above the inputed limit;" +
            "\n2) Filtr list by numbers belowe the inputed limit;" +
            "\n3) End.");
        while (flag)
        {
            Console.Write("\n--> ");
            int action = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (action)
            {
                case 1:
                    Console.Write("Input the limit: ");
                    int limit = Convert.ToInt32(Console.ReadLine());
                    List<int> filtered_list = lambda_filtration_above(num_list, limit);
                    PrintList(filtered_list);
                    break;
                case 2:
                    Console.Write("Input the limit: ");
                    limit = Convert.ToInt32(Console.ReadLine());
                    filtered_list = lambda_filtration_belowe(num_list, limit);
                    PrintList(filtered_list);
                    break;
                case 3:
                    flag = false;
                    break;
                default:
                    Console.Write("Something went wrong, try again.");
                    break;
            }
        }
    }
}
// signature Task 1
// делегат для операцій
delegate int MathOperation(int x, int y);
// клас з діями
public class _MathOperation
{
    public int Addition(int x, int y) { return x + y; }
    public int Subtraction(int x, int y) { return x - y; }
    public int Multiply(int x, int y) { return x * y; }
    public int Division(int x, int y) { return x / y; }
}

// signatre Task 2
// делегат
delegate bool Filtration(int number, int limit);

// signatre Task 3
// делегат
delegate List<int> LambdaListFiltration(List<int> list, int limit);
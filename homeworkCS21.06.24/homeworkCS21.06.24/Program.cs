// event processor
public class EventProcessor
{
    // delegate + event
    public delegate void DataProcessHandler<T>(T result);
    public event DataProcessHandler<string> Notify;
    // method
    public void ProcessData(string input, Func<string, int> process)
    {
        // notifying
        Notify?.Invoke($"- Result: {process(input)}");
    }
}

internal class Program
{
    // method as the way to notify
    public static void PrintToConsole(string message)
    {
        Console.WriteLine(message);
    }
    // method to use as Func, calculates words in Str
    public static int WordsCalculator(string text)
    {
        string[] words_arr = text.Split(' ');
        return words_arr.Length;
    }

    private static void Main(string[] args)
    {
        Operation addition = new _Operations().Addition;
        Operation subtraction = new _Operations().Subtraction;
        Operation multiply = new _Operations().Multiply;
        Operation division = new _Operations().Division;
        // lambda
        Calculator calculator = (int x, int y, Operation operation) =>
        {
            return operation(x, y);
        };

        bool flag = true;
        Console.Write("Task 1. Calculator." +
            "\n1) Start;" +
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
                    Console.Write("Operation, 1) '+' 2) '-' 3) '*' 4) '/': ");
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            Console.WriteLine($"Addition: {first_num} + {second_num} = {calculator(first_num, second_num, addition)}");
                            break;
                        case 2:
                            Console.WriteLine($"Addition: {first_num} - {second_num} = {calculator(first_num, second_num, subtraction)}");
                            break;
                        case 3:
                            Console.WriteLine($"Addition: {first_num} * {second_num} = {calculator(first_num, second_num, multiply)}");
                            break;
                        case 4:
                            Console.WriteLine($"Addition: {first_num} / {second_num} = {calculator(first_num, second_num, division)}");
                            break;
                        default: 
                            Console.WriteLine("Smth went wrong..");
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

        // random text to process
        string text_1 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit," +
            " sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." +
            " Elit ut aliquam purus sit amet luctus venenatis lectus magna. Porta non pulvinar neque laoreet suspendisse." +
            " Sapien eget mi proin sed libero enim sed. Amet facilisis magna etiam tempor orci eu lobortis.";
        string text_2 = "Felis bibendum ut tristique et egestas quis ipsum suspendisse ultrices." +
            " Tempor commodo ullamcorper a lacus vestibulum sed. Sed ullamcorper morbi tincidunt ornare massa eget egestas." +
            " Tempor nec feugiat nisl pretium fusce. Eget est lorem ipsum dolor sit. Vitae tortor condimentum lacinia quis." +
            ". In mollis nunc sed id semper risus. Eget arcu dictum varius duis at consectetur lorem donec. Odio tempor orci dapibus ultrices in.";
        string text_3 = "Sed euismod nisi porta lorem. Eget mauris pharetra et ultrices neque ornare. Eget felis eget nunc lobortis mattis aliquam faucibus purus." +
            " Ornare aenean euismod elementum nisi quis eleifend quam.";
        // event processor
        EventProcessor eventHandler = new EventProcessor();
        eventHandler.Notify += PrintToConsole;

        flag = true;
        Console.Write("Task 2. EventProcessor(calculates words quantity in string)." +
            "\n1) Start;" +
            "\n2) End.");
        while (flag)
        {
            Console.Write("\n--> ");
            int action = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (action)
            {
                case 1:
                    // зробив все через метод виводу
                    PrintToConsole("--- First text:");
                    PrintToConsole(text_1);
                    eventHandler.ProcessData(text_1, WordsCalculator);

                    PrintToConsole("--- Second text:");
                    PrintToConsole(text_2);
                    eventHandler.ProcessData(text_2, WordsCalculator);

                    PrintToConsole("--- Third text:");
                    PrintToConsole(text_3);
                    eventHandler.ProcessData(text_3, WordsCalculator);
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

// delagete for math operations
delegate int Operation(int x, int y);
// delegate for lambda
delegate int Calculator(int x, int y, Operation operation);
// operations
public class _Operations
{
    public int Addition(int x, int y) { return x + y; }
    public int Subtraction(int x, int y) { return x - y; }
    public int Multiply(int x, int y) { return x * y; }
    public int Division(int x, int y) { return x / y; }
}
internal class Folder
{
    public string _action;
    public string _time;

    public Folder(string action, string time)
    {
        this._action = action;
        this._time = time;
    }

    public void Print()
    {
        Console.WriteLine($"{_time}) {_action};");
    }
}

internal class Calculator
{
    public List<Folder> _actions_story_list { get; set; }

    public Calculator()
    {
        _actions_story_list = new List<Folder>();
    }

    public void Action()
    {
        Console.WriteLine("Choose your action(+, -, *, /):");
        string action = Console.ReadLine();
        Console.WriteLine("Write your numbers:");
        int num_1 = Convert.ToInt32(Console.ReadLine());
        int num_2 = Convert.ToInt32(Console.ReadLine());
        int result = 0;
        if (action == "+")
        {
            result = num_1 + num_2;
        }
        else if (action == "-")
        {
            result = num_1 - num_2;
        }
        else if (action == "*")
        {
            result = num_1 * num_2;
        }
        else if (action == "/")
        {
            result = num_1 / num_2;
        }
        string time = DateTime.Now.ToString("HH:mm");
        string action_showcase = $"{num_1} {action} {num_2} = {result}";
        Folder folder = new Folder(action_showcase, time);
        _actions_story_list.Add(folder);
        Console.WriteLine($"{num_1} {action} {num_2} = {result}");
    }
    public void PrintStoryList()
    {
        for (int i = 0; i < _actions_story_list.Count; i++)
        {
            Console.Write($"{i+1}. ");
            _actions_story_list[i].Print();
        }
    }
}



internal class Program
{
    static public int LetterCounter(string text)
    {
        int count = 0;
        // text = text.ToLower();
        foreach (var item in text.ToLower())
        {
            if(item == 'a' || item == 'e' || item == 'i' || item == 'o' || item == 'u')
            {
                count++;
            }   
        }
        return count;
    }

    private static void Main(string[] args)
    {
        Calculator calculator = new Calculator();
        bool flag = true;
        Console.Write("Task 1. Calculator with story list.\n1) Do action;\n2) Print story;\n3) next task.");
        while (flag)
        {
            Console.Write("\n--> ");
            int action = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (action)
            {
                case 1:
                    calculator.Action();
                    break;
                case 2:
                    calculator.PrintStoryList();
                    break;
                case 3:
                    flag = false;
                    break;
                default:
                    break;
            }
        }
        flag = true;
        Console.WriteLine("Task 2. Program that counts a, e, i, o, u in line.\n1) Write line;\n2) End.");
        //a, e, i, o, u)
        while (flag)
        {
            Console.Write("\n--> ");
            int action = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (action)
            {
                case 1:
                    Console.Write("Your text: ");
                    Console.WriteLine($"Letter count: {LetterCounter(Console.ReadLine())}");
                    break;
                case 2:
                    flag = false;
                    break;
                default:
                    break;
            }
        }
    }
}
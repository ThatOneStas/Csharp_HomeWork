using System.Text.RegularExpressions;
using homeworkCS10._06._24.Exceptions;

// global
public static class Globals
{
    // variables
    public static User CURRENT_USER = null;
    public static List<User> USER_LIST = [
        new User("Rohan","simple@host.com","qwerty123"),
        new User("Jotaro Kujo", "jojo@gmail.com", "star_dust"),
        new User("John Doe", "johndoe@host.edu.com", "password1"),
    ];
    // regex for email checking
    public static Regex EMAIL_REGEX = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
    // methods
    public static void addNewUser() // creating and imidiately adding it to global list
    {
        string name = null;
        string email = null;
        string password = null;

        bool flag = true;
        // name
        while (flag)
        {
            Console.Write("Input your name: ");
            name = Console.ReadLine();
            try
            {
                for (int i = 0; i < USER_LIST.Count; i++)
                {
                    if (USER_LIST[i]._name.ToLower() == name.ToLower())
                    {
                        throw new NameAlreadyExists("Current name already exists.");
                    }
                }
                flag = false;
            }
            catch (NameAlreadyExists msg)
            {
                flag = true;
                Console.WriteLine($"{msg.Message} Try again.");
            }
        }
        flag = true;
        // email
        while (flag)
        {
            Console.Write("Input your email: ");
            email = Console.ReadLine();
            try
            {
                for (int i = 0; i < USER_LIST.Count; i++)
                {
                    if (USER_LIST[i]._email == email)
                    {
                        throw new EmailAlreadyExists("Current email already exists.");
                    }
                }
                try
                {
                    if (!EMAIL_REGEX.IsMatch(email))
                    {
                        throw new IncorrectEmail("FORM");
                    }
                    if (email.Contains("bk.ru") || email.Contains("mail.ru"))
                    {
                        throw new IncorrectEmail("TYPE_BANNED");
                    }
                }
                catch (IncorrectEmail msg)
                {
                    if (msg.Message == "FORM")
                    {
                        throw new IncorrectEmailForm("Incorrect email form, use email@(your type).");
                    }
                    if (msg.Message == "TYPE_BANNED")
                    {
                        throw new IncorrectEmailForm("Banned domains, banned: 'mail.ru' or 'bk.ru'.");
                    }
                }
                flag = false;
            }
            catch (IncorrectEmailForm msg)
            {
                flag = true;
                Console.WriteLine($"{msg.Message} Try again.");
            }
            catch (IncorrectEmailType msg)
            {
                flag = true;
                Console.WriteLine($"{msg.Message} Try again.");
            }
            catch (EmailAlreadyExists msg)
            {
                flag = true;
                Console.WriteLine($"{msg.Message} Try again.");
            }
        }
        flag = true;
        // password
        while (flag)
        {
            Console.Write("Input your password: ");
            password = Console.ReadLine();
            try
            {
                if(password.Length < 8)
                {
                    throw new PasswordIsTooShort("Password is too short, it has to contain atleast 8 symbols.");
                }
                flag = false;
            }
            catch (PasswordIsTooShort msg)
            {
                flag = true;
                Console.WriteLine($"{msg.Message} Try again.");
            }
        }
        USER_LIST.Add(new User(name, email, password));
    }
    // login - changing current for another one
    public static void logIn()
    {
        string name = null;
        string email = null;
        string password = null;
        User user_to_login = null;

        bool flag = true;
        // name
        while (flag)
        {
            Console.Write("Input name: ");
            name = Console.ReadLine();
            try
            {
                for (int i = 0; i < USER_LIST.Count; i++)
                {
                    if (USER_LIST[i]._name.ToLower() == name.ToLower())
                    {
                        user_to_login = USER_LIST[i];
                    }
                }
                if(user_to_login == null)
                {
                    throw new NameNotFound("User with this name doesn`t exist.");
                }
                flag = false;
            }
            catch (NameNotFound msg)
            {
                flag = true;
                Console.WriteLine($"{msg.Message} Try again.");
            }
        }
        flag = true;
        // email
        while (flag)
        {
            Console.Write("Input email: ");
            email = Console.ReadLine();
            try
            {
                try
                {
                    if (!EMAIL_REGEX.IsMatch(email))
                    {
                        throw new IncorrectEmail("FORM");
                    }
                    if (email.Contains("bk.ru") || email.Contains("mail.ru"))
                    {
                        throw new IncorrectEmail("TYPE_BANNED");
                    }
                    if (email != user_to_login._email)
                    {
                        throw new IncorrectEmail("NOTFOUND");
                    }
                }
                catch (IncorrectEmail msg)
                {
                    if (msg.Message == "FORM")
                    {
                        throw new IncorrectEmailForm("Incorrect email form, use email@(your type).");
                    }
                    if (msg.Message == "TYPE_BANNED")
                    {
                        throw new IncorrectEmailForm("Banned domains, banned: 'mail.ru' or 'bk.ru'.");
                    }
                    if (msg.Message == "NOTFOUND")
                    {
                        throw new IncorrectEmail("Emails don`t match.");
                    }
                }
                flag = false;
            }
            catch (IncorrectEmailForm msg)
            {
                flag = true;
                Console.WriteLine($"{msg.Message} Try again.");
            }
            catch (IncorrectEmailType msg)
            {
                flag = true;
                Console.WriteLine($"{msg.Message} Try again.");
            }
            catch (IncorrectEmail msg)
            {
                flag = true;
                Console.WriteLine($"{msg.Message} Try again.");
            }
            catch (EmailAlreadyExists msg)
            {
                flag = true;
                Console.WriteLine($"{msg.Message} Try again.");
            }
        }
        flag = true;
        // passwrod
        while (flag)
        {
            Console.Write("Input password: ");
            password = Console.ReadLine();
            try
            {
                if (password.Length < 8)
                {
                    throw new PasswordIsTooShort("Password is too short, it has to contain atleast 8 symbols.");
                }
                else if (password != user_to_login._password)
                {
                    throw new IncorrectPassword("Passwords don`t match.");
                }
                flag = false;
            }
            catch (PasswordIsTooShort msg)
            {
                flag = true;
                Console.WriteLine($"{msg.Message} Try again.");
            }
            catch (IncorrectPassword msg)
            {
                flag = true;
                Console.WriteLine($"{msg.Message} Try again.");
            }
        }
        CURRENT_USER = user_to_login;
    }
    public static void printList()
    {
        for(int i = 0; i <  USER_LIST.Count; i++)
        {
            Console.WriteLine($"{USER_LIST[i]._name}, {USER_LIST[i]._email}");
        }
    }
    public static void addCurrentUser()
    {
        USER_LIST.Add(CURRENT_USER);
    }
    public static void delCurrentUser()
    {
        USER_LIST.Remove(CURRENT_USER);
    }
}

// user class
public class User
{
    public string _name;
    public string _email;
    public string _password;
    public User(string name, string email, string password) // constructor
    {
        _name = name;
        _email = email;
        _password = password;
    }
    public void printInfo()
    {
        Console.WriteLine($"Name: {_name}, Email: {_email}, Password: {_password}");
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        bool flag = true;
        // я зробив його чуток по своєму.
        // буде регестрація з її обробкою та
        // вхід який також буде мати свою обробку
        Console.Write("Task 1. UserRegistration (my edition):" +
            "\n1) Print user list;" +
            "\n2) Print current user;" +
            "\n3) Log In (you have to know name, email, password of existsing user);" +
            "\n4) Create new user (after creating you will have to login anyways);" +
            "\n5) Delete current user from list;" +
            "\n6) Add current user back.");
        while (flag)
        {
            Console.Write("\n--> ");
            int action = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (action)
            {
                case 1:
                    Globals.printList();
                    break;
                case 2:
                    if(Globals.CURRENT_USER != null) 
                    { 
                        Globals.CURRENT_USER.printInfo();
                    }
                    else
                    {
                        Console.WriteLine("Login as current user is NULL.");
                    }  
                    break;
                case 3:
                    Globals.logIn();
                    break;
                case 4:
                    Globals.addNewUser();
                    break;
                case 5:
                    Globals.delCurrentUser();
                    break;
                case 6:
                    Globals.addCurrentUser();
                    break;
                default:
                    Console.Write("Something went wrong, try again.");
                    break;
            }
        }
    }
}
using System.Numerics;

namespace Class_Library.Models;

public class TemperatureConverter
{
    public void ConvertTemp()
    {
        Console.WriteLine("Input the current temp type:\n1) Celsius; 2) Fahrenheit; 3) Kelvin.");
        bool flag = true;
        int current_type = 0;
        while (flag)
        {
            Console.Write("--> ");
            current_type = Convert.ToInt32(Console.ReadLine());
            if (current_type == 0) { Console.WriteLine("Oops. Wrong key. Try again."); flag = true; }
            else { flag = false; }
        }

        Console.WriteLine("Input the temp.");
        Console.Write("--> ");
        double current_temp = Convert.ToDouble(Console.ReadLine());
        double end_temp = 0;

        Console.WriteLine("Input the temp type you want to convert in:\n1) Celsius; 2) Fahrenheit; 3) Kelvin.");
        flag = true;
        int end_type = 0;
        while (flag)
        {
            Console.Write("--> ");
            end_type = Convert.ToInt32(Console.ReadLine());
            if (end_type == 0) { Console.WriteLine("Oops. Wrong key. Try again."); flag = true; }
            else { flag = false; }
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
                    end_temp = current_temp * 9 / 5 + 32;
                    Console.WriteLine($"Converted from {current_temp}°C to {end_temp}°F");
                }
                else if (end_type == 3)
                {
                    end_temp = current_temp + 273.15;
                    Console.WriteLine($"Converted from {current_temp}°C to {end_temp}°K");
                }
                break;
            case 2:
                if (end_type == 1)
                {
                    end_temp = (current_temp - 32) * 5 / 9;
                    Console.WriteLine($"Converted from {current_temp}°F to {end_temp}°C");
                }
                else if (end_type == 2)
                {
                    end_temp = current_temp;
                    Console.WriteLine($"Converted from {current_temp}°F to {end_temp}°F");
                }
                else if (end_type == 3)
                {
                    end_temp = (current_temp + 459.67) * 5 / 9;
                    Console.WriteLine($"Converted from {current_temp}°F to {end_temp}°K");
                }
                break;
            case 3:
                if (end_type == 1)
                {
                    end_temp = current_temp - 273.15;
                    Console.WriteLine($"Converted from {current_temp}°K to {end_temp}°C");
                }
                else if (end_type == 2)
                {
                    end_temp = current_temp * 9 / 5 - 459.67;
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
    }
}
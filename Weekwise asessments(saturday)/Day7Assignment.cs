using System;

class HelloWorld
{
    static void Main()
    {
        Console.WriteLine("Enter <GateCode>|<UserInitial>|<AccessLevel>|<IsActive>|<Attempts> separated by '|': ");
        
        string input = Console.ReadLine();
        string[] inputs = input.Split('|');

        string gcode = inputs[0];
        char uinit = char.Parse(inputs[1]);
        byte alevel = byte.Parse(inputs[2]);
        bool isactive = bool.Parse(inputs[3]);
        byte attempts = byte.Parse(inputs[4]);

        Console.WriteLine("\n--- Access Log ---");
        Console.WriteLine($"Gate Code    : {gcode,6}");
        Console.WriteLine($"User Initial : {uinit,6}");
        Console.WriteLine($"Access Level : {alevel,6}");
        Console.WriteLine($"Is Active    : {isactive,6}");
        Console.WriteLine($"Attempts     : {attempts,6}");

        Console.WriteLine("\nStatus:");

        if (
            gcode.Length != 2 ||
            !char.IsLetter(gcode[0]) ||
            !char.IsDigit(gcode[1]) ||
            !char.IsLetter(uinit) ||
            alevel < 1 || alevel > 7 ||
            attempts > 200
        )
        {
            Console.WriteLine("Invalid Access Log ...");
        }
        else if (!isactive)
        {
            Console.WriteLine("Access Denied - Invalid User");
        }
        else if (attempts > 100)
        {
            Console.WriteLine("Access Denied - Too Many Attempts");
        }
        else if (alevel > 5)
        {
            Console.WriteLine("Access Granted - HIGH SECURITY");
        }
        else
        {
            Console.WriteLine("Access Granted - STANDARD SECURITY");
        }
    }
}

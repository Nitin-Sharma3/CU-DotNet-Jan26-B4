using System;
using System.Collections.Generic;

namespace Assignment
{
    internal class TheSecureTerminal
    {
        static void Main(string[] args)
        {
            int pin = 1234;
            string s = string.Empty;

            Console.WriteLine("Enter the pin:");

            int pincount = 4;
            while (pincount != 0)
            {
                ConsoleKeyInfo ch = Console.ReadKey(true);

                if (char.IsDigit(ch.KeyChar))
                {
                    Console.Write("*");
                    s += ch.KeyChar;
                    pincount--;
                }
                else if (ch.Key == ConsoleKey.Backspace && s.Length > 0) {
                    Console.Write("\b \b");
                    s= s.Substring(0, s.Length - 1);
                    pincount++;
                }
            }
            int enteredPin = int.Parse(s);

            Console.WriteLine();

            if (enteredPin == pin)
                Console.WriteLine("Access verified!");
            else
                Console.WriteLine("Incorrect pin!");
        }
    }
}

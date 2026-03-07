using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
//    Assignment: The Daily Logger
//Objective: Create a console application that prompts a user for a "Daily Reflection."
//Every time the program runs, it should save the user's input to a file named journal.txt.
//Crucially, it must not overwrite previous entries; it must add them to the end of the file.

//Step 1: The Code Implementation
//You can use the StreamWriter constructor that accepts a file path and a boolean for append mode.

//Key Technical Details
//The Boolean Toggle: In new StreamWriter(filePath, true), the true tells the system to
//seek the end of the file before writing.If you set it to false (or omit it), the file is overwritten.
    internal class DailyLogger
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Daily Logger");
            Console.WriteLine("Enter today's Daily activity:");
            string file = @"..\..\..\journal.txt";
            string message = Console.ReadLine();
            using (StreamWriter S1 = new StreamWriter(file, true))
            {
                S1.WriteLine(message);
            }
            Console.WriteLine("Your Current Record :");
            using StreamReader S2 = new StreamReader(file);
            do
            {
                string line = S2.ReadLine();
                if (line == null) break;
                else
                    Console.WriteLine(line);
            } while (true);

        }
    }
}

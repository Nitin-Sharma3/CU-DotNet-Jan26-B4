using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
//Assignment: The Loan Portfolio Manager
//Objective: Create a Loan class, save a list of loan objects to a CSV file,
//and then read them back to identify which loans are "High Risk" based on their interest rate.

//Step 1: Define the Data Structure
//First, we need a simple class to represent our Loan.
//C#

//public class Loan
//{
//    public string ClientName { get; set; }
//    public double Principal { get; set; }
//    public double InterestRate { get; set; } // e.g., 5.5 for 5.5%
//}

//Step 2: The Implementation
//This code should demonstrate writing multiple objects and then parsing them back into a collection.
//Critical Concepts to Note
//•	The CSV Format: We use line.Split(',') to turn a single string into an array. This is the foundation of data parsing in C#.

//•	The Header: Notice we write a header row so humans can read the file in Excel, but we must
//use reader.ReadLine() once before the loop to "skip" it so it doesn't crash our math logic.
//•	The "C" Formatter: Using: C inside a string interpolation (e.g., {principal:C}) automatically
//formats the number as local currency.
//Your Challenge Tasks
//1.	Append Mode: Modify the "Write" section so that instead of overwriting the file,
//it asks the user for a new loan's details and appends it to the existing CSV.
//2.Calculated Field: In the "Read" section, calculate the total interest amount
//(Principal * Rate / 100) and display it alongside the name.
//3.	Data Safety: Wrap the double.Parse in a try-catch block or use double.
//TryParse to prevent the program from crashing if the CSV has a typo.

//Interest calculation logic:
//•	High Risk: Interest Rate > 10%
//•	Medium Risk: Interest Rate between 5% and 10%
//•	Low Risk: Interest Rate< 5%





namespace ExceptionHandling
{
    class Loan
    {
        public string ClientName { get; set; }
        public double Principle { get; set; }
        public double InterestRate { get; set; }
        public string RiskLevel { get; set; }
        public override string ToString()
        {
            return $"{ClientName,-10}|{Principle,15:C2}|{InterestRate,12}|{RiskLevel,-20}";
        }
    }
    internal class TheLoanPortfolioManager
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            using StreamWriter S1 = new StreamWriter(@"..\..\..\Data.csv",true);
            List<Loan> L = new List<Loan>();
            FileInfo V = new FileInfo(@"..\..\..\Data.csv");
            if (V.Length == 0)
            {
                S1.WriteLine($"{"CLIENT",-10}|{"PRINCPILE",15}|{"INTEREST",12}|{"RISK LEVEL",-20}");
                S1.WriteLine("----------------------------------------------------------------");
            }
            try
            {
                while (true)
                {
                    Console.WriteLine("Write name,principle,InterestRate" +
                        " separated by comma(,) or write \"STOP\" to exit!");
                    string[] a = Console.ReadLine().Split(',');
                    if (a[0] == "STOP") break;
                    double princ;
                    bool q = double.TryParse(a[1], out princ);
                    double inter;
                    bool w = double.TryParse(a[2],out inter);
                    string Risky=string.Empty;
                    if (inter < 5) Risky = "LOW";
                    else if ((inter >= 5) && (inter <= 10)) Risky = "MEDIUM";
                    else if (inter > 10) Risky= "HIGH";
                    L.Add(new() { ClientName = a[0], InterestRate = inter, Principle = princ,RiskLevel=Risky });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("EXCEPTION OCCURED");
            }
            foreach (Loan l in L)
            {
                S1.WriteLine(l.ToString());
            }

        }

    }
}

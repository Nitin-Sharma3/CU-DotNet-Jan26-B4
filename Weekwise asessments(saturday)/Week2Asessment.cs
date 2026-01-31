using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CSharpLearning
{
    internal class Week2Asessment
    {
        static string[] GetInput(int num)
        {
            string[] s = new string[5];
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine($"Write name of policy holder {i + 1}: ");
                string name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("The name is Empty.Please try again");
                    i--;
                }
                else
                    s[i] = name;
            }
            return s;
        }
        static decimal[] GetPremium(int num)
        {
            decimal[] marks = new decimal[num];
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine($"Write premiuim of {i + 1} customer: ");
                decimal a = decimal.Parse(Console.ReadLine());
                if (a <= 0)
                {
                    i--;
                    Console.WriteLine("INVALID Premium mentioned, TRY AGAIN! ");
                }
                else
                    marks[i] = a;
            }
            return marks;
        }

        static void Main(string[] args)
        {

            string[] policyHolderNames = GetInput(5);
            decimal[] annualPremiums = GetPremium(5);
            decimal total, avg, high, low;
            total = 0m;
            high = annualPremiums.Max();
            low= annualPremiums.Min();
            for (int i = 0;i < annualPremiums.Length; i++)
            {
                total += annualPremiums[i];
            }
            avg = annualPremiums.Average();
            Console.WriteLine("Insurance Premium Summary");
            Console.WriteLine("----------------------------");
            Console.WriteLine($"{"Name",-12}{"Premium",-12}{"Category",-12}");
            for (int i = 0; i < 5; i++)
            {
                string category=string.Empty;
                if (annualPremiums[i] < 10000) category = "LOW";
                else if (annualPremiums[i] > 10000 && annualPremiums[i] < 25000) category = "MEDIUM";
                else category = "HIGH";
                Console.WriteLine($"{policyHolderNames[i],-12}{annualPremiums[i],-12:F2}{category,-12}");
            }
            Console.WriteLine("......");
            Console.WriteLine("-----------------------------------------------");
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"{"Total Premium",-15}:{total:C}");
            Console.WriteLine($"{"Average Premium",-15}:{avg:F2}");
            Console.WriteLine($"{"Highest Premium",-15}:{high:F2}");
            Console.WriteLine($"{"Lowest Premiuim",-15}:{low:F2}");

        }
    }
}

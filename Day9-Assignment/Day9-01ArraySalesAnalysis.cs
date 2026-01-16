using System.ComponentModel.Design;
using System.Threading.Channels;
using System.Transactions;

namespace CSharpLearning
{
    internal class Day9_01ArraySalesAnalysis
    {
        static void Main(string[] args)
        {
            decimal[] sales = new decimal[7];
            for (int i = 0; i < sales.Length; i++)
            {
                Console.WriteLine($"Enter day {i+1} sale: ");
                string a = Console.ReadLine();
                decimal temp = decimal.Parse(a);
                sales[i] = temp;
                if (!(temp > 0))
                {
                    i--;
                    Console.WriteLine("Invalid entry try again...");
                }
            }
            decimal sum = 0m;
            decimal high = 0m;
            decimal low = decimal.MaxValue;
            for (int i = 0; i < sales.Length; i++)
            {
                sum += sales[i];
                high = Math.Max(high, sales[i]);
                low = Math.Min(low, sales[i]);
            }
            Console.WriteLine($"Total Sales: {sum:F2}");
            Console.WriteLine($"Average Daily Sale: {(sum / 7m):F2}");
            Console.WriteLine($"Highest Sale: {high:F2}");
            Console.WriteLine($"Lowest Sale: {low:F2}");
            int abovedays=0;
            string[] strsales = new string[7];
            for (int i = 0; i < sales.Length; i++)
            {
                if (sales[i] > (sum / 7m)) abovedays++;
                if (sales[i] > 0 && sales[i] < high / 3) strsales[i] = "LOW";
                else if (sales[i] > high / 3 && sales[i] < (high / 3) * 2) strsales[i] = "MEDIUM";
                else if (sales[i] > (high / 3) * 2 && sales[i] <= high) strsales[i] = "HIGH";
            }
            Console.WriteLine($"Days above average: {abovedays}");
            for (int i = 0; i < strsales.Length; i++) {
                Console.WriteLine($"Day {i+1} sales : {strsales[i]}");
            }
        }
    }
}

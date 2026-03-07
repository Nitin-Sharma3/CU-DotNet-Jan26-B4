using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Player
    {
        public string Name { get; set; }
        public int RunsScored { get; set; }
        public int BallsFaced { get; set; }
        public bool IsOut { get; set; }
        public double StrikeRate { get; set; }
        public double Average { get; set; }
        public override string ToString()
        {
            return $"{Name,-15}{RunsScored,10}{StrikeRate,7}{Average,8}";
        }
    }
    internal class CricketPlayerPerformanceTracker
    {
        static void Main(string[] args)
        {
            List<Player> L = new List<Player>();
            using (StreamReader reader = new StreamReader(@"..\..\..\players.csv")) {
                try
                {
                    do
                    {
                        string l = reader.ReadLine();
                        if (l == null) break;
                        string[] p = l.Split(',');
                        double SR = (int.Parse(p[1]) / int.Parse(p[2])) * 100;
                        L.Add(new() { Name = p[0], RunsScored = int.Parse(p[1]), BallsFaced = int.Parse(p[2]), IsOut = bool.Parse(p[3]), StrikeRate = SR, Average = int.Parse(p[1]) });


                    } while (true);
                }catch(Exception e) {
                    Console.WriteLine("An error occured. Please check the entries again");
                }
            }
            using StreamWriter writer = new StreamWriter(@"..\..\..\Cricket.txt");
            FileInfo F = new FileInfo(@"..\..\..\Cricket.txt");
            if (F.Length == 0)
            {
                writer.WriteLine($"{"NAME",-15}{"RUNS",10}{"SR",7}{"AVG",8}");
                writer.WriteLine("----------------------------------------------------");
            }
            foreach (Player p in L)
            {
                writer.WriteLine(p.ToString());
            }
        }
    }
}

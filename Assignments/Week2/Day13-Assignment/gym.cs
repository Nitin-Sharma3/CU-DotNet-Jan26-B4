using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CSharpLearning
{
    internal class gym
    {
        static void gymtotal()
        {
            while (true)
            {
                bool cardio, join, weight, zumba;
                decimal total = 0m;

                Console.WriteLine("Do you want to join the gym ?(true/false)");
                join = bool.Parse(Console.ReadLine());

                if (!join)
                {
                    Console.WriteLine("Thank you! have a nice day!");
                    return;
                }

                total += 1000;

                Console.WriteLine("Do you want cardio classes?(true/false)");
                cardio = bool.Parse(Console.ReadLine());
                if (cardio) total += 300;

                Console.WriteLine("Do you want to do weight training?(true/false)");
                weight = bool.Parse(Console.ReadLine());
                if (weight) total += 500;

                Console.WriteLine("Do you want to do Zumba classes?(true/false)");
                zumba = bool.Parse(Console.ReadLine());
                if (zumba) total += 250;

                if (!zumba && !weight && !cardio)
                {
                    Console.WriteLine("Apply for at least one service. Try again!");
                    Console.WriteLine("-----------------------------------");
                    continue;
                }

                Console.WriteLine("After applying GST...");
                total += total * 0.05m;
                Console.WriteLine($"Your total : {total:F2}");
                break;
            }
        }

        static void Main(string[] args)
            {
                gymtotal();
            }
        }
    }


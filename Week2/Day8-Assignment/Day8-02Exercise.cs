using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning
{
    internal class Day8_02Exercise
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the bank details: ");
            string bankdetails = Console.ReadLine(); //take from user 
            string refined = bankdetails.Trim(); // remove spaces 
            refined = string.Join(" ", refined.Split(' ',StringSplitOptions.RemoveEmptyEntries)); //remove inbetween spaces
            //pehle ye split krta h removing the spaces and then ye single spaced ko join krdeta h 
            refined = refined.ToLower();//convert to lower case
            string[] detail = refined.Split('#');//# se split krdiya ek array me 

            Console.WriteLine($"Transaction id : {detail[0]}");
            Console.WriteLine($"Account Holder : {detail[1]}");
            Console.WriteLine($"Narration : {detail[2]}");
            Console.Write("Category : ");

            if ((refined.Contains("deposit") ||
                refined.Contains("withdrawal")||
                refined.Contains("transfer")))
            {
                if(refined == bankdetails) Console.WriteLine("STANDARD TRANSACTION");
                else
                {
                    Console.WriteLine("CUSTOM TRANSACTION");
                }
            }
            else
            {
                Console.WriteLine("NON FINANCIAL TRANSACTION");
            }



        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_week4
{
    class Loan
    {
        public string LoanNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal PrincipalAmount { get; set; }
        public int TenureInYears { get; set; }
        public Loan()
        {
            LoanNumber = string.Empty;
            CustomerName = string.Empty;
            PrincipalAmount = 0;
            TenureInYears = 0;
        }
        public Loan(string loanNumber, string customerName, decimal principalAmount, int tenureInYears)
        {
            LoanNumber = loanNumber;
            CustomerName = customerName;
            PrincipalAmount = principalAmount;
            TenureInYears = tenureInYears;
        }
        public decimal CalculateEmi()
        {
            decimal si = (PrincipalAmount * 10 * TenureInYears) / 100;
            decimal payingamt = PrincipalAmount + si;
            return payingamt/(12*TenureInYears);
        }
    }
    class HomeLoan : Loan
    {
        public new decimal CalculateEmi()
        {
            decimal si = (PrincipalAmount * 8* TenureInYears) / 100;
            decimal processingfee = 1 * PrincipalAmount / 100;
            decimal payingamt = PrincipalAmount + si+processingfee;
            return payingamt / (12 * TenureInYears);
        }
        public HomeLoan(string loanNumber, string customerName, decimal principalAmount, int tenureInYears):base(loanNumber,customerName,principalAmount,tenureInYears)
        {
            LoanNumber = loanNumber;
            CustomerName = customerName;
            PrincipalAmount = principalAmount;
            TenureInYears = tenureInYears;
        }
    }
    class CarLoan : Loan
    {
        public new decimal CalculateEmi()
        {
            decimal si = (PrincipalAmount * 9 * TenureInYears) / 100;
            decimal payingamt = PrincipalAmount + si + 15000;
            return payingamt / (12 * TenureInYears);
        }
        public CarLoan(string loanNumber, string customerName, decimal principalAmount, int tenureInYears) : base(loanNumber, customerName, principalAmount, tenureInYears)
        {
            LoanNumber = loanNumber;
            CustomerName = customerName;
            PrincipalAmount = principalAmount;
            TenureInYears = tenureInYears;
        }
    }
    internal class LoanInheritence
    {
        static void Main(string[] args)
        {
            //CarLoan car = new CarLoan("12ab", "Nitin", 10000, 2);
            //Console.WriteLine(car.CalculateEmi());
            //HomeLoan home = new HomeLoan("12bc", "Tintin", 10000, 2);
            //Console.WriteLine(home.CalculateEmi());
            Loan[] arr =
            {
                new HomeLoan("1111","Lovely",10000,3),
                new HomeLoan("1112","Aniket",150000,4),
                new CarLoan("1","Abhishek",10000,3),
                new CarLoan("2","Aryan",23000,2)
            };
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(Math.Round(arr[i].CalculateEmi(),2));
            }
        }
    }
}

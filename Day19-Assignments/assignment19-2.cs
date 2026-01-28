using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    abstract class UtilityBill
    {
        public int ConsumerId { get; set; }
        public string ConsumerName { get; set; }
        public decimal UnitsConsumed { get; set; }
        public decimal RatePerUnit { get; set; }
        public abstract decimal CalculateBillAmount();
        public virtual decimal CalculateTax(decimal billamount)
        {
            return billamount*0.05m; 
        }
        protected UtilityBill(int id,string name,decimal units,decimal rate)
        {
            ConsumerId = id;
            ConsumerName = name;
            UnitsConsumed = units;
            RatePerUnit= rate;
        }
        public string PrintBill()
        {
            decimal a = CalculateBillAmount();
            a += CalculateTax((UnitsConsumed*RatePerUnit));
            return new string($"ConsumerId - {ConsumerId}\n" +
                $"Units Consumed - {UnitsConsumed}\n" +
                $"Rate per unit - {RatePerUnit}\n" +
                $"Payable amount(including tax) - {a}");
        }
    }
    class ElectricityBill : UtilityBill
    {
        public ElectricityBill(int id, string name, decimal units, decimal rate):base(id,name,units,rate)
        {
            ConsumerId = id;
            ConsumerName = name;
            UnitsConsumed = units;
            RatePerUnit = rate;
        }
        public override decimal CalculateBillAmount()
        {
            if (UnitsConsumed > 300)return  RatePerUnit*UnitsConsumed * 0.1m;
            else
                return RatePerUnit * UnitsConsumed;
        }
        public override decimal CalculateTax(decimal billamount)
        {
            return base.CalculateTax(billamount);
        }
    }
    class WaterBill : UtilityBill
    {
        public WaterBill(int id, string name, decimal units, decimal rate):base(id,name,units,rate)
        {
            ConsumerId = id;
            ConsumerName = name;
            UnitsConsumed = units;
            RatePerUnit = rate;
        }
        public override decimal CalculateBillAmount()
        {
            return UnitsConsumed * RatePerUnit;
        }
        public override decimal CalculateTax(decimal billamount)
        {
            return (billamount * 0.02m);
        }
    }
    class GasBill : UtilityBill
    {
        public GasBill(int id, string name, decimal units, decimal rate):base(id,name,units,rate)
        {
            ConsumerId = id;
            ConsumerName = name;
            UnitsConsumed = units;
            RatePerUnit = rate;
        }
        public override decimal CalculateBillAmount()
        {
            return UnitsConsumed * RatePerUnit + 150;
        }
        public override decimal CalculateTax(decimal billamount)
        {
            return 0m;
        }
    }


    internal class assignment19_2
    {
        static void Main(string[] args)
        {
            List<UtilityBill> bills = new List<UtilityBill>()
            {
                new GasBill(1,"Nitin",30,15),
                new ElectricityBill(2,"Aniket",301,40),
                new WaterBill(3,"Arav",22,19)
            };
            foreach (var item in bills)
            {
                Console.WriteLine(item.PrintBill()); ;
            }
        }
    }
}

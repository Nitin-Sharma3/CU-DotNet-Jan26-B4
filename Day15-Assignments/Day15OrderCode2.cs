using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsDemo
{
    class Order
    {
        public int OrderID { get; set; }
        private string customerName;

        public string CustomerName
        {
            get { return customerName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    customerName = value;
                }
            }
        }
        public decimal TotalAmount { get; set; }
        public Order() 
        {
            DateTime now = DateTime.Now;
            Console.WriteLine($"Current Date : {now}");
            Console.WriteLine("Status: NEW");
        }
        public Order(int id, string customerName)
        {
            this.OrderID = id;
            this.CustomerName = customerName;
        }
        public void AddItem(decimal price)
        {
            TotalAmount += price;
        }
        public void ApplyDiscount(decimal percentage)
        {
            if(percentage>=1 && percentage<=30)
            TotalAmount = TotalAmount-(TotalAmount*percentage/100);
        }
        public void GetOrderSummary()
        {
            Console.WriteLine($"OrderID: {OrderID}\nCustomer name: {CustomerName}\nTotal amount: {TotalAmount:C}\n Status: NEW");
        }
    }
    internal class Day15Assignment2
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Order order = new Order(101,"Nitin");
            order.AddItem(500);
            order.AddItem(500);
            order.ApplyDiscount(10);
            order.GetOrderSummary();
        }
    }
}

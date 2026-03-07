using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaaSArchitect
{
    // ABSTRACT BASE CLASS
    abstract class Subscriber : IComparable<Subscriber>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }

        public abstract decimal CalculateMonthlyBill();

        // EQUALITY BASED ON GUID
        public override bool Equals(object obj)
        {
            if (obj is Subscriber other)
                return ID == other.ID;
            return false;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        // SORTING: JoinDate ASC -> Name ASC
        public int CompareTo(Subscriber other)
        {
            int result = JoinDate.CompareTo(other.JoinDate);

            if (result == 0)
                result = Name.CompareTo(other.Name);

            return result;
        }
    }

    // BUSINESS SUBSCRIBER
    class BusinessSubscriber : Subscriber
    {
        public decimal FixedRate { get; set; }
        public decimal TaxRate { get; set; }

        public override decimal CalculateMonthlyBill()
        {
            return FixedRate * (1 + TaxRate);
        }
    }

    // CONSUMER SUBSCRIBER
    class ConsumerSubscriber : Subscriber
    {
        public decimal DataUsageGB { get; set; }
        public decimal PricePerGB { get; set; }

        public override decimal CalculateMonthlyBill()
        {
            return DataUsageGB * PricePerGB;
        }
    }

    // REPORT GENERATOR
    class ReportGenerator
    {
        public static void PrintRevenueReport(IEnumerable<Subscriber> subscribers)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("===== REVENUE REPORT =====");
            sb.AppendLine("Name\t\tType\t\tJoinDate\t\tMonthly Bill");

            foreach (var sub in subscribers)
            {
                string type = sub.GetType().Name;

                sb.AppendLine($"{sub.Name}\t\t{type}\t\t{sub.JoinDate.ToShortDateString()}\t\t{sub.CalculateMonthlyBill():C}");
            }

            Console.WriteLine(sb.ToString());
        }
    }

    class Program
    {
        static void Main()
        {
            // DICTIONARY: Email -> Subscriber
            Dictionary<string, Subscriber> subscribers = new Dictionary<string, Subscriber>();

            // ADD SUBSCRIBERS
            subscribers.Add("corp@company.com",
                new BusinessSubscriber
                {
                    ID = Guid.NewGuid(),
                    Name = "Corporate Ltd",
                    JoinDate = new DateTime(2023, 5, 10),
                    FixedRate = 500,
                    TaxRate = 0.18m
                });

            subscribers.Add("startup@tech.com",
                new BusinessSubscriber
                {
                    ID = Guid.NewGuid(),
                    Name = "Startup Tech",
                    JoinDate = new DateTime(2024, 2, 12),
                    FixedRate = 300,
                    TaxRate = 0.15m
                });

            subscribers.Add("john@gmail.com",
                new ConsumerSubscriber
                {
                    ID = Guid.NewGuid(),
                    Name = "John",
                    JoinDate = new DateTime(2024, 1, 5),
                    DataUsageGB = 50,
                    PricePerGB = 2
                });

            subscribers.Add("emma@gmail.com",
                new ConsumerSubscriber
                {
                    ID = Guid.NewGuid(),
                    Name = "Emma",
                    JoinDate = new DateTime(2023, 12, 20),
                    DataUsageGB = 70,
                    PricePerGB = 2
                });

            subscribers.Add("alex@gmail.com",
                new ConsumerSubscriber
                {
                    ID = Guid.NewGuid(),
                    Name = "Alex",
                    JoinDate = new DateTime(2024, 3, 1),
                    DataUsageGB = 40,
                    PricePerGB = 2
                });

            // SORT BY MONTHLY BILL DESCENDING
            List<KeyValuePair<string, Subscriber>> sortedSubscribers =
                subscribers
                .OrderByDescending(s => s.Value.CalculateMonthlyBill())
                .ToList();

            // EXTRACT SUBSCRIBER LIST
            List<Subscriber> orderedSubs =
                sortedSubscribers.Select(s => s.Value).ToList();

            // POLYMORPHIC REPORT
            ReportGenerator.PrintRevenueReport(orderedSubs);

            Console.ReadLine();
        }
    }
}
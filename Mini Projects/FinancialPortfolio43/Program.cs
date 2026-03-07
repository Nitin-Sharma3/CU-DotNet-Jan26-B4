using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace FinancialPortfolioSystem
{
    // CUSTOM EXCEPTION
    class InvalidFinancialDataException : Exception
    {
        public InvalidFinancialDataException(string msg) : base(msg) { }
    }

    // INTERFACES
    interface IRiskAssessable
    {
        string GetRiskCategory();
    }

    interface IReportable
    {
        string GenerateReportLine();
    }

    // ABSTRACT CLASS
    abstract class FinancialInstrument
    {
        private decimal quantity;
        private decimal purchasePrice;
        private decimal marketPrice;

        public string InstrumentId { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public DateTime PurchaseDate { get; set; }

        public decimal Quantity
        {
            get { return quantity; }
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Negative quantity not allowed");
                quantity = value;
            }
        }

        public decimal PurchasePrice
        {
            get { return purchasePrice; }
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Negative purchase price");
                purchasePrice = value;
            }
        }

        public decimal MarketPrice
        {
            get { return marketPrice; }
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Negative market price");
                marketPrice = value;
            }
        }

        public abstract decimal CalculateCurrentValue();

        public virtual string GetInstrumentSummary()
        {
            return $"{InstrumentId} - {Name} ({Currency})";
        }
    }

    // EQUITY
    class Equity : FinancialInstrument, IRiskAssessable, IReportable
    {
        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }

        public string GetRiskCategory()
        {
            return "High";
        }

        public string GenerateReportLine()
        {
            return $"{InstrumentId} | Equity | {CalculateCurrentValue():C}";
        }
    }

    // BOND
    class Bond : FinancialInstrument, IRiskAssessable, IReportable
    {
        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }

        public string GetRiskCategory()
        {
            return "Low";
        }

        public string GenerateReportLine()
        {
            return $"{InstrumentId} | Bond | {CalculateCurrentValue():C}";
        }
    }

    // FIXED DEPOSIT
    class FixedDeposit : FinancialInstrument
    {
        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }
    }

    // MUTUAL FUND
    class MutualFund : FinancialInstrument
    {
        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }
    }

    // PORTFOLIO
    class Portfolio
    {
        public List<FinancialInstrument> instruments = new List<FinancialInstrument>();
        public Dictionary<string, FinancialInstrument> lookup = new Dictionary<string, FinancialInstrument>();

        public void AddInstrument(FinancialInstrument instrument)
        {
            if (lookup.ContainsKey(instrument.InstrumentId))
                throw new Exception("Duplicate Instrument ID");

            instruments.Add(instrument);
            lookup[instrument.InstrumentId] = instrument;
        }

        public void RemoveInstrument(string id)
        {
            if (lookup.ContainsKey(id))
            {
                instruments.Remove(lookup[id]);
                lookup.Remove(id);
            }
        }

        public FinancialInstrument GetInstrumentById(string id)
        {
            return lookup.ContainsKey(id) ? lookup[id] : null;
        }

        public decimal GetTotalPortfolioValue()
        {
            return instruments.Sum(i => i.CalculateCurrentValue());
        }

        public IEnumerable<FinancialInstrument> GetInstrumentsByRisk(string risk)
        {
            return instruments
                .Where(i => i is IRiskAssessable r && r.GetRiskCategory() == risk);
        }
    }

    // TRANSACTION
    class Transaction
    {
        public string TransactionId { get; set; }
        public string InstrumentId { get; set; }
        public string Type { get; set; }
        public decimal Units { get; set; }
        public DateTime Date { get; set; }
    }

    // TRANSACTION PROCESSOR
    class TransactionProcessor
    {
        public void Process(Transaction t, Portfolio portfolio)
        {
            var inst = portfolio.GetInstrumentById(t.InstrumentId);

            if (inst == null)
                throw new Exception("Instrument not found");

            if (t.Type == "Buy")
            {
                inst.Quantity += t.Units;
            }
            else if (t.Type == "Sell")
            {
                if (inst.Quantity < t.Units)
                    throw new Exception("Selling more units than owned");

                inst.Quantity -= t.Units;
            }
        }
    }

    // REPORT GENERATOR
    class ReportGenerator
    {
        public void GenerateConsoleReport(Portfolio portfolio)
        {
            Console.WriteLine("\n===== PORTFOLIO SUMMARY =====\n");

            var groups = portfolio.instruments.GroupBy(i => i.GetType().Name);

            foreach (var g in groups)
            {
                decimal investment = g.Sum(i => i.Quantity * i.PurchasePrice);
                decimal current = g.Sum(i => i.CalculateCurrentValue());

                Console.WriteLine($"Instrument Type: {g.Key}");
                Console.WriteLine($"Total Investment: {investment:C}");
                Console.WriteLine($"Current Value: {current:C}");
                Console.WriteLine($"Profit/Loss: {(current - investment):C}");
                Console.WriteLine();
            }

            Console.WriteLine($"Overall Portfolio Value: {portfolio.GetTotalPortfolioValue():C}");

            var riskGroups = portfolio.instruments
                .OfType<IRiskAssessable>()
                .GroupBy(r => r.GetRiskCategory());

            Console.WriteLine("\nRisk Distribution:");
            foreach (var r in riskGroups)
                Console.WriteLine($"{r.Key}: {r.Count()}");
        }

        public void GenerateFileReport(Portfolio portfolio)
        {
            try
            {
                string file = $"PortfolioReport_{DateTime.Now:yyyyMMdd}.txt";

                using (StreamWriter sw = new StreamWriter(file))
                {
                    sw.WriteLine("===== PORTFOLIO REPORT =====");
                    sw.WriteLine($"Generated: {DateTime.Now}");
                    sw.WriteLine();

                    foreach (var inst in portfolio.instruments)
                        sw.WriteLine(inst.GetInstrumentSummary());

                    sw.WriteLine();
                    sw.WriteLine($"Total Portfolio Value: {portfolio.GetTotalPortfolioValue():C}");
                }

                Console.WriteLine("File report generated.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("File error: " + ex.Message);
            }
        }
    }

    // MAIN PROGRAM
    class Program
    {
        static void Main()
        {
            Portfolio portfolio = new Portfolio();

            try
            {
                // CSV INPUT
                string csv = "EQ001,Equity,INFY,INR,100,1500,1650";
                var parts = csv.Split(',');

                FinancialInstrument inst = new Equity()
                {
                    InstrumentId = parts[0],
                    Name = parts[2],
                    Currency = parts[3],
                    Quantity = decimal.Parse(parts[4]),
                    PurchasePrice = decimal.Parse(parts[5]),
                    MarketPrice = decimal.Parse(parts[6]),
                    PurchaseDate = DateTime.Now
                };

                portfolio.AddInstrument(inst);

                // ADD MORE INSTRUMENTS
                portfolio.AddInstrument(new Bond()
                {
                    InstrumentId = "BD001",
                    Name = "Gov Bond",
                    Currency = "INR",
                    Quantity = 50,
                    PurchasePrice = 1000,
                    MarketPrice = 1050,
                    PurchaseDate = DateTime.Now
                });

                portfolio.AddInstrument(new MutualFund()
                {
                    InstrumentId = "MF001",
                    Name = "HDFC Fund",
                    Currency = "INR",
                    Quantity = 200,
                    PurchasePrice = 500,
                    MarketPrice = 550,
                    PurchaseDate = DateTime.Now
                });

                // ARRAY OF TRANSACTIONS
                Transaction[] transactionArray =
                {
                    new Transaction{ TransactionId="T1", InstrumentId="EQ001", Type="Buy", Units=10, Date=DateTime.Now},
                    new Transaction{ TransactionId="T2", InstrumentId="EQ001", Type="Sell", Units=5, Date=DateTime.Now}
                };

                // CONVERT ARRAY -> LIST
                List<Transaction> transactions = transactionArray.ToList();

                TransactionProcessor processor = new TransactionProcessor();

                foreach (var t in transactions)
                    processor.Process(t, portfolio);

                // REPORT
                ReportGenerator report = new ReportGenerator();

                report.GenerateConsoleReport(portfolio);
                report.GenerateFileReport(portfolio);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Patient
    {
        public string Name { get; set; }
        public decimal BaseFee { get; set; }
        public virtual decimal CalculateFinalBill()
        {
            return BaseFee;
        }
    }
    class Inpatient : Patient
    {
        public int DaysStayed { get; set; }
        public decimal DailyRate { get; set; }
        public override decimal CalculateFinalBill()
        {
            return BaseFee + (DailyRate * DaysStayed);
        }
    }
    class OutPatient : Patient
    {
        public decimal ProcedureFee { get; set; }
        public override decimal CalculateFinalBill()
        {
            return ProcedureFee + BaseFee;
        }
    }
    class EmergencyPatient : Patient
    {
        private int severityLevel;

        public int SeverityLevel
        {
            get { return severityLevel; }
            set { if(value>0 &&value<5)severityLevel = value; }
        }
        public override decimal CalculateFinalBill()
        {
            return BaseFee * SeverityLevel;
        }
    }
    class HospitalBilling
    {
        List<Patient> MasterList = new List<Patient>();
        public void AddPatient(Patient p)
        {
            MasterList.Add(p);
        }
        public void GenerateDailyReport()
        {
            foreach (var item in MasterList)
            {
                Console.WriteLine($"Name - {item.Name} | Bill - {item.CalculateFinalBill()}");
            }
        }
        public void CalculateTotalRevenue()
        {
            decimal totalRevenue = 0;
            foreach(var item in MasterList)
            {
                totalRevenue += item.CalculateFinalBill();
            }
            Console.WriteLine($"Total Revenue : {totalRevenue:C2}");
        }
        public int GetInpatientcount()
        {
            int inpatients = 0;
            foreach (var item in MasterList)
            {
                if(item is  Inpatient) inpatients++;
            }
            return inpatients;
        }
    }
    internal class WeeklyAsessment4
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Patient p1 = new Patient()
            {
                BaseFee = 100,
                 Name="Hari"
            };
            Patient p2 = new Patient() { Name="nitin", BaseFee=250 };
            Inpatient p3 = new Inpatient() { BaseFee=100, Name="Shyam", DailyRate=49, DaysStayed=5};
            OutPatient p4 = new OutPatient() { Name = "Prasad", BaseFee = 300, ProcedureFee = 99 };
            EmergencyPatient p5 = new EmergencyPatient() { BaseFee = 500, Name = "Hemraj", SeverityLevel = 4 };
            HospitalBilling reports = new HospitalBilling();
            reports.AddPatient(p1);
            reports.AddPatient(p2);
            reports.AddPatient(p3);
            reports.AddPatient(p4);
            reports.AddPatient(p5);
            Console.WriteLine("Daily Report:");
            reports.GenerateDailyReport();
            Console.WriteLine("=============================================================================");
            reports.CalculateTotalRevenue();
            Console.WriteLine("Total Inpatients(currently):"+reports.GetInpatientcount()); 
            
        }
    }
}

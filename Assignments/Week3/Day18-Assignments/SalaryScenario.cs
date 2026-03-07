namespace OOPS_week4
{
    class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal BasicSalary { get; set; }
        public int ExperienceInYears { get; set; }
        public Employee()
        {
            EmployeeId = 0;
            EmployeeName=string.Empty;  
            BasicSalary = 0;
            ExperienceInYears = 0;
        }
        public Employee(int id,string name,decimal salary,int exp)
        {
            EmployeeId = id;
            EmployeeName = name;
            BasicSalary = salary;
            ExperienceInYears = exp;
        }
        public decimal CalcAnnualSalary()
        {
            return BasicSalary * 12;
        }
    }
    class PermanentEmployee:Employee
    {
        public PermanentEmployee(int id, string name, decimal salary, int exp):base(id,name,salary,exp)
        {
            EmployeeId = id;
            EmployeeName = name;
            BasicSalary = salary;
            ExperienceInYears = exp;
        }
        public new decimal CalcAnnualSalary() {
            decimal hra = 0.2m * BasicSalary;
            decimal spec = 0.1m * BasicSalary;
            if (ExperienceInYears > 5) return BasicSalary + hra + spec + 50000m;
            else
                return BasicSalary*12+hra+spec;
        }
    }
    class ContractEmployee : Employee
    {
        public int DurationInMonths { get; set; }
        public ContractEmployee(int Duration,int id, string name, decimal salary, int exp) : base(id, name, salary, exp)
        {
            DurationInMonths = Duration;
            EmployeeId = id;
            EmployeeName = name;
            BasicSalary = salary;
            ExperienceInYears = exp;
        }
        public new decimal CalcAnnualSalary()
        {
            if (DurationInMonths > 12) return BasicSalary * DurationInMonths + 30000;
            else return BasicSalary * DurationInMonths;
        }
    }
    class InternEmployee : Employee
    {
        public InternEmployee( int id, string name, decimal salary, int exp) : base(id, name, salary, exp)
        {
            EmployeeId = id;
            EmployeeName = name;
            BasicSalary = salary;
            ExperienceInYears = exp;
        }
        public new  decimal CalcAnnualSalary()
        {
            return BasicSalary * 12;
        }
    }

    internal class SalaryScenario
    {
        static void Main(string[] args)
        {
            PermanentEmployee pe = new PermanentEmployee(1,"Nitin",20000,4);
            ContractEmployee ce = new ContractEmployee(21,2,"baldev",21000,3);
            InternEmployee ee = new InternEmployee(3,"Anni",15000,0);
            Console.WriteLine(pe.CalcAnnualSalary());
            Console.WriteLine(ce.CalcAnnualSalary());
            Console.WriteLine(ee.CalcAnnualSalary());
        }
    }
}

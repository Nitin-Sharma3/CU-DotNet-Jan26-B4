namespace FinanceLibraryProject
{

    public class EmployeBonus
    {
        public decimal BaseSalary { get; set; }
        public int PerformanceRating { get; set; }
        public int YearsOfExperience { get; set; }
        public decimal DepartmentMultiplier { get; set; }
        public double AttendancePercentage { get; set; }
        public decimal NetAnnualBonus => CalculateSalaryIncludingTax();

        public decimal CalculateSalaryIncludingTax()
        {
            if (BaseSalary <= 0) return 0;
            if (PerformanceRating < 1 || PerformanceRating > 5) throw new InvalidOperationException();
            int percent = 0;
            if (PerformanceRating == 5) percent = 25;
            else if (PerformanceRating == 4) percent = 18;
            else if (PerformanceRating == 3) percent = 12;
            else if (PerformanceRating == 2) percent = 5;
            else if (PerformanceRating == 1) percent = 0;
            //-------------
            if (YearsOfExperience > 10) percent += 5;
            else if (YearsOfExperience > 5) percent += 3;
            //--------------
            if (AttendancePercentage < 85) percent -= 20;
            decimal bonus = (BaseSalary * percent) / 100;
            bonus *= DepartmentMultiplier;
            //-------------
            if (bonus > BaseSalary * 0.4m) bonus = BaseSalary * 0.4m;
            int tax = 0;
            if (bonus <= 150000) tax = 10;
            else if (bonus >= 150000 && bonus <= 300000) tax = 20;
            else if (bonus > 300000) tax = 30;
            bonus = bonus - (bonus * tax) / 100;
            //NetAnnualBonus = bonus;
            return Math.Round(bonus, 2);
        }

    }
}

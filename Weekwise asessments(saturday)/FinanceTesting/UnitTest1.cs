
using FinanceLibraryProject;

namespace FinanceTesting
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NormalHighPerformer()
        {
            decimal ans = 123200.00m;
            // Arrange
            var bonus = new EmployeBonus
            {
                BaseSalary = 500000,
                PerformanceRating = 5,
                YearsOfExperience = 6,
                DepartmentMultiplier = 1.1m,
                AttendancePercentage = 95
            };

            // Act
            var result = bonus.NetAnnualBonus;

            // Assert
            Assert.AreEqual(result,ans);
        }
        [Test]
        public void AttendancePenaltyApplied()
        {
            decimal ans = 60480.00m;
            // Arrange
            var bonus = new EmployeBonus
            {
                BaseSalary = 400000,
                PerformanceRating = 4,
                YearsOfExperience = 8,
                DepartmentMultiplier = 1.0m,
                AttendancePercentage = 80
            };

            // Act
            var result = bonus.NetAnnualBonus;

            // Assert
            Assert.AreEqual(result, ans);
        }
        [Test]
        public void CapTriggered()
        {
            decimal ans = 280000.00m;
            // Arrange
            var bonus = new EmployeBonus
            {
                BaseSalary = 10000000,
                PerformanceRating = 5,
                YearsOfExperience = 15,
                DepartmentMultiplier = 1.5m,
                AttendancePercentage = 95
            };

            // Act
            var result = bonus.NetAnnualBonus;

            // Assert
            Assert.AreEqual(result, ans);
        }
        [Test]
        public void ZeroSalary()
        {
            decimal ans = 0.00m;
            // Arrange
            var bonus = new EmployeBonus
            {
                BaseSalary = 0,
                PerformanceRating = 4,
                YearsOfExperience = 8,
                DepartmentMultiplier = 1.0m,
                AttendancePercentage = 80
            };

            // Act
            var result = bonus.NetAnnualBonus;

            // Assert
            Assert.AreEqual(result, ans);
        }
        [Test]
        public void LowPerformer()
        {
            decimal ans = 13500.00m;
            // Arrange
            var bonus = new EmployeBonus
            {
                BaseSalary = 300000,
                PerformanceRating = 2,
                YearsOfExperience = 3,
                DepartmentMultiplier = 1.0m,
                AttendancePercentage = 90
            };

            // Act
            var result = bonus.NetAnnualBonus;

            // Assert
            Assert.AreEqual(result, ans);
        }
        [Test]
        public void Exact150000TaxBoundary()
        {
            decimal ans = 64800.00m;
            // Arrange
            var bonus = new EmployeBonus
            {
                BaseSalary = 600000,
                PerformanceRating = 3,
                YearsOfExperience = 0,
                DepartmentMultiplier = 1.0m,
                AttendancePercentage = 100
            };

            // Act
            var result = bonus.NetAnnualBonus;

            // Assert
            Assert.AreEqual(result, ans);
        }
        [Test]
        public void HighTaxSlab()
        {
            decimal ans = 226800.00m;
            // Arrange
            var bonus = new EmployeBonus
            {
                BaseSalary = 900000,
                PerformanceRating = 5,
                YearsOfExperience = 11,
                DepartmentMultiplier = 1.2m,
                AttendancePercentage = 100
            };

            // Act
            var result = bonus.NetAnnualBonus;

            // Assert
            Assert.AreEqual(result, ans);
        }
        [Test]
        public void RoundingPrecisionCase()
        {
            decimal ans = 118649.88m;
            // Arrange
            var bonus = new EmployeBonus
            {
                BaseSalary = 555555,
                PerformanceRating = 4,
                YearsOfExperience = 6,
                DepartmentMultiplier = 1.13m,
                AttendancePercentage = 92
            };

            // Act
            var result = bonus.NetAnnualBonus;

            // Assert
            Assert.AreEqual(result, ans);
        }
    }
}
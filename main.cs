/******************************************************************************

                            Online C# Compiler.
                Code, Compile, Run and Debug C# program online.
Write your code in this editor and press "Run" button to execute it.

*******************************************************************************/

using System;
class HelloWorld {
  static void Main() {
     // ================================
        // Exercise 1: 
        // ================================
        int[] attendance = { 45, 48, 50 };     
        int totalDays = 60;
        double percentage = (attendance[0] + attendance[1] + attendance[2]) * 100.0 / (3 * totalDays);
        int displayPercentage = (int)percentage;
        int roundedPercentage = (int)Math.Round(percentage); 

        // ================================
        // Exercise 2:
        // ================================
        int[] marks = { 78, 82, 91 };
        double avg = (marks[0] + marks[1] + marks[2]) / 3.0;
        double avgTwoDecimals = Math.Round(avg, 2);
        int scholarshipScore = (int)avg;

        // ================================
        // Exercise 3: 
        // ================================
        decimal finePerDay = 2.50m;
        int daysOverdue = 7;
        decimal totalFine = finePerDay * daysOverdue; 
        double loggedFine = (double)totalFine;

        // ================================
        // Exercise 4:
        // ================================
        decimal balance = 10000m;
        float interestRate = 6.5f; 
        decimal monthlyInterest = balance * (decimal)interestRate / 1200;
        balance += monthlyInterest;

        // ================================
        // Exercise 5: 
        // ================================
        double cartTotal = 1999.99;
        decimal tax = 0.18m;
        decimal discount = 100m;
        decimal finalPayable = (decimal)cartTotal + ((decimal)cartTotal * tax) - discount;
        

        // ================================
        // Exercise 6: 
        // ================================
        short sensorReading = 305;
        double temperatureC = sensorReading / 10.0;
        int dashboardTemp = (int)Math.Round(temperatureC); 
    

        // ================================
        // Exercise 7:
        // ================================
        double finalScore = 86.4;
        byte grade;
        if (finalScore >= 90) grade = 10;
        else if (finalScore >= 80) grade = 9;
        else if (finalScore >= 70) grade = 8;
        else grade = 5;
  

        // ================================
        // Exercise 8: 
        // ================================
        long bytesUsed = 5_368_709_120; // bytes
        double mbUsed = bytesUsed / (1024.0 * 1024);
        double gbUsed = bytesUsed / (1024.0 * 1024 * 1024);
        int monthlySummaryGB = (int)Math.Round(gbUsed);


        // ================================
        // Exercise 9: 
        // ================================
        int itemCount = 45000;
        ushort maxCapacity = 50000;
        bool withinLimit = itemCount <= maxCapacity; 
       

        // ================================
        // Exercise 10: 
        // ================================
        int basicSalary = 30000;
        double allowance = 5500.75;
        double deduction = 1200.25;
        decimal netSalary = basicSalary + (decimal)allowance - (decimal)deduction;

  }
}
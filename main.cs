/******************************************************************************

                            Online C# Compiler.
                Code, Compile, Run and Debug C# program online.
Write your code in this editor and press "Run" button to execute it.

*******************************************************************************/

using System;
class HelloWorld {
  static void Main() {
   // Q1
int attended = 23;
int total = 55;

double percentage = (attended * 100.0) / total;
int displayPercent = (int)Math.Round(percentage);

//Q2
int totalMarks = 129;
int subjects = 7;

double average = totalMarks / (double)subjects;
double roundedAvg = Math.Round(average, 2);

int scholarshipScore = (int)Math.Floor(roundedAvg);


//Q3
decimal finePerDay = 2.50m;
int daysLate = 7;

decimal totalFine = finePerDay * daysLate;
double analyticsFine = (double)totalFine;

//Q4
decimal balance = 100000m;
float rate = 7.5f;

decimal interestRate = (decimal)rate / 100;
decimal interest = balance * interestRate / 12;

balance += interest;

//Q5
double cartTotal = 999.99;
decimal taxRate = 0.18m;

decimal total = (decimal)cartTotal;
decimal tax = total * taxRate;
decimal finalAmount = total + tax;


//Q6

short sensorValue = 325;
double celsius = sensorValue / 10.0;

int displayTemp = (int)Math.Round(celsius);

//Q7

double score = 87.5;
byte grade;

if (score >= 90) grade = 10;
else if (score >= 80) grade = 9;
else grade = 8;

//Q8
long bytesUsed = 5368709120; 

double gb = bytesUsed / (1024.0 * 1024 * 1024);
int roundedGB = (int)Math.Round(gb);

//Q9
int items = 500;
ushort maxCapacity = 600;

if (items >= maxCapacity)
{
    Console.WriteLine(“Cant store anymore”);
}
//
    Q10

int basic = 30000;
double allowance = 5230.75;
double deduction = 1800.25;

decimal netSalary = basic
    + (decimal)allowance
    - (decimal)deduction;

  }
}

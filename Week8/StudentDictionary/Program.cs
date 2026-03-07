using System;
using System.Collections.Generic;

public class Program
{
    class Student
    {
        public int StudId { get; set; }
        public string SName { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Student other)
                return StudId == other.StudId;
            return false;
        }

        public override int GetHashCode()
        {
            return StudId.GetHashCode();
        }
    }

    static void Main()
    {
        Dictionary<Student, int> studentMarks = new Dictionary<Student, int>();

        AddOrUpdateStudent(studentMarks, new Student { StudId = 1, SName = "Aman" }, 70);
        AddOrUpdateStudent(studentMarks, new Student { StudId = 2, SName = "Ravi" }, 85);
        AddOrUpdateStudent(studentMarks, new Student { StudId = 3, SName = "Neha" }, 90);

        // improvement case
        AddOrUpdateStudent(studentMarks, new Student { StudId = 1, SName = "Aman" }, 80);

        // lower marks -> ignore
        AddOrUpdateStudent(studentMarks, new Student { StudId = 2, SName = "Ravi" }, 60);

        Console.WriteLine("Latest Student Records:");

        foreach (var item in studentMarks)
        {
            Console.WriteLine($"{item.Key.StudId} {item.Key.SName} {item.Value}");
        }
    }

    static void AddOrUpdateStudent(Dictionary<Student, int> dict, Student s, int marks)
    {
        if (dict.ContainsKey(s))
        {
            if (marks > dict[s])
                dict[s] = marks;
        }
        else
        {
            dict.Add(s, marks);
        }
    }
}
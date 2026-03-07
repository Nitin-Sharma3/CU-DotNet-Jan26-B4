using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    class CollageManagement
    {
        Dictionary<string, Dictionary<string, int>> studentRecords =
            new Dictionary<string, Dictionary<string, int>>();

        Dictionary<string, LinkedList<KeyValuePair<string, int>>> studentSubjectsOrder =
            new Dictionary<string, LinkedList<KeyValuePair<string, int>>>();

        Dictionary<string, Dictionary<string, int>> subjectsRecords =
            new Dictionary<string, Dictionary<string, int>>();

        Dictionary<string, LinkedList<KeyValuePair<string, int>>> subjectsStudentsOrder =
            new Dictionary<string, LinkedList<KeyValuePair<string, int>>>();


        // ADD STUDENT
        public int AddStudent(string studentId, string subject, int marks)
        {
            if (!studentRecords.ContainsKey(studentId))
            {
                studentRecords[studentId] = new Dictionary<string, int>();
                studentSubjectsOrder[studentId] = new LinkedList<KeyValuePair<string, int>>();
            }

            if (!subjectsRecords.ContainsKey(subject))
            {
                subjectsRecords[subject] = new Dictionary<string, int>();
                subjectsStudentsOrder[subject] = new LinkedList<KeyValuePair<string, int>>();
            }

            // UPDATE ONLY IF MARKS GREATER
            if (studentRecords[studentId].ContainsKey(subject))
            {
                if (marks > studentRecords[studentId][subject])
                {
                    studentRecords[studentId][subject] = marks;
                    subjectsRecords[subject][studentId] = marks;
                }
            }
            else
            {
                studentRecords[studentId][subject] = marks;
                subjectsRecords[subject][studentId] = marks;

                studentSubjectsOrder[studentId].AddLast(
                    new KeyValuePair<string, int>(subject, marks));

                subjectsStudentsOrder[subject].AddLast(
                    new KeyValuePair<string, int>(studentId, marks));
            }

            return 1;
        }


        // REMOVE STUDENT
        public int RemoveStudent(string studentId)
        {
            if (!studentRecords.ContainsKey(studentId))
                return 0;

            foreach (var subject in studentRecords[studentId].Keys.ToList())
            {
                subjectsRecords[subject].Remove(studentId);

                var list = subjectsStudentsOrder[subject];
                var node = list.First;

                while (node != null)
                {
                    if (node.Value.Key == studentId)
                    {
                        list.Remove(node);
                        break;
                    }
                    node = node.Next;
                }
            }

            studentRecords.Remove(studentId);
            studentSubjectsOrder.Remove(studentId);

            return 1;
        }


        // TOP STUDENT
        public string TopStudent(string subject)
        {
            if (!subjectsRecords.ContainsKey(subject) ||
                subjectsRecords[subject].Count == 0)
                return "";

            int maxMarks = subjectsRecords[subject].Values.Max();

            StringBuilder sb = new StringBuilder();

            foreach (var pair in subjectsStudentsOrder[subject])
            {
                string student = pair.Key;

                if (subjectsRecords[subject].ContainsKey(student) &&
                    subjectsRecords[subject][student] == maxMarks)
                {
                    sb.AppendLine($"{student} {maxMarks}");
                }
            }

            return sb.ToString().Trim();
        }


        // RESULT (AVERAGE MARKS)
        public string Result()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var student in studentRecords)
            {
                double avg = student.Value.Values.Average();

                sb.AppendLine($"{student.Key} {avg:F2}");
            }

            return sb.ToString().Trim();
        }
    }


    public static void Main()
    {
        CollageManagement cm = new CollageManagement();

        List<string> input = new List<string>()
        {
            "ADD S1 Math 80",
            "ADD S2 Math 90",
            "ADD S3 Math 90",
            "ADD S1 Phy 90",
            "TOP Math",
            "RESULT",
            "REMOVE S1"
        };

        foreach (var line in input)
        {
            var parts = line.Split(' ');

            if (parts[0] == "ADD")
            {
                cm.AddStudent(parts[1], parts[2], int.Parse(parts[3]));
            }
            else if (parts[0] == "REMOVE")
            {
                cm.RemoveStudent(parts[1]);
            }
            else if (parts[0] == "TOP")
            {
                Console.WriteLine(cm.TopStudent(parts[1]));
            }
            else if (parts[0] == "RESULT")
            {
                Console.WriteLine(cm.Result());
            }
        }
    }
}
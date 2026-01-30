using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_week4
{
    //entity class
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }
        public override string ToString()
        {
            return $"Id - {Id}| Name - {Name}| Marks - {Marks}";
        }
    }
    //student manager
    class StudentManager
    {
        Dictionary<int,Student> studentsData=new Dictionary<int,Student>();
        public bool AddStudent(Student student)
        {
            int id = student.Id;
            if (!studentsData.ContainsKey(id))
            {
                studentsData.Add(id, student);
                return true;
            }
            return false;
        }
        public void DisplayAllStudents()
        {
            foreach (var student in studentsData)
            {
                Console.WriteLine(student.Value);
            }
        }
        public Student SearchStudent(int id)
        {
            Student student = null;
            bool found= studentsData.TryGetValue(id,out student);
            return student;
        }
        public bool UpdateStudent(int id, int marks)
        {
            Student foundStudent = SearchStudent(id);
            if (foundStudent != null)
            {
                foundStudent.Marks = marks;
                return true;
            }

            return true;
        }
        public bool DeleteStudent(int id) { 
            Student student = SearchStudent(id);
               return studentsData.Remove(id);
        }

    } 
    internal class UsestudentManager
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Menu Driven Student Management System:-");
            StudentManager studentManager = new StudentManager();
            while (true)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Select the options to do:\n" +
                "Type:\n1 to add student\n2 to remove student\n3 to update student\n4 to display all students\n5 to exit");
                int a = int.Parse(Console.ReadLine());
                if (a == 5) break;
                switch (a)
                {
                    case 1:
                        Console.Write("Enter ID : ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter name : ");
                        string name = Console.ReadLine();
                        Console.Write("Enter marks : ");
                        int marks = int.Parse(Console.ReadLine());
                        studentManager.AddStudent(new Student() { Id = id, Marks = marks, Name = name });
                        Console.WriteLine("Student Added Successfully");
                        break;
                    case 2:
                        Console.Write("Enter the id to remove : ");
                        int dd = int.Parse(Console.ReadLine());
                        bool deleted = studentManager.DeleteStudent(dd);
                        if(deleted) Console.WriteLine("Student deleted successfully");
                        else Console.WriteLine("Student not found!");
                        break;
                    case 3:
                        Console.WriteLine("Enter the id to update and the marks to update: ");
                        string[] arr = Console.ReadLine().Split(' ');
                        bool updated = studentManager.UpdateStudent(int.Parse(arr[0]), int.Parse(arr[1]));
                        if (updated) Console.WriteLine("Updated successfully!");
                        else Console.WriteLine("Unable to update");
                            break;
                    case 4:
                        studentManager.DisplayAllStudents();
                        break;
                    default:
                        break;
                }
            }

            //StudentManager manager = new StudentManager();
            //manager.AddStudent(new Student()
            //{
            //    Id = 111,
            //    Name = "Nitin",
            //    Marks = 98
            //});
            //manager.AddStudent(new Student()
            //{
            //    Id = 112,
            //    Name = "Aniket",
            //    Marks = 95
            //});
            //int searchId = 115;
            //Student foundStudent = manager.SearchStudent(searchId);
            //if(foundStudent != null)
            //Console.WriteLine(foundStudent);
            //else Console.WriteLine($"Student with {searchId} not found ");
            //Console.WriteLine("-------------------------------------");
            //bool updated = manager.UpdateStudent(111, 80);
            //if (updated)
            //{
            //    Console.WriteLine(manager.SearchStudent(111));
            //}
            //Console.WriteLine("-----------------------------------");
            //manager.DisplayAllStudents();

        }
    }
}

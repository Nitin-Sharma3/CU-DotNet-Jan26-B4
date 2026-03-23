using Day63_01.Models;
using Day63_01.Repositories;
using Day63_01.Services;
using System.Threading.Channels;
namespace Day63_01.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Where do you want to put the data");
            Console.WriteLine("Press 1 for File");
            Console.WriteLine("Press 2 for Local");
            int choice = int.Parse(Console.ReadLine());
            IStudentRepository repo = null;
            if (choice == 1)
            {
                Console.WriteLine("JSON called...");
                repo = new JsonStudentRepository();
            }
            else
            {
                Console.WriteLine("Local List called...");
                repo = new ListStudentRepository();
            }
            var student = AddStudent();
            IStudentService studentService = new StudentService(repo);
            studentService.AddStudent(student);
            Console.WriteLine("showing data from your choice");
            IEnumerable<Student> ggs = studentService.getData(student);
            DisplayStudents(ggs);
        }
        static Student AddStudent()
        {
            Student student1 = new Student()
            {
                Id = 1,
                Name = "Tillu Sharma",
                Grade = "B"
            };
            return student1;
        }
        static void DisplayStudents(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Grade: {student.Grade}");
            }
        }
    }
}

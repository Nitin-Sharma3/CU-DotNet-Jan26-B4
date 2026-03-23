using Day63_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Day63_01.Models;
namespace Day63_01.Repositories
{
    internal class JsonStudentRepository: IStudentRepository
    {
        List<Student> students = new List<Student>(); 
        static string filePath = @"../../../students.json";
        public void AddStudent(Student student)
        {
            string existing = File.ReadAllText(filePath);
            students = JsonSerializer.Deserialize<List<Student>>(existing) ?? new List<Student>();
            students.Add(student);
            string json = JsonSerializer.Serialize(students,
            new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public IEnumerable<Student> getData(Student student)
        {
            return students;
        }
    }
}

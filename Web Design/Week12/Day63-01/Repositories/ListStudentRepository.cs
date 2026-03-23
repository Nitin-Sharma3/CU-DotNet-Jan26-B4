using Day63_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day63_01.Repositories
{
    internal class ListStudentRepository : IStudentRepository
    {
        private List<Student> _students = new List<Student>();

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public IEnumerable<Student> getData(Student student)
        {
            return _students;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day63_01.Models;
namespace Day63_01.Repositories
{
    internal interface IStudentRepository
    {
        void AddStudent(Student student);
        IEnumerable<Student> getData(Student student);
    }
}

using Day63_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Day63_01.Services
{
    internal interface IStudentService
    {
        void AddStudent(Student student);
        IEnumerable<Student> getData(Student student);
    }
}

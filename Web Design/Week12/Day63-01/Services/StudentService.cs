using Day63_01.Models;
using Day63_01.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Day63_01.Services
{
    internal class StudentService : IStudentService
    {
        private IStudentRepository _studentRepository{get;set; }
        public StudentService()
        {
            this._studentRepository = new ListStudentRepository();
        }
        public StudentService(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }
        public void AddStudent(Student student)
        {

            if(string.IsNullOrEmpty(student.Name))
                throw new Exception("Name cannot be empty");
            if(string.IsNullOrEmpty(student.Grade))
                throw new Exception("Grade cannot be empty");
            if(student.Grade != "A" && student.Grade != "B" && student.Grade != "C" && student.Grade != "D" && student.Grade != "F")
                throw new Exception("Grade must be A, B, C, D or F");
            _studentRepository.AddStudent(student);
        }

        public IEnumerable<Student> getData(Student student)
        {
            return _studentRepository.getData(student);
        }
    }
}

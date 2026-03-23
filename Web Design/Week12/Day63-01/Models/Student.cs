using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day63_01.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public string Grade { get; set; }
        
        override public string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Grade: {Grade}";
        }
    }
}

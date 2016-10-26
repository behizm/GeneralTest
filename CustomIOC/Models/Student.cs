using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomIOC.Models
{
    public class Student
    {
        public Student()
        {
        }
        public Student(int id, int personId, string className, double average)
        {
            Id = id;
            PersonId = personId;
            ClassName = className;
            Average = average;
        }

        public int Id { get; set; }
        public int PersonId { get; set; }
        public string ClassName { get; set; }
        public double Average { get; set; }
    }
}

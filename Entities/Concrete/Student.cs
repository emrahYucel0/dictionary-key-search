using SearchWithDictionary.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchWithDictionary.Entities.Concrete
{
    public class Student: User, IStudent
    {
        public string StudentNumber { get; set; }
        public short Absenteeism { get; set; }
        public byte Mark {  get; set; } 
        public Student() { }

        public Student(string userName, string password, string firstName, string lastName, string identityNumber, bool isActive,
            string studentNumber, short absenteeism, byte mark) : base(userName, password, firstName, lastName, identityNumber, isActive)
        {
            StudentNumber = studentNumber;
            Absenteeism = absenteeism;
            Mark = mark;
        }
    }
}

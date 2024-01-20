using SearchWithDictionary.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchWithDictionary.Entities.Concrete
{
    public class Personal : User, IPersonal
    {
        public string SSN { get; set; }
        public decimal Salary { get; set; }

        public Personal() { }

        public Personal (string userName, string password, string firstName, string lastName, string identityNumber, bool isActive, 
            string ssn, decimal salary) : base(userName, password, firstName, lastName, identityNumber, isActive)
        {
            SSN = ssn;
            Salary = salary;
        }
        public void CalculateSalary(short workingHours)
        {
            Console.WriteLine(@$"Calculated salary: {Salary * workingHours} ₺");
        }

    }
}

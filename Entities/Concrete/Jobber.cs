using SearchWithDictionary.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchWithDictionary.Entities.Concrete
{
    public class Jobber : User, IJobber
    {
        public string PlateNumber { get; set; }
        public string WorkArea { get; set; }
        public Jobber() { }

        public Jobber (string userName, string password, string firstName, string lastName, string identityNumber, bool isActive, 
            string plateNumber, string workArea) : base(userName, password, firstName, lastName, identityNumber,isActive)
        {
            PlateNumber = plateNumber;
            WorkArea = workArea;
        }

    }
}

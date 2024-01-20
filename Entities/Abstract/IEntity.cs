using SearchWithDictionary.Entities.Abstract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchWithDictionary.Entities.Abstract
{
    public interface IStudent : IUser
    {   
        string StudentNumber { get; set; }
        short Absenteeism { get; set; }
        byte Mark { get; set; }
    }
    public interface IPersonal : IUser
    {
        string SSN { get; set; }
        decimal Salary { get; set; }
    }
    public interface IJobber : IUser
    {
        string PlateNumber { get; set; }
        string WorkArea { get; set; }
    }
    public abstract class User : IUser
    {
        public string UserName { get; set ;}
        public string Password { get; set ;}
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string IdentityNumber { get; set;}
        public bool IsActive { get; set; }

        public User() { }
        public User(string userName, string password, string firstName, string lastName, string identityNumber, bool isActive)
        {
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            IdentityNumber = identityNumber;
            IsActive = isActive;
        }
    }

}

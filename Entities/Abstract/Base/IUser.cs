using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchWithDictionary.Entities.Abstract.Base
{
    public interface IUser
    {
        string UserName { get; set; }
        string Password { get; set; }
        string FirstName {  get; set; }
        string LastName { get; set; }
        string IdentityNumber { get; set; }
        bool IsActive { get; set; }
        

    }
}

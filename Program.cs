// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using SearchWithDictionary;
using SearchWithDictionary.Entities.Abstract.Base;
using SearchWithDictionary.Entities.Concrete;



var studentUsers = JsonConvert.DeserializeObject<IList<Student>>(Data.StudentJson);
var personalUsers = JsonConvert.DeserializeObject<IList<Personal>>(Data.PersonalJson);
var jobberUsers = JsonConvert.DeserializeObject<IList<Jobber>>(Data.JobberJson);
IDictionary<string,IList<string>> indexes = new Dictionary<string, IList<string>>();
IDictionary<string, IUser> fastList = new Dictionary<string, IUser>();

fastList.AddToDictionary(studentUsers.Select(user => (user as IUser)).ToList(), indexes);
fastList.AddToDictionary(personalUsers.Select(user => (user as IUser)).ToList(), indexes);
fastList.AddToDictionary(jobberUsers.Select(user => (user as IUser)).ToList(), indexes);

//Absenteeism ile arama
FindByIndex("27").Writeline();

//StudentNumber ile arama
FindByIndex("67-670-6781").Writeline();

//Mark ile arama
FindByIndex("60").Writeline();

//WorkArea ile arama
FindByIndex("Sports").Writeline();

//PlateNumber ile arama
FindByIndex("61-657-9777").Writeline();

//SSN ile arama
FindByIndex("238-06-2289").Writeline();

//Salary ile arama
FindByIndex("31383").Writeline();

//UserName key  student jobber personal tüm kullanıcıları getirir
fastList.Writeline();


IList<IUser>? FindByIndex(string search)
{
    if (indexes.ContainsKey(search))
    {
        var findedKeys = indexes[search];
        return findedKeys.Select(key => fastList[key]).ToList();
    }
    return null;
}




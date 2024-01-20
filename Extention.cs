using Newtonsoft.Json;
using SearchWithDictionary.Entities.Abstract.Base;
using SearchWithDictionary.Entities.Abstract;
using SearchWithDictionary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchWithDictionary
{
    public static class ConsoleExtentions
    {
        public static void Writeline<T>(this T text)
        {
            Console.WriteLine(JsonConvert.SerializeObject(text));
            Console.ReadKey();
        }
    }

    public static class SearchExtentions
    {
        public static List<T> FindAll<T>(this IList<T> values, Predicate<T> predicate)
        {
            return values.ToList().FindAll(predicate);
        }
        public static T? Find<T>(this IList<T> values, Predicate<T> predicate)
        {
            return values.ToList().Find(predicate);
        }
    }

    public static class DictionaryAddExtentions
    {
        public static void AddToDictionary<TKey, TValue>(
            this IDictionary<TKey, TValue> values,
            IList<TValue> users,
            IDictionary<TKey, IList<TKey>> indexes
            )
            where TValue : IUser
            where TKey : notnull
        {
            TKey castToKey(object key)
            {
                return (TKey)Convert.ChangeType(key, typeof(TKey));
            };

            void addIndex(object findKeyObject, TKey dataKey)
            {
                TKey findKey = castToKey(findKeyObject);
                if (indexes.ContainsKey(findKey))
                {
                    indexes[findKey].Add(dataKey);
                }
                else
                {
                    indexes.Add(findKey, new List<TKey>() { dataKey });
                }
            };

            users?.ToList().ForEach(user =>
            {
                TKey key = castToKey(user.UserName);
                values.Add(key, user);
                addIndex(user.FirstName, key);
                addIndex(user.LastName, key);
                addIndex(user.IdentityNumber, key);
                addIndex(user.Password, key);

                var student = user.CastTo<IStudent>();
                if (student != null)
                {
                    addIndex(student.StudentNumber, key);
                    addIndex(student.Absenteeism, key);
                    addIndex(student.Mark, key);
                }

                var personal = user.CastTo<IPersonal>();
                if (personal != null)
                {
                    addIndex(personal.SSN, key);
                    addIndex(personal.Salary, key);
                }

                var jobber = user.CastTo<Jobber>();
                if (jobber != null)
                {
                    addIndex(jobber.PlateNumber, key);
                    addIndex(jobber.WorkArea, key);
                }

            });
        }

        public static TObject? CastTo<TObject>(this object value)
            where TObject : class
        {
            if (value is TObject)
            {
                return value as TObject;
            }
            return null;
        }

    }
}

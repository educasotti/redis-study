using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PersonService : IPersonService
    {
        public PersonService() { }
        public List<Person> GetPeople()
        {
            return new List<Person>
            {
                new Person("abcd", "Eduardo"),
                new Person("efgh", "Adan"),
                new Person("ijkl", "Marcelo"),
            };
        }
    }
}

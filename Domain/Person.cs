using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public  class Person
    {
        public Person(string document, string name)
        {
            this.Document = document;
            this.Name = name;
        }
        
        public string Name { get; private set; }
        public string Document { get; private set; }
    }
}

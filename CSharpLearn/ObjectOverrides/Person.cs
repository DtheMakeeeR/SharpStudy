using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOverrides
{
    internal class Person
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
       // public string SSN { get; set; } = "";
        public int Age { get; set; }
        public Person(string fName, string lName, int personAge)
        {
            FirstName = fName;
            LastName = lName;
            Age = personAge;
        }
        public Person() { }
        public override string ToString()
        {
            return $"[FistName: {FirstName}; LastName: {LastName}; Age: {Age}]";
        }
        public override bool Equals(object obj)
        {
            return obj?.ToString() == this.ToString() ;
        }
        public override int GetHashCode()
        {
           // return SSN.GetHashCode() ;
            return ToString().GetHashCode() ;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel; 

namespace FunWithGenericCollections
{
    class Person
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; } = 10;
        public Person()
        {

        }
        public Person(string fn, string ln, int age)
        {
            FirstName = fn;
            LastName = ln;
            Age = age;
        }
        public override string ToString()
        {
            return $"FirstName: {FirstName}; LastName: {LastName}; Age: {Age}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //UseGeneric();
            UseObjectModel();
        }
        static void UseGeneric()
        {
            List<Person> people = new List<Person>()
            {
            new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 },
            new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 },
            new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 },
            new Person { FirstName = "Bart", LastName = "Simpson", Age = 9}
            };
            Console.WriteLine("List's length is: {0}", people.Count);
            foreach (Person person in people)
            {
                Console.WriteLine(person.ToString());
            }
            Console.WriteLine("\n->Inserting new person.");
            people.Insert(2, new Person { FirstName = "Maggie", LastName = "Simpson", Age = 2 });
            Console.WriteLine("List's length is: {0}", people.Count);
            Person[] newPeople = people.ToArray();
            foreach (var person in newPeople)
            {
                Console.WriteLine(person.FirstName);
            }
        }
        static void UseObjectModel()
        {
            ObservableCollection<Person> people = new ObservableCollection<Person>
            {
                new Person("Homer", "Simpson", 40),
                new Person("Marge", "Simpson", 42),
            };
            people.CollectionChanged += People_CollectionChanged;
            people.Add(new Person("Fred", "Mertins", 18));
            people.Remove(people[1]);
        }

        private static void People_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine($"The action is {e.Action}");
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Here're OLD items");
                foreach (Person person in e.OldItems)
                {
                    Console.WriteLine(person.ToString());
                }
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("Here're NEW items");
                foreach (Person person in e.NewItems)
                {
                    Console.WriteLine(person.ToString());
                }
            }
        }
    }
}


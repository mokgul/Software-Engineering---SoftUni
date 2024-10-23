using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Oldest_Family_Member
{
    class Family
    {
        public Family()
        {
            this.People = new List<Person>();
        }
        public List<Person> People { get; set; }

        public void AddMember(Person person)
        {
            this.People.Add(person);
        }

        public Person GetOldestMember()
        {
            List<Person> sortedByAge = People.OrderByDescending(p => p.Age).ToList();
            return sortedByAge[0];
        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Family family = GetInfo();
            Person oldest = family.GetOldestMember();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }

        private static Family GetInfo()
        {
            Family family = new Family();

            int familyMembers = int.Parse(Console.ReadLine());
            for (int i = 0; i < familyMembers; i++)
            {
                string[] line = Console.ReadLine().Split(" ");
                string name = line[0];
                int age = int.Parse(line[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }
            return family;
        }
    }
}

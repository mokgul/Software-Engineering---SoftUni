using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;

namespace _07._Order_by_Age
{
    class Person
    {
        public Person(string name, string id, int age)
        {
            this.Name = name;
            this.ID = id;
            this.Age = age;
        }
        public string Name { get; set; }

        public string ID { get; set; }

        public int Age { get; set; }

        public void UpdateInfo(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public void Print()
        {
            Console.WriteLine($"{this.Name} with ID: {this.ID} is {this.Age} years old.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = GetInfo();
            people = people.OrderBy(x => x.Age).ToList();

            people.ForEach(p => p.Print());
        }

        private static List<Person> GetInfo()
        {
            List<Person> people = new List<Person>();
            while (true)
            {
                string[] tokens = Console.ReadLine().Split(' ');
                if (tokens[0] == "End") break;

                Person person = new Person(tokens[0], tokens[1], int.Parse(tokens[2]));

                if (IsInList(people, tokens[1]))
                {
                    person.UpdateInfo(tokens[0], int.Parse(tokens[2]));
                }
                else
                {
                    people.Add(person);
                }
            }
            return people;
        }

        private static bool IsInList(List<Person> people, string id)
        {
            bool isInList = (people.Any(p => p.ID == id)) ? true : false;
            return isInList;
        }
    }
}

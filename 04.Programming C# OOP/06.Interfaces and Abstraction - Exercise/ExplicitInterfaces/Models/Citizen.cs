﻿
using System;

namespace ExplicitInterfaces.Models
{
    using Interfaces;
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }
        public string Name { get; }
        public string Country { get; }

        public int Age { get; }
        string IResident.GetName()
            => $"Mr/Ms/Mrs " + $"{Name}";

        string IPerson.GetName()
        => Name ;

    }
}

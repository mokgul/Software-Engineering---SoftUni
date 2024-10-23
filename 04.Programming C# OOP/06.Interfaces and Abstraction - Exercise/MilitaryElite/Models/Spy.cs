﻿
using System;

namespace MilitaryElite.Models
{
    using Interfaces;
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
            => $"Name: {FirstName} {LastName} Id: {Id} "
               + Environment.NewLine + $"  Code Number: {CodeNumber}";
    }
}

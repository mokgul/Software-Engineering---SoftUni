using System;
using System.Collections.Generic;
using System.Text;
 
namespace ComputerArchitecture
{
    public class CPU
    {
        public CPU(string brand, int cores, double frequency)
        {
            this.Brand = brand;
            this.Cores = cores;
            this.Frequency = frequency;
        }
        private string brand;
        private int cores;
        private double frequency;
 
        public string Brand { get { return this.brand; } set { this.brand = value; } }
        public int Cores { get { return this.cores; } set { this.cores = value; } }
        public double Frequency { get { return this.frequency; } set { this.frequency = value; } }
 
        public override string ToString()
        {
            string result = $"{this.brand} CPU:" + Environment.NewLine + $"Cores: {this.cores}" + Environment.NewLine +
                            $"Frequency: {this.frequency} GHz";
            return result;
        }
    }
}
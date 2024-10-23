using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Enumerable = System.Linq.Enumerable;
 
namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            this.Model = model;
            this.Capacity = capacity;
            this.Multiprocessor = new List<CPU>();
        }
        private string model;
        private int capacity;
        private List<CPU> multiprocessor;
        public string Model { get { return this.model; } set { this.model = value; } }
        public int Capacity { get { return this.capacity; } set { this.capacity = value; } }
        public List<CPU> Multiprocessor { get { return this.multiprocessor; } set { this.multiprocessor = value; } }
 
        public int Count { get { return this.multiprocessor.Count; } }
 
        public void Add(CPU cpu)
        {
            if(this.Multiprocessor.Count < this.Capacity)
                this.Multiprocessor.Add(cpu);
        }
 
        public bool Remove(string brand)
        {
            if(this.Multiprocessor.Contains(this.Multiprocessor.Find(c => c.Brand == brand)))
            {
                this.Multiprocessor.Remove(this.Multiprocessor.Find(c => c.Brand == brand));
                return true;
            }
            return false;
        }
 
        public CPU MostPowerful()
            => this.Multiprocessor.OrderByDescending(c => c.Frequency).First();
 
        public CPU GetCPU(string brand)
            => this.Multiprocessor.FirstOrDefault(c => c.Brand == brand);
 
        public string Report()
        {
            string result = $"CPUs in the Computer {this.Model}:";
            foreach (var cpu in this.Multiprocessor)
            {
                result = result + Environment.NewLine + cpu.ToString();
            }
 
            return result;
        }
    }
}
using System;
using System.Text;


namespace Animals
{
    public class Animal
    {
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        private string name;
        private int age;
        private string gender;

        public string Name
        {
            get => name;
            private set
            {
                if(string.IsNullOrEmpty(value))
                    throw new ArgumentException("Invalid input!");
                name = value;
            }
        }

        public int Age
        {
            get => age;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Invalid input!");
                age = value;
            }
        }

        public string Gender
        {
            get => gender;
            private set
            {
                if (value != "Male" && value != "Female")
                    throw new ArgumentException("Invalid input!");
                gender = value;
            }
        }

        public virtual string ProduceSound() => "Noise";

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name}")
                .AppendLine($"{Name} {Age} {Gender}")
                .Append(ProduceSound());
            return sb.ToString();
        }
    }
}

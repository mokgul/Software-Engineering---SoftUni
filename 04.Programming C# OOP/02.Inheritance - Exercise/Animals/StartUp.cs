using System;
using System.Text;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            while (true)
            {
                string type = Console.ReadLine();
                if (type == "Beast!") break;
                string[] tokens = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string gender = tokens.Length > 2 ? tokens[2] : string.Empty;

                switch (type)
                {
                    case "Cat":
                        Cat cat = new Cat(name, age, gender);
                        result.AppendLine(cat.ToString());
                        break;
                    case "Dog":
                        Dog dog = new Dog(name, age, gender);
                        result.AppendLine(dog.ToString());
                        break;
                    case "Frog": 
                        Frog frog = new Frog(name, age, gender);
                        result.AppendLine(frog.ToString());
                        break;
                    case "Kitten": 
                        Kitten kitten = new Kitten(name, age);
                        result.AppendLine(kitten.ToString());
                        break;
                    case "Tomcat": 
                        Tomcat tomcat = new Tomcat(name, age);
                        result.Append(tomcat.ToString());
                        break;
                    default:
                        throw new ArgumentException("Invalid input!");
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}

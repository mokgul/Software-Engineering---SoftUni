using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace _01._Ranking
{
    class Student
    {
        public Student(string name)
        {
            this.Name = name;
            this.ContestsTaken = new Dictionary<string, int>();
        }
        public string Name { get; set; }
        public Dictionary<string, int> ContestsTaken { get; set; }

        public static string[] GetTotalPoints(List<Student> students)
        {
            Dictionary<string, int> totalPoints = new Dictionary<string, int>();
            foreach (var student in students)
            {
                totalPoints.Add(student.Name, student.ContestsTaken.Sum(x => x.Value));
            }

            string[] best = new string[2];
            int maxPoints = 0;
            foreach (var item in totalPoints)
            {
                if (item.Value > maxPoints)
                {
                    maxPoints = item.Value;
                    best[0] = item.Key;
                    best[1] = item.Value.ToString();
                }
            }
            return best;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = GetContests();
            List<Student> students = GetStudents(contests);

            students = students.OrderBy(x => x.Name).ToList();
            //students = SortByPoints(students);

            string[] best = Student.GetTotalPoints(students);
            Console.WriteLine($"Best candidate is {best[0]} with total {best[1]} points.");
            Console.WriteLine("Ranking:");

            foreach (Student student in students)
            {
                Console.WriteLine(student.Name);
                Console.WriteLine(string.Join(Environment.NewLine,
                    student.ContestsTaken.OrderByDescending(p => p.Value)
                        .Select(y => $"#  {y.Key} -> {y.Value}")));
            }
        }

        private static Dictionary<string, string> GetContests()
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            string line = Console.ReadLine();
            while (line != "end of contests")
            {
                string[] tokens = line.Split(':');
                string contest = tokens[0];
                string password = tokens[1];

                contests.Add(contest, password);
                //contests[contest] = password;
                line = Console.ReadLine();
            }
            return contests;
        }

        private static List<Student> GetStudents(Dictionary<string, string> contests)
        {
            List<Student> students = new List<Student>();

            string line = Console.ReadLine();
            while (line != "end of submissions")
            {
                string[] tokens = line.Split(new char[] { '=', '>' }, StringSplitOptions.RemoveEmptyEntries);
                string contest = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);


                if (isValid(contest, password, contests))
                {
                    if (students.Any(s => s.Name == username))
                    {
                        students = UpdateInfo(students, username, contest, points);
                    }
                    else
                    {
                        Student student = new Student(username);
                        student.ContestsTaken.Add(contest, points);
                        students.Add(student);
                    }
                }
                line = Console.ReadLine();
            }
            return students;
        }

        private static List<Student> UpdateInfo(List<Student> students, string username, string contest, int points)
        {
            foreach (Student student in students)
            {
                if (student.Name == username)
                {
                    if (student.ContestsTaken.ContainsKey(contest))
                    {
                        if (points > student.ContestsTaken[contest])
                            student.ContestsTaken[contest] = points;
                    }
                    else
                    {
                        student.ContestsTaken.Add(contest, points);
                    }
                }
            }
            return students;
        }
        private static bool isValid(string contest, string password, Dictionary<string, string> contests)
        {
            bool valid = (contests.Any(c => c.Key == contest))
                ? contests.Any(p => p.Value == password) : false;
            return valid;
        }
    }
}

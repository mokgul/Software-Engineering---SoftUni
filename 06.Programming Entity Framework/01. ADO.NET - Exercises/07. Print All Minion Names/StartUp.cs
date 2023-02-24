using Config;
using Microsoft.Data.SqlClient;

namespace _07._Print_All_Minion_Names
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            List<string> newOrder = new List<string>();

            using SqlConnection conn = new SqlConnection(ConnectionString.ConfigString);
            conn.Open();

            SqlCommand getNames = new SqlCommand(
                @"SELECT Name FROM Minions", conn
            );
            using (SqlDataReader reader = getNames.ExecuteReader())
            {
                while (reader.Read())
                {
                    names.Add((string)reader["Name"]);
                }
            }
            newOrder = Rearrange(names, newOrder);
            Console.WriteLine(string.Join(Environment.NewLine, newOrder));
        }

        private static List<string> Rearrange(List<string> names, List<string> newOrder)
        {
            if (names.Count == 0) return newOrder;
            newOrder.Add(names.First());
            names.RemoveAt(0);
            names.Reverse();
            return Rearrange(names,newOrder);
        }
    }
}
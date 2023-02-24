using Config;
using Microsoft.Data.SqlClient;

namespace _08._Increase_Minion_Age
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string,int> minions = new Dictionary<string,int>();
            int[] minionIDs = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToArray();

            using SqlConnection conn = new SqlConnection(ConnectionString.ConfigString);
            conn.Open();


            for (int i = 0; i < minionIDs.Length; i++)
            {
                SqlCommand updateAge = new SqlCommand(
                    @"UPDATE Minions
                        SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                        WHERE Id = @Id", conn
                );
                updateAge.Parameters.AddWithValue("@Id", minionIDs[i]);
                updateAge.ExecuteNonQuery();
            }

            SqlCommand getMinions = new SqlCommand(
                @"SELECT Name,Age FROM Minions", conn);
            using SqlDataReader reader = getMinions.ExecuteReader();
            while (reader.Read())
            {
                string name = (string)reader["Name"];
                int age = (int)reader["Age"];
                if(!minions.ContainsKey(name))
                    minions.Add(name, age);
            }
            foreach (var minion in minions)
            {
                Console.WriteLine($"{minion.Key} {minion.Value}");
            }
        }
    }
}
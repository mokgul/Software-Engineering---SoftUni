using Config;
using Microsoft.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Threading.Channels;

namespace _01._Initial_Setup
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(ConnectionString.ConfigString);
            string villianName = string.Empty;
            string villianId = Console.ReadLine();


            conn.Open();
            using (conn)
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT Name FROM Villains WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", villianId);
                SqlDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        villianName = (string)reader["Name"];
                        Console.WriteLine($"Villain: {villianName}");
                    }
                }
            }

            if (String.IsNullOrEmpty(villianName))
            {
                Console.WriteLine($"No villain with ID {villianId} exists in the database.");
                return;
            }
            conn = new SqlConnection(ConnectionString.ConfigString);
            conn.Open();
            using (conn)
            {
                SqlCommand cmd2 = new SqlCommand(
                        @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                                             m.Name, 
                                             m.Age
                                        FROM MinionsVillains AS mv
                                        JOIN Minions As m ON mv.MinionId = m.Id
                                       WHERE mv.VillainId = @Id
                                    ORDER BY m.Name", conn
                    );
                cmd2.Parameters.AddWithValue("@Id", villianId);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                using (reader2)
                {
                    string minionName = string.Empty;
                    while (reader2.Read())
                    {
                        long row = (long)reader2["RowNum"];
                        minionName = (string)reader2["Name"];
                        int age = (int)reader2["Age"];
                        Console.WriteLine($"{row}. {minionName} {age}");
                    }
                    if(String.IsNullOrEmpty(minionName))
                        Console.WriteLine("(no minions)");
                }
            }
        }
    }
}
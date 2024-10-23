using Config;
using Microsoft.Data.SqlClient;

namespace _01._Initial_Setup
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(ConnectionString.ConfigString);

            conn.Open();

            using (conn)
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                            FROM Villains AS v 
                            JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                            GROUP BY v.Id, v.Name 
                            HAVING COUNT(mv.VillainId) > 3 
                            ORDER BY COUNT(mv.VillainId)", conn
                );

                SqlDataReader reader = cmd.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string villianName = (string)reader["Name"];
                        int minionsNumber = (int)reader["MinionsCount"];

                        Console.WriteLine($"{villianName} - {minionsNumber}");
                    }
                }
            }
        }
    }
}
using Config;
using Microsoft.Data.SqlClient;

namespace _09._Increase_Age_Stored_Procedure
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int minionId = int.Parse(Console.ReadLine());
            string minion = String.Empty;

            using SqlConnection conn = new SqlConnection(ConnectionString.ConfigString);
            conn.Open();

            SqlCommand procedure = new SqlCommand(
                @" CREATE OR ALTER PROC usp_GetOlder(@Id INT)
                         AS 
                         UPDATE Minions
                         SET Age += 1
                         WHERE Id = @Id",
                conn);
           
            procedure.ExecuteNonQuery();

            SqlCommand cmd = new SqlCommand(@"EXEC usp_GetOlder @Id", conn);
            cmd.Parameters.AddWithValue("@Id", minionId);
            cmd.ExecuteNonQuery();
            
            SqlCommand getMinion = new SqlCommand(
                @"SELECT Name, Age FROM Minions WHERE Id = @Id", conn
            );
            getMinion.Parameters.AddWithValue("@Id", minionId);
            using (SqlDataReader reader = getMinion.ExecuteReader())
            {
                while (reader.Read())
                {
                    minion = (string)reader["name"] +
                             " - " +
                             reader["Age"].ToString() +
                             " years old";
                }
            }

            Console.WriteLine(minion);
        }
    }
}
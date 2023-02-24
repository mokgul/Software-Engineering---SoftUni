using Config;
using Microsoft.Data.SqlClient;

namespace _06._Remove_Villain
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());
            string villanName = string.Empty;

            using SqlConnection conn = new SqlConnection(ConnectionString.ConfigString);

            conn.Open();

            SqlCommand getVillainId = new SqlCommand(
                @"SELECT Name FROM Villains WHERE Id = @villainId", conn
            );
            getVillainId.Parameters.AddWithValue(@"villainId", villainId);
            villanName = (string)getVillainId.ExecuteScalar();
            if (String.IsNullOrEmpty(villanName))
            {
                Console.WriteLine("No such villain was found.");
                return;
            }

            int counter = 0;
            SqlCommand getCount = new SqlCommand(
                @"SELECT COUNT(*) FROM MinionsVillains 
                        WHERE VillainId = @villainId", conn
            );
            getCount.Parameters.AddWithValue(@"villainId", villainId);
            counter = (int)getCount.ExecuteScalar();

            SqlCommand deleteFromMapTable = new SqlCommand(
                @"DELETE FROM MinionsVillains 
                        WHERE VillainId = @villainId", conn
            );
            deleteFromMapTable.Parameters.AddWithValue(@"villainId", villainId);
            deleteFromMapTable.ExecuteNonQuery();

            SqlCommand deleteVillain = new SqlCommand(
                @"DELETE FROM Villains
                    WHERE Id = @villainId", conn
            );
            deleteVillain.Parameters.AddWithValue(@"villainId", villainId);
            deleteVillain.ExecuteNonQuery();
            Console.WriteLine($"{villanName} was deleted.");
            Console.WriteLine($"{counter} minions were released.");
        }
    }
}
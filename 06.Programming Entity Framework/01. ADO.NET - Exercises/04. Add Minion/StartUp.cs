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

            string[] minionInfo = Console.ReadLine().Split();
            string[] villainInfo = Console.ReadLine().Split();

            string minionName = minionInfo[1];
            string minionAge = minionInfo[2];
            string minionTown = minionInfo[3];
            int minionId = 0;

            string villainName = villainInfo[1];
            int villainId = 0;

            using (conn)
            {
                //Check if villain is in DB
                SqlCommand villainCheck = new SqlCommand(
                    @"SELECT Id FROM Villains WHERE Name = @Name", conn
                );
                
                villainCheck.Parameters.AddWithValue("@Name", villainName);
                
                using (SqlDataReader reader = villainCheck.ExecuteReader())
                {
                    while (reader.Read())
                        villainId = (int)reader["Id"];
                }

                if (villainId == 0)
                {
                    SqlCommand addVillain = new SqlCommand(
                        @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)", conn
                    );
                    addVillain.Parameters.AddWithValue("@villainName", villainName);
                    addVillain.ExecuteNonQueryAsync();
                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                //Check if minion in DB
                SqlCommand minionCheck = new SqlCommand(
                    @"SELECT Id FROM Minions WHERE Name = @Name", conn
                );
                minionCheck.Parameters.AddWithValue("@Name", minionName);
                using (SqlDataReader reader = minionCheck.ExecuteReader())
                {
                    while (reader.Read())
                        minionId = (int)reader["Id"];
                }

                if (minionId == 0)
                {
                    int townId = 0;
                    SqlCommand townIdSQL = new SqlCommand(
                        @"SELECT Id FROM Towns WHERE Name = @townName", conn);
                    townIdSQL.Parameters.AddWithValue("@townName", minionTown);
                    if (townIdSQL.ExecuteNonQuery() == -1)
                    {
                        SqlCommand addTown = new SqlCommand(
                            @"INSERT INTO Towns (Name) VALUES (@townName)", conn);
                        addTown.Parameters.AddWithValue("@townName", minionTown);
                        addTown.ExecuteNonQueryAsync();
                        Console.WriteLine($"Town {minionTown} was added to the database.");
                    }
                    else
                        townId = townIdSQL.ExecuteNonQuery();

                    SqlCommand addMinion = new SqlCommand(
                        @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)", conn);
                    addMinion.Parameters.AddWithValue("@name", minionName);
                    addMinion.Parameters.AddWithValue("@age", minionAge);
                    addMinion.Parameters.AddWithValue("@townId", townId);
                    addMinion.ExecuteNonQueryAsync();

                }
                SqlCommand addToMapTable = new SqlCommand(
                        @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)", conn);
                    addToMapTable.Parameters.AddWithValue(@"MinionId", minionId);
                    addToMapTable.Parameters.AddWithValue(@"VillainId", villainId);
                    addToMapTable.ExecuteNonQueryAsync();
                    Console.WriteLine($"Successfully add {minionName} to be minion of {villainName}");
                
            }
        }
    }
}
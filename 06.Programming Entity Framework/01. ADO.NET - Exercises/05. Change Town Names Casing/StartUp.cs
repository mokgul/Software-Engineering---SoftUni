using System.ComponentModel.DataAnnotations.Schema;
using Config;
using Microsoft.Data.SqlClient;

namespace _01._Initial_Setup
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            int countryCode = 0;
            SqlConnection conn = new SqlConnection(ConnectionString.ConfigString);

            conn.Open();

            using (conn)
            {
                SqlCommand getCountryCode = new SqlCommand(
                    @"SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName", conn
                );
                SqlCommand checkIfCountryHasTowns = new SqlCommand(
                    @"SELECT t.Name 
                           FROM Towns as t
                           JOIN Countries AS c ON c.Id = t.CountryCode
                          WHERE c.Name = @countryName", conn
                );
                getCountryCode.Parameters.AddWithValue("@countryName", country);
                checkIfCountryHasTowns.Parameters.AddWithValue(@"countryName", country);
                int townCount = 0;
               
                using (SqlDataReader reader = getCountryCode.ExecuteReader())
                {
                    while (reader.Read())
                        countryCode = (int)reader["Id"];
                }
                string townName = string.Empty;
                using (SqlDataReader reader = checkIfCountryHasTowns.ExecuteReader())
                {
                    while (reader.Read())
                        townName = (string)reader["Name"];
                }

                if (countryCode == 0 || townName == String.Empty)
                {
                    Console.WriteLine("No town names were affected.");
                    return;
                }

                List<string> towns = new List<string>();
                SqlCommand getCountry = new SqlCommand(
                    @"UPDATE Towns
                           SET Name = UPPER(Name)
                           WHERE CountryCode = @countryCode"
                    , conn
                );
                getCountry.Parameters.AddWithValue(@"@countryCode", countryCode);
                getCountry.ExecuteNonQuery();
                using(SqlDataReader reader = checkIfCountryHasTowns.ExecuteReader())
                {
                    while (reader.Read())
                        towns.Add((string)reader["Name"]);

                }
                
                Console.WriteLine($"{towns.Count} towns names were affected.");
                Console.WriteLine($"[" + (string.Join(", ", towns)) + "]");
            }
        }
    }
}
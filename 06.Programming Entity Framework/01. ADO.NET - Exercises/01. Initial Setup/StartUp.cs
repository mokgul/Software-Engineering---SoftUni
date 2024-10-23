using Config;
using Microsoft.Data.SqlClient;

namespace _01._Initial_Setup
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(ConnectionString.ConfigString);
        }
    }
}
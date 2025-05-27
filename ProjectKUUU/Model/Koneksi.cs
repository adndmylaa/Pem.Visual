using MySql.Data.MySqlClient;

namespace ProjectKUUU.Model
{
    public static class Koneksi
    {
        private static string connectionString = "server=localhost;user id=root;password=;database=mathrush;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}

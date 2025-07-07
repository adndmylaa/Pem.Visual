using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace ProjectKUUU.Model
{
    public class ScoreEntry
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }

    public class DatabaseHelper
    {
        public static string ConnectionString = "server=localhost;user=root;password=;database=mathrush;";

        public DatabaseHelper()
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();

                string createScoreTable = @"
                    CREATE TABLE IF NOT EXISTS scores (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        name VARCHAR(100) NOT NULL,
                        score INT NOT NULL
                    );";

                string createUserTable = @"
                    CREATE TABLE IF NOT EXISTS users (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        email VARCHAR(100) NOT NULL UNIQUE,
                        password VARCHAR(100) NOT NULL,
                        created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                    );";

                using (var cmd = new MySqlCommand(createScoreTable, conn))
                    cmd.ExecuteNonQuery();

                using (var cmd = new MySqlCommand(createUserTable, conn))
                    cmd.ExecuteNonQuery();
            }
        }

        // ------------------- SCORE FUNCTIONS -------------------

        public void SaveScore(string name, int score)
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO scores (name, score) VALUES (@name, @score)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@score", score);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateNameById(int id, string newName)
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE scores SET name = @name WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@name", newName);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }


        public void DeleteScore(string name)
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "DELETE FROM scores WHERE name = @name";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ScoreEntry> GetLeaderboard()
        {
            var list = new List<ScoreEntry>();

            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT name, score FROM scores ORDER BY score DESC LIMIT 10";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ScoreEntry
                        {
                            Name = reader.GetString("name"),
                            Score = reader.GetInt32("score")
                        });
                    }
                }
            }

            return list;
        }

        public DataTable GetAllScores()
        {
            DataTable dt = new DataTable();

            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT id, name, score FROM scores";
                using (var adapter = new MySqlDataAdapter(query, conn))
                {
                    adapter.Fill(dt);
                }
            }

            return dt;
        }

        // ------------------- USER FUNCTIONS -------------------

        public void SaveUser(string email, string password)
        {
            if (CheckUserExists(email))
                throw new Exception("Email sudah terdaftar.");

            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO users (email, password) VALUES (@Email, @Password)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password); // Disarankan: hash password
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool CheckUserExists(string email)
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM users WHERE email = @Email";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public bool ValidateUser(string email, string password)
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM users WHERE email = @Email AND password = @Password";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }
    }
}

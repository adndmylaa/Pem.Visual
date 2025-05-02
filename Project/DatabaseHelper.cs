using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace MathRush
{
    public class ScoreEntry
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }

    public class DatabaseHelper
    {
        private string connectionString = "server=localhost;user=root;password=;database=mathrush;";

        public DatabaseHelper()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS scores (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        name VARCHAR(100) NOT NULL,
                        score INT NOT NULL
                    );
                ";

                using (var cmd = new MySqlCommand(createTableQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void SaveScore(string name, int score)
        {
            using (var conn = new MySqlConnection(connectionString))
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

        public void UpdateScore(string name, int newScore)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE scores SET score = @score WHERE name = @name";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@score", newScore);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteScore(string name)
        {
            using (var conn = new MySqlConnection(connectionString))
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

            using (var conn = new MySqlConnection(connectionString))
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

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT name AS Name, score AS Score FROM scores";

                using (var adapter = new MySqlDataAdapter(query, conn))
                {
                    adapter.Fill(dt);
                }
            }

            return dt;
        }
    }
}

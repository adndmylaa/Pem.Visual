using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Timers;
using MySql.Data.MySqlClient;
using ProjectKUUU;

namespace ProjectKUUU.View
{
    public partial class MainForm : Form
    {
        private Random random = new Random();
        private int num1, num2, score, timeLeft;
        private string correctAnswer;
        private System.Timers.Timer timer;

        public MainForm()
        {
            InitializeComponent();
            ResetGameUI();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            score = 0;
            timeLeft = 10;
            lblScore.Text = "Skor: 0";
            btnSubmit.Enabled = true;
            txtAnswer.Enabled = true;
            btnStart.Enabled = false;
            btnKelola.Enabled = false;
            lstLeaderboard.Items.Clear();
            GenerateQuestion();
            StartTimer();
        }

        private void GenerateQuestion()
        {
            num1 = random.Next(1, 20);
            num2 = random.Next(1, 20);
            lblQuestion.Text = $"{num1} + {num2} = ?";
            correctAnswer = (num1 + num2).ToString();
        }

        private void StartTimer()
        {
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
            UpdateTimerUI();
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnTimedEvent(source, e)));
                return;
            }

            timeLeft--;
            UpdateTimerUI();

            if (timeLeft <= 0)
            {
                timer.Stop();
                EndGame();
            }
        }

        private void UpdateTimerUI()
        {
            lblTimer.Text = $"Sisa waktu: {timeLeft} detik";
            progressBar.Value = Math.Max(0, timeLeft * 10);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtAnswer.Text.Trim() == correctAnswer)
            {
                score++;
                lblScore.Text = $"Skor: {score}";
                timeLeft = 10; // reset timer
                GenerateQuestion();
            }
            txtAnswer.Clear();
        }

        private void EndGame()
        {
            txtAnswer.Enabled = false;
            btnSubmit.Enabled = false;
            btnStart.Enabled = true;
            btnKelola.Enabled = true;

            string name = Prompt.ShowDialog("Masukkan nama Anda:", "Game Selesai");
            if (!string.IsNullOrEmpty(name))
            {
                SaveScore(name, score);
            }

            LoadLeaderboard();
        }

        private void SaveScore(string name, int score)
        {
            try
            {
                using (MySqlConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO scores (name, score) VALUES (@name, @score)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@score", score);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan skor: " + ex.Message);
            }
        }

        private void LoadLeaderboard()
        {
            lstLeaderboard.Items.Clear();

            try
            {
                using (MySqlConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT name, score FROM scores ORDER BY score DESC LIMIT 10";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString("name");
                            int score = reader.GetInt32("score");
                            lstLeaderboard.Items.Add($"{name} - {score}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat leaderboard: " + ex.Message);
            }
        }

        private void btnKelola_Click(object sender, EventArgs e)
        {
            FormCRUD crudForm = new FormCRUD();
            crudForm.ShowDialog();
        }

        private void ResetGameUI()
        {
            lblQuestion.Text = "";
            lblTimer.Text = "Klik Mulai Game";
            progressBar.Maximum = 100;
            progressBar.Value = 0;
            txtAnswer.Text = "";
            txtAnswer.Enabled = false;
            btnSubmit.Enabled = false;
        }
    }
}

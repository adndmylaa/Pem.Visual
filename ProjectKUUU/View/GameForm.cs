using System;
using System.Media;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using ProjectKUUU;

namespace ProjectKUUU.View
{
    public partial class GameForm : Form
    {
        private int score = 0;
        private int timeLeft = 15;
        private int correctAnswer;
        private int correctStreak = 0;
        private string currentOperator;
        private Random rand = new Random();
        private Timer gameTimer;
        private readonly SoundPlayer clickSound;

        public GameForm()
        {
            InitializeComponent();
            clickSound = new SoundPlayer(Path.Combine(Application.StartupPath, "click.wav"));
            GenerateQuestion();
            StartGameTimer();
        }

        private void StartGameTimer()
        {
            gameTimer = new Timer();
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            lblTimer.Text = $"Time: {timeLeft}";
            progressBar.Value = timeLeft * 100 / 15;

            if (timeLeft <= 0)
            {
                gameTimer.Stop();
                string playerName = Interaction.InputBox("Masukkan nama Anda:", "Waktu Habis", "Player");
                if (!string.IsNullOrWhiteSpace(playerName))
                {
                    SaveScore(playerName, score);
                    MessageBox.Show("Skor disimpan!");
                }
                this.Close();
            }
        }

        private void GenerateQuestion()
        {
            int a = rand.Next(1, 20);
            int b = rand.Next(1, 20);
            int op = rand.Next(4);

            switch (op)
            {
                case 0:
                    currentOperator = "+";
                    correctAnswer = a + b;
                    break;
                case 1:
                    currentOperator = "-";
                    correctAnswer = a - b;
                    break;
                case 2:
                    currentOperator = "×";
                    correctAnswer = a * b;
                    break;
                case 3:
                    b = rand.Next(1, 10);
                    a = b * rand.Next(1, 10); // memastikan hasil bagi bulat
                    currentOperator = "÷";
                    correctAnswer = a / b;
                    break;
            }

            lblQuestion.Text = $"{a} {currentOperator} {b} = ?";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            clickSound.Play();

            if (int.TryParse(txtAnswer.Text, out int userAnswer) && userAnswer == correctAnswer)
            {
                score++;
                correctStreak++;
                if (correctStreak == 5)
                {
                    MessageBox.Show("🔥 Streak x5! Bonus +2!");
                    score += 2;
                    correctStreak = 0;
                }
                lblScore.Text = $"Score: {score}";
                timeLeft = 15;
                GenerateQuestion();
            }
            else
            {
                MessageBox.Show("Salah!");
                correctStreak = 0;
            }

            txtAnswer.Clear();
            txtAnswer.Focus();
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
    }
}

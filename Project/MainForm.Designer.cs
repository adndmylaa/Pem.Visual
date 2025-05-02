using System.Windows.Forms;
using System.Drawing;

namespace MathRush
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblQuestion;
        private Label lblTimer;
        private TextBox txtAnswer;
        private Button btnSubmit;
        private Label lblScore;
        private ProgressBar progressBar;
        private ListBox lstLeaderboard;
        private Button btnKelola;
        private Button btnStart;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblQuestion = new Label();
            this.lblTimer = new Label();
            this.txtAnswer = new TextBox();
            this.btnSubmit = new Button();
            this.lblScore = new Label();
            this.progressBar = new ProgressBar();
            this.lstLeaderboard = new ListBox();
            this.btnKelola = new Button();
            this.btnStart = new Button();
            this.SuspendLayout();

            // lblQuestion
            this.lblQuestion.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblQuestion.Location = new Point(50, 30);
            this.lblQuestion.Size = new Size(300, 40);
            this.lblQuestion.TextAlign = ContentAlignment.MiddleCenter;
            this.lblQuestion.BackColor = Color.Transparent;

            // lblTimer
            this.lblTimer.Font = new Font("Segoe UI", 14F);
            this.lblTimer.ForeColor = Color.Red;
            this.lblTimer.Location = new Point(50, 80);
            this.lblTimer.Size = new Size(300, 30);
            this.lblTimer.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTimer.BackColor = Color.Transparent;

            // progressBar
            this.progressBar.Location = new Point(50, 115);
            this.progressBar.Size = new Size(300, 15);

            // txtAnswer
            this.txtAnswer.Font = new Font("Segoe UI", 14F);
            this.txtAnswer.Location = new Point(50, 140);
            this.txtAnswer.Size = new Size(150, 32);

            // btnSubmit
            this.btnSubmit.Font = new Font("Segoe UI", 12F);
            this.btnSubmit.Location = new Point(220, 140);
            this.btnSubmit.Size = new Size(100, 35);
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            // lblScore
            this.lblScore.Font = new Font("Segoe UI", 14F);
            this.lblScore.Location = new Point(50, 180);
            this.lblScore.Size = new Size(300, 30);
            this.lblScore.TextAlign = ContentAlignment.MiddleCenter;
            this.lblScore.BackColor = Color.Transparent;

            // lstLeaderboard
            this.lstLeaderboard.Location = new Point(50, 220);
            this.lstLeaderboard.Size = new Size(300, 100);

            // btnKelola
            this.btnKelola.Font = new Font("Segoe UI", 10F);
            this.btnKelola.Location = new Point(220, 330);
            this.btnKelola.Size = new Size(120, 30);
            this.btnKelola.Text = "Kelola Skor";
            this.btnKelola.Click += new System.EventHandler(this.btnKelola_Click);

            // btnStart
            this.btnStart.Font = new Font("Segoe UI", 10F);
            this.btnStart.Location = new Point(50, 330);
            this.btnStart.Size = new Size(120, 30);
            this.btnStart.Text = "Mulai Game";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);

            // MainForm
            this.ClientSize = new Size(400, 400);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lstLeaderboard);
            this.Controls.Add(this.btnKelola);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "MainForm";
            this.Text = "MathRush";
            this.BackgroundImage = Properties.Resources.background; // Tambahkan gambar ke resource
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

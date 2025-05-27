namespace ProjectKUUU.View
{
    partial class GameForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.ProgressBar progressBar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblQuestion = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();

            this.SuspendLayout();

            this.lblQuestion.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblQuestion.Location = new System.Drawing.Point(30, 30);
            this.lblQuestion.Size = new System.Drawing.Size(440, 50);
            this.lblQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblTimer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTimer.Location = new System.Drawing.Point(30, 90);
            this.lblTimer.Size = new System.Drawing.Size(440, 25);
            this.lblTimer.Text = "Time: 15";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.progressBar.Location = new System.Drawing.Point(30, 120);
            this.progressBar.Size = new System.Drawing.Size(440, 15);
            this.progressBar.Maximum = 100;
            this.progressBar.Value = 100;

            this.txtAnswer.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtAnswer.Location = new System.Drawing.Point(120, 150);
            this.txtAnswer.Size = new System.Drawing.Size(150, 32);

            this.btnSubmit.Text = "Submit";
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSubmit.Location = new System.Drawing.Point(290, 150);
            this.btnSubmit.Size = new System.Drawing.Size(100, 35);
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblScore.Location = new System.Drawing.Point(30, 200);
            this.lblScore.Size = new System.Drawing.Size(440, 30);
            this.lblScore.Text = "Score: 0";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.ClientSize = new System.Drawing.Size(500, 260);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblScore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Text = "Permainan";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

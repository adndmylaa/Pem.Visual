using System;
using System.Data;
using System.Windows.Forms;

namespace MathRush
{
    public partial class FormCRUD : Form
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        public FormCRUD()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = dbHelper.GetAllScores();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (int.TryParse(txtScore.Text.Trim(), out int score) && !string.IsNullOrEmpty(name))
            {
                dbHelper.SaveScore(name, score);
                LoadData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (int.TryParse(txtScore.Text.Trim(), out int newScore) && !string.IsNullOrEmpty(name))
            {
                dbHelper.UpdateScore(name, newScore);
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                dbHelper.DeleteScore(name);
                LoadData();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txtName.Text = dataGridView1.CurrentRow.Cells["Name"].Value?.ToString();
                txtScore.Text = dataGridView1.CurrentRow.Cells["Score"].Value?.ToString();
            }
        }
    }
}

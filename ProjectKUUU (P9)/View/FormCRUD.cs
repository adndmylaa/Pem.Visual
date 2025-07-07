using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ProjectKUUU.Model;


namespace ProjectKUUU.View
{
    public partial class FormCRUD : Form
    {
        private MySqlConnection conn;

        public FormCRUD()
        {
            InitializeComponent();
            conn = Koneksi.GetConnection();
            try
            {
                conn.Open();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membuka koneksi: " + ex.Message);
            }

            this.FormClosed += new FormClosedEventHandler(FormCRUD_FormClosed);
        }

        private void LoadData()
        {
            try
            {
                string query = "SELECT id, name, score FROM scores";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;

                if (dataGridView1.Columns.Contains("name"))
                    dataGridView1.Columns["name"].HeaderText = "Nama";
                if (dataGridView1.Columns.Contains("score"))
                    dataGridView1.Columns["score"].HeaderText = "Skor";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Nama tidak boleh kosong!");
                return;
            }

            if (!int.TryParse(txtScore.Text.Trim(), out int score) || score < 0)
            {
                MessageBox.Show("Score harus berupa angka positif!");
                return;
            }

            try
            {
                string query = "INSERT INTO scores (name, score) VALUES (@name, @score)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@score", score);
                cmd.ExecuteNonQuery();

                LoadData();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menambahkan data: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Pilih data yang akan diubah terlebih dahulu.");
                return;
            }

            if (!int.TryParse(dataGridView1.CurrentRow.Cells["id"].Value.ToString(), out int id))
            {
                MessageBox.Show("ID tidak valid.");
                return;
            }

            string newName = txtName.Text.Trim();

            if (string.IsNullOrEmpty(newName))
            {
                MessageBox.Show("Nama tidak boleh kosong!");
                return;
            }

            if (!int.TryParse(txtScore.Text.Trim(), out int newScore) || newScore < 0)
            {
                MessageBox.Show("Score harus berupa angka positif!");
                return;
            }

            try
            {
                string query = "UPDATE scores SET name = @name, score = @score WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", newName);
                cmd.Parameters.AddWithValue("@score", newScore);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                LoadData();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengupdate data: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Pilih data yang akan dihapus terlebih dahulu.");
                return;
            }

            if (!int.TryParse(dataGridView1.CurrentRow.Cells["id"].Value.ToString(), out int id))
            {
                MessageBox.Show("ID tidak valid.");
                return;
            }

            var confirm = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                string query = "DELETE FROM scores WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                LoadData();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghapus data: " + ex.Message);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                try
                {
                    txtName.Text = dataGridView1.CurrentRow.Cells["name"].Value?.ToString();
                    txtScore.Text = dataGridView1.CurrentRow.Cells["score"].Value?.ToString();
                }
                catch
                {
                    if (dataGridView1.CurrentRow.Cells.Count >= 3)
                    {
                        txtName.Text = dataGridView1.CurrentRow.Cells[1].Value?.ToString();
                        txtScore.Text = dataGridView1.CurrentRow.Cells[2].Value?.ToString();
                    }
                }
            }
        }

        private void txtScore_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtScore.Clear();
        }

        private void FormCRUD_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}

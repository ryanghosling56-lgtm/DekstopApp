using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace WindowsFormsApp1
{
    public partial class FormBuku : Form
    {
        private int selectedBukuId = 0;
        public FormBuku()
        {
            InitializeComponent();
            TampilData();
        }

        //clear input setelah aksi
        private void ClearFields()
        {

        }



        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(Classkoneksi.ConnectionString))
            {
                try
                {
                    string query = "SELECT * FORM Buku";
                    SqlDataAdapter da = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvBuku.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Load Data" + ex.Message);
                }

            }
        }

        private void FormBuku_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void TampilData()
        {
            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM Buku";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvBuku.DataSource = dt;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message);

                }

            }
        }






        //CREATE DATA
        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtJudul.Text) || string.IsNullOrEmpty(txtPenulis.Text))
            {
                MessageBox.Show("Semua Kolom Harus Diisi"); return;
            }

            using (SqlConnection conn = new SqlConnection(Classkoneksi.ConnectionString))
            {
                try
                {
                    conn.Open();

                    //agar stok berupa angka[int]
                    int stok;
                    if (int.TryParse(txtStok.Text, out stok))
                    {
                        MessageBox.Show("Stok harus diisi angka!!");
                        return;
                    }

                    string sql = "INSERT INTO Buku (judul, penulis, stok) VALUES (@judul, @penulis, @stok)";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@judul", txtJudul.Text);
                    cmd.Parameters.AddWithValue("@penulis", txtPenulis.Text);
                    cmd.Parameters.AddWithValue("@stok", stok);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Ditambah");

                    TampilData();
                    ClearFields();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menambah data:" + ex.Message);
                }
            }

        }



        //Edit data

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (selectedBukuId == 0)
            {
                MessageBox.Show("Pilih data yang ingin diubah!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(Classkoneksi.ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Buku SET judul=@judul, penulis=@penulis, stok=@stok WHERE id=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", selectedBukuId);
                    cmd.Parameters.AddWithValue("@judul", txtJudul.Text);
                    cmd.Parameters.AddWithValue("@penulis", txtPenulis.Text);
                    cmd.Parameters.AddWithValue("@stok", int.Parse(txtStok.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil diubah!");
                    TampilData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal Ubah: " + ex.Message);
                }
            }
        }

        //  DELETE: Hapus Data
        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (selectedBukuId == 0) return;

            // Konfirmasi Hapus (Poin User Experience)
            DialogResult dr = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(Classkoneksi.ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM Buku WHERE id=@id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", selectedBukuId);

                        cmd.ExecuteNonQuery();
                        LoadData();
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal Hapus: " + ex.Message);
                    }
                }
            }
        }


        private void dgvBuku_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBuku.Rows[e.RowIndex];
                selectedBukuId = int.Parse(row.Cells["id"].Value.ToString());
                txtJudul.Text = row.Cells["judul"].Value.ToString();
                txtPenulis.Text = row.Cells["penulis"].Value.ToString();
                txtStok.Text = row.Cells["Stok"].Value.ToString();
            }
        }


        private void clearFields()

        {
            txtJudul.Clear();
            txtPenulis.Clear();
            txtStok.Clear();
            selectedBukuId = 0;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvBuku_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dgvBuku_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row
                     = dgvBuku.Rows[e.RowIndex];

                selectedBukuId = int.Parse(row.Cells["0"].Value.ToString());

                txtJudul.Text = row.Cells["Judul"].Value.ToString();
                txtPenulis.Text = row.Cells["penulis"].Value.ToString();
                txtStok.Text = row.Cells["stok"].Value.ToString();
            }
        }
    }
}

    




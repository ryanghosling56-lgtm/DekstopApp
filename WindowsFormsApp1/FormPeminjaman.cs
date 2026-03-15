using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormPeminjaman : Form
    {
        public FormPeminjaman()
        {
            InitializeComponent();
            TampilPinjam();
            LoadData();
        }

        //hubung ke database!!
        private void LoadData()
        {
            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                try
                {
                    string query = @"SELECT p.id, u.username as [Nama Peminjam], b.judul as [Judul Buku],
                                    p.tgl_pinjam as [Tanggal Pinjam], p.tgl_kembali as [Deadline], p.status as [Status]
                                    FROM Peminjaman p
                                    JOIN Users u ON p.user_id = u.id
                                    JOIN Buku b ON p.buku_id = b.id";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvPeminjaman.DataSource = dt;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Load Data!" + ex.Message);

                }
            }

        }

        //menampilkan data di dgvpeminjaman!
        private void TampilPinjam()
        {
            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                try
                {
                    conn.Open();

                    string sql = @"SELECT p.id as [id pinjam],
                                u.username as [Peminjam],
                                b.judul as [Judul Buku],
                                p.tgl_pinjam as [Tanggal Pinjam],
                               p.tgl_kembali as [Deadline],
                                p.status as [Status],
                                 FROM Peminjaman p 
                                JOIN Users u ON p.user_id = u.id,
                                JOIN Buku b ON p.buku_id = b.id";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvPeminjaman.DataSource = dt;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal Ambil Data : " + ex.Message);
                }
            }
        }
            
            
        

        private void FormPengembalian_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FormDashboard"];
            if (frm != null)
            {
                frm.BringToFront();
                frm.Focus();

            }
            else
            {
                FormDashboard dash = new FormDashboard();
                dash.Show();


            }
            this.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btntambah_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                conn.Open();

                string sql = @"INSERT INTO Peminjaman (user_id, buku_id, tgl_pinjam, tgl_kembali, status)
                             VALUES (@uid, @bid, @tglp, @tglk, 'Dipinjam');
                             UPDATE Buku SET stok = stok - 1 WHERE id = @bid;";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@uid", cmbUser.SelectedValue);
                cmd.Parameters.AddWithValue("@bid", cmbBuku.SelectedValue);
                cmd.Parameters.AddWithValue("@tglp", dtpPinjam.Value);
                cmd.Parameters.AddWithValue("@tglk", dtpKembali.Value);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Peminjaman Berhasil!");
                TampilPinjam();

            }
        }
    }
}

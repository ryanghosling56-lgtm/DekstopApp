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
    public partial class Detail_Transaksi : Form
    {
        private int SelectedDetailID = 0;

        public Detail_Transaksi()
        {
            InitializeComponent();
            TampilDetail();




        }

        public void ClearField()
        {

        }

        //hubung ke database!!

        private void KoneksiDatabase()
        {
            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                try
                {
                    string query =@"SELECT p.id, u.email as [Peminjam], b.judul as [Judul Buku], p.tgl_pinjam as [Tanggal Pinjam], p.tgl_kembali as [Tanggal Kembali], p.tgl_nyata_kembali as [Tanggal Nyata Dikembalikan], p.denda as [Denda], k.nama_kondisi as [Kondisi Buku] FROM Peminjaman p JOIN Users u ON p.user_id = u.id JOIN Buku b ON p.buku_id = b.id JOIN Kondisi k ON p.kondisi_id = k.id_kondisi";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Load Data : " + ex.Message);

                }
            }
        }


        //Load Data di DGV DETAIL!!

        private void TampilDetail()
        {
            using (SqlConnection conn= Classkoneksi.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = @"SELECT p.id, u.email as [Peminjam], b.judul as [Judul Buku], p.tgl_pinjam as [Tanggal Pinjam], p.tgl_kembali as [Tanggal Kembali], p.tgl_nyata_kembali as [Tanggal Nyata Dikembalikan], p.denda as [Denda], k.nama_kondisi as [Kondisi Buku] FROM Peminjaman p JOIN Users u ON p.user_id = u.id JOIN Buku b ON p.buku_id = b.id JOIN Kondisi k ON p.kondisi_id = k.id_kondisi ORDER BY p.id DESC";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    //Agar data terbaru muncul diatas!!
                    dataGridView1.ReadOnly = true;
                  

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Load Data: " + ex.Message);

                }
            }

        }

        private void Detail_Transaksi_Load(object sender, EventArgs e)
        {
            TampilDetail();
        }




        //Kembali ke form dashboard!!
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

       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = @"SELECT u.email, b.judul, p.denda, k.nama_kondisi FROM Peminjaman p JOIN Users u ON p.user_id = u.id JOIN Buku b ON p.buku_id = b.id JOIN Kondisi k ON p.kondisi_id = k.id_kondisi WHERE u.email LIKE @cari OR b.judul LIKE @cari OR p.denda LIKE @cari OR k.nama_kondisi LIKE @cari"; 

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@cari", "%" + txtSearch.Text + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message );

                }
            }
        }

        

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        //filter Rentang tanggal Button!!
        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                try
                {
                    conn.Open();

                    DateTime tglawal = dtpAwal.Value.Date;
                    DateTime tglakhir = dtpAkhir.Value.Date;

                    string sql = @"SELECT p.id, u.email, b.judul, p.tgl_pinjam, p.tgl_kembali, p.tgl_nyata_kembali, p.denda, k.nama_kondisi 
                                 FROM Peminjaman p JOIN Users u ON p.user_id = u.id JOIN Buku b ON p.buku_id = b.id JOIN Kondisi k ON p.kondisi_id = k.id_kondisi
                                 WHERE (tgl_pinjam BETWEEN @tglawal AND @tglakhir) OR (tgl_kembali BETWEEN @tglawal AND @tglakhir) OR (tgl_nyata_kembali BETWEEN @tglawal AND @tglakhir) 
                                 ORDER BY tgl_pinjam DESC";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@tglawal", tglawal);
                    cmd.Parameters.AddWithValue("@tglakhir", tglakhir);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtpAwal.Value = DateTime.Now;
            dtpAkhir.Value = DateTime.Now;

            if (txtSearch !=null)
            {
                txtSearch.Clear();
            }

            TampilDetail();


            txtSearch.Focus();

        }
    }
}

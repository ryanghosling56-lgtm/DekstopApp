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
    public partial class FormPengembalian : Form
    {
        private int SelectedPinjamID = 0;

        
        public FormPengembalian()
        {
            InitializeComponent();
            TampilKembali();
        }

        public void ClearField()
        {


        }


        //HUbungkan ke DAtabase!
        private void KoneksiDatabase()
        {
            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                try
                {
                    string query = @"SELECT p.id, u.email as [Peminjam] , b.judul as [Judul Buku] , p.tgl_pinjam as [Tanggal Pinjam], p.tgl_kembali as [Tanggal Kembali], p.tgl_nyata_kembali as [Tanggal Nyata Kembali] , p.denda as [Denda], k.nama_kondisi as [Kondisi Buku] FROM Peminjaman p JOIN Users u ON p.user_id = u.id JOIN Buku b ON p.buku_id = b.id  JOIN Kondisi k ON p.kondisi_id = k.id_kondisi";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvKembali.DataSource = dt;



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Load Data!! ; " + ex.Message);

                }

            }
        }


        //Menampilkan Data pada DGV!
        private void TampilKembali()
        {
            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = @"SELECT p.id as [ID Peminjam],                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
                                 u.email as [Peminjam],
                                 b.judul as [Judul Buku],
                                p.tgl_pinjam as [Tanggal Pinjam],
                                p.tgl_kembali as [Tanggal Kembali],
                                p.tgl_nyata_kembali as [Tanggal Nyata Kembali],
                                p.denda as [Denda]
                                   FROM Peminjaman p 
                                JOIN Users u ON p.user_id = u.id
                                JOIN Buku b ON p.buku_id = b.id
                                WHERE p.kondisi_id = 1";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvKembali.DataSource = dt;




                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal Ambil Data ; " + ex.Message);
                }
            }
        }

        //Agar DGV dapat di pilih atau klik!!
        private void dgvKembali_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKembali.Rows[e.RowIndex];
                {
                    if (row.Cells["ID Peminjam"].Value != null)
                    {
                        SelectedPinjamID = int.Parse(row.Cells["ID Peminjam"].Value.ToString());

                        cmbUser.Text = row.Cells["Peminjam"].Value.ToString();
                        cmbBuku.Text = row.Cells["Judul Buku"].Value.ToString();

                        dtpPinjam.Value = Convert.ToDateTime(row.Cells["Tanggal Pinjam"].Value);
                        dtpKembali.Value = Convert.ToDateTime(row.Cells["Tanggal Kembali"].Value);
                        dtpNyata.Value = DateTime.Now;
                        HitungDenda();
                    }
                }

            }
        }

        //Fungsi query Agregat Denda! atau hitung denda!
        private void HitungDenda()
        {
            TimeSpan selisih = dtpNyata.Value - dtpKembali.Value.Date;
            
            if (selisih.Days > 0)
            {
                int denda = selisih.Days * 2000;
                txtDenda.Text = denda.ToString();
            }
            else
            {
                txtDenda.Text = "0";

            }
        }


        //Agar Denda berubah otomatis saat berganti atau update hari!!
        private void dtpNyata_ValueChanged(object sender, EventArgs e)
        {
            HitungDenda();

        }


        //Tombol Mengembalikan!!
        private void btntambah_Click(object sender, EventArgs e)
        {
            if (SelectedPinjamID == 0)
            {
                MessageBox.Show("Pilih Data Yang Ingin Di Kembalikan!");

                return;
            }
            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                try
                {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction();

                    try
                    {
                        //update status pinjam menjadi kembali!!
                        string queryUpdate = @"UPDATE Peminjaman SET
                                              tgl_nyata_kembali = @tgl,
                                              denda = @denda,
                                              kondisi_id = 2
                                              WHERE id = @id";

                        SqlCommand cmd = new SqlCommand(queryUpdate, conn, trans);

                        cmd.Parameters.AddWithValue("@tgl", dtpNyata.Value);
                        cmd.Parameters.AddWithValue("@denda", txtDenda.Text);
                        cmd.Parameters.AddWithValue("@id", SelectedPinjamID);
                        cmd.ExecuteNonQuery();


                        //query update stok ketika mengembalikan!
                        string queryStok = " UPDATE Buku SET stok = stok + 1 WHERE judul = @judul";
                        SqlCommand cmd1 = new SqlCommand(queryStok, conn, trans);

                        cmd1.Parameters.AddWithValue("@judul", cmbBuku.Text);
                        cmd1.ExecuteNonQuery();

                        trans.Commit();
                        MessageBox.Show("Berhasil Dikembalikan");

                        TampilKembali();
                        ClearField();




                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Gagal Menyimpan :" + ex.Message);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Koneksi Error :" + ex.Message);

                }
            }

        }

        private void LoadComboBox()
        {
            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                try
                {
                    conn.Open();

                    string sqlPeminjam = "SELECT id, email FROM Users ";
                    SqlDataAdapter daP = new SqlDataAdapter(sqlPeminjam, conn);
                    DataTable dtP = new DataTable();
                    daP.Fill(dtP);

                    cmbUser.DataSource = dtP;
                    cmbUser.DisplayMember = "email";
                    cmbUser.ValueMember = "id";


                    string sqlB = "SELECT id, judul FROM Buku";
                    SqlDataAdapter daB = new SqlDataAdapter(sqlB, conn);
                    DataTable dtB = new DataTable();
                    daB.Fill(dtB);

                    cmbBuku.DataSource = dtB;
                    cmbBuku.DisplayMember = "judul";
                    cmbBuku.ValueMember = "id";

                    cmbUser.SelectedIndex = -1;
                    cmbBuku.SelectedIndex = -1;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal Load Data: " + ex.Message );
                }
                
            }
             
        }       





        //Tombol kembali ke dahsboard!
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
               FormDashboard formDashboard = new FormDashboard();
                formDashboard.Show();


            }
            this.Close();
        }


        //Load agar dgv muncul dan ComboBox berisi!!
        private void FormPengembalian_Load(object sender, EventArgs e)
        {
            TampilKembali();
            LoadComboBox();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

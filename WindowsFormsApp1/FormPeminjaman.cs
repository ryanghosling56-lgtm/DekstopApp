using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormPeminjaman : Form
    {
        private int SelectedPinjamID = 0;
        public FormPeminjaman()
        {
            InitializeComponent();
            TampilPinjam();
           
        }

        public void ClearField()
        {
            cmbUser.SelectedIndex = -1;
            cmbBuku.SelectedIndex = -1;
            cmbKondisi.SelectedIndex = -1;
            dtpKembali.Value = DateTime.Now;
            dtpPinjam.Value = DateTime.Now;
        }


        //hubung ke database!!
        private void LoadData()
        {
            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                try
                {
                    string query = @"SELECT p.id, u.email as [Peminjam], b.judul as [Judul Buku], b.stok as [Stok Tersisa],
                                    p.tgl_pinjam as [Tanggal Pinjam], p.tgl_kembali as [Tanggal Kembali], p.denda as [Denda], k.nama_kondisi as [Kondisi Buku]
                                    FROM Peminjaman p
                                    JOIN Kondisi k ON p.kondisi_id = k.id_kondisi
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

                    string sql = @"SELECT p.id ,
                                u.email as [Peminjam],
                                b.judul as [Judul Buku],
                                b.stok as [Stok Tersisa],
                                p.tgl_pinjam as [Tanggal Pinjam],
                                p.tgl_kembali as [Tanggal Kembali],
                                p.denda as [Denda],
                                k.nama_kondisi as [Kondisi Buku]

                                FROM Peminjaman p 
                                JOIN Kondisi k ON p.kondisi_id = k.id_kondisi
                                JOIN Users u ON p.user_id = u.id
                                JOIN Buku b ON p.buku_id = b.id
                                ORDER BY p.id DESC";

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


        //Pinjam btn !
        private void btntambah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbUser.Text) || string.IsNullOrEmpty(cmbBuku.Text))  
            {
                MessageBox.Show("Semua Kolom Harus Diisi!");
                return;
            }




            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                try
                {
                    conn.Open();
                    //Update stok 
                    string sqlupdate = "UPDATE Buku SET stok = stok - 1 WHERE id = @bid AND stok > 0 ";
                    SqlCommand cmd = new SqlCommand(sqlupdate, conn);
                    cmd.Parameters.AddWithValue("@bid", cmbBuku.SelectedValue);

                    //cek berhasilkah, jika 0 stok kosong! 
                    int stok = cmd.ExecuteNonQuery();

                    if (stok > 0)
                    {
                        string sqlinsert = @"INSERT INTO Peminjaman (user_id, buku_id, kondisi_id , tgl_pinjam, tgl_kembali )
                                            VALUES (@uid, @bid, @kid, @tglp, @tglk )";

                        SqlCommand cmd1 = new SqlCommand(sqlinsert, conn);
                        cmd1.Parameters.AddWithValue("@uid", cmbUser.SelectedValue);
                        cmd1.Parameters.AddWithValue("@bid", cmbBuku.SelectedValue);
                        cmd1.Parameters.AddWithValue("@kid", cmbKondisi.SelectedValue);
                        cmd1.Parameters.AddWithValue("@tglp", dtpPinjam.Value);
                        cmd1.Parameters.AddWithValue("@tglk", dtpKembali.Value);



                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Peminjaman Berhasil!");

                        TampilPinjam();
                        ClearField();
                    }
                    else
                    {
                        MessageBox.Show("Maaf Stok Buku Kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }






                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message);

                }

            }
        }

        //Edit Pinjam!!
        private void button1_Click(object sender, EventArgs e)
        {
            if (SelectedPinjamID == 0 )
            {
                MessageBox.Show("Pilih Data Yang Ingin di edit!");
                return;
            }

            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = @"UPDATE Peminjaman SET  
                                 user_id = @uid,
                                 buku_id = @bid,
                                 kondisi_id = @kid,
                                 tgl_pinjam = @tglp,
                                 tgl_kembali = @tglk
                               
                                 WHERE id = @id";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@id", SelectedPinjamID);

                    cmd.Parameters.AddWithValue("@uid", cmbUser.SelectedValue);
                    cmd.Parameters.AddWithValue("@bid", cmbBuku.SelectedValue);
                    cmd.Parameters.AddWithValue("@kid", cmbKondisi.SelectedValue);
                    cmd.Parameters.AddWithValue("@tglp", dtpPinjam.Value);
                    cmd.Parameters.AddWithValue("@tglk", dtpKembali.Value);
                   

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Peminjaman Berhasil Diubah!");

                    //Disimpan dan Diperlihatkan di DGVpinjam
                    LoadData();
                    ClearField();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal Edit Data : " + ex.Message);

                }

            }
            
        }

        //Hapus btn
        private void button2_Click(object sender, EventArgs e)
        {
            if (SelectedPinjamID == 0)
            {
                MessageBox.Show("Pilih Data Yang Ingin Dihapus!");
                return;
            }

            DialogResult dr = MessageBox.Show("Yakin ingin Menghapus Detail Transaksi?" , "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                using (SqlConnection conn = Classkoneksi.GetConn())
                    try
                    {
                        conn.Open();
                        string sql = "DELETE FROM Peminjaman WHERE id=@id";
                        SqlCommand cmd = new SqlCommand(sql, conn);

                        cmd.Parameters.AddWithValue("@id", SelectedPinjamID);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Berhasil Dihapus");

                        TampilPinjam();
                        ClearField();




                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal Menghapus Data : " + ex.Message );
                    }
            }
        }



        //Load cmb agar terisi!!
        private void LoadComboBox()
        {
            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                try
                {
                    conn.Open();

                    string sqlPeminjam = "SELECT id, email FROM Users";
                    SqlDataAdapter daSiswa = new SqlDataAdapter(sqlPeminjam, conn);
                    DataTable dtPeminjam = new DataTable();
                    daSiswa.Fill(dtPeminjam);

                    cmbUser.DataSource = dtPeminjam;
                    cmbUser.DisplayMember = "email";
                    cmbUser.ValueMember = "id";

                    string sqlBuku = "SELECT id, judul FROM Buku";
                    SqlDataAdapter daBuku = new SqlDataAdapter(sqlBuku, conn);
                    DataTable dtBuku = new DataTable();
                    daBuku.Fill(dtBuku);

                    cmbBuku.DataSource = dtBuku;
                    cmbBuku.DisplayMember = "judul";
                    cmbBuku.ValueMember = "id";


                    string sqlKondisi = "SELECT id_kondisi, nama_kondisi FROM Kondisi";
                    SqlDataAdapter daKondisi = new SqlDataAdapter(sqlKondisi, conn);
                    DataTable dtKondisi = new DataTable();
                    daKondisi.Fill(dtKondisi);

                    cmbKondisi.DataSource = dtKondisi;
                    cmbKondisi.DisplayMember = "nama_kondisi";
                    cmbKondisi.ValueMember = "id_kondisi";

                    //Agar Cmb kosong saat pertama kali form dibuka!
                    cmbUser.SelectedIndex = -1;
                    cmbBuku.SelectedIndex = -1;
                    cmbKondisi.SelectedIndex = -1;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("gagal memuat data: " + ex.Message);

                }
            }
        }
       



        //Load agar dgv muncul dan ComboBox berisi!!
        private void FormPengembalian_Load(object sender, EventArgs e)
        {
            TampilPinjam();
            LoadComboBox();
        }

        //Agar Data Dapat dipilih Pada DGV
        private void dgvPeminjaman_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPeminjaman.Rows[e.RowIndex].Cells[0].Value != null) 
            
            {
                DataGridViewRow row = dgvPeminjaman.Rows[e.RowIndex];

                SelectedPinjamID = int.Parse(row.Cells[0].Value.ToString());
                cmbUser.Text = row.Cells[1].Value.ToString();
                cmbBuku.Text = row.Cells[2].Value.ToString();
                cmbKondisi.Text = row.Cells[3].Value.ToString();

                dtpPinjam.Value = Convert.ToDateTime(row.Cells[4].Value);
                dtpKembali.Value = Convert.ToDateTime(row.Cells[5].Value);


            }
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

        //kembali
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


        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void dgvPeminjaman_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormPeminjaman_Click(object sender, EventArgs e)
        {

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT p.id, u.email, b.judul, b.stok, p.tgl_pinjam, p.tgl_kembali, p.tgl_nyata_kembali, p.denda, k.nama_kondisi FROM Peminjaman p JOIN Users u ON p.user_id = u.id JOIN Buku b ON p.buku_id = b.id JOIN Kondisi k ON p.kondisi_id = k.id_kondisi WHERE u.email LIKE @cari OR b.judul LIKE @cari OR b.stok LIKE @cari OR p.denda LIKE @cari OR k.nama_kondisi LIKE @cari ";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@cari", "%" + txtSearch.Text + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvPeminjaman.DataSource = dt;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);

                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = @"SELECT p.id, u.email, b.judul, b.stok, p.tgl_pinjam, p.tgl_kembali, p.tgl_nyata_kembali, p.denda, k.nama_kondisi FROM Peminjaman p JOIN Users u ON p.user_id = u.id JOIN Buku b ON p.buku_id = b.id JOIN Kondisi k ON p.kondisi_id = k.id_kondisi WHERE CAST(p.tgl_pinjam AS DATE) = @tgl";


                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@tgl", dateTimePicker1.Value.Date);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvPeminjaman.DataSource= dt;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error :" + ex.Message );

                }
            }
        }

        private void toolStrip1_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["formUser"];
            if (frm != null)
            {
                frm.BringToFront();
                frm.Focus();
            }
            else
            {
                formUser user = new formUser();
                user.Show();




            }
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dtpPinjam.Value = DateTime.Now;

            if (txtSearch != null)
            {
                txtSearch.Clear();


            }

            TampilPinjam();


            txtSearch.Focus();

        }
    }
}

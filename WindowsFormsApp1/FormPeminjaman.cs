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
        private int SelectedPinjamID = 0;
        public FormPeminjaman()
        {
            InitializeComponent();
            TampilPinjam();
           
        }

        public void ClearField()
        {
            

        }


        //hubung ke database!!
        private void LoadData()
        {
            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                try
                {
                    string query = @"SELECT p.id, u.email as [Nama Peminjam], b.judul as [Judul Buku],
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
                                u.email as [Peminjam],
                                b.judul as [Judul Buku],
                                p.tgl_pinjam as [Tanggal Pinjam],
                                p.tgl_kembali as [Tanggal Kembali],
                                p.status as [Status]

                                FROM Peminjaman p 
                                JOIN Users u ON p.user_id = u.id
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


        //Create btn !
        private void btntambah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbUser.Text) || string.IsNullOrEmpty(cmbUser.Text))  
            {
                MessageBox.Show("Semua Kolom Harus Diisi!");
                return;
            }

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
                ClearField();

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
                                 tgl_pinjam = @tglp,
                                 tgl_kembali = @tglk,
                                 status = @status,
                                 WHERE id = @id";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@id", SelectedPinjamID);

                    cmd.Parameters.AddWithValue("@uid", cmbUser.SelectedValue);
                    cmd.Parameters.AddWithValue("@bid", cmbBuku.SelectedValue);
                    cmd.Parameters.AddWithValue("@tglp", dtpPinjam.Value);
                    cmd.Parameters.AddWithValue("@tglk", dtpKembali.Value);
                    cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedValue);

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


                    string sqlStatus = "SELECT * FROM [Status]";
                    SqlDataAdapter daStatus = new SqlDataAdapter(sqlStatus, conn);
                    DataTable dtStatus = new DataTable();
                    daStatus.Fill(dtStatus);

                    cmbStatus.DataSource = dtStatus;
                    cmbStatus.DisplayMember = "nama_status";
                    cmbStatus.ValueMember = "id";

                    //Agar Cmb kosong saat pertama kali form dibuka!
                    cmbUser.SelectedIndex = -1;
                    cmbBuku.SelectedIndex = -1;
                    cmbStatus.SelectedIndex = -1;

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
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPeminjaman.Rows[e.RowIndex];
                SelectedPinjamID = int.Parse(row.Cells["id"].Value.ToString());
                cmbUser.Text = row.Cells["email"].Value.ToString();
                cmbBuku.Text = row.Cells["judul"].Value.ToString();
                cmbStatus.Text = row.Cells["nama_status"].Value.ToString();

                dtpPinjam.Value = Convert.ToDateTime(row.Cells["Tanggal Pinjam"].Value);
                dtpKembali.Value = Convert.ToDateTime(row.Cells["Tanggal Kembali"].Value);



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
    }
}

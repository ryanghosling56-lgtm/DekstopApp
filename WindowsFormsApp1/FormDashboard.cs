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
using System.Windows.Forms.DataVisualization.Charting;


namespace WindowsFormsApp1
{
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
        }


        //Load Dashboard!!
        private void FormDashboard_Load(object sender, EventArgs e)
        {
            //menampilkan chart 
            TampilGrafik();

            //label status di bwah / opsional

            labelStatus.Text = "Status Login : " + Classkoneksi.StatusUser;

        }


        // MEnampilkan Laporan chart!!
        private void TampilGrafik()
        {
            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = @"SELECT DATENAME(MONTH, tgl_pinjam) AS Bulan, COUNT(id) AS TOTAL FROM Peminjaman GROUP BY DATENAME(MONTH, tgl_pinjam), MONTH(tgl_pinjam) ORDER BY MONTH(tgl_pinjam) ASC";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    chart1.Series["Data Transaksi /bln"].Points.Clear();

                    foreach (DataRow row in dt.Rows)
                    {
                        chart1.Series["Data Transaksi /bln"].Points.AddXY(row["Bulan"].ToString(), row["TOTAL"]);


                    }






                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal Load Grafik:" + ex.Message);

                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void tRANSAKSIToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        //exit app!!

        private void eXITAPPLICATIONToolStripMenuItem_Click(object sender, EventArgs e)

        {
            DialogResult dr = MessageBox.Show("Yakin Ingin Keluar Dari Aplikasi?" , "Konfirmasi" , MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
         
        // membuka formBuku!

        private void bUKUToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormBuku formbuku = new FormBuku();
            formbuku.ShowDialog();
        }


        // SignOut
        private void uSERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //kosongkan formlogin
            Classkoneksi.NamaUser = null;
            Classkoneksi.StatusUser = null;

            DialogResult dr = MessageBox.Show(" Anda Yakin Ingin SignOut ? ", "Konfirmasi", MessageBoxButtons.YesNo , MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                LoginPerpus login = new LoginPerpus();
                login.Show();
                this.Close();
            }

          
        }

        private void fILEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bUKUToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

       

        //membuka form USers!

        private void uSERSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formUser formUser = new formUser();
            formUser.ShowDialog();

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void sfToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
         // membuka form Peminjaman!!

        private void pEMINJAMANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPeminjaman formPeminjaman = new FormPeminjaman();
            formPeminjaman.ShowDialog();
        }

        private void pENGEMBALIANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPengembalian formPengembalian = new FormPengembalian();
            formPengembalian.ShowDialog();
        }

        private void dETAILTRANSAKSIToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Detail_Transaksi detail = new Detail_Transaksi();
            detail.ShowDialog();
        }


        //Ketika buka dashboard Chartnya auto update!!!
        private void FormDashboard_Activated(object sender, EventArgs e)
        {
            TampilGrafik();

        }
    }
}

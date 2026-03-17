using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
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
            DialogResult dr = MessageBox.Show("Yakin Ingin Keluar Dari Aplikasi?" , "Konfirmasi" , MessageBoxButtons.YesNo);
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

            DialogResult dr = MessageBox.Show(" Anda Yakin Ingin SignOut ? ", "Konfirmasi", MessageBoxButtons.YesNo);
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

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            labelStatus.Text= "   Status Login : " + Classkoneksi.StatusUser ;
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
    }
}

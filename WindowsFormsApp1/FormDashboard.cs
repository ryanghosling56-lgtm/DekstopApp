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

        private void eXITAPPLICATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bUKUToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormBuku formbuku = new FormBuku();
            formbuku.ShowDialog();
        }

        private void uSERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //kosongkan formlogin
            Classkoneksi.NamaUser = null;
            Classkoneksi.StatusUser = null;

            LoginPerpus login = new LoginPerpus();
            login.Show();
            this.Close();
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
            labelStatus.Text= "Sttaus Login: " + Classkoneksi.StatusUser;
        }
    }
}

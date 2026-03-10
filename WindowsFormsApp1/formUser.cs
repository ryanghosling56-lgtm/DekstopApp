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
    public partial class formUser : Form
    {
        public formUser()
        {
            InitializeComponent();
            TampilData();
        }

        private void ClearFields()
        {

        }

        //Menampilkan Data User dari database
        void TampilData()
        {
            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM Users";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvUsers.DataSource = dt;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal Memuat Data! : " +  ex.Message );

                }

            }
        }

        private void formUser_Load(object sender, EventArgs e)
        {
            TampilData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btntambah_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text)) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Semua Kolom harus diisi");
                return;
            }
        }
    }
}
term
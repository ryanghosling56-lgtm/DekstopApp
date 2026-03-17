using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class LoginPerpus : Form
    {
        public LoginPerpus()
        {
            InitializeComponent();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        //Tombol SIGN IN!!!
        private void button1_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                try
                {
                    
                    string sql = "SELECT U.email, R.nama_status FROM Users U " +
                                 " JOIN Status R ON U.status_id = R.id " +
                                 " WHERE U.email=@email AND U.password=@pass";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text.Trim());

                    //membuka koneksi
                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    //Saat Data ditemukan..
                    if (dr.Read())
                    {
                        Classkoneksi.NamaUser = dr["email"].ToString();
                        Classkoneksi.StatusUser = dr["nama_status"].ToString();

                        if (Classkoneksi.StatusUser.ToLower() == "admin") 

                        {
                            MessageBox.Show(" Login Berhasil sebagai Admin ");

                            FormDashboard dash = new FormDashboard();
                            dash.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Akses Ditolak! Hanya admin yang dapat login");
                            conn.Close();

                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Email atau password salah!!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi Kesalahan: " + ex.Message);

                }

               
            }
        }

        //Checkbox Show Passwordd
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.PasswordChar = '\0';
            
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void chkRemember_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

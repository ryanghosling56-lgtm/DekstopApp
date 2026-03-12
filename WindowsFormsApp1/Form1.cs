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


        //Tombol Login!!!
        private void button1_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                try
                {
                    
                    string sql = "SELECT U.username, R.nama_status FROM Users U " +
                                 " JOIN Status R ON U.status_id = R.id " +
                                 " WHERE U.username=@user AND U.password=@pass";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text.Trim());

                    //membuka koneksi
                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    //Saat Data ditemukan..
                    if (dr.Read())
                    {
                        Classkoneksi.NamaUser = dr["username"].ToString();
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
                        MessageBox.Show("Username atau password salah!!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi Kesalahan: " + ex.Message);

                }

                if (chkRemember.Checked)
                {
                    Properties.Settings.Default.Username = txtUsername.Text;
                    Properties.Settings.Default.RememberMe = true;
                }

                else 
                {

                    Properties.Settings.Default.Username = "";
                    Properties.Settings.Default.RememberMe = false;

                    Properties.Settings.Default.Save();

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

        private void LoginPerpus_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RememberMe == true)
            {
                txtUsername.Text = Properties.Settings.Default.Username;
                chkRemember.Checked = true;

            }
        }

        private void chkRemember_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

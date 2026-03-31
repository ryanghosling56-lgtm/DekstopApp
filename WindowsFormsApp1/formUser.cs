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
        private int SelectedUserID = 0;
        public formUser()
        {
            InitializeComponent();
            TampilUser();
            LoadComboBox();
        }

        private void ClearFields()
        {
            txtEmail.Clear();
            txtPassword.Clear();
            SelectedUserID = 0; 
        }







        //Koneksi Database
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(Classkoneksi.ConnectionString))
            {
                try
                {
                    string query = "SELECT * FROM Users";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvUsers.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Load Data!" + ex.Message);

                }
            }
        }

        



        //Menampilkan Data Di DataGridView
        void TampilUser()
        {
            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT Users.id, Users.email, Users.password, [Status].nama_status FROM Users JOIN [Status] ON Users.status_id = [status].id";
                                  



                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvUsers.DataSource = dt;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal Memuat Data! : " + ex.Message);

                }

            }
        }

      


        //memunculkan ComboBox status!
        private void LoadComboBox() 
        {
            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                try
                {
                    conn.Open();

                    string sql = "SELECT * FROM [Status]";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    cmbStatus.DataSource = dt;
                    cmbStatus.DisplayMember = "nama_status";
                    cmbStatus.ValueMember = "id";

                    //Agar Cmb kosong saat pertama kali form dibuka!
                    cmbStatus.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat status!");

                }

            }
        }


        //Tombol create Users 
        private void btntambah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text)) 
            {
                MessageBox.Show("Semua Kolom Wajib Diisi!");
                return;
            }

            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO Users (email, password, status_id) VALUES (@email, @password, @status) ";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedValue);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Berhasil Ditambah");

                    TampilUser();
                    ClearFields();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal Menambah User" + ex.Message);
                }

                }
            }


        //EDIT: edit user!!
        private void btnedit_Click(object sender, EventArgs e)
        {
            if (SelectedUserID == 0) 
            {
                MessageBox.Show("Pilih User yang ingin di edit!");
                return;
            }

            using (SqlConnection conn = Classkoneksi.GetConn())

            {
                try
                {
                    conn.Open();

                    string sql = "UPDATE Users SET email=@email, password=@password, status_id=@status WHERE id=@id ";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@id", SelectedUserID);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedValue);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data User berhasil diperbarui");

                    TampilUser();
                    ClearFields();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memperbarui data!" + ex.Message);

                }
            }
            }

        //Delete Data Users!!
        private void btnhapus_Click(object sender, EventArgs e)

        {
            
            if (SelectedUserID == 0)
            {
                MessageBox.Show("Pilih Data yang ingin dihapus!");
                return;
            }

            //KOnfirmasi hapus!

            DialogResult dr = MessageBox.Show("Yakin ingin Menghapus User?", "Konfirmasi"  , MessageBoxButtons.YesNo , MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                using (SqlConnection conn = Classkoneksi.GetConn())
                    try
                    {
                        conn.Open();
                        string sql = "DELETE FROM Users WHERE id=@id";
                        SqlCommand cmd = new SqlCommand(sql, conn);


                        cmd.Parameters.AddWithValue("@id", SelectedUserID);


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User Berhasil Dihapus");


                        TampilUser();
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(" Gagal menghapus Data User" + ex.Message);
                    }
            }
           
        }


                    
                

         



//Agar Data DApat dipilih pada DGV!!
private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvUsers.Rows[e.RowIndex].Cells[0].Value != null) 
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
                SelectedUserID = int.Parse(row.Cells[0].Value.ToString());
                txtEmail.Text = row.Cells[1].Value.ToString();
                txtPassword.Text = row.Cells[2].Value.ToString();
                cmbStatus.Text = row.Cells[3].Value.ToString();

            }
        }



        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        







        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            
        }
       





        











        private void formUser_Load(object sender, EventArgs e)
        {
            TampilUser();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
      



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            

        }

        private void toolStrip2_ItemClicked(object sender, EventArgs e)
        {
           


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FormDashboard"];


            if (frm != null)
            {
                frm.BringToFront(); // Jika sudah ada, cukup tampilkan ke depan
                frm.Focus();

            }
            else
            {
                FormDashboard dash = new FormDashboard();
                dash.Show();

            }

            this.Close();
        }

        //Search!
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = Classkoneksi.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT Users.id, Users.email, Users.password, [Status].nama_status FROM Users JOIN [Status] ON Users.status_id = [status].id WHERE Users.email LIKE @cari OR [Status].nama_status LIKE @cari OR Users.id LIKE @cari";




                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@cari", "%" + txtSearch.Text + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvUsers.DataSource = dt;




                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);

                }
            }
        }



   
        private void toolStrip2_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {


        }

        //reload page!!
        private void toolStrip2_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (txtSearch != null)
            {
                txtSearch.Clear();
            }

            TampilUser();


            txtSearch.Focus();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
namespace HTQL_BHX
{
    public partial class Login : Form
    {
        public SqlConnection conn = new SqlConnection();
         Functions ham = new Functions();
        
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            ham.Connect(conn);

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
           /*
            if (MessageBox.Show("Bạn có thật sự muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
              {
                  e.Cancel = true;
                  //DialogResult.OK đại diện kq của tbao có chọn ok không. e.cancel=true: ngăn hành form đống , nếu false thì form sẽ đóng. Cancel là thuocj tính của lớp  FormClosingEventArgs e;
              }
           */



        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string pass = textBox2.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng không bỏ trống");
            }
            else
            {
                checkrole(username, pass);
            }

        }

        void checkrole(string username, string pass)
        {
            string tim_nv = "SELECT nv.chucvu  FROM TK_NV TK, NHAN_VIEN NV WHERE TK.ID_NV = NV.ID_NV AND (USERNAME = @username AND PASSWORD = @password)";

            SqlCommand cmd = new SqlCommand(tim_nv, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", pass);


            try
            {
                /* if (conn.State == ConnectionState.Closed)
                 {

                     conn.Open();
                 }*/
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    string role = rd.GetString(0);
                    Index index = new Index(username,role);

                    if (role == "Quan ly")
                    {
                        this.Hide();
                        index.ShowDialog();
                        this.Close();

                        //index.usnIndex.Text = username;
                        // MessageBox.Show(rd.GetString(0));
                    }
                    else if (role == "Nhan vien")
                    {
                        this.Hide();
                        index.ShowDialog();
                        this.Close();


                    }
                    rd.Close();

                }
                else
                {
                    rd.Close();
                    MessageBox.Show("Sai thông tin đăng nhập!");
                    //return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
                //Application.Exit();
                DialogResult result = MessageBox.Show("Bạn thật sự muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Hiển thị mật khẩu
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                // Ẩn mật khẩu
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void Login_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            /*if (MessageBox.Show("Bạn có thật sự muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
            {
                //e.Cancel = true;
                
                //DialogResult.OK đại diện kq của tbao có chọn ok không. e.cancel=true: ngăn hành form đống , nếu false thì form sẽ đóng. Cancel là thuocj tính của lớp  FormClosingEventArgs e;
            }*/
        }
    }
}

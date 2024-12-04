using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HTQL_BHX
{
    public partial class Customer : Form
    {
        protected SqlConnection conn = new SqlConnection();
        Functions ham = new Functions();

        private string username;
        private string userRole;
        public Customer(string username,string userRole)
        {
            InitializeComponent();
            this.username = username;
            this.userRole = userRole;
        }

        public Customer()
        {
            InitializeComponent();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Customer_Load(object sender, EventArgs e)
        {
             button1.Enabled = false;
            label10.Visible= false;
            textBox7.Visible = false;
            label8.Visible = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            //textBox7.Enabled = false;
            panel3.BackColor = Color.LightGray;
            ham.Connect(conn);
            ham.HienThiDuLieuDG(dataGridView1, "SELECT id_kh,hoten,diachi,sdt FROM KHACH_HANG WHERE DELETE_KH = 0", conn);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (userRole == "Nhan vien")
            {
                textBox2.Enabled = true;
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                //textBox7.Enabled = false;
                button1.Enabled = true;
                button4.Enabled = false;
                int stt = e.RowIndex + 1;
                textBox1.Text = stt.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString().PadLeft(10, '0');
                // textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;
            }
            else
            {
                textBox2.Enabled = true;
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                //textBox7.Enabled = false;
                button1.Enabled = true;
                button4.Enabled = true;
                int stt = e.RowIndex + 1;
                textBox1.Text = stt.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString().PadLeft(10, '0');
                // textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;
            }
        }



        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Index index = new Index(username, userRole);
            index.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            label10.Text = "";
            label10.Visible = false;
            textBox7.Text = "";
            textBox7.Visible = false;
            label8.Visible = false;
            //button1.Enabled = false;
            label4.ForeColor = Color.Black;
            textBox6.Text = "";
            panel3.BackColor = Color.LightGray;
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = false;
            textBox1.Enabled = false;
            textBox1.Text = "";
            textBox2.Enabled = false;
            textBox2.Text = "";
            textBox3.Enabled = false;
            textBox3.Text = "";
            textBox4.Enabled = false;
            textBox4.Text = "";
            textBox5.Enabled = false;
            textBox5.Text = "";
            //textBox7.Enabled = false;
            //textBox7.Enabled = false;
            //textBox7.Text = "";
            ham.HienThiDuLieuDG(dataGridView1, "SELECT id_kh,hoten,diachi,sdt FROM KHACH_HANG WHERE DELETE_KH = 0", conn);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        private void button2_Click_1(object sender, EventArgs e)

        {
            label10.Visible = true;
            label10.Text = "Nhập vào '0' để xác định trạng thái";
            textBox7.Visible = true;
            label8.Visible = true;
            button1.Enabled = false;
            button5.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = false;
            textBox3.Enabled = true;
            textBox3.Text = "";
            textBox4.Enabled = true;
            textBox4.Text = "";
            textBox5.Enabled = true;
            textBox5.Text = "";
            //textBox7.Enabled = false;
           // textBox7.Text = "";

            string icr_mkh = "SELECT MAX(SUBSTRING(ID_KH, 4, LEN(ID_KH))) FROM KHACH_HANG"; 

            try
            {

               /* if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }*/

                SqlCommand cmd = new SqlCommand(icr_mkh, conn);
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    // Nếu có dữ liệu trả về
                    if (!rd.IsDBNull(0))
                    {   // GetValue(0) cột đầu tiên như nhau nhưng thằng value thường dùng cho int, nếu bản chất nó int thì đem lên sài này khỏi ép 
                        int mkh_tt = Convert.ToInt32(rd.GetString(0)) + 1;

                        if (mkh_tt < 10)
                        {
                            textBox2.Text = "KH00" + mkh_tt.ToString();
                        }
                        else if (mkh_tt >= 10)
                        {
                            textBox2.Text = "KH0" + mkh_tt.ToString();
                        }
                        else if (mkh_tt <= 1000)
                        {
                            textBox2.Text = "KH" + mkh_tt.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Mã khách hàng chỉ chứa đủ KHxxx, vui lòng xem lại!!");
                        }
                    }
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
             
               /* if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }*/
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string idkh = textBox2.Text;
            string ten = textBox3.Text;
           
            string sdtValue = textBox5.Text;
            string dc = textBox4.Text;

            bool delete_kh = (textBox7.Text == "0") ? false : true;

            if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(dc) || string.IsNullOrEmpty(sdtValue) || string.IsNullOrEmpty(idkh) || string.IsNullOrEmpty(delete_kh.ToString()))
            {
                MessageBox.Show("Vui lòng không để trống !");
            }
            else
            {
                string tenPattern = @"^\p{L}[\p{L}\s]*$";
                if (!Regex.IsMatch(ten, tenPattern))
                {
                    MessageBox.Show("Tên không được chứa kí tự số, kí tự đặc biệt !");
                    return;

                }
                int sdt;
                bool isSdtValid = int.TryParse(textBox5.Text, out sdt);
                if (!isSdtValid)
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng số !");
                    return;

                }

                string insert_kh = "INSERT INTO KHACH_HANG(ID_KH, HoTen, DiaChi, SDT,delete_kh) VALUES('" + idkh + "',N'" + ten + "',N'" + dc + "','" + sdt + "','" + (delete_kh ? 1 : 0) + "')";
                ham.Save(insert_kh, conn);
                MessageBox.Show("Thêm thành công !");
                ham.HienThiDuLieuDG(dataGridView1, "SELECT id_kh,hoten,diachi,sdt FROM KHACH_HANG WHERE DELETE_KH = 0", conn);
                textBox1.Enabled = false;
                textBox1.Text = "";
                textBox2.Enabled = false;
                textBox2.Text = "";
                textBox3.Enabled = false;
                textBox3.Text = "";
                textBox4.Enabled = false;
                textBox4.Text = "";
                textBox5.Enabled = false;
                textBox5.Text = "";

                label10.Text = "";
                label10.Visible = false;
                textBox7.Text = "";
                textBox7.Visible = false;
                label8.Visible = false;
                //textBox7.Enabled = false;
                //textBox7.Text = "";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;


            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string idkh = textBox2.Text;
            DialogResult result = MessageBox.Show("Bạn thật sự muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                /*string delete = "DELETE FROM KHACH_HANG WHERE ID_KH = '" + textBox2.Text + "'";
                ham.Save(delete, conn);*/
                SqlCommand cmd = new SqlCommand("xoa_customer", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idkh", idkh);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã xóa khách hàng : " +idkh);
                ham.HienThiDuLieuDG(dataGridView1, "SELECT id_kh,hoten,diachi,sdt FROM KHACH_HANG WHERE DELETE_KH = 0", conn);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;
                button2.Enabled = false;
                button3.Enabled = false;
                textBox1 .Enabled = false;
                textBox1.Text = "";
                textBox2.Enabled = false;
                textBox2.Text = "";
                textBox3.Enabled = false;
                textBox3.Text = "";
                textBox4.Enabled = false;
                textBox4.Text = "";
                textBox5.Enabled = false;
                textBox5.Text = "";
                //textBox7.Enabled = false;
                //textBox7.Text = "";
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //textBox2.ForeColor = Color.Navy;
            label4.ForeColor = Color.Navy;
            panel3.BackColor = Color.Navy;
            string keywords = textBox6.Text;
            //panel3.BorderStyle = BorderStyle.Fixed3D;

            string search = "SELECT id_kh,hoten,diachi,sdt FROM KHACH_HANG WHERE ID_KH LIKE '%" + keywords + "%' OR HoTen LIKE N'%" + keywords + "%' OR DiaChi LIKE N'%" + keywords + "%' and DELETE_KH = 0";
            ham.HienThiDuLieuDG(dataGridView1, search, conn);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.ReadOnly = false;
            string idkh = textBox2.Text;
            string ten = textBox3.Text;
           

            string dc = textBox4.Text;
            string sdtValue = textBox5.Text;

            if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(dc) || string.IsNullOrEmpty(sdtValue) || string.IsNullOrEmpty(idkh) )
            {
                MessageBox.Show("Vui lòng không để trống !");
            }
            else
            {
                string tenPattern = @"^\p{L}[\p{L}\s]*$";
                if (!Regex.IsMatch(ten, tenPattern))
                {
                    MessageBox.Show("Tên không được chứa kí tự số, kí tự đặc biệt !");
                    return;

                }

                int sdt;
                bool isSdtValid = int.TryParse(textBox5.Text, out sdt);
                if (!isSdtValid)
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng số !");
                    return;

                }
                string update_kh = "update khach_hang set  HoTen = N'" + ten + "', DiaChi = N'" + dc + "', SDT = '" + sdt + "' where id_kh = '" +idkh+ "'";
                ham.Save(update_kh, conn);
                MessageBox.Show("Cập nhật thông tin khách hàng : " +idkh+ " thành công !");
                ham.HienThiDuLieuDG(dataGridView1, "SELECT id_kh,hoten,diachi,sdt FROM KHACH_HANG WHERE DELETE_KH = 0", conn);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
          
        }
    }
}

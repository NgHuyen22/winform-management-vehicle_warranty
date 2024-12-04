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
using System.Text.RegularExpressions;
using System.IO;

namespace HTQL_BHX
{
    public partial class staff_management : Form
    {
        protected SqlConnection conn = new SqlConnection();
        
        Functions ham = new Functions();

        private string username;
        private string userRole;
        public staff_management(string username, string userRole)
        {
            InitializeComponent();
            this.username = username;
            this.userRole = userRole;
        }
        public staff_management()
        {
            InitializeComponent();
          
        }

        private void staff_management_Load(object sender, EventArgs e)

        {
            label10.Visible = false;
            textBox8.Visible = false;
            label13.Visible = false;
            panel3.BackColor = Color.LightGray;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button7.Enabled = false;
            button6.Enabled = false;
            label11.Text = "";

            textBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox8.Enabled = false;
            comboBox1.Enabled = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            ham.Connect(conn);
            ham.HienThiDuLieuDG(dataGridView1, "SELECT id_nv,Hoten,diachi,sdt,chucvu,gioitinh,linkanh FROM NHAN_VIEN where DELETE_NV = 0", conn);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;

            //conn.Close();

            //ham.HienThitextBox(textBox3, "SELECT ID_NV FROM NHAN_VIEN", conn);

        }

        /*private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Tính toán chiều rộng của DataGridView
            int totalWidth = 0;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                totalWidth += dataGridView1.Columns[i].Width;
            }

            // Cập nhật kích thước của hàng
            dataGridView1.Rows[e.RowIndex].Height = (int)Math.Ceiling((double)totalWidth / dataGridView1.Columns.Count);
        }*/




        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Index index = new Index(username, userRole);
            index.ShowDialog();
            this.Close();
        }





        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox8.Visible = false;
            label10.Visible = false;
            label13.Visible = false;
            pictureBox1.Visible = true;
            pictureBox1.Enabled = true;
          
            button7.Enabled = false;
            textBox1.Enabled=false;
            textBox3.Enabled = false;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            comboBox1.Enabled= true;
            textBox8.ReadOnly = true;
            button6.Enabled = true;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            int stt = e.RowIndex + 1;
            //button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            textBox1.Text = stt.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString().PadLeft(10, '0');
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            label11.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();


            //ham.Connect(conn);
            // ham.HienThiComboBox(comboBox1, "SELECT DISTINCT ChucVu FROM NHAN_VIEN", conn);
            ham.HienThiComboBox(comboBox1, "SELECT DISTINCT ChucVu FROM NHAN_VIEN", conn);
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
           
           // conn.Close();
            string link = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
          
            pictureBox1.Image = new Bitmap(link);
   
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // điều chỉnh kích thước của các cột để nó co dãn theo vừa vs  dtgview1 
            dataGridView1.ReadOnly = true;
            //dataGridView1.RowPrePaint += dataGridView1_RowPrePaint;

            string gender = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            if (gender == "Nam")
             {
                 checkBox1.Checked = true;
                 checkBox2.Checked = false;


             }
             else if (gender == "Nữ")
             {
                 checkBox1.Checked = false;
                 checkBox2.Checked = true;

             }


        }

        private void dataGridView1_Leave(object sender, EventArgs e)
        {



        }

        private void staff_management_Leave(object sender, EventArgs e)
        {


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
           


        }
        private void textBox3_TextChanged(object sender, EventArgs e)

        {
           

         

     }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
            textBox8.Visible = false;
            label10.Visible = false;
            label13.Text = "";
            label13.Visible = false;

            textBox2.Text = "";
            label8.ForeColor = Color.Black;
            panel3.BackColor = Color.LightGray;
            textBox1.Enabled = false;
            textBox1.Text = "";
            textBox3.Enabled =false;
            textBox3.Text = "";
            textBox4.Enabled= false;
            textBox4.Text = "";
            textBox5.Enabled= false;
            textBox5.Text= "";
            textBox6.Enabled= false;
            textBox6.Text = "";
            comboBox1.Enabled= false;
           
            comboBox1.Text = "Chọn chức vụ";
            label11.Text = "";
           
            textBox8.Enabled= false;
            textBox8.Text = "";
            checkBox1.Enabled = false;

            checkBox2.Enabled = false;
            checkBox2.Checked = false;
         
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            //button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            button6.Enabled =false;
            pictureBox1.Enabled = false;
            pictureBox1.Image = null;
            ham.HienThiDuLieuDG(dataGridView1, "SELECT id_nv,Hoten,diachi,sdt,chucvu,gioitinh,linkanh FROM NHAN_VIEN where DELETE_NV = 0", conn);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;

        }

      

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           if (checkBox1.Checked)
            {
                checkBox2.Enabled = false;
            }
            else
            {
                checkBox2.Enabled = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            label10.Visible = true;
            textBox8.Visible = true;
            label13.Visible = true;
            label13.Text = "Nhập vào '0' để xác định trạng thái";
            label13.ForeColor = Color.Navy;
            textBox8.ReadOnly = false;
            textBox8.Enabled = true;
            button6.Enabled = true;
            button3.Enabled= false;
            button4.Enabled= false;
            button7.Enabled = true;
            textBox1.Enabled = false;

            textBox3.Enabled = true;
            // textBox3.Text = "";
            pictureBox1.Enabled = true;
            pictureBox1.Image = null;

            string icr_mnv = "SELECT MAX(SUBSTRING(ID_NV, 4, LEN(ID_NV))) FROM NHAN_VIEN"; 

            try
            {
                
               /* if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }*/

                SqlCommand cmd = new SqlCommand(icr_mnv, conn);
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    // Nếu có dữ liệu trả về
                    if (!rd.IsDBNull(0))
                    {   // GetValue(0) cột đầu tiên như nhau nhưng thằng value thường dùng cho int, nếu bản chất nó int thì đem lên sài này khỏi ép 
                        int mnv_tt = Convert.ToInt32(rd.GetString(0)) + 1;
                        
                        if (mnv_tt < 10)
                        {
                            textBox3.Text = "NV00" + mnv_tt.ToString();
                        }
                        else if (mnv_tt >= 10)
                        {
                            textBox3.Text = "NV0" + mnv_tt.ToString();
                        }
                        else if (mnv_tt <= 1000)
                        {
                            textBox3.Text = "NV" + mnv_tt.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Mã Nhân viên chỉ chứa đủ NVxxx, vui lòng xem lại!!");
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
            textBox3.Enabled = false;
            textBox4.Enabled = true;
            textBox4.Text = "";
            textBox5.Enabled = true;
            textBox5.Text = "";
            textBox6.Enabled = true;
            textBox6.Text = "";
            comboBox1.Enabled = true;
            //comboBox1.Text = "Chọn chức vụ";
            //ham.Connect(conn);
            ham.HienThiComboBox(comboBox1, "SELECT DISTINCT ChucVu FROM NHAN_VIEN", conn);
            comboBox1.Text = "Chọn chức vụ";
          
            textBox8.Enabled = true;
            textBox8.Text = "";
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
           


        }
        private void button7_Click(object sender, EventArgs e)
        {
            string idnv = textBox3.Text;
            string ten = textBox4.Text;
          
            string sdt = textBox5.Text;

            string dc = textBox6.Text.Trim();
            string cv = comboBox1.Text.ToString();

            string gioitinh = "";
            if (checkBox2.Checked)
            {
                gioitinh = "Nữ";
            }
            else if (checkBox1.Checked)
            {
                gioitinh = "Nam";
            }
          
            bool delete_nv = (textBox8.Text == "0") ? false : true;


          

            if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(dc) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(cv) || comboBox1.Text == "Chọn chức vụ" || string.IsNullOrEmpty(gioitinh) || string.IsNullOrEmpty(delete_nv.ToString()) || string.IsNullOrEmpty(label11.Text))
            {
                 
                    MessageBox.Show("Vui lòng không để trống !");
            }
            else { 
                   
                string tenPattern = @"^\p{L}[\p{L}\s]*$";
                if (!Regex.IsMatch(ten, tenPattern))
                {
                    MessageBox.Show("Tên không được chứa kí tự số, kí tự đặc biệt !");
                    return;
                }

                int sdtValue;
                bool isSdtValid = int.TryParse(sdt, out sdtValue);
                if (!isSdtValid)
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng số !");
                    return;
                }
                string insert_nv = "INSERT INTO NHAN_VIEN(ID_NV,HoTen,DiaChi,SDT,ChucVu,GioiTinh,LinkAnh,DELETE_NV) VALUES('" + idnv + "',N'" + ten + "',N'" + dc + "','" + sdtValue + "','" + cv + "',N'" + gioitinh + "' , '" + label11.Text + "', '" + (delete_nv ? 1 : 0) + "')";

                ham.Save(insert_nv, conn);
                MessageBox.Show("Thêm thành công !");
                ham.HienThiDuLieuDG(dataGridView1, "SELECT id_nv,Hoten,diachi,sdt,chucvu,gioitinh,linkanh FROM NHAN_VIEN where DELETE_NV = 0", conn);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;
                label13.Text = "";
                label13.Visible = false;
                textBox3.Enabled = false;
                textBox1.Enabled = false;
                textBox1.Text = "";
                textBox3.Text = "";
                textBox4.Enabled = false;
                textBox4.Text = "";
                textBox5.Enabled = false;
                textBox5.Text = "";
                textBox6.Enabled = false;
                textBox6.Text = "";
                comboBox1.Enabled = false;
                comboBox1.Text = "Chọn chức vụ";
                checkBox1 .Enabled = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox2.Enabled = false;
                textBox8.Enabled = false;
                button6 .Enabled = false;
            }
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            button5.Enabled = true;
            button8.Enabled = true;
            string idnv = textBox3.Text;
            string ten = textBox4.Text;

            string sdt = textBox5.Text;
            
            //int sdt = Convert.ToInt32(textBox5.Text);
            string dc = textBox6.Text.Trim();

            string cv = comboBox1.Text.ToString();

            string gioitinh = "";
            if (checkBox2.Checked)
            {

                gioitinh = "Nữ";

            }
            else if (checkBox1.Checked)
            {
                gioitinh = "Nam";

            }

            if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(dc) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(cv) || comboBox1.Text == "Chọn chức vụ" || string.IsNullOrEmpty(gioitinh) || string.IsNullOrEmpty(label11.Text))
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

                int sdtValue;
                bool isSdtValid = int.TryParse(sdt, out sdtValue);
                if (!isSdtValid)
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng số !");
                    return;
                }
                string sql_update = "UPDATE NHAN_VIEN SET HOTEN = N'" + ten + "', DiaChi =N'" + dc + "' , SDT = " + sdtValue + ",ChucVu = '" + cv + "',GioiTinh =N'" + gioitinh + "', LinkAnh = '" + label11.Text + "' WHERE ID_NV = '" + idnv + "'";
                ham.Save(sql_update, conn);
                MessageBox.Show("Cập nhật thành công mã nhân viên : " + idnv);
                ham.HienThiDuLieuDG(dataGridView1, "SELECT id_nv,Hoten,diachi,sdt,chucvu,gioitinh,linkanh FROM NHAN_VIEN where DELETE_NV = 0", conn);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;
            }
           
           /* textBox1.Text = "";
            textBox1.Enabled = false;
            textBox3.Text = "";
            textBox3.Enabled = false;
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
            comboBox1.Enabled = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;*/

        }

        private void textBox2_TextChanged(object sender, EventArgs e)

        {   
            textBox2.ForeColor = Color.Navy;
            label8.ForeColor = Color.Navy;
            string keywords = textBox2.Text;
            panel3.BackColor = Color.Navy;
            //panel3.BorderStyle = BorderStyle.Fixed3D;

            string search = "SELECT id_nv,Hoten,diachi,sdt,chucvu,gioitinh,linkanh FROM NHAN_VIEN WHERE ID_NV LIKE '%" + keywords + "%' OR HoTen LIKE N'%" + keywords + "%' OR DiaChi LIKE N'%" + keywords + "%'  OR ChucVu LIKE N'%" + keywords + "%' OR GioiTinh LIKE N'%" + keywords + "%' and DELETE_NV = 0";
            ham.HienThiDuLieuDG(dataGridView1, search, conn);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (e.KeyCode == Keys.Enter)
            {

                string keywords = textBox2.Text;

                string search = "SELECT * FROM NHAN_VIEN WHERE ID_NV LIKE '%" + keywords + "%' OR HoTen LIKE N'%" + keywords + "%' OR DiaChi LIKE N'%" + keywords + "%'  OR ChucVu LIKE N'%" + keywords + "%' OR GioiTinh LIKE N'%" + keywords + "%'";
                ham.HienThiDuLieuDG(dataGridView1, search, conn);
            }*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string idnv = textBox3.Text;
            DialogResult result = MessageBox.Show("Bạn thật sự muốn xóa?","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                /* string delete = "DELETE FROM NHAN_VIEN WHERE ID_NV = '" + textBox3.Text + "'";
                 ham.Save(delete, conn);*/
                SqlCommand cmd = new SqlCommand("xoa_nv", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idnv", idnv);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã xóa nhân viên : " +textBox3.Text);
                ham.HienThiDuLieuDG(dataGridView1, "SELECT id_nv, Hoten, diachi, sdt, chucvu, gioitinh, linkanh FROM NHAN_VIEN where DELETE_NV = 0", conn);
                dataGridView1.ReadOnly = true;
                textBox3.Enabled = false;
                textBox1.Enabled = false;
                textBox1.Text = "";
                textBox3.Text = "";
                textBox4.Enabled = false;
                textBox4.Text= "";
                textBox5.Enabled = false;
                textBox5.Text = "";
                textBox6.Enabled = false;
                textBox6.Text = "";
                comboBox1.Text = "Chọn chức vụ";
                comboBox1.Enabled = false;
                checkBox1.Checked = false;
                checkBox1 .Enabled = false;
                checkBox2.Checked = false;
                checkBox2.Enabled = false;
                pictureBox1.Enabled = false;
                pictureBox1.Image = null;
                button2.Enabled = false;
                button3.Enabled = false;
                button7.Enabled = false;

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDL = new OpenFileDialog();
            DialogResult result = openDL.ShowDialog();
            if(result == DialogResult.OK)
            {
                string fileAnh = openDL.FileName;
                pictureBox1.Image = new Bitmap(fileAnh);
                label11.Text = "";
                //label11.Text = Path.GetFileName(fileAnh);
                label11.Text = fileAnh;
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
 } 

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
using System.IO;

namespace HTQL_BHX
{
    public partial class View_vehicle_information : Form
    {
        
        protected SqlConnection conn = new SqlConnection();
        Functions ham = new Functions();

        private string username;
        private string userRole;

        public View_vehicle_information(string username, string userRole)
        {
            InitializeComponent();
            this.username = username;
            this.userRole = userRole;
        }
        public View_vehicle_information()
        {
            InitializeComponent();
        }

        private void View_vehicle_information_Load(object sender, EventArgs e)
        {
            label12.Visible = false;
            textBox6.Visible = false;
            label15.Visible = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button7.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;

            comboBox1.Text = "Chọn loại";
            comboBox2.Text = "Chọn hãng";

            textBox7.Enabled = false;
            textBox9.Enabled = false;
            label8.Visible = false;

            ham.Connect(conn);
            ham.HienThiDuLieuDG(dataGridView1, "SELECT X.MAXE,X.DONGXE,X.PHIENBAN,X.PHANKHUC,X.DONGCO,X.GIANIEMYET,LX.MALOAI,LX.TENLOAI,H.MAHANG,H.TENHANG,X.LINKANH FROM XE X, LOAI_XE LX ,HANG_XE H WHERE X.MALOAI = LX.MALOAI AND X.MAHANG = H.MAHANG AND X.DELETE_XE = 0", conn);
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (userRole == "Nhan vien")
            {
                button7.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                pictureBox1.Enabled = true;
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                textBox7.ReadOnly = true;
                textBox9.ReadOnly = true;
                int stt = e.RowIndex + 1;
                textBox1.Text = stt.ToString();
                textBox1.ReadOnly = true;
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.ReadOnly = true;
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.ReadOnly = true;
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox4.ReadOnly = true;
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox7.ReadOnly = true;
                textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox9.ReadOnly = true;
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox5.ReadOnly = true;

                label8.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                label8.Visible = false;

                // ham.Connect(conn);

                ham.HienThiComboBoxHideID(comboBox1, "SELECT MALOAI,TENLOAI FROM LOAI_XE ", conn, "TENLOAI", "MALOAI");

                ham.HienThiComboBoxHideID(comboBox2, "SELECT MAHANG,TENHANG FROM HANG_XE ", conn, "TENHANG", "MAHANG");

                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();

                string link = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();

                pictureBox1.Image = new Bitmap( link);
                //label11.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            else
            {
                button7.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = true;
                button4.Enabled = true;
                pictureBox1.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                textBox7.Enabled = true;
                textBox9.Enabled = true;
                int stt = e.RowIndex + 1;
                textBox1.Text = stt.ToString();
                textBox1.ReadOnly = true;
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.ReadOnly = true;
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

                label8.Visible = false;
                label8.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();

                // ham.Connect(conn);

                ham.HienThiComboBoxHideID(comboBox1, "SELECT MALOAI,TENLOAI FROM LOAI_XE ", conn, "TENLOAI", "MALOAI");

                ham.HienThiComboBoxHideID(comboBox2, "SELECT MAHANG,TENHANG FROM HANG_XE ", conn, "TENHANG", "MAHANG");

                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();

                string link = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();

                pictureBox1.Image = new Bitmap(link);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Index index = new Index(username,userRole);
            index.ShowDialog();
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            textBox11.ForeColor = Color.Navy;
            label10.ForeColor = Color.Navy;
            string keywords = textBox11.Text;
            panel3.BackColor = Color.Navy;
            //panel3.BorderStyle = BorderStyle.Fixed3D;

            string search = "SELECT X.MAXE,X.DONGXE,X.PHIENBAN,X.PHANKHUC,X.DONGCO,X.GIANIEMYET,LX.MALOAI,LX.TENLOAI,H.MAHANG,H.TENHANG,X.LINKANH FROM XE X, LOAI_XE LX, HANG_XE H WHERE X.MALOAI = LX.MALOAI AND X.MAHANG = H.MAHANG AND (X.MAXE LIKE N'%" + keywords + "%' OR X.DONGXE LIKE N'%" + keywords + "%' OR X.PHANKHUC LIKE N'%" + keywords + "%' OR X.PHIENBAN LIKE N'%" + keywords + "%' OR X.DONGCO LIKE N'%" + keywords + "%' OR X.GIANIEMYET LIKE N'%" + keywords + "%' OR H.TENHANG LIKE N'%" + keywords + "%' OR LX.TENLOAI LIKE N'%" + keywords + "%' and  X.DELETE_XE = 0)";

            ham.HienThiDuLieuDG(dataGridView1, search, conn);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (userRole == "Nhan vien")
            {

                label8.Text = "";
                label8.Visible = false;
                label15.Text = "";
                label15.Visible = false;
                textBox6.Text = "";
                textBox6.Visible = false;
                textBox11.Text = "";
                panel3.BackColor = Color.LightGray;
                label10.ForeColor = Color.Black;

                pictureBox1.Image = null;

                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button7.Enabled = false;
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
                textBox7.Enabled = false;
                textBox7.Text = "";
                textBox9.Enabled = false;
                textBox9.Text = "";

                comboBox1.Enabled = false;
                comboBox1.Text = "";

                comboBox2.Enabled = false;
                comboBox2.Text = "";
                dataGridView1.ReadOnly = true;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                label8.Text = "";
                label8.Visible = false;
                label15.Text = "";
                label15.Visible = false;
                textBox6.Text = "";
                textBox6.Visible = false;
                textBox11.Text = "";
                panel3.BackColor = Color.LightGray;
                label10.ForeColor = Color.Black;

                pictureBox1.Image = null;

                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = false;
                button4.Enabled = false;
                button7.Enabled = false;
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
                textBox7.Enabled = false;
                textBox7.Text = "";
                textBox9.Enabled = false;
                textBox9.Text = "";

                comboBox1.Enabled = false;
                comboBox1.Text = "";

                comboBox2.Enabled = false;
                comboBox2.Text = "";
                dataGridView1.ReadOnly = true;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label12.Visible = true;
            label15.Visible = true;
            label15.ForeColor = Color.Navy;
            label15.Text = "Nhập vào '0' để xác định trạng thái";
            textBox6.Visible = true;
            pictureBox1.Enabled = true;

            button1.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = false;
            button7.Enabled = true;
           
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox7.Enabled = true;
            textBox9.Enabled = true;
         
            comboBox1 .Enabled = true;
            comboBox2.Enabled = true;
         
            label8.Enabled = true;


           // ham.Connect(conn);
            ham.HienThiComboBoxHideID(comboBox1, "SELECT MALOAI,TENLOAI FROM LOAI_XE ", conn, "TENLOAI", "MALOAI");
            comboBox1.Text = "Chọn loại";
         
            //ham.Connect(conn);
            ham.HienThiComboBoxHideID(comboBox2, "SELECT MAHANG,TENHANG FROM HANG_XE ", conn, "TENHANG", "MAHANG");
            comboBox2.Text = "Chọn hãng";

            string icr_mhd = "SELECT MAX(SUBSTRING(MAXE, 4, LEN(MAXE))) FROM XE";
           /* if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }*/

            SqlCommand cmd = new SqlCommand(icr_mhd, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                if (!rd.IsDBNull(0))
                {

                    int mhd_tt = Convert.ToInt32(rd.GetString(0)) + 1;

                    if (mhd_tt < 10)
                    {
                        textBox2.Text = "X000" + mhd_tt.ToString();
                    }
                    else if (mhd_tt >= 10)
                    {
                        textBox2.Text = "X00" + mhd_tt.ToString();
                    }
                    else if (mhd_tt <= 1000)
                    {
                        textBox2.Text = "X0" + mhd_tt.ToString();
                    }
                    else
                    {
                        textBox2.Text = "X" + mhd_tt.ToString();
                    }
                }

            }
            rd.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string mx = textBox2.Text;
            string dx = textBox3.Text.Trim();
            string pb = textBox4.Text.Trim();
            string dc = textBox9.Text.Trim();
            string pk = textBox7.Text.Trim();
            string ml = comboBox1.SelectedValue.ToString();
            string mh = comboBox2.SelectedValue.ToString();
            string gia = textBox5.Text;
            bool delete_xe = (textBox6.Text == "0") ? false : true;

            if (string.IsNullOrEmpty(dx) || string.IsNullOrEmpty(pb) || string.IsNullOrEmpty(pk) || string.IsNullOrEmpty(dc) || comboBox1.Text == "Chọn loại" || comboBox2.Text == "Chọn hãng" || string.IsNullOrEmpty(gia) || string.IsNullOrEmpty(label8.Text) || string.IsNullOrEmpty(delete_xe.ToString()))
            {
                MessageBox.Show("Vui lòng không bỏ trống!");
            }
            else
            {
                string tenPattern = @"^[A-Za-z0-9\s]*$";
                if (!Regex.IsMatch(dx, tenPattern))
                {
                    MessageBox.Show("Tên không được chứa kí tự số, kí tự đặc biệt !");
                    return;
                }

                int giaValue;
                bool result = int.TryParse(gia, out giaValue);
                if (!result)
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng số !");
                    return;
                }

               


                string insert_xe = "INSERT INTO XE(maxe,dongxe,phienban,phankhuc,dongco,gianiemyet,mahang,maloai,linkanh,delete_xe) VALUES('" + mx + "',N'" + dx + "',N'" + pb + "',N'" + pk + "',N'" + dc + "','" + giaValue + "' , N'" + mh + "', N'" + ml + "', '" + label8.Text + "','" + (delete_xe ? 1 : 0) + "' )";

                /*if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }*/
                ham.Save(insert_xe, conn);
                MessageBox.Show("Thêm thành công !");
                ham.HienThiDuLieuDG(dataGridView1, "SELECT X.MAXE,X.DONGXE,X.PHIENBAN,X.PHANKHUC,X.DONGCO,X.GIANIEMYET,LX.MALOAI,LX.TENLOAI,H.MAHANG,H.TENHANG,X.LINKANH FROM XE X, LOAI_XE LX ,HANG_XE H WHERE X.MALOAI = LX.MALOAI AND X.MAHANG = H.MAHANG AND X.DELETE_XE = 0", conn);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                label8.Text = "";
                label8.Visible = false;
                label15.Text = "";
                label15.Visible = false;
                textBox6.Text = "";
                textBox6.Visible = false;
                button3.Enabled = false;
                button4.Enabled = false;

                button1.Enabled = false;
                button2.Enabled = false;

                button7.Enabled = false;
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
                textBox7.Enabled = false;
                textBox7.Text = "";
                textBox9.Enabled = false;
                textBox9.Text = "";

                comboBox1.Enabled = false;
                comboBox1.Text = "";
                comboBox2.Enabled = false;
                comboBox2.Text = "";

                //label8.Text = "";
                label8.Enabled = false;
                pictureBox1.Image = null;
                pictureBox1.Enabled = false;

            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDL = new OpenFileDialog();
            DialogResult result = openDL.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileAnh = openDL.FileName;
                pictureBox1.Image = new Bitmap(fileAnh);
                label8.Text = fileAnh;
                label8.Visible = true;
                pictureBox1.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mx = textBox2.Text;
            string dx = textBox3.Text.Trim();
            string pb = textBox4.Text.Trim();
            string tenPattern = @"^[A-Za-z0-9\s]*$";
            string dc = textBox9.Text.Trim();
            string pk = textBox7.Text.Trim();
            string ml = comboBox1.SelectedValue.ToString();
            string mh = comboBox2.SelectedValue.ToString();

            if (!Regex.IsMatch(dx, tenPattern))
            {
                MessageBox.Show("Tên không được chứa kí tự số, kí tự đặc biệt !");
                return;
            }

            int gia;
            bool result = int.TryParse(textBox5.Text, out gia);
            if (!result)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số !");
                return;
            }


            string update_xe = "UPDATE XE SET DONGXE = N'" + dx + "', PHIENBAN = N'" + pb + "' , PHANKHUC = N'" + pk + "', DONGCO = N'" + dc + "', GIANIEMYET = '" + gia + "', MAHANG = '" + mh + "', MALOAI = '" + ml + "', LINKANH = '" + label8.Text + "' WHERE MAXE = '" + mx+ "'";
            //ham.Connect(conn);
            ham.Save(update_xe, conn);
            MessageBox.Show("Cập nhật mã xe : " +mx+ " thành công!");
            ham.HienThiDuLieuDG(dataGridView1, "SELECT X.MAXE,X.DONGXE,X.PHIENBAN,X.PHANKHUC,X.DONGCO,X.GIANIEMYET,LX.MALOAI,LX.TENLOAI,H.MAHANG,H.TENHANG,X.LINKANH FROM XE X, LOAI_XE LX ,HANG_XE H WHERE X.MALOAI = LX.MALOAI AND X.MAHANG = H.MAHANG AND X.DELETE_XE = 0", conn);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string mx = textBox2.Text;
            DialogResult result = MessageBox.Show("Bạn thật sự muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                /*string delete = "DELETE FROM XE WHERE MAXE = '" + textBox2.Text + "'";
                ham.Save(delete, conn);*/

                
                //SqlCommand cmd = new SqlCommand("delete_xe_bh_ct", conn);
                SqlCommand cmd = new SqlCommand("delete_vehicle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mx",mx);

               
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã xóa xe : " + textBox2.Text);
                ham.HienThiDuLieuDG(dataGridView1, "SELECT X.MAXE,X.DONGXE,X.PHIENBAN,X.PHANKHUC,X.DONGCO,X.GIANIEMYET,LX.MALOAI,LX.TENLOAI,H.MAHANG,H.TENHANG,X.LINKANH FROM XE X, LOAI_XE LX ,HANG_XE H WHERE X.MALOAI = LX.MALOAI AND X.MAHANG = H.MAHANG and X.DELETE_XE = 0", conn);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
              
                textBox1.Text = "";
                textBox1.Enabled = false;
                textBox2.Text = "";
                textBox2.Enabled = false;
                textBox3.Text = "";
                textBox3.Enabled = false;
                textBox4.Text = "";
                textBox4.Enabled = false;
                textBox5.Text = "";
                textBox5.Enabled = false;
                textBox7.Text = "";
                textBox7.Enabled = false;
                textBox9.Text = "";
                textBox9.Enabled = false;

                comboBox1.Text = "";
                comboBox1.Enabled = false;
                comboBox1.Text = "Chọn loại";

                comboBox2.Text = "";
                comboBox2.Enabled = false;
                comboBox2.Text = "Chọn hãng";

                button7.Enabled = false;
                pictureBox1.Visible = false; // ẨN

                button3.Enabled = false;
                button4.Enabled = false;
                button1.Enabled = false;
            }
        }
    }
}

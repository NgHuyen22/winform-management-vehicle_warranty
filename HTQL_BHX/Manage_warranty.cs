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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HTQL_BHX
{
    public partial class Manage_warranty : Form
    {

        protected SqlConnection conn = new SqlConnection();
        Functions ham = new Functions();
        private string userName;
        private string userRole;
  
     
        public Manage_warranty(string userName, string userRole)
        {
            InitializeComponent();
            this.userName = userName;
            this.userRole = userRole;
        }
        public Manage_warranty()
        {
            InitializeComponent();
           
        }

        private void Manage_warranty_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;

            ham.Connect(conn);
            //conn.Open();
            ham.HienThiDuLieuDG(dataGridView1, "SELECT bh.MAPHIEU, bh.TENPHIEU,bh.MAXE,x.DongXE, bh.THOIHAN,nd.MA_HD,b.NgayLap,kh.ID_KH,kh.hoten,kh.DiaChi,kh.SDT ,nd.MOTA,nd.DIEUKIEN FROM PHIEU_BH bh, NOI_DUNG_BH nd, BILL b,KHACH_HANG kh, XE x WHERE bh.MAPHIEU = nd.MAPHIEU AND nd.MA_HD = b.MA_HD AND b.ID_KH = kh.ID_KH and bh.MAXE = x.MAXE", conn);
        }
        private void button2_Click(object sender, EventArgs e)
        {
           // conn.Close();
            button6.Enabled = true;
            comboBox1.Enabled = true;
            //ham.Connect(conn);
            ham.HienThiComboBoxHideID(comboBox1, "SELECT MAXE,DONGXE FROM XE where delete_xe = 0", conn, "DONGXE", "MAXE");
            comboBox1.Text = "Chọn xe";

            comboBox2.Enabled = true;
            //ham.Connect(conn);
            ham.HienThiComboBox1(comboBox2, "SELECT MA_HD FROM BILL", conn, "MA_HD");
            comboBox2.Text = "Chọn HD";
            textBox2.Enabled = true;
            textBox2.ReadOnly = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox10.Enabled = true;
            textBox11.Enabled = true;

            string icr_mp = "SELECT MAX(SUBSTRING(MAPHIEU, 4, LEN(MAPHIEU))) FROM PHIEU_BH";
            SqlCommand cmd = new SqlCommand(icr_mp, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                // Nếu có dữ liệu trả về
                if (!rd.IsDBNull(0))
                {   // GetValue(0) cột đầu tiên như nhau nhưng thằng value thường dùng cho int, nếu bản chất nó int thì đem lên sài này khỏi ép 
                    int mp_tt = Convert.ToInt32(rd.GetString(0)) + 1;

                    if (mp_tt < 10)
                    {
                        textBox2.Text = "BH00" + mp_tt.ToString();
                    }
                    else if (mp_tt >= 10)
                    {
                        textBox2.Text = "BH0" + mp_tt.ToString();
                    }
                    else if (mp_tt <= 1000)
                    {
                        textBox2.Text = "BH" + mp_tt.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Mã hóa đơn chỉ chứa đủ HDxxx, vui lòng xem lại!!");
                    }
                }
            }
            rd.Close();





        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (userRole == "Nhan vien")
            {

                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.ReadOnly = true;
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
                textBox8.ReadOnly = true;
                textBox10.Enabled = true;
                textBox11.Enabled = true;
                comboBox1.Enabled = true;
                comboBox2.Enabled = false;

                button3.Enabled = true;
                button4.Enabled = false;
                button2.Enabled = false;

                int stt = e.RowIndex + 1;
                textBox1.Text = stt.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();

                ham.HienThiComboBoxHideID(comboBox1, "SELECT MAXE,DONGXE FROM XE where delete_xe = 0", conn, "DONGXE", "MAXE");

                ham.HienThiComboBox1(comboBox2, "SELECT MA_HD FROM BILL", conn, "MA_HD");

                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;
            }
            else
            {
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.ReadOnly = true;
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
                textBox8.ReadOnly = true;
                textBox10.Enabled = true;
                textBox11.Enabled = true;
                comboBox1.Enabled = true;
                comboBox2.Enabled = false;

                button3.Enabled = true;
                button4.Enabled = true;
                button2.Enabled = false;

                int stt = e.RowIndex + 1;
                textBox1.Text = stt.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();

                ham.HienThiComboBoxHideID(comboBox1, "SELECT MAXE,DONGXE FROM XE where delete_xe = 0", conn, "DONGXE", "MAXE");

                ham.HienThiComboBox1(comboBox2, "SELECT MA_HD FROM BILL", conn, "MA_HD");

                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label14.ForeColor = Color.Black;
            panel3.BackColor = Color.Gray;
            textBox12.Text = "";
            button2.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;

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
            textBox6.Text = "";
            textBox6.Enabled = false;
            textBox7.Text = "";
            textBox7.Enabled = false;
            textBox8.Text = "";
            textBox8.Enabled = false;
            textBox10.Text = "";
            textBox10.Enabled = false;
            textBox11.Text = "";
            textBox11.Enabled = false;

            comboBox1.Text = "";
            comboBox1.Enabled = false;
            comboBox2.Text = "";
            comboBox2.Enabled = false;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            label14.ForeColor = Color.Navy;
            panel3.BackColor = Color.Navy;
            string keywords = textBox12.Text;
            string search = @"SELECT bh.MAPHIEU, bh.TENPHIEU, bh.MAXE, x.DongXE, bh.THOIHAN, nd.MA_HD, b.NgayLap, kh.ID_KH, kh.hoten, kh.DiaChi, kh.SDT, nd.MOTA, nd.DIEUKIEN 
                  FROM PHIEU_BH bh
                  INNER JOIN NOI_DUNG_BH nd ON bh.MAPHIEU = nd.MAPHIEU
                  INNER JOIN BILL b ON nd.MA_HD = b.MA_HD
                  INNER JOIN KHACH_HANG kh ON b.ID_KH = kh.ID_KH
                  INNER JOIN XE x ON bh.MAXE = x.MAXE
                  WHERE bh.MAPHIEU LIKE '%" + keywords + @"%'
                  OR bh.tenphieu LIKE N'%" + keywords + @"%'
                  OR x.DONGXE LIKE '%" + keywords + @"%'
                  OR bh.THOIHAN LIKE N'%" + keywords + @"%'
                  OR kh.HOTEN LIKE N'%" + keywords + @"%'
                  OR kh.Diachi LIKE N'%" + keywords + @"%'
                  OR nd.MA_HD LIKE '%" + keywords + @"%'
                  OR nd.MoTa LIKE N'%" + keywords + @"%'
                  OR nd.Dieukien LIKE N'%" + keywords + @"%'";


            ham.HienThiDuLieuDG(dataGridView1, search, conn);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            string mp = textBox2.Text;
            string tp = textBox3.Text;
            string th = textBox4.Text;
            string tx = comboBox1.SelectedValue.ToString();
            string nd = textBox10.Text;
            string dk = textBox11.Text;
            string mhd = comboBox2.Text;
           

            /* if (conn.State == ConnectionState.Closed)
             {
                 conn.Open();
             }*/
            if (string.IsNullOrEmpty(tp) || string.IsNullOrEmpty(th) || string.IsNullOrEmpty(tx) || string.IsNullOrEmpty(nd) || string.IsNullOrEmpty(dk) || comboBox2.Text == "Chọn HD")
            {
                MessageBox.Show("Vui lòng không bỏ trống !");
            }
            else
            {

                SqlCommand cmd = new SqlCommand("insert_pbh", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MP", mp);
                cmd.Parameters.AddWithValue("@MX", tx);
                cmd.Parameters.AddWithValue("@TP", tp);
                cmd.Parameters.AddWithValue("@TH", th);
                cmd.Parameters.AddWithValue("@MHD", mhd);
                cmd.Parameters.AddWithValue("@MT", nd);
                cmd.Parameters.AddWithValue("@DK", dk);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công !");
                ham.HienThiDuLieuDG(dataGridView1, "SELECT bh.MAPHIEU, bh.TENPHIEU,bh.MAXE,x.DongXE, bh.THOIHAN,nd.MA_HD,b.NgayLap,kh.ID_KH,kh.hoten,kh.DiaChi,kh.SDT ,nd.MOTA,nd.DIEUKIEN FROM PHIEU_BH bh, NOI_DUNG_BH nd, BILL b,KHACH_HANG kh, XE x WHERE bh.MAPHIEU = nd.MAPHIEU AND nd.MA_HD = b.MA_HD AND b.ID_KH = kh.ID_KH and bh.MAXE = x.MAXE", conn);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                textBox1.Text = "";
                textBox1.Enabled = false;
                textBox2.Text = "";
                textBox2.Enabled = false;
                textBox3.Text = "";
                textBox3.Enabled = false;
                textBox4.Text = "";
                textBox4.Enabled= false;
                textBox5.Text = "";
                textBox5.Enabled = false;
                textBox6.Text = "";
                textBox6.Enabled = false;
                textBox7.Text = "";
                textBox7.Enabled = false;
                textBox8.Text = "";
                textBox8.Enabled= false;
                textBox10.Text = "";
                textBox10.Enabled = false;
                textBox11.Enabled = false;
                textBox11.Text = "";
                comboBox1.Text = "";
                comboBox1.Enabled = false;
                comboBox2.Text = "";
                comboBox2.Enabled = false;
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            string mp = textBox2.Text;
            string tp = textBox3.Text;
            string th = textBox4.Text;
            string tx = comboBox1.SelectedValue.ToString();
            string nd = textBox10.Text;
            string dk = textBox11.Text;
            string mhd = comboBox2.Text;

            if (string.IsNullOrEmpty(tp) || string.IsNullOrEmpty(th) || string.IsNullOrEmpty(tx) || string.IsNullOrEmpty(nd) || string.IsNullOrEmpty(dk) || comboBox2.Text == "Chọn HD")
            {
                MessageBox.Show("Vui lòng không bỏ trống !");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("update_pbh", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MP", mp);
                cmd.Parameters.AddWithValue("@MX", tx);
                cmd.Parameters.AddWithValue("@TP", tp);
                cmd.Parameters.AddWithValue("@TH", th);
                //cmd.Parameters.AddWithValue("@MHD", mhd);
                cmd.Parameters.AddWithValue("@MT", nd);
                cmd.Parameters.AddWithValue("@DK", dk);
               /* if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }*/
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật phiếu : " + mp + " thành công !");
                ham.HienThiDuLieuDG(dataGridView1, "SELECT bh.MAPHIEU, bh.TENPHIEU,bh.MAXE,x.DongXE, bh.THOIHAN,nd.MA_HD,b.NgayLap,kh.ID_KH,kh.hoten,kh.DiaChi,kh.SDT ,nd.MOTA,nd.DIEUKIEN FROM PHIEU_BH bh, NOI_DUNG_BH nd, BILL b,KHACH_HANG kh, XE x WHERE bh.MAPHIEU = nd.MAPHIEU AND nd.MA_HD = b.MA_HD AND b.ID_KH = kh.ID_KH and bh.MAXE = x.MAXE", conn);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string mp = textBox2.Text;
            DialogResult result = MessageBox.Show("Bạn thật sự muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("delete_pbh", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MP", mp);
                /*if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }*/
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã xóa phiếu : " + mp);

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
                textBox6.Text = "";
                textBox6.Enabled = false;
                textBox7.Text = "";
                textBox7.Enabled = false;
                textBox8.Text = "";
                textBox8.Enabled = false;
                textBox10.Text = "";
                textBox10.Enabled = false;
                textBox11.Enabled = false;
                textBox11.Text = "";
                comboBox1.Text = "";
                comboBox1.Enabled = false;
                comboBox2.Text = "";
                comboBox2.Enabled = false;
                ham.HienThiDuLieuDG(dataGridView1, "SELECT bh.MAPHIEU, bh.TENPHIEU,bh.MAXE,x.DongXE, bh.THOIHAN,nd.MA_HD,b.NgayLap,kh.ID_KH,kh.hoten,kh.DiaChi,kh.SDT ,nd.MOTA,nd.DIEUKIEN FROM PHIEU_BH bh, NOI_DUNG_BH nd, BILL b,KHACH_HANG kh, XE x WHERE bh.MAPHIEU = nd.MAPHIEU AND nd.MA_HD = b.MA_HD AND b.ID_KH = kh.ID_KH and bh.MAXE = x.MAXE", conn);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                button3.Enabled = false;
                button6.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            Index index = new Index(userName,userRole);
            index.ShowDialog();
            this.Close();

        }
    }
    }

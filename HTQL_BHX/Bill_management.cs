using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HTQL_BHX
{
    public partial class Bill_management : Form
    {
        protected SqlConnection conn = new SqlConnection();
        Functions ham = new Functions();

        private string username;
        private string userRole;

        public Bill_management(string username, string userRole)
        {
            InitializeComponent();
            this.username = username;
            this.userRole = userRole;

    }

        public Bill_management()
        {
            InitializeComponent();

        }

        private void Bill_management_Load(object sender, EventArgs e)
        {
           
                panel3.BackColor = Color.LightGray;
                label8.ForeColor = Color.Black;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button6.Enabled = false;
                textBox1.Enabled = false;
                // textBox1.Text = "";
                textBox2.Enabled = false;
                // textBox2.Text = "";
                textBox3.Enabled = false;
                // textBox3.Text = "";
                textBox5.Enabled = false;
                //  textBox5.Text = "";
                textBox6.Enabled = false;

                comboBox1.Enabled = false;
                comboBox1.Text = "Chọn xe";

                comboBox2.Enabled = false;
                comboBox2.Text = "Chọn KH";
                comboBox3.Enabled = false;
                comboBox3.Text = "Chọn NV";
                //textBox6.Enabled = false;
                //textBox6.Text = "";
                //textBox7.Enabled = false;
                //textBox7.Text = "";
                //textBox9.Enabled = false;
                //textBox9.Text = "";
                ham.Connect(conn);
                ham.HienThiDuLieuDG(dataGridView1, "SELECT  b.ma_hd , b.id_kh,b.id_nv, b.ngaylap,x.maxe,x.dongxe,ct.SoLuong,ct.ThanhTien FROM BILL b,CHI_TIET_HD ct, XE x WHERE b.Ma_HD = ct.Ma_HD AND x.MaXe = ct.MaXe ", conn);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;
                

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (userRole == "Nhan vien")
            {
                textBox1.Enabled = true;
                textBox1.ReadOnly = true;

                textBox2.Enabled = true;
                textBox2.ReadOnly = true;

                textBox3.Enabled = true;
                textBox3.ReadOnly = true;

                textBox4.Enabled = true;
                textBox5.Enabled = false;
                textBox6.Enabled = false;

                comboBox1.Enabled = false;

                ham.HienThiComboBoxHideID(comboBox1, "SELECT DISTINCT MaXe,DongXe FROM XE where delete_xe = 0", conn, "DongXe", "MaXe");

                comboBox2.Enabled = false;
                // comboBox2.Text = "Chọn KH";

                ham.HienThiComboBox(comboBox2, "SELECT DISTINCT ID_KH FROM KHACH_HANG where delete_kh = 0", conn);


                comboBox3.Enabled = false;
                // comboBox3.Text = "Chọn NV";

                ham.HienThiComboBox(comboBox3, "SELECT ID_NV FROM NHAN_VIEN where delete_nv = 0", conn);


                button4.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button6.Enabled = true;
               

                int stt = e.RowIndex + 1;
                textBox1.Text = stt.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                textBox5.TextChanged += new EventHandler(UpdateTextBox6);
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;
            }
            else
            {
                textBox1.Enabled = true;
                textBox1.ReadOnly = true;

                textBox2.Enabled = true;
                textBox2.ReadOnly = true;

                textBox3.Enabled = true;
                textBox3.ReadOnly = true;

                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;

                comboBox1.Enabled = true;

                ham.HienThiComboBoxHideID(comboBox1, "SELECT DISTINCT MaXe,DongXe FROM XE where delete_xe = 0", conn, "DongXe", "MaXe");

                comboBox2.Enabled = true;
                // comboBox2.Text = "Chọn KH";

                ham.HienThiComboBox(comboBox2, "SELECT DISTINCT ID_KH FROM KHACH_HANG where delete_kh = 0", conn);


                comboBox3.Enabled = true;
                // comboBox3.Text = "Chọn NV";

                ham.HienThiComboBox(comboBox3, "SELECT ID_NV FROM NHAN_VIEN where delete_nv = 0", conn);


                button4.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                //button6.Enabled = false;
                 button6.Enabled = true;

                int stt = e.RowIndex + 1;
                textBox1.Text = stt.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                textBox5.TextChanged += new EventHandler(UpdateTextBox6);
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;
            
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.BackColor = Color.LightGray;
            label8.ForeColor = Color.Black;
            textBox4.Text = "";
            button2.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
            textBox1.Enabled = false;
            textBox1.Text = "";
            textBox2.Enabled = false;
            textBox2.Text = "";
            textBox3.Enabled = false;
            textBox3.Text = "";
            textBox5.TextChanged -= UpdateTextBox6;
            textBox5.Enabled = false;
            textBox5.Text = "";

            textBox6.Text = "";
            textBox6.Enabled = false;


            comboBox1.Enabled = false;
            //  ham.Connect(conn);
            //ham.HienThiComboBoxHideID(comboBox1, "SELECT DISTINCT MaXe,DongXe FROM XE", conn, "DongXe", "MaXe");
            comboBox1.Text = "Chọn xe";


            comboBox2.Enabled = false;

            // ham.HienThiComboBox(comboBox2, "SELECT DISTINCT ID_KH FROM KHACH_HANG", conn);
            comboBox2.Text = "Chọn KH";


            comboBox3.Enabled = false;
            // ham.HienThiComboBox(comboBox3, "SELECT ID_NV FROM NHAN_VIEN", conn);
            comboBox3.Text = "Chọn NV";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Index index = new Index(username, userRole);
            index.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            textBox5.Enabled = true;
            textBox6.Enabled = true;
            comboBox1.Enabled = true;


            string mhd = textBox2.Text;
            string maxe = comboBox1.SelectedValue.ToString(); //giá trị thực ẩn nảy 
            string idkh = comboBox2.Text;
            string idnv = comboBox3.Text;
            string sll = textBox5.Text;
            string check_tt = textBox6.Text;

            if (maxe == "Chọn xe" || idkh == "Chọn KH" || idnv == "Chọn NV" || string.IsNullOrEmpty(sll.ToString()) || string.IsNullOrEmpty(check_tt.ToString()))
            {
                MessageBox.Show("Vui lòng không bỏ trống !");
            }
            else
            {
                int sl = int.Parse(textBox5.Text);
                if (sl <= 0)
                {
                    MessageBox.Show("Số lượng lớn hơn 0 và không bỏ trống !");
                    return;
                }
                int tt = int.Parse(textBox6.Text);

                SqlCommand cmd = new SqlCommand("update_bill", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MHD", mhd);
                cmd.Parameters.AddWithValue("@IDKH", idkh);
                cmd.Parameters.AddWithValue("@IDNV", idnv);
                cmd.Parameters.AddWithValue("@MX", maxe);
                cmd.Parameters.AddWithValue("@SL", sl);
                cmd.Parameters.AddWithValue("@TT", tt);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật hóa đơn : " + mhd + " thành công !");
                ham.HienThiDuLieuDG(dataGridView1, "SELECT  b.ma_hd , b.id_kh,b.id_nv, b.ngaylap,x.maxe,x.dongxe,ct.SoLuong,ct.ThanhTien FROM BILL b,CHI_TIET_HD ct, XE x WHERE b.Ma_HD = ct.Ma_HD AND x.MaXe = ct.MaXe", conn);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;
               
            }
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Navy;
            panel3.BackColor = Color.Navy;
            string keywords = textBox4.Text;
            string search = "SELECT b.ma_hd , b.id_kh,b.id_nv, b.ngaylap,x.maxe,x.dongxe FROM BILL b,CHI_TIET_HD ct, XE x WHERE b.Ma_HD = ct.Ma_HD AND x.MaXe = ct.MaXe AND (b.Ma_HD LIKE '%" + keywords + "%' OR b.ID_KH LIKE '%" + keywords + "%' OR b.ID_NV LIKE '%" + keywords + "%' OR X.DongXe LIKE '%" + keywords + "%')";
            ham.HienThiDuLieuDG(dataGridView1, search, conn);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox5.Enabled = true;
            // Gán phương thức xử lý sự kiện UpdateTextBox6 cho sự kiện TextChanged của textBox5
            textBox5.TextChanged += new EventHandler(UpdateTextBox6);

            textBox6.Enabled = true;
            comboBox2.Text = "";
            comboBox1.Text = "";
            comboBox3.Text = "";
            comboBox1.Enabled = true;
            ham.HienThiComboBoxHideID(comboBox1, "SELECT DISTINCT MaXe,DongXe FROM XE where delete_xe = 0", conn, "DongXe", "MaXe");
            comboBox1.Text = "Chọn xe";


            comboBox2.Enabled = true;
            ham.HienThiComboBox(comboBox2, "SELECT DISTINCT ID_KH FROM KHACH_HANG where delete_kh = 0", conn);
            comboBox2.Text = "Chọn KH";

            comboBox3.Enabled = true;
            ham.HienThiComboBox(comboBox3, "SELECT ID_NV FROM NHAN_VIEN where delete_nv = 0", conn);
            comboBox3.Text = "Chọn NV";

            string icr_mhd = "SELECT MAX(SUBSTRING(MA_HD, 4, LEN(MA_HD))) FROM BILL";

            try
            {


                SqlCommand cmd = new SqlCommand(icr_mhd, conn);
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    // Nếu có dữ liệu trả về
                    if (!rd.IsDBNull(0))
                    {   // GetValue(0) cột đầu tiên như nhau nhưng thằng value thường dùng cho int, nếu bản chất nó int thì đem lên sài này khỏi ép 
                        int mhd_tt = Convert.ToInt32(rd.GetString(0)) + 1;

                        if (mhd_tt < 10)
                        {
                            textBox2.Text = "HD00" + mhd_tt.ToString();
                        }
                        else if (mhd_tt >= 10)
                        {
                            textBox2.Text = "HD0" + mhd_tt.ToString();
                        }
                        else if (mhd_tt <= 1000)
                        {
                            textBox2.Text = "HD" + mhd_tt.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Mã hóa đơn chỉ chứa đủ HDxxx, vui lòng xem lại!!");
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

                /*if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }*/
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.BackColor = Color.LightGray;
            label8.ForeColor = Color.Black;
            textBox4.Text = "";
            textBox3.Enabled = false;
            string mhd = textBox2.Text;
            string maxe = comboBox1.SelectedValue.ToString(); //giá trị thực ẩn nảy 
            string idkh = comboBox2.Text;
            string idnv = comboBox3.Text;
            string sll = textBox5.Text;
            string check_tt = textBox6.Text;

            if (maxe == "Chọn xe" || idkh == "Chọn KH" || idnv == "Chọn NV" || string.IsNullOrEmpty(sll.ToString()) || string.IsNullOrEmpty(check_tt.ToString()))
            {
                MessageBox.Show("Vui lòng không bỏ trống !");
            }
            else
            {
                int sl = int.Parse(textBox5.Text);
                if (sl <= 0)
                {
                    MessageBox.Show("Số lượng lớn hơn 0 và không bỏ trống !");
                    return;
                }
                int tt = int.Parse(textBox6.Text);

                SqlCommand cmd = new SqlCommand("insert_gia", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MHD", mhd);
                cmd.Parameters.AddWithValue("@IDKH", idkh);
                cmd.Parameters.AddWithValue("@IDNV", idnv);
                cmd.Parameters.AddWithValue("@MX", maxe);
                cmd.Parameters.AddWithValue("@SL", sl);
                cmd.Parameters.AddWithValue("@TT", tt);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm thành công !");
                ham.HienThiDuLieuDG(dataGridView1, "SELECT  b.ma_hd , b.id_kh,b.id_nv, b.ngaylap,x.maxe,x.dongxe,ct.SoLuong,ct.ThanhTien FROM BILL b,CHI_TIET_HD ct, XE x WHERE b.Ma_HD = ct.Ma_HD AND x.MaXe = ct.MaXe", conn);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;
                textBox1.Enabled = false;
                textBox1.Text = "";
                textBox2.Enabled = false;
                textBox2.Text = "";
                textBox3.Enabled = false;
                textBox3.Text = "";
                comboBox1.Enabled = false;
                comboBox1.Text = "Chọn xe";
                comboBox2.Enabled = false;
                comboBox2.Text = "Chọn KH";
                comboBox3.Enabled = false;
                comboBox3.Text = "Chọn NV";
                textBox5.Enabled = false;
                textBox5.Text = "";
                textBox6.Enabled = false;
                textBox6.Text = "";
            }


        }
    

        


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
           


        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateTextBox6(object sender, EventArgs e)
        {
           
            string input = textBox5.Text;

            
            if (int.TryParse(input, out int sl))
            {
               
                string tenxe = comboBox1.Text;

                try
                {
                    SqlCommand cmd = new SqlCommand("tim_gia_xe", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TX", tenxe);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        string gia = dr["GIANIEMYET"].ToString();
                        dr.Close();
                        textBox6.Text = (sl * Convert.ToInt32(gia)).ToString();
                    }
                    else
                    {
                        dr.Close();
                     
                        MessageBox.Show("Không tìm thấy giá của xe");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
               
                textBox6.Text = "";
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            string mhd = textBox2.Text;
            DialogResult result = MessageBox.Show("Bạn thật sự muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
               
                    SqlCommand cmd = new SqlCommand("delete_hd", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mhd", mhd);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã xóa hóa đơn : " + textBox2.Text);
                    ham.HienThiDuLieuDG(dataGridView1, "SELECT  b.ma_hd , b.id_kh,b.id_nv, b.ngaylap,x.maxe,x.dongxe,ct.SoLuong,ct.ThanhTien FROM BILL b,CHI_TIET_HD ct, XE x WHERE b.Ma_HD = ct.Ma_HD AND x.MaXe = ct.MaXe", conn);
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.ReadOnly = true;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button6.Enabled = false;
                    textBox1.Text = "";
                    textBox1.Enabled = false;
                    textBox2.Text = "";
                    textBox2.Enabled = false;
                    textBox3.Text = "";
                    textBox3.Enabled = false;

                    comboBox1.Text = "Chọn xe";
                    comboBox1.Enabled = false;
                    comboBox2.Text = "Chọn KH";
                    comboBox2.Enabled = false;
                    comboBox3.Text = "Chọn NV";
                    comboBox3.Enabled = false;
               /* }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }*/
            }

            }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
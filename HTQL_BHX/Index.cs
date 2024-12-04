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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HTQL_BHX
{
    public partial class Index : Form
    {
        protected SqlConnection conn = new SqlConnection();
        Functions ham = new Functions();

        private string userRole;
        private string userName;
        
        public Index(string username, string role)
        {
            InitializeComponent();
            usnIndex.Text = username;
            userRole = role;
            userName = username;
        }
        public Index(string username)
        {
            InitializeComponent();
            usnIndex.Text = username;   

        }
        public Index()
        {
            InitializeComponent();
            
        }
        private void Index_Load(object sender, EventArgs e)
        {
           /* if(userRole == "Nhan vien")
            {
                button5.Enabled = false;
                pictureBox5.Enabled = false;
            }*/
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           

        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            Manage_warranty pbh = new Manage_warranty(userName, userRole);
            pbh.ShowDialog();
            this.Close();
        }
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
          
            this.Hide();
            Manage_warranty pbh = new Manage_warranty(userName, userRole);
            pbh.ShowDialog();
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_vehicle_information xe = new View_vehicle_information(userName, userRole);
            xe.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            View_vehicle_information xe = new View_vehicle_information(userName, userRole);
            xe.ShowDialog();
            this.Close();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer customer = new Customer(userName, userRole);
            customer.ShowDialog();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer customer = new Customer(userName, userRole);
            customer.ShowDialog();
            this.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bill_management bill = new Bill_management(userName,userRole);
            bill.ShowDialog();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bill_management bill = new Bill_management(userName,userRole);
            bill.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (userRole == "Nhan vien")
            {
                MessageBox.Show("Không đủ quyền truy cập !!");
            }
            else
            {

                this.Hide();
                staff_management staff = new staff_management(userName, userRole);
                staff.ShowDialog();
                this.Close();
            }


        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (userRole == "Nhan vien")
            {
                MessageBox.Show("Không đủ quyền truy cập !!");
            }
            else
            {
                this.Hide();
                staff_management staff = new staff_management(userName, userRole);
                staff.ShowDialog();
                this.Close();
            }

        }
       
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();  
            login.ShowDialog();
            this.Close();
        }

      


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Index_Load_1(object sender, EventArgs e)
        {

        }
    }
}

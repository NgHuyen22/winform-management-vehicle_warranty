using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace HTQL_BHX
{
    internal class Functions
    {

        public void Connect(SqlConnection conn)
        {
            string stringconnect = "SERVER = NGOCHUYEN\\SQLEXPRESS; Database = HTQL_BHX; Integrated Security = True";

            conn.ConnectionString = stringconnect;
            conn.Open(); 
        }

        public void HienThiDuLieuDG(DataGridView dv, string sql, SqlConnection conn)
        {
           

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dv.DataSource = dt; // Gán dữ liệu vào DataGridView
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                //conn.Close(); 
            }

        }
       

        public void HienThiComboBoxHideID(ComboBox cb, string sql, SqlConnection conn, string show, string hide)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql,conn);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                cb.DataSource = dt;
                cb.DisplayMember = show;
                cb.ValueMember = hide;
                reader.Close();
            } catch (Exception ex)
            {
                MessageBox.Show (ex.Message);
            }
            finally
            {
                //conn.Close();
            }

        }
        public void HienThiComboBox(ComboBox cb,string sql,SqlConnection conn)
          {
            try
             {
                 SqlCommand comd = new SqlCommand(sql, conn);
                 SqlDataReader rd = comd.ExecuteReader();
                 DataTable dt = new DataTable();
                cb.Items.Clear();
                while (rd.Read()) 
                 {
                     string value = rd.GetString(0);
                     cb.Items.Add(value);

                 }


                 rd.Close();

             }
             catch (Exception ex)
             {
                 MessageBox.Show("ERROR: " + ex.Message);
             }
             finally
             {
                 //conn.Close();
             }
           

        }

        public void HienThiComboBox1(ComboBox cb, string sql, SqlConnection conn, string hienthi)
        {
            SqlCommand comd = new SqlCommand(sql, conn);
            SqlDataReader rd = comd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rd);
            cb.DataSource = dt;
            cb.DisplayMember = hienthi;
            rd.Close();


        }



        public void Save(string sql, SqlConnection con)
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                try
                {
                    //con.Open();  
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                 
                    MessageBox.Show("Error :" + ex.Message + "in sql :" + sql);
                }
            }
        }



    }
}

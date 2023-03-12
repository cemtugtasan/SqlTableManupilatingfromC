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

namespace TableManuplatingFromSql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-55D3033\\MSSQLSERVER01;Initial Catalog=Manupulation;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into UserTab Values (@ID,@Name,@Age)",con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(tbID.Text));
            cmd.Parameters.AddWithValue("@Name",tbName.Text);
            cmd.Parameters.AddWithValue("@Age", float.Parse(tbAge.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Added");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-55D3033\\MSSQLSERVER01;Initial Catalog=Manupulation;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update UserTab set Name=@Name,Age=@Age where ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(tbID.Text));
            cmd.Parameters.AddWithValue("@Name", tbName.Text);
            cmd.Parameters.AddWithValue("@Age", float.Parse(tbAge.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-55D3033\\MSSQLSERVER01;Initial Catalog=Manupulation;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete Usertab where ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(tbID.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-55D3033\\MSSQLSERVER01;Initial Catalog=Manupulation;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Usertab where ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(tbID.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);            
            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = true;
            
        }
    }
}

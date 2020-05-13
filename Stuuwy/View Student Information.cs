using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace Stuuwy
{
    public partial class View_Student_Information : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-V7SNEIV;Initial Catalog=Stuuwy;Integrated Security=True");
        public View_Student_Information()
        {
            InitializeComponent();
        }

        private void View_Student_Information_Load(object sender, EventArgs e)
        {
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            String query = "SELECT * FROM Student_Information";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void textBox1_KeyUp_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    dataGridView1.Columns.Clear();
                    dataGridView1.Refresh();
                    String query = "SELECT * FROM Student_Information WHERE studentFirstName like('%" + textBox1.Text + "%') ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                if (radioButton2.Checked)
                {
                    dataGridView1.Columns.Clear();
                    dataGridView1.Refresh();
                    String query = "SELECT * FROM Student_Information WHERE studentLastName like('%" + textBox1.Text + "%') ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                if (radioButton3.Checked)
                {
                    dataGridView1.Columns.Clear();
                    dataGridView1.Refresh();
                    String query = "SELECT * FROM Student_Information WHERE studentIndeks like('%" + textBox1.Text + "%') ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                if (radioButton4.Checked)
                {
                    dataGridView1.Columns.Clear();
                    dataGridView1.Refresh();
                    String query = "SELECT * FROM Student_Information WHERE studentSemestar like('%" + textBox1.Text + "%') ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                if (radioButton5.Checked)
                {
                    dataGridView1.Columns.Clear();
                    dataGridView1.Refresh();
                    String query = "SELECT * FROM Student_Information WHERE studentPrograma like('%" + textBox1.Text + "%') ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Enter student's firstname";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Enter student's lastname";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Enter student's indeks";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Enter student's semestar";
        }
    }
} 

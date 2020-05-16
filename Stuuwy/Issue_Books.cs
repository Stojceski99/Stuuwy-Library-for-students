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

namespace Stuuwy
{
    public partial class Issue_Books : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-V7SNEIV;Initial Catalog=Stuuwy;Integrated Security=True");
        public Issue_Books()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            String query = "SELECT * FROM Student_Information WHERE studentIndeks ='" + txt_Indeks.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                label9.Text = "Record not found";
                MessageBox.Show("Record not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearBox();
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txt_first.Text = dr["studentFirstName"].ToString();
                    txt_last.Text = dr["studentLastName"].ToString();
                    txt_programa.Text = dr["studentPrograma"].ToString();
                    txt_semestar.Text = dr["studentSemestar"].ToString();
                    txt_email.Text = dr["studentEmail"].ToString();
                }
            }
        }

        private void Issue_Books_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }
        private void txt_bookName_KeyUp(object sender, KeyEventArgs e)
        {
            int count = 0;
            if (e.KeyCode == Keys.Enter)
            {
                listBox1.Items.Clear();

                String query = "SELECT * FROM Book_Information WHERE bookName LIKE ('%"+ txt_Indeks.Text +"%')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                count = Convert.ToInt32(dt.Rows.Count.ToString());
                if (count > 0)
                {
                    listBox1.Visible = true;
                    foreach(DataRow dr in dt.Rows)
                    {
                        listBox1.Items.Add(dr["bookName"].ToString());
                    }
                }
            }
        }
        private void txt_bookName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_bookName.Text = listBox1.SelectedIndex.ToString();
                listBox1.Visible = false;
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            txt_bookName.Text = listBox1.SelectedIndex.ToString();
            listBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String query = "INSERT INTO Book_Issue VALUES(" + txt_Indeks.Text + ",'" + txt_first.Text + "','" + txt_last.Text + "','" + txt_programa.Text + "'," + txt_semestar.Text + ",'" + txt_email.Text + "','" + txt_bookName.Text + "','" + dateTimePicker1.Value.ToShortDateString() + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Book issued.", "Inforamation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Metodi

        private void ClearBox()
        {
            txt_Indeks.Text = "";
            txt_first.Text = "";
            txt_last.Text = "";
            txt_programa.Text = "";
            txt_semestar.Text = "";
            txt_email.Text = "";
        }
    }
}

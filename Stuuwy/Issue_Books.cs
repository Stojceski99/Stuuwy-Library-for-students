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
using System.Text.RegularExpressions;

namespace Stuuwy
{
    public partial class Issue_Books : Form
    {
        bool indeksValidaiton = false;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-V7SNEIV;Initial Catalog=Stuuwy;Integrated Security=True");
        public Issue_Books()
        {
            InitializeComponent();
        }

        private void txt_Indeks_Leave(object sender, EventArgs e)
        {
            indeksValidaiton = ValidateInteger(txt_Indeks, label1);
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
            if (e.KeyCode != Keys.Enter)
            {
                listBox1.Items.Clear();

                String query = "SELECT * FROM Book_Information WHERE bookName LIKE ('%"+ txt_bookName.Text +"%')";
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
                //listBox1.SelectedIndex = 0;
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_bookName.Text = listBox1.SelectedItem.ToString();
                listBox1.Visible = false;
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            txt_bookName.Text = listBox1.SelectedItem.ToString();
            listBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int checkBookQuantity = 0;
            checkBookQuantity = 0;
            String queryCheck = "SELECT * FROM Book_Information WHERE bookName='" + txt_bookName.Text + "'";
            SqlCommand cmdCheck = new SqlCommand(queryCheck, con);
            cmdCheck.ExecuteNonQuery();
            DataTable dtCheck = new DataTable();
            SqlDataAdapter daCheck = new SqlDataAdapter(cmdCheck);
            daCheck.Fill(dtCheck);

            foreach (DataRow drCheck in dtCheck.Rows)
            {
                checkBookQuantity = Convert.ToInt32(drCheck["availableQuantity"].ToString());
            }

            if (checkBookQuantity > 0)
            {
                // Query for inserting information about issued book in database
                String query = "INSERT INTO Book_Issue VALUES(" + txt_Indeks.Text + ",'" + txt_first.Text + "','" + txt_last.Text + "','" + txt_programa.Text + "'," + txt_semestar.Text + ",'" + txt_email.Text + "','" + txt_bookName.Text + "','" + dateTimePicker1.Value.ToShortDateString() + "','')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                // Query for updating availableQuantity
                String queryUpdate = "UPDATE Book_Information SET availableQuantity = availableQuantity-1 WHERE bookName ='" + txt_bookName.Text + "' ";
                SqlCommand cmdUpdate = new SqlCommand(queryUpdate, con);
                cmdUpdate.ExecuteNonQuery();

                ClearBox();
                MessageBox.Show("Book issued successfully.", "Inforamation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                txt_bookName.Focus();
                MessageBox.Show("Book not available.", "Inforamation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            txt_bookName.Text = "";
        }
        private int CheckAvailability (int checkBookQuantity)
        {
            checkBookQuantity = 0;
            String queryCheck = "SELECT * FROM Book_Information WHERE bookName='" + txt_bookName.Text + "'";
            SqlCommand cmdCheck = new SqlCommand(queryCheck, con);
            cmdCheck.ExecuteNonQuery();
            DataTable dtCheck = new DataTable();
            SqlDataAdapter daCheck = new SqlDataAdapter(cmdCheck);
            daCheck.Fill(dtCheck);
            foreach (DataRow drCheck in dtCheck.Rows)
            {
                checkBookQuantity = Convert.ToInt32(drCheck["availableQuantity"].ToString());
            }
            return checkBookQuantity;
        }
        public bool ValidateInteger(TextBox textBox, Label label)
        {
            if (!Regex.Match(textBox.Text, "^[0-9]+$").Success)
            {
                label9.Text = label.Text + " is invalid.";
                MessageBox.Show("Invalid " + label.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus();
                textBox.Text = "";
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

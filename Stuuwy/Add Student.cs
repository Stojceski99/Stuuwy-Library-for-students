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
    public partial class add_Student_info : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-V7SNEIV;Initial Catalog=Stuuwy;Integrated Security=True");
        bool emailValidation = false;
        public add_Student_info()
        {
            InitializeComponent();
        }

        private void add_Student_info_Load(object sender, EventArgs e)
        {

        }
        private void textBox6_Leave(object sender, EventArgs e) // validacija na Email
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$"; // tocna sema na Email - Thank you Youtube.
            if (Regex.IsMatch(textBox6.Text, pattern))
                emailValidation = true;
            else
            {
                label7.Text = "Email was incorect.";
                MessageBox.Show("Enter valid mail.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka
                textBox6.Text = "";
                textBox6.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT studentIndeks,studentEmail FROM Student_Information WHERE studentIndeks='" + textBox3.Text + "' OR studentEmail='" + textBox6.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                label7.Text = "Student Indeks or Student Email are already taken.";
                MessageBox.Show("Student Indeks or Student Email are already taken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka
            }
            else if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || textBox6.Text.Length == 0) // ako se prazni textBox-ovite
            {
                label1.Text = "All field's are required.";
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            else if (emailValidation)
            {
                try
                {
                    con.Open();
                    String query = "INSERT INTO Student_Information VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "'," + textBox5.Text + ",'" + textBox6.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error." + exp.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                label7.Text = "Something went wrong.";
                MessageBox.Show("Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                button1_Click(sender, e);
        }
    }
}

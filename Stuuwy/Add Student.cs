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
        bool firstNameValidation = false;
        bool lastNameValidation = false;
        bool indeksValidation = false;
        bool programaValidation = false;
        bool semestarValidation = false;
        bool emailValidation = false;
        public add_Student_info()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT studentIndeks,studentEmail FROM Student_Information WHERE studentIndeks='" + studentIndeks.Text + "' OR studentEmail='" + studentEmail.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                label7.Text = "Student Indeks or Student Email are already taken.";
                MessageBox.Show("Student Indeks or Student Email are already taken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (studentFirst.Text.Length == 0 || studentLast.Text.Length == 0 || studentIndeks.Text.Length == 0 || studentPrograma.Text.Length == 0 || studentSemestar.Text.Length == 0 || studentEmail.Text.Length == 0) // ako se prazni textBox-ovite
            {
                label7.Text = "All field's are required.";
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (firstNameValidation && lastNameValidation && indeksValidation && programaValidation && semestarValidation && emailValidation)
            {
                try
                {
                    con.Open();
                    String query = "INSERT INTO Student_Information VALUES ('" + studentFirst.Text + "','" + studentLast.Text + "','" + studentIndeks.Text + "','" + studentPrograma.Text + "'," + studentSemestar.Text + ",'" + studentEmail.Text + "','"+ studentPassword.Text+"')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    ClearTextBox();
                    MessageBox.Show("Student added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label7.Text = "";
                    con.Close();
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error." + exp.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                label7.Text = "Something went wrong.";
                MessageBox.Show("Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBox1_Leave(object sender, EventArgs e) // validacija na Firstname
        {
            firstNameValidation = ValidateString(studentFirst, label1);
        }
        private void textBox2_Leave(object sender, EventArgs e) // validacija na Lastname
        {
            lastNameValidation = ValidateString(studentLast, label2);
        }
        private void textBox3_Leave(object sender, EventArgs e) // validacija na Indeks
        {
            indeksValidation = ValidateInteger(studentIndeks, label3);
        }
        private void textBox4_Leave(object sender, EventArgs e) // validacija na Programa
        {
            programaValidation = ValidateString(studentPrograma, label4);
        }
        private void textBox5_Leave(object sender, EventArgs e) // validacija na Semestar
        {
            semestarValidation = ValidateInteger(studentSemestar, label5);
        }
        private void textBox6_Leave(object sender, EventArgs e) // validacija na Email
        {
            emailValidation = ValidateEmail(studentEmail, label6);
        }
        // Metodi

        public bool ValidateInteger(TextBox textBox, Label label)
        {
            if (!Regex.Match(textBox.Text, "^[0-9]+$").Success)
            {
                label7.Text = label.Text + " is invalid.";
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
        public bool ValidateEmail(TextBox textBox, Label label)
        {
            if (!Regex.Match(textBox.Text, "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$").Success)
            {
                label7.Text = label.Text + " is invalid.";
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
        public bool ValidateString(TextBox textBox, Label label)
        {
            if (!Regex.Match(textBox.Text, "^[A-Z][a-zA-Z]*$").Success)
            {
                label7.Text = label.Text + " is invalid.";
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
        private void ClearTextBox() 
        {
            studentFirst.Text = "";
            studentLast.Text = "";
            studentIndeks.Text = "";
            studentPrograma.Text = "";
            studentSemestar.Text = "";
            studentEmail.Text = "";
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                button1_Click(sender, e);
        }
    }
}

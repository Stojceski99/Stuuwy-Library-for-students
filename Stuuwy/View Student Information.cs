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
using System.Text.RegularExpressions;

namespace Stuuwy
{
    public partial class View_Student_Information : Form
    {
        bool firstNameValidation = true;
        bool lastNameValidation = true;
        bool indeksValidation = true;
        bool programaValidation = true;
        bool semestarValidation = true;
        bool emailValidation = true;

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
            FillGrid();      
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
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
        private void studentFirst_Leave(object sender, EventArgs e)
        {
            firstNameValidation = ValidateString(studentFirst, label4);
        }

        private void studentLast_Leave(object sender, EventArgs e)
        {
            lastNameValidation = ValidateString(studentLast, label5);
        }

        private void studentIndeks_Leave(object sender, EventArgs e)
        {
            indeksValidation = ValidateInteger(studentIndeks, label6);
        }

        private void studentPrograma_Leave(object sender, EventArgs e)
        {
            programaValidation = ValidateString(studentPrograma, label7);
        }

        private void studentSemestar_Leave(object sender, EventArgs e)
        {
            semestarValidation = ValidateInteger(studentSemestar, label8);
        }

        private void studentEmail_Leave(object sender, EventArgs e)
        {
            emailValidation = ValidateEmail(studentEmail, label9);
        }
        private void button1_Click(object sender, EventArgs e) // FOR OPTIMATIZATION, YOU CAN CHECK IN WHICH TEXTBOX TEXT HAS BEEN CHANGED(TEXT CHANGED EVENT), THEN YOU CAN UPDATE TEXT TO ONLY THOSE TEXTBOX'S, NOT ALL OF THEM!
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            
            SqlDataAdapter da = new SqlDataAdapter("SELECT studentIndeks,studentEmail FROM Student_Information WHERE studentIndeks='" + studentIndeks.Text + "' OR studentEmail='" + studentEmail.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 1)  // POSSIBLE BUG  !!!!!!!
            {
                label3.Text = "Student Indeks or Student Email are already taken.";
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
                    int i;
                    i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                    con.Open();
                    String query = "UPDATE Student_Information SET studentFirstName ='" + studentFirst.Text + "',studentLastName ='" + studentLast.Text + "',studentIndeks =" + studentIndeks.Text + ",studentPrograma ='" + studentPrograma.Text + "',studentSemestar =" + studentSemestar.Text + ",studentEmail ='" + studentEmail.Text + "' WHERE ID ="+ i +"";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    FillGrid();
                    MessageBox.Show("Student information updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                label3.Text = "Something went wrong.";
                MessageBox.Show("Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            String query = "SELECT * FROM Student_Information";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                studentFirst.Text = dr["studentFirstName"].ToString();
                studentLast.Text = dr["studentLastName"].ToString();
                studentIndeks.Text = dr["studentIndeks"].ToString();
                studentPrograma.Text = dr["studentPrograma"].ToString();
                studentSemestar.Text = dr["studentSemestar"].ToString();
                studentEmail.Text = dr["studentEmail"].ToString();
            }

        }
        //Metodi

        public bool ValidateInteger(TextBox textBox, Label label)
        {
            if (!Regex.Match(textBox.Text, "^[0-9]+$").Success)
            {
                label3.Text = label.Text + " is invalid.";
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
                label3.Text = label.Text + " is invalid.";
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
            if (!Regex.Match(textBox.Text, "^[A-Z\\s][a-zA-Z\\s]+$").Success)
            {
                label3.Text = label.Text + " is invalid.";  
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
        public void FillGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();

            String query = "SELECT * FROM Student_Information";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
} 

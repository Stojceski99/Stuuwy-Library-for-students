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
        bool firstNameValidation = false;
        bool lastNameValidation = false;
        bool indeksValidation = false;
        bool programaValidation = false;
        bool semestarValidation = false;
        bool emailValidation = false;

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
        private void txt_StudentFirstname_Leave(object sender, EventArgs e)
        {
            firstNameValidation = ValidateString(txt_StudentFirstname, label5);
        }

        private void txt_StudentLastName_Leave(object sender, EventArgs e)
        {
            lastNameValidation = ValidateString(txt_StudentLastName, label6);
        }

        private void txt_StudentIndeks_Leave(object sender, EventArgs e)
        {
            indeksValidation = ValidateInteger(txt_StudentIndeks, label7);
        }

        private void txt_StudentPrograma_Leave(object sender, EventArgs e)
        {
            programaValidation = ValidateString(txt_StudentPrograma, label8);
        }

        private void txt_StudentSemestar_Leave(object sender, EventArgs e)
        {
            semestarValidation = ValidateInteger(txt_StudentSemestar, label9);
        }

        private void txt_StudentEmail_Leave(object sender, EventArgs e)
        {
            emailValidation = ValidateEmail(txt_StudentEmail, label10);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // prikazuvanje na vrednostite na polinjata vo textBoxovite.
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            String query = "SELECT * FROM Student_Information WHERE ID="+ i +"";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txt_StudentFirstname.Text = dr["studentFirstName"].ToString();
                txt_StudentLastName.Text = dr["studentLastName"].ToString();
                txt_StudentIndeks.Text = dr["studentIndeks"].ToString();
                txt_StudentPrograma.Text = dr["studentPrograma"].ToString();
                txt_StudentSemestar.Text = dr["studentSemestar"].ToString();
                txt_StudentEmail.Text = dr["studentEmail"].ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlDataAdapter da = new SqlDataAdapter("SELECT studentIndeks,studentEmail FROM Student_Information WHERE studentIndeks='" + txt_StudentIndeks.Text + "' OR studentEmail='" + txt_StudentEmail.Text + "' EXCEPT " +
                "", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                label3.Text = "Student Indeks or Student Email are already taken.";
                MessageBox.Show("Student Indeks or Student Email are already taken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (txt_StudentFirstname.Text == "" || txt_StudentLastName.Text == "" || txt_StudentIndeks.Text == "" || txt_StudentPrograma.Text == "" || txt_StudentSemestar.Text == "" || txt_StudentEmail.Text == ""   )
            {
                label3.Text = "All field's are required.";
                MessageBox.Show("All field's are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_StudentFirstname.Focus();
                return;
            }
            if (firstNameValidation && lastNameValidation && indeksValidation && programaValidation && semestarValidation && emailValidation )
            {
                try
                {
                    con.Open();
                    String query = "UPDATE Student_Information SET studentFirstName ='" + txt_StudentFirstname.Text + "',studentLastName ='" + txt_StudentLastName.Text + "',studentIndeks ='" + txt_StudentIndeks.Text + "',studentPrograma ='" + txt_StudentPrograma.Text + "',studentSemestar ='" + txt_StudentSemestar.Text + "',studentEmail ='" + txt_StudentEmail.Text + "' WHERE ID=" + i + "";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    FillGrid();
                    con.Close();
                }
                catch(Exception exp)
                {
                    MessageBox.Show("Error." + exp.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                label3.Text = "Something went wrong.";
                MessageBox.Show("Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (!Regex.Match(textBox.Text, "^[A-Z][a-zA-Z]*$").Success)
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

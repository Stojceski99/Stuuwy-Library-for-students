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
    public partial class loginForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-V7SNEIV;Initial Catalog=Stuuwy;Integrated Security=True"); // konekciski string so data bazata
        int countLibrarian = 0;
        int countStudent = 0;
        public loginForm()
        {
            InitializeComponent();
            // Form control buttons
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            countLibrarian = CheckLibrarian();
            countStudent = CheckStudent();
            // IF CASSES FOR LOGIN
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0) // ako texBox1 i textBox2 se prazni
            {
                label3.Text = "All field's are required.";
                MessageBox.Show("Enter username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka
            }
            else if (countLibrarian == 0 && countStudent == 0) // ako metodot ExecuteNonQuery() vrati rezultat 0 [nema kolona so takva kombinacija na "username" i "password"]
            {
                label3.Text = "Credentials don't match.";
                MessageBox.Show("Credentials don't match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka
            }
            else if (countLibrarian >= 1) // ako ima >=1 t.e ako postoi taa kombinacija na "username" i "password"
            {
                this.Hide();
                MDI_Librarian ml = new MDI_Librarian();
                ml.Show();
            }
            else if (countStudent >= 1)
            {
                this.Hide();
                mdi_user mu = new mdi_user();
                mu.Show();
            }
            else // nepredviden slucaj 
            {
                label3.Text = "Try again.";
                MessageBox.Show("Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka
            }
                
        }

        private void loginForm_Load(object sender, EventArgs e) // pri vcituvanje na formata loginForm
        {
            if (con.State == ConnectionState.Open) // ako konekcijata e otvorena
            {
                con.Close(); // zatvorija
            }
            con.Open(); //..vo sprotivno otvorija
        }

        private void label4_Click(object sender, EventArgs e) // registriranje
        {
            this.Hide();
            Register_Form rf = new Register_Form();
            rf.Show();
        }

        private void TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                button1_Click(sender, e);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private int CheckLibrarian()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            int i = 0;
            SqlCommand cmdLibrarian = con.CreateCommand();
            cmdLibrarian.CommandType = CommandType.Text;
            cmdLibrarian.CommandText = "SELECT * FROM Librarian WHERE email COLLATE Latin1_general_CS_AS ='" + textBox1.Text + "' AND password COLLATE Latin1_general_CS_AS ='" + textBox2.Text + "'";
            cmdLibrarian.ExecuteNonQuery(); // metod koj se koristi za manipuliranje podatoci vo databaza i se koristi vo naredbi bez rezultat kako CREATE,INSERT,UPDATE,DELETE,SELECT ...
            DataTable dtLibrarian = new DataTable();
            SqlDataAdapter daLibrarian = new SqlDataAdapter(cmdLibrarian);
            daLibrarian.Fill(dtLibrarian);
            i = Convert.ToInt32(dtLibrarian.Rows.Count.ToString());
            return i;
        }
        private int CheckStudent()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            int x = 0;
            SqlCommand cmdStudent = con.CreateCommand();
            cmdStudent.CommandType = CommandType.Text;
            cmdStudent.CommandText = "SELECT * FROM Student_Information WHERE studentEmail COLLATE Latin1_general_CS_AS ='" + textBox1.Text + "' AND studentPassword COLLATE Latin1_general_CS_AS ='" + textBox2.Text + "'";
            cmdStudent.ExecuteNonQuery(); // metod koj se koristi za manipuliranje podatoci vo databaza i se koristi vo naredbi bez rezultat kako CREATE,INSERT,UPDATE,DELETE,SELECT ...
            DataTable dtStudent = new DataTable();
            SqlDataAdapter daStudent = new SqlDataAdapter(cmdStudent);
            daStudent.Fill(dtStudent);
            x = Convert.ToInt32(dtStudent.Rows.Count.ToString());
            return x;
        }
    }
}

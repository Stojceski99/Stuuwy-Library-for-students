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
using System.Text.RegularExpressions; // biblioteka za ne-mutiracki regularni izrazi [regex] - ja koristam za validacija na EMAIL adresa 57 programski red
namespace Stuuwy
{
    public partial class Register_Form : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-V7SNEIV;Initial Catalog=Stuuwy;Integrated Security=True");
        bool emailValidation = false;
        public Register_Form()
        {
            InitializeComponent();
        }

        private void Register_Form_Load(object sender, EventArgs e) // pri vcituvanje na formata Register_Form
        {
            if (con.State == ConnectionState.Open) // ako konekcijata e otvorena
            {
                con.Close(); // zatvorija
            }
            con.Open(); //..vo sprotivno otvorija
        }
        private void textBox6_Leave(object sender, EventArgs e) // validacija na mail pri gubenje na focus od textBox6
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$"; // tocna sema na Email - Thank you Youtube.
            if (Regex.IsMatch(textBox6.Text, pattern))
                emailValidation = true;
            else
            {
                label1.Text = "Email was incorect.";
                MessageBox.Show("Enter valid mail.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka
                textBox6.Text = "";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try {
                String firstName = textBox1.Text;
                String lastName = textBox2.Text;
                String userName = textBox3.Text;
                String password = textBox4.Text;
                String con_password = textBox5.Text;
                String email = textBox6.Text;

                String query = "INSERT INTO Registered_Users (firstName,lastName,userName,password,email) VALUES ('" + firstName + "','" + lastName + "','" + userName + "','" + password + "','" + email + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                int count = cmd.ExecuteNonQuery();
            }
            catch(System.Exception exp)
            {
                MessageBox.Show("Enter username and password." + exp.ToString(), "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        //Metodi
        private void clearTextBox() // metod za brisenje na podatocite vo textBox-ovite
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
        private void show_loginForm() // loadiranje na loginForm
        {
            this.Hide();
            loginForm lf = new loginForm();
            lf.Show();
        }
    }
}

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
            //Proverka na userName i email pri registracija - ako se zafateni obidise so drugo userName ili drug email
            SqlDataAdapter da = new SqlDataAdapter("SELECT userName,email FROM Registered_Users WHERE userName='" + textBox3.Text + "' OR email='" + textBox6.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1) // Ako postoi barem 1 kolona so takvi userName OR email
            {
                label1.Text = "Username or email are already taken.";
                MessageBox.Show("Username or email are already taken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka
            }
            else if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || textBox6.Text.Length == 0) // ako se prazni textBox-ovite
            {
                label1.Text = "All field's are required.";
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka
            }
            else if (textBox5.Text != textBox4.Text) // ako ne se ednakvi stringovite [0-ednakvi,1-prviot pomal od vtoriot,-1-vtoriot pogolem od prviot]
            {
                textBox4.Text = "";
                textBox5.Text = "";
                textBox4.Focus();
                label1.Text = "Password don't match.";
                MessageBox.Show("Password don't match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka

            }
            else if (emailValidation)
            {
                try
                {
                    // Dodeluvanje na vrednosti od textBox-ovite vo string
                    String firstName = textBox1.Text;
                    String lastName = textBox2.Text;
                    String userName = textBox3.Text;
                    String password = textBox4.Text;
                    String con_password = textBox5.Text;
                    String email = textBox6.Text;

                    String query = "INSERT INTO Registered_Users (firstName,lastName,userName,password,email) VALUES ('" + firstName + "','" + lastName + "','" + userName + "','" + password + "','" + email + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    int count = cmd.ExecuteNonQuery();
                    MessageBox.Show("You were registered successufully.","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearTextBox();
                    show_loginForm();
                }
                catch (System.Exception exp)
                {
                    MessageBox.Show("Enter username and password." + exp.ToString(), "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            } 
            else // nepredviden slucaj
            {
                label1.Text = "Something went wrong.";
                MessageBox.Show("Something went wrong,please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka
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

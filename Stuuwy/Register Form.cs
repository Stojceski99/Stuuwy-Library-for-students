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
        bool firstValidation = false;
        bool lastValidation = false;
        bool indeksValidation = false;
        bool programaValidation = false;
        bool semestarValidation = false;
        public Register_Form()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void Register_Form_Load(object sender, EventArgs e) // pri vcituvanje na formata Register_Form
        {
            if (con.State == ConnectionState.Open) // ako konekcijata e otvorena
            {
                con.Close(); // zatvorija
            }
            con.Open(); //..vo sprotivno otvorija
        }
        private void studentFirst_Leave(object sender, EventArgs e)
        {
            firstValidation = ValidateString(studentFirst, label2);
        }

        private void studentLast_Leave(object sender, EventArgs e)
        {
            lastValidation = ValidateString(studentLast, label3);
        }
        private void studentIndeks_Leave(object sender, EventArgs e)
        {
            indeksValidation = ValidateInteger(studentIndeks, label4);
        }

        private void studentPrograma_Leave(object sender, EventArgs e)
        {
            programaValidation = ValidateString(studentPrograma, label8);
        }

        private void studentSemestar_Leave(object sender, EventArgs e)
        {
            semestarValidation = ValidateInteger(studentSemestar, label9);
        }
        private void textBox6_Leave(object sender, EventArgs e) // validacija na mail pri gubenje na focus od textBox6
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$"; // tocna sema na Email
            if (Regex.IsMatch(studentEmail.Text, pattern))
                emailValidation = true;
            else
            {
                label1.Text = "Email was incorect.";
                MessageBox.Show("Enter valid mail.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka
                studentEmail.Text = "";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Proverka na userName i email pri registracija - ako se zafateni obidise so drugo userName ili drug email
            SqlDataAdapter da = new SqlDataAdapter("SELECT userName,email FROM Registered_Users WHERE userName COLLATE Latin1_general_CS_AS ='" + studentIndeks.Text + "' OR email COLLATE Latin1_general_CS_AS ='" + studentEmail.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1) // Ako postoi barem 1 kolona so takvi userName OR email
            {
                label1.Text = "Username or email are already taken.";
                MessageBox.Show("Username or email are already taken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka
                return;
            }
            if (studentFirst.Text.Length == 0 || studentLast.Text.Length == 0 || studentIndeks.Text.Length == 0 || studentPrograma.Text.Length == 0 || studentPrograma.Text.Length == 0 ||studentPass.Text.Length == 0 || studentConPass.Text.Length == 0 || studentEmail.Text.Length == 0) // ako se prazni textBox-ovite
            {
                label1.Text = "All field's are required.";
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka
                return;
            }
            if (studentConPass.Text != studentPass.Text) // ako ne se ednakvi stringovite 
            {
                studentPass.Text = "";
                studentConPass.Text = "";
                studentPass.Focus();
                label1.Text = "Password don't match.";
                MessageBox.Show("Password don't match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka
                return;
            }
            if (emailValidation && firstValidation && lastValidation && indeksValidation && programaValidation && semestarValidation)
            {
                try
                {
                    String query = "INSERT INTO Student_Information (studentFirstName,studentLastName,studentIndeks,studentPrograma,studentSemestar,studentEmail,studentPassword) VALUES ('" + studentFirst.Text + "','" + studentLast.Text + "'," +
                        "" + studentIndeks.Text + ",'" + studentPrograma.Text + "','"+ studentSemestar.Text +"','" + studentEmail.Text + "'," +
                        "'" + studentPass.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("You were registered successufully.","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTextBox();
                    Show_loginForm();
                }
                catch (System.Exception exp)
                {
                    label1.Text = "Something went wrong.";
                    MessageBox.Show("Something went wrong,please try again." + exp.ToString(), "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            } 
            else // nepredviden slucaj
            {
                label1.Text = "Try again.";
                MessageBox.Show("Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka
            }
            
        } 
        //Metodi
        private void ClearTextBox() // metod za brisenje na podatocite vo textBox-ovite
        {
            studentFirst.Text = "";
            studentLast.Text = "";
            studentIndeks.Text = "";
            studentPass.Text = "";
            studentConPass.Text = "";
            studentEmail.Text = "";
        }
        private void Show_loginForm() // loadiranje na loginForm
        {
            this.Hide();
            loginForm lf = new loginForm();
            lf.Show();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
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
        public bool ValidateString(TextBox textBox, Label label)
        {
            if (!Regex.Match(textBox.Text, "^[A-Z\\s][a-zA-Z\\s]+$").Success)
            {
                label1.Text = label.Text + " is invalid.";
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
    }
}

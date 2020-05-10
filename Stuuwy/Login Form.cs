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
        int count = 0;
        public loginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Librarian WHERE username='" + textBox1.Text + "' AND password ='" + textBox2.Text + "'";
            cmd.ExecuteNonQuery(); // metod koj se koristi za manipuliranje podatoci vo databaza i se koristi vo naredbi bez rezultat kako CREATE,INSERT,UPDATE,DELETE,SELECT ...
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());

            // IF CASSES FOR LOGIN
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0) // ako texBox1 i textBox2 se prazni
            {
                label3.Text = "All field's are required.";
                MessageBox.Show("Enter username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka
            }
            else if (count == 0) // ako metodot ExecuteNonQuery() vrati rezultat 0 [nema kolona so takva kombinacija na "username" i "password"]
            {
                label3.Text = "Credentials don't match.";
                MessageBox.Show("Credentials don't match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka
            }
            else if (count >= 1) // ako ima >=1 t.e ako postoi taa kombinacija na "username" i "password"
            {
                this.Hide();
                mdi_user mu = new mdi_user();
                mu.Show();
            }
            else // nepredviden slucaj 
            {
                label3.Text = "Bad credentials.";
                MessageBox.Show("Bad credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka
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
    }
}

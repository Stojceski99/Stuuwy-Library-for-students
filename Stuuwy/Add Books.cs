using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Stuuwy
{
    public partial class add_books : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-V7SNEIV;Initial Catalog=Stuuwy;Integrated Security=True");
        public add_books()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Proverka na bookName AND bookAuthor pri vnes - ako se zafateni obidise so drugo bookName ili drug bookAuthor
            SqlDataAdapter da = new SqlDataAdapter("SELECT bookName,bookAuthor FROM Book_Information WHERE bookName='" + textBox1.Text + "' AND bookAuthor='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1) // Ako postoi barem 1 kolona so takvi userName OR email
            {
                label7.Text = "That book is already in database.";
                MessageBox.Show("That book is already in database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            else if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || dateTimePicker1.Text.Length == 0 || textBox5.Text.Length == 0 || textBox6.Text.Length == 0) // ako se prazni textBox-ovite
            {
                label7.Text = "All field's are required.";
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            else if (dt.Rows.Count == 0)
            {
                String query = "INSERT INTO Book_Information VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Text + "'," + textBox5.Text + "," + textBox6.Text + ")";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Book was added successufully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                ClearTextBox();
            }
            else
            {
                label7.Text = "Something went wrong.";
                MessageBox.Show("Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearTextBox() // metod za brisenje na podatocite vo textBox-ovite
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                button1_Click(sender, e);
        }

        private void add_books_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open) // ako konekcijata e otvorena
            {
                con.Close(); // zatvorija
            }
            con.Open(); //..vo sprotivno otvorija
        }
        //Metodi
    }

}

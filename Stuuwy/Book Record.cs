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
using System.Net;
using System.Net.Mail;    // biblioteka za mail prakanje

namespace Stuuwy
{
    public partial class Book_Record : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-V7SNEIV;Initial Catalog=Stuuwy;Integrated Security=True");
        public Book_Record()
        {
            InitializeComponent();
        }

        private void Book_Record_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            FillBookInfo();
        }
        //Metodi

        private void FillBookInfo()
        {
            String query = "SELECT bookName,bookAuthor,bookQuantity,availableQuantity FROM Book_Information";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView2.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String i;
            i = dataGridView1.SelectedCells[0].Value.ToString();

            String query = "SELECT * FROM Book_Issue WHERE bookName='" + i.ToString() + "' AND bookReturnDate=''";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.Visible = true;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            int i;
            String queryValidate = "SELECT bookName,bookAuthor,bookQuantity,availableQuantity FROM Book_Information WHERE bookName like ('%" + textBox1.Text + "%')";
            SqlCommand cmdValidate = new SqlCommand(queryValidate, con);
            cmdValidate.ExecuteNonQuery();
            DataTable dtValidate = new DataTable();
            SqlDataAdapter daValidate = new SqlDataAdapter(cmdValidate);
            daValidate.Fill(dtValidate);
            i = Convert.ToInt32(dtValidate.Rows.Count.ToString());
            if (i == 0)
            {
                label3.Text = "No such book,try again.";
                textBox1.Text = "";
                MessageBox.Show("No such book,try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                String query = "SELECT bookName,bookAuthor,bookQuantity,availableQuantity FROM Book_Information WHERE bookName like ('%" + textBox1.Text + "%')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView2.Visible = false;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String i;
            i = dataGridView2.SelectedCells[6].Value.ToString();
            textBox2.Text = i.ToString();
            panel3.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;

            // Username, password from admin
            smtp.Credentials = new NetworkCredential("stuuwylibrary@gmail.com", "hubabahu123");

            //FROM, TO, SUBJECT, BODY
            // MAKE SURE YOU ENABLE FORWARDING POP/IMAP ON YOUR GMAIL ACCOUNT [Settings, Forwarding POP/IMAP, Enable IMAP, Save Changes]
            // Allow less secure apps: ON [https://myaccount.google.com/lesssecureapps] 

            MailMessage mail = new MailMessage("stuuwylibrary@gmail.com", textBox2.Text, "Потсетник за враќање на книгата", textBox3.Text);
            mail.Priority = MailPriority.High;
            smtp.Send(mail);
            MessageBox.Show("Mail successfully sent.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox3.Text = "";
        }
    }
}


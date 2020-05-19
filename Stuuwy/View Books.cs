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
    public partial class view_books : Form
    {
        bool bookNameValidation = false;
        bool bookAuthorValidation = false;
        bool bookPublisherNameValidation = false;
        bool bookPriceValidation = false;
        bool bookQuantityValidation = false;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-V7SNEIV;Initial Catalog=Stuuwy;Integrated Security=True");
        public view_books()
        {
            InitializeComponent();
        }

        private void view_books_Load(object sender, EventArgs e)
        {
            Display_Grid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                con.Open();
                String query = "SELECT * FROM Book_Information WHERE bookName LIKE('%"+ textBox1.Text +"%')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    MessageBox.Show("Book not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                textBox1.Text = "";
                dataGridView1.DataSource = dt; 
                con.Close();

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                button1_Click(sender, e);
        }
        private void txt_BookName_Leave(object sender, EventArgs e)
        {
            bookNameValidation = ValidateString(txt_BookName, label5);
        }

        private void txt_AuthorName_Leave(object sender, EventArgs e)
        {
            bookAuthorValidation = ValidateString(txt_AuthorName, label6);
        }

        private void txt_PublisherName_Leave(object sender, EventArgs e)
        {
            bookPublisherNameValidation = ValidateString(txt_PublisherName, label7);
        }

        private void txt_Price_Leave(object sender, EventArgs e)
        {
            bookPriceValidation = ValidateInteger(txt_Price,label9);
        }

        private void txt_Quantity_Leave(object sender, EventArgs e)
        {
            bookQuantityValidation = ValidateString(txt_Quantity, label10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                con.Open();
                String query = "SELECT * FROM Book_Information WHERE bookAuthor LIKE('%" + textBox2.Text + "%')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                    MessageBox.Show("Author not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) // ENTER
                button2_Click(sender, e);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel4.Visible = true;
            // Za sekoja kolona selektirana od datagridView da se pretstavaat soodvetnite vrednosti vo textBox-ovite.
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {
                con.Open();
                String query = "SELECT * FROM Book_Information WHERE ID ="+ i +"";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows) // Za sekoj red vo dt[DataTable] da se prikazat vrednostite:
                {
                    txt_BookName.Text = dr["bookName"].ToString();
                    txt_AuthorName.Text = dr["bookAuthor"].ToString();
                    txt_PublisherName.Text = dr["bookPublisherName"].ToString();
                    dateTimePicker1.Text = (dr["bookPurchaseDate"].ToString()); // dateTimePicker1.Text = Convert.ToDateTime((dr["bookPurchaseDate"].ToString())); -> ERROR ????
                    txt_Price.Text = dr["bookPrice"].ToString();
                    txt_Quantity.Text = dr["bookQuantity"].ToString();
                }

                con.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {
                con.Open();
                String query = "UPDATE  Book_Information SET bookName='"+ txt_BookName.Text +"',bookAuthor='"+ txt_AuthorName.Text +"',bookPublisherName='"+ txt_PublisherName.Text +"',bookPurchaseDate='"+ dateTimePicker1.Value.ToString() +"',bookPrice="+ txt_Price.Text +",bookQuantity='"+ txt_Quantity.Text+"' WHERE ID ="+i+"";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Display_Grid();
                label12.Text = "";
                MessageBox.Show("Record updated successfully.","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel4.Visible = false;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Metodi
        private void Display_Grid()
        {
            try
            {
                con.Open();
                String query = "SELECT * FROM Book_Information";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt; // data grid se polni so informacii od Book_Information
                con.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool ValidateInteger(TextBox textBox, Label label)
        {
            if (!Regex.Match(textBox.Text, "^[0-9]+$").Success)
            {
                label12.Text = "";
                label12.Text = label.Text + " is invalid.";
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
            if (!Regex.Match(textBox.Text, "^[A-Z0-9]*[0-9a-zA-Z\\s]").Success)
            {
                label12.Text = "";
                label12.Text = label.Text + " is invalid.";
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

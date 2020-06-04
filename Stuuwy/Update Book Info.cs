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
    public partial class Update_Book_Info : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-V7SNEIV;Initial Catalog=Stuuwy;Integrated Security=True");

        bool bookNameValidation = false;
        bool bookAuthorValidation = false;
        bool bookPublisherNameValidation = false;
        bool bookPriceValidation = false;
        bool bookQuantityValidation = false;
        public Update_Book_Info()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
                String query = "UPDATE  Book_Information SET bookName='" + txt_BookName.Text + "',bookAuthor='" + txt_AuthorName.Text + "',bookPublisherName='" + txt_PublisherName.Text + "',bookPurchaseDate='" + dateTimePicker1.Value.ToString() + "',bookPrice=" + txt_Price.Text + ",availableQuantity='" + txt_Quantity.Text + "' WHERE ID =" + i + "";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                Display_Grid();
                label12.Text = "";
                MessageBox.Show("Record updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel4.Visible = false;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Update_Book_Info_Load(object sender, EventArgs e)
        {
            Display_Grid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel4.Visible = true;
            // Za sekoja kolona selektirana od datagridView da se pretstavaat soodvetnite vrednosti vo textBox-ovite.
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
                String query = "SELECT * FROM Book_Information WHERE ID =" + i + "";
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
                    txt_Quantity.Text = dr["availableQuantity"].ToString();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            bookPriceValidation = ValidateInteger(txt_Price, label9);
        }

        private void txt_Quantity_Leave(object sender, EventArgs e)
        {
            bookQuantityValidation = ValidateString(txt_Quantity, label10);
        }
        //Metodi
        private void Display_Grid()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
                String query = "SELECT * FROM Book_Information";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt; // data grid se polni so informacii od Book_Information
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

﻿using System;
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
    public partial class view_books : Form
    {
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
                    MessageBox.Show("Book not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
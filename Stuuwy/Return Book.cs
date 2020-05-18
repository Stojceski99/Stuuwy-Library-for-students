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
    public partial class Return_Book : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-V7SNEIV;Initial Catalog=Stuuwy;Integrated Security=True");
        public Return_Book()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillGrid( textBox1.Text);
            panel2.Visible = true;
        }

        private void Return_Book_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        //Metodi

        private void FillGrid(string indeks)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();

            String query = "SELECT * FROM Book_Issue WHERE studentIndeks='"+ indeks.ToString() +"' AND bookReturnDate=''";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel4.Visible = true;
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            String query = "SELECT * FROM Book_Issue WHERE ID ="+ i +"";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                lbl_bookNameInv.Text = dr["bookName"].ToString();
                lbl_issueDateInv.Text = dr["bookIssueDate"].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            String query = "UPDATE Book_Issue SET bookReturnDate='"+ dateTimePicker1.Value.ToString()+"' WHERE ID="+ i +"";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

            String queryUpdate = "UPDATE Book_Information SET availableQuantity=availableQuantity+1 WHERE bookName='" + lbl_bookNameInv.Text + "'";
            SqlCommand cmdUpdate = new SqlCommand(queryUpdate, con);
            cmdUpdate.ExecuteNonQuery();

            MessageBox.Show("Book returned successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            panel3.Visible = true;

            FillGrid(textBox1.Text);
        }
    }
}

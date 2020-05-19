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
    public partial class Report_for_Books : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-V7SNEIV;Initial Catalog=Stuuwy;Integrated Security=True");
        public Report_for_Books()
        {
            InitializeComponent();
        }
        private void Report_for_Books_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // if you get error IO.FileNotFoundException, you need to add in App.config  "<startup useLegacyV2RuntimeActivationPolicy="true">" 
            DataSet1 ds = new DataSet1();
            String query = "SELECT * FROM Book_Issue WHERE bookReturnDate='' ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds.DataTable1);
            CrystalReport1 report = new CrystalReport1();
            report.SetDataSource(ds);
            crystalReportViewer1.ReportSource = report;
        }
    }
}

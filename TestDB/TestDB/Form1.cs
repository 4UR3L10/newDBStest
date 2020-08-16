using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connectionVar = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Projects\newDBStest\TestDB\TestDB\ProductDB.mdf; Integrated Security = True; Connect Timeout = 30");
            connectionVar.Open();
            SqlCommand commandVar = connectionVar.CreateCommand();
            commandVar.CommandType = CommandType.Text;
            commandVar.CommandText = "SELECT Description FROM Product WHERE Product_Number = '10-01'";
            commandVar.ExecuteNonQuery();


            DataTable dataTableVar = new DataTable();
            SqlDataAdapter dataAdapterVar = new SqlDataAdapter(commandVar);
            dataAdapterVar.Fill(dataTableVar);
            foreach (DataRow dataRowVar in dataTableVar.Rows)
            {
                MessageBox.Show(dataRowVar["Description"].ToString());
            }
            connectionVar.Close();
            MessageBox.Show("Record Selected Successfully");
        }
    }
}

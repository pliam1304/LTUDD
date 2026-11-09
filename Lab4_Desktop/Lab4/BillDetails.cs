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

namespace Lab4
{
    public partial class BillDetails : Form
    {
        string connectionString;
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;

        public BillDetails()
        {

            InitializeComponent();
            connectionString = "server=.;database = RestaurantManagement; Integrated Security = true;";
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = sqlConnection.CreateCommand();
        }

        private void BillDetails_Load(object sender, EventArgs e)
        {

        }
        public void LoadDetails(string billID)
        {
            string query = "SELECT * FROM BillDetails WHERE InvoiceID = " + billID;
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable("BillDetails");

            da.Fill(dt);

            dgvBillDetail.DataSource = dt;
            sqlConnection.Close();
        }
    }
}

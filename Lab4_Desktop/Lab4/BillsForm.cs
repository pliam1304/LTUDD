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

namespace Lab4
{
    public partial class BillsForm : Form
    {
        string connectionString;
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;

        public BillsForm()
        {
            InitializeComponent();
            connectionString = "server=.;database = RestaurantManagement; Integrated Security = true;";
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = sqlConnection.CreateCommand();
        }

        private void BillsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Bills WHERE CAST(CheckoutDate AS DATE) <= '" + dtpDenNgay.Value.ToString("yyyy-MM-dd") + "' AND CAST(CheckoutDate AS DATE) >= '" + dtpTuNgay.Value.ToString("yyyy-MM-dd") + "'";
            sqlCommand.CommandText = query;
            sqlConnection.Open();


            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable("Bills");

            da.Fill(dt);

            dgvBills.DataSource = dt;
            sqlConnection.Close();
        }

        private void dgvBills_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvBills_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BillDetails form = new BillDetails();
            DataGridViewRow row = dgvBills.SelectedRows[0];

            form.Show();
            form.LoadDetails(row.Cells["ID"].Value?.ToString());
        }
    }
}

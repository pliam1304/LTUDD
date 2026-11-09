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
namespace Lab5
{
    public partial class FoodForm : Form
    {
        private DataTable foodTable;
        string connectionString;
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;

        public FoodForm()
        {
            InitializeComponent();
            connectionString = "server=.;database=RestaurantManagement;Integrated Security=true;";
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = sqlConnection.CreateCommand();
        }

        private void FoodForm_Load(object sender, EventArgs e)
        {
            LoadCategory();
        }

        private void LoadCategory()
        {
            string query = "SELECT ID, Name FROM Category";
            sqlCommand.CommandText = query;

            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();

            sqlConnection.Open();
            da.Fill(dt);
            sqlConnection.Close();

            cbbCategory.DataSource = dt;

            cbbCategory.DisplayMember = "Name";
            cbbCategory.ValueMember = "ID";

        }

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCategory.SelectedIndex == -1) return;

            string query = "SELECT * FROM Food WHERE FoodCategoryID = @categoryId";
            sqlCommand.CommandText = query;

            if (!sqlCommand.Parameters.Contains("@CategoryId"))
            {
                sqlCommand.Parameters.Add("@categoryId", SqlDbType.Int);

            }

            if (cbbCategory.SelectedValue is DataRowView)
            {
                DataRowView dv = cbbCategory.SelectedValue as DataRowView;
                sqlCommand.Parameters["@categoryId"].Value = dv["ID"];
            }
            else
            {
                sqlCommand.Parameters["@categoryId"].Value = cbbCategory.SelectedValue;

            }


            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            foodTable = new DataTable();
            sqlConnection.Open();

            da.Fill(foodTable);
            sqlConnection.Close();

            dgvFoodList.DataSource = foodTable;
            lblQuantity.Text = foodTable.Rows.Count.ToString();
            lblCatName.Text = cbbCategory.Text;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void tsmCalculateQuantity_Click(object sender, EventArgs e)
        {
            string query = "SELECT @numSaleFood = sum(Quantity) FROM BillDetails WHERE FoodID = @foodId";

            if (dgvFoodList.SelectedRows.Count <= 0) return;

            sqlCommand.CommandText = query;
            DataGridViewRow row = dgvFoodList.SelectedRows[0];

            DataRowView rowView = row.DataBoundItem as DataRowView;

            if (!sqlCommand.Parameters.Contains("@numSaleFood"))
            {
                sqlCommand.Parameters.Add("@numSaleFood", SqlDbType.Int);
                sqlCommand.Parameters["@numSaleFood"].Direction = ParameterDirection.Output;

            }

            if (!sqlCommand.Parameters.Contains("@foodId"))
            {
                sqlCommand.Parameters.Add("@foodId", SqlDbType.Int);
                sqlCommand.Parameters["@foodId"].Value = rowView["ID"];
            }
            sqlConnection.Open();

            sqlCommand.ExecuteNonQuery();
            string result = sqlCommand.Parameters["@numSaleFood"].Value.ToString();
            MessageBox.Show($"Tổng số lượng món {rowView["Name"]} đã bán là {result} {rowView["Unit"]}");

            sqlConnection.Close();


            sqlCommand.Dispose();
        }

        private void tsmAddFood_Click(object sender, EventArgs e)
        {

        }

        private void tsmUpdateFood_Click(object sender, EventArgs e)
        {

        }
    }
}

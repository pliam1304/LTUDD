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
    public partial class Form1 : Form
    {
        string connectionString;
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        int currentCategoryID;
        public Form1()
        {
            InitializeComponent();

            connectionString = "server=.;database=RestaurantManagement; Integrated Security = true;";
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = sqlConnection.CreateCommand();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void LoadFood(int categoryID)
        {
            currentCategoryID = categoryID;
            sqlCommand.CommandText = "SELECT Name FROM Category where ID = " + categoryID;

            sqlConnection.Open();

            string catName = sqlCommand.ExecuteScalar().ToString();
            this.Text = "Danh sách các món ăn thuộc nhóm: " + catName;

            sqlCommand.CommandText = "SELECT * FROM Food WHERE FoodCategoryID = " + categoryID;

            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);

            DataTable dt = new DataTable("Food");
            da.Fill(dt);

            dgvFood.DataSource = dt;

            sqlConnection.Close();
            da.Dispose();
            dt.Dispose();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (dgvFood.SelectedRows.Count > 0)
            {

                string ids = "";
                foreach (DataGridViewRow row in dgvFood.SelectedRows)
                {
                    ids += row.Cells[0].Value + ",";
                }
                ids = ids.Substring(0, ids.Length - 1);

                sqlCommand.CommandText = "DELETE FROM Food WHERE ID IN (" + ids + ")";
                Console.WriteLine(connectionString);
                sqlConnection.Open();
                int numRowsEffected = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                if (numRowsEffected >= 1)
                {
                    LoadFood(currentCategoryID);
                    MessageBox.Show("Xóa thành công");
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại");
                }
            }
        }
    }
}

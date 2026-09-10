using System.Windows.Forms;

namespace QuanLySinhVien_ChuDe3
{
    public partial class frmTimKiem : Form
    {
        public string MSSV => txtMSSV.Text.Trim();
        public string Ten => txtTen.Text.Trim();
        public string Lop => txtLop.Text.Trim();

        public frmTimKiem()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MSSV) && string.IsNullOrWhiteSpace(Ten) && string.IsNullOrWhiteSpace(Lop))
            {
                MessageBox.Show("Vui lòng nhập ít nhất 1 điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDong_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

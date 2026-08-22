using System;
using System.Windows.Forms;

namespace BaiTapBuoi2_2411869
{
    public partial class FormThemNV : Form
    {
        // Ket qua tra ve cho Form1 sau khi nhan "Dong y"
        public NhanVien KetQua { get; private set; }

        public FormThemNV()
        {
            InitializeComponent();
            cboLoaiNV.SelectedIndex = 0; // mac dinh chon "Nhan vien hop dong"
            CapNhatGiaoDien();
        }

        // Hien/an cac o nhap tuong ung voi loai nhan vien dang chon
        private void cboLoaiNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatGiaoDien();
        }

        private void CapNhatGiaoDien()
        {
            bool laHopDong = cboLoaiNV.SelectedIndex == 0;

            lblHeSoLuong.Visible = laHopDong;
            txtHeSoLuong.Visible = laHopDong;

            lblSoGio.Visible = !laHopDong;
            txtSoGio.Visible = !laHopDong;
            lblTienCong.Visible = !laHopDong;
            txtTienCong.Visible = !laHopDong;
        }

        // Yeu cau 2: tao doi tuong NhanVien (NVHopDong hoac NVTheoGio) tu du lieu nhap
        private void btnOK_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();

            if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui long nhap day du Ma NV va Ho ten.", "Loi du lieu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboLoaiNV.SelectedIndex == 0)
            {
                float heSoLuong;
                if (!float.TryParse(txtHeSoLuong.Text.Trim(), out heSoLuong) || heSoLuong <= 0)
                {
                    MessageBox.Show("He so luong phai la so va lon hon 0.", "Loi du lieu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                KetQua = new NVHopDong(maNV, hoTen, heSoLuong);
            }
            else
            {
                int soGio;
                int tienCong;
                if (!int.TryParse(txtSoGio.Text.Trim(), out soGio) || soGio < 0)
                {
                    MessageBox.Show("So gio lam phai la so nguyen khong am.", "Loi du lieu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!int.TryParse(txtTienCong.Text.Trim(), out tienCong) || tienCong <= 0)
                {
                    MessageBox.Show("Tien cong 1 gio phai la so nguyen lon hon 0.", "Loi du lieu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                KetQua = new NVTheoGio(maNV, hoTen, soGio, tienCong);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            KetQua = null;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapBuoi2_2411869
{
    public partial class Form1 : Form
    {
        // Danh sach nhan vien dung chung cho toan bo form
        private DsNhanVien ds = new DsNhanVien();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Co the nhap san du lieu co dinh ngay khi mo form (khong bat buoc)
            // ds.NhapCoDinh();
            // LoadDataToGrid(ds);
        }

        // Ham dung chung: do du lieu tu 1 DsNhanVien len DataGridView
        // (khong bind truc tiep vi can gop thong tin rieng cua tung loai NV)
        private void LoadDataToGrid(DsNhanVien danhSach)
        {
            dgvNhanVien.Rows.Clear();
            dgvNhanVien.Columns.Clear();
            dgvNhanVien.Columns.Add("MaNV", "Ma NV");
            dgvNhanVien.Columns.Add("HoTen", "Ho ten");
            dgvNhanVien.Columns.Add("Loai", "Loai NV");
            dgvNhanVien.Columns.Add("ThongTinThem", "He so / So gio - Tien cong");
            dgvNhanVien.Columns.Add("Luong", "Luong thang");
            dgvNhanVien.Columns["Luong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            for (int i = 0; i < danhSach.Count; i++)
            {
                NhanVien nv = danhSach.GetAt(i);
                string loai = "";
                string thongTinThem = "";

                NVHopDong hd = nv as NVHopDong;
                NVTheoGio tg = nv as NVTheoGio;

                if (hd != null)
                {
                    loai = "Hop dong";
                    thongTinThem = "He so: " + hd.SalaryCoefficient;
                }
                else if (tg != null)
                {
                    loai = "Theo gio";
                    thongTinThem = tg.HoursWorkedInMonth + " gio x " + tg.PayPerHour.ToString("N0") + " d/gio";
                }

                dgvNhanVien.Rows.Add(
                    nv.EmployeeId,
                    nv.FullName,
                    loai,
                    thongTinThem,
                    nv.TinhLuongThang().ToString("N0") + " d"
                );
            }
        }

        // Yeu cau 3 + 4: nhap danh sach co dinh roi hien thi len luoi
        private void btnNhapCoDinh_Click(object sender, EventArgs e)
        {
            ds = new DsNhanVien();
            ds.NhapCoDinh();
            LoadDataToGrid(ds);
        }

        // Yeu cau 4: xuat lai toan bo danh sach hien co
        private void btnXuatTatCa_Click(object sender, EventArgs e)
        {
            LoadDataToGrid(ds);
        }

        // Yeu cau 5: tim nhan vien theo ten nhap tu TextBox
        private void btnTimTheoTen_Click(object sender, EventArgs e)
        {
            string ten = txtTimTen.Text.Trim();
            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Vui long nhap ten can tim.", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DsNhanVien ketQua = ds.TimNVTheoTen(ten);
            if (ketQua.Count == 0)
            {
                MessageBox.Show("Khong tim thay nhan vien nao co ten nay.", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadDataToGrid(ketQua);
        }

        // Yeu cau 6: hien thi nhan vien (theo gio) lam nhieu gio nhat
        private void btnLamNhieuGioNhat_Click(object sender, EventArgs e)
        {
            DsNhanVien ketQua = ds.TimNVLamNhieuGioNhat();
            if (ketQua.Count == 0)
            {
                MessageBox.Show("Chua co nhan vien theo gio nao trong danh sach.", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadDataToGrid(ketQua);
        }

        // Yeu cau 7: hien thi DS nhan vien hop dong da sap xep theo luong
        private void btnSapXepLuong_Click(object sender, EventArgs e)
        {
            DsNhanVien ketQua = ds.LayDSHDTGSapXepTangTheoLuong();
            LoadDataToGrid(ketQua);
        }

        // Yeu cau 2: mo Form phu FormThemNV de nhap day du thong tin
        // nhan vien moi (hop dong hoac theo gio), sau do them vao DsNhanVien
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            using (FormThemNV f = new FormThemNV())
            {
                if (f.ShowDialog(this) == DialogResult.OK && f.KetQua != null)
                {
                    ds.ThemNV(f.KetQua);
                    LoadDataToGrid(ds);
                    MessageBox.Show("Them nhan vien thanh cong!", "Thong bao",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}

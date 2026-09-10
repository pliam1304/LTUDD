using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace QuanLySinhVien_ChuDe3
{
    public partial class frmSinhVien : Form
    {
        private readonly QuanLySinhVien qlsv = new QuanLySinhVien();
        private const string TEN_FILE_MAC_DINH = "students.txt";

        public frmSinhVien()
        {
            InitializeComponent();
        }

        #region Nạp / hiển thị dữ liệu

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            if (cboLop.Items.Count > 0)
                cboLop.SelectedIndex = 0;

            // Yêu cầu: "Khi chạy chương trình danh sách sinh viên sẽ được tải từ tập tin."
            string duongDan = TEN_FILE_MAC_DINH;
            if (!File.Exists(duongDan))
                duongDan = Path.Combine(Application.StartupPath, TEN_FILE_MAC_DINH);

            if (File.Exists(duongDan))
            {
                qlsv.TaiTuFile(duongDan);
            }
            else
            {
                // Không có sẵn tập tin -> tạo tập tin văn bản rỗng để chương trình có nơi lưu
                qlsv.LuuFile(duongDan);
            }

            HienThi(qlsv.DanhSach);
            CapNhatStatusStrip();
        }

        private void HienThi(List<SinhVien> ds)
        {
            lvSinhVien.Items.Clear();
            foreach (SinhVien sv in ds)
            {
                ListViewItem item = new ListViewItem(sv.MSSV);
                item.SubItems.Add(sv.HoTen);
                item.SubItems.Add(sv.Lop);
                item.SubItems.Add(sv.CMND);
                item.SubItems.Add(sv.SDT);
                item.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(sv.GioiTinh ? "Nam" : "Nữ");
                item.SubItems.Add(sv.DiaChi);
                item.SubItems.Add(string.Join(", ", sv.MonDangKy));
                item.Tag = sv;
                lvSinhVien.Items.Add(item);
            }
            CapNhatStatusStrip();
        }

        private void CapNhatStatusStrip()
        {
            tsslTongSV.Text = "Tổng số sinh viên: " + qlsv.DanhSach.Count;
            tsslFile.Text = string.IsNullOrEmpty(qlsv.DuongDanHienTai)
                ? "Chưa mở tập tin"
                : $"Tập tin đang làm việc: {qlsv.DuongDanHienTai}  ({qlsv.LoaiFileHienTai})";
        }

        #endregion

        #region Lấy / gán thông tin lên control

        private SinhVien LaySinhVienTuForm()
        {
            List<string> monDaChon = new List<string>();
            foreach (var item in clbMonDangKy.Items)
                monDaChon.Add(item?.ToString() ?? "");

            return new SinhVien(
                mtxtMSSV.Text.Trim(),
                txtHoTen.Text.Trim(),
                cboLop.Text,
                mtxtCMND.Text.Trim(),
                mtxtSDT.Text.Trim(),
                txtDiaChi.Text.Trim(),
                dtpNgaySinh.Value,
                rdNam.Checked,
                monDaChon
            );
            // Lưu ý: ở đây lưu toàn bộ danh sách môn hiển thị trên CheckedListBox làm
            // "môn đăng ký" cho đơn giản hoá phần thao tác chọn môn; có thể đổi thành
            // clbMonDangKy.CheckedItems nếu muốn chỉ lưu các môn được tích chọn.
        }

        private void GanSinhVienLenForm(SinhVien sv)
        {
            mtxtMSSV.Text = sv.MSSV;
            txtHoTen.Text = sv.HoTen;
            cboLop.Text = sv.Lop;
            mtxtCMND.Text = sv.CMND;
            mtxtSDT.Text = sv.SDT;
            txtDiaChi.Text = sv.DiaChi;
            dtpNgaySinh.Value = sv.NgaySinh;
            rdNam.Checked = sv.GioiTinh;
            rdNu.Checked = !sv.GioiTinh;

            clbMonDangKy.Items.Clear();
            foreach (string mon in sv.MonDangKy)
                clbMonDangKy.Items.Add(mon, true);
        }

        private void ResetControls()
        {
            mtxtMSSV.Text = "";
            txtHoTen.Text = "";
            if (cboLop.Items.Count > 0) cboLop.SelectedIndex = 0;
            mtxtCMND.Text = "";
            mtxtSDT.Text = "";
            txtDiaChi.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            rdNam.Checked = true;
            clbMonDangKy.Items.Clear();
        }

        /// <summary>
        /// Yêu cầu: "Người dùng phải nhập hết thông tin rồi mới cho phép thêm mới
        /// hoặc cập nhật. Nếu chưa nhập đầy đủ thì cần thông báo."
        /// </summary>
        private bool KiemTraDuThongTin(out string thongBao)
        {
            thongBao = "";
            if (string.IsNullOrWhiteSpace(mtxtMSSV.Text) ||
                string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(cboLop.Text) ||
                string.IsNullOrWhiteSpace(mtxtCMND.Text) ||
                string.IsNullOrWhiteSpace(mtxtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                thongBao = "Vui lòng nhập đầy đủ thông tin sinh viên trước khi Thêm / Cập nhật!";
                return false;
            }

            if (!SinhVien.KiemTraDinhDangMSSV(mtxtMSSV.Text.Trim(), cboLop.Text, out string loiMssv))
            {
                thongBao = loiMssv;
                return false;
            }

            if (mtxtCMND.Text.Trim().Length != 9 || !SinhVien.IsAllDigit(mtxtCMND.Text.Trim()))
            {
                thongBao = "Số CMND phải gồm đúng 9 chữ số!";
                return false;
            }

            if (mtxtSDT.Text.Trim().Length != 10 || !SinhVien.IsAllDigit(mtxtSDT.Text.Trim()))
            {
                thongBao = "Số điện thoại phải gồm đúng 10 chữ số!";
                return false;
            }

            return true;
        }

        #endregion

        #region Sự kiện: Thêm / Cập nhật / Xóa / Mặc định / Thoát

        private void btnThemCapNhat_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuThongTin(out string loi))
            {
                MessageBox.Show(loi, "Thiếu / sai thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SinhVien sv = LaySinhVienTuForm();

            if (qlsv.TonTaiMSSV(sv.MSSV))
            {
                qlsv.CapNhat(sv);
                MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                qlsv.Them(sv);
                MessageBox.Show("Thêm sinh viên mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            HienThi(qlsv.DanhSach);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên đã chọn?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            string mssv = lvSinhVien.SelectedItems[0].SubItems[0].Text;
            qlsv.Xoa(mssv);
            HienThi(qlsv.DanhSach);
            ResetControls();
        }

        // Yêu cầu: cho phép chọn nhiều sinh viên bằng Checkbox trên ListView,
        // nhấp chuột phải mở ContextMenu để xóa 1 hoặc nhiều sinh viên đã chọn.
        private void cmsDanhSachXoa_Click(object sender, EventArgs e)
        {
            if (lvSinhVien.CheckedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng tích chọn (checkbox) sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Xóa {lvSinhVien.CheckedItems.Count} sinh viên đã chọn?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            List<string> dsMSSV = new List<string>();
            foreach (ListViewItem item in lvSinhVien.CheckedItems)
                dsMSSV.Add(item.SubItems[0].Text);

            qlsv.XoaNhieu(dsMSSV);
            HienThi(qlsv.DanhSach);
            ResetControls();
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Yêu cầu: "Khi người dùng nhấn nút Thoát phải hỏi lại người dùng có chắc
        // chắn muốn thoát chương trình hay không." Đặt ở FormClosing để bắt luôn cả
        // trường hợp bấm nút [X] trên tiêu đề cửa sổ.
        private void frmSinhVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?",
                "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlg != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region Sự kiện: chọn sinh viên trên danh sách

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count > 0 && lvSinhVien.SelectedItems[0].Tag is SinhVien sv)
            {
                GanSinhVienLenForm(sv);
            }
        }

        #endregion

        #region Sự kiện: Môn đăng ký (ContextMenu thêm / xóa môn)

        private void cmsMonThem_Click(object sender, EventArgs e)
        {
            using frmThemMon frm = new frmThemMon();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (!clbMonDangKy.Items.Contains(frm.TenMon))
                    clbMonDangKy.Items.Add(frm.TenMon, true);
                else
                    MessageBox.Show("Môn học này đã có trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmsMonXoa_Click(object sender, EventArgs e)
        {
            if (clbMonDangKy.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn môn học cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            clbMonDangKy.Items.Remove(clbMonDangKy.SelectedItem);
        }

        #endregion

        #region Sự kiện: Tìm kiếm

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using frmTimKiem frm = new frmTimKiem();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                List<SinhVien> ketQua = qlsv.TimKiem(frm.MSSV, frm.Ten, frm.Lop);
                HienThi(ketQua);

                if (ketQua.Count == 0)
                    MessageBox.Show("Không tìm thấy sinh viên thỏa điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            HienThi(qlsv.DanhSach);
        }

        #endregion

        #region Sự kiện: Menu Tập tin (Mở / Lưu thành - Txt / Xml / Json)

        private void MoTapTin(string filter, string defaultExt)
        {
            using OpenFileDialog ofd = new OpenFileDialog { Filter = filter, DefaultExt = defaultExt };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                qlsv.TaiTuFile(ofd.FileName);
                HienThi(qlsv.DanhSach);
                ResetControls();
            }
        }

        private void LuuThanhTapTin(string filter, string defaultExt)
        {
            using SaveFileDialog sfd = new SaveFileDialog { Filter = filter, DefaultExt = defaultExt };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                qlsv.LuuFile(sfd.FileName);
                CapNhatStatusStrip();
                MessageBox.Show("Lưu tập tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsmiMoTxt_Click(object sender, EventArgs e) => MoTapTin("Text Files (*.txt)|*.txt", "txt");
        private void tsmiMoXml_Click(object sender, EventArgs e) => MoTapTin("XML Files (*.xml)|*.xml", "xml");
        private void tsmiMoJson_Click(object sender, EventArgs e) => MoTapTin("JSON Files (*.json)|*.json", "json");

        private void tsmiLuuThanhTxt_Click(object sender, EventArgs e) => LuuThanhTapTin("Text Files (*.txt)|*.txt", "txt");
        private void tsmiLuuThanhXml_Click(object sender, EventArgs e) => LuuThanhTapTin("XML Files (*.xml)|*.xml", "xml");
        private void tsmiLuuThanhJson_Click(object sender, EventArgs e) => LuuThanhTapTin("JSON Files (*.json)|*.json", "json");

        #endregion
    }
}

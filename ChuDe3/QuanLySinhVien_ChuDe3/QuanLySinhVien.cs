using System;
using System.Collections.Generic;

namespace QuanLySinhVien_ChuDe3
{
    /// <summary>
    /// Lớp StudentManager (QuanLySinhVien): quản lý danh sách sinh viên
    /// trong bộ nhớ và đồng bộ với tập tin (txt/xml/json) thông qua ISinhVienIO.
    /// </summary>
    public class QuanLySinhVien
    {
        public List<SinhVien> DanhSach { get; private set; }

        private string duongDanFile = "";
        private LoaiTapTin loaiFile = LoaiTapTin.Txt;

        public QuanLySinhVien()
        {
            DanhSach = new List<SinhVien>();
        }

        public string DuongDanHienTai => duongDanFile;
        public LoaiTapTin LoaiFileHienTai => loaiFile;

        /// <summary>Nạp danh sách sinh viên từ tập tin (txt/xml/json tùy đuôi file).</summary>
        public void TaiTuFile(string duongDan)
        {
            duongDanFile = duongDan;
            loaiFile = SinhVienIOFactory.TuDuoiFile(duongDan);
            ISinhVienIO io = SinhVienIOFactory.TaoDoiTuong(loaiFile);
            DanhSach = io.Doc(duongDan);
        }

        /// <summary>Lưu danh sách sinh viên hiện tại xuống tập tin đang làm việc.</summary>
        public void LuuFile()
        {
            if (string.IsNullOrEmpty(duongDanFile)) return;
            ISinhVienIO io = SinhVienIOFactory.TaoDoiTuong(loaiFile);
            io.Ghi(duongDanFile, DanhSach);
        }

        public void LuuFile(string duongDan)
        {
            duongDanFile = duongDan;
            loaiFile = SinhVienIOFactory.TuDuoiFile(duongDan);
            LuuFile();
        }

        public bool TonTaiMSSV(string mssv)
        {
            return DanhSach.Exists(sv => sv.MSSV.Equals(mssv, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>Thêm sinh viên mới. Trả về false nếu MSSV đã tồn tại.</summary>
        public bool Them(SinhVien sv)
        {
            if (TonTaiMSSV(sv.MSSV)) return false;
            DanhSach.Add(sv);
            LuuFile();
            return true;
        }

        /// <summary>Cập nhật thông tin sinh viên theo MSSV. Trả về false nếu không tìm thấy.</summary>
        public bool CapNhat(SinhVien sv)
        {
            SinhVien? existing = DanhSach.Find(x => x.MSSV.Equals(sv.MSSV, StringComparison.OrdinalIgnoreCase));
            if (existing == null) return false;

            existing.HoTen = sv.HoTen;
            existing.Lop = sv.Lop;
            existing.CMND = sv.CMND;
            existing.SDT = sv.SDT;
            existing.DiaChi = sv.DiaChi;
            existing.NgaySinh = sv.NgaySinh;
            existing.GioiTinh = sv.GioiTinh;
            existing.MonDangKy = sv.MonDangKy;

            LuuFile();
            return true;
        }

        /// <summary>Xóa 1 sinh viên theo MSSV.</summary>
        public bool Xoa(string mssv)
        {
            int soLuong = DanhSach.RemoveAll(sv => sv.MSSV.Equals(mssv, StringComparison.OrdinalIgnoreCase));
            if (soLuong > 0)
            {
                LuuFile();
                return true;
            }
            return false;
        }

        /// <summary>Xóa nhiều sinh viên cùng lúc theo danh sách MSSV.</summary>
        public int XoaNhieu(IEnumerable<string> dsMSSV)
        {
            HashSet<string> tap = new HashSet<string>(dsMSSV, StringComparer.OrdinalIgnoreCase);
            int soLuong = DanhSach.RemoveAll(sv => tap.Contains(sv.MSSV));
            if (soLuong > 0) LuuFile();
            return soLuong;
        }

        /// <summary>
        /// Tìm kiếm sinh viên theo một hoặc nhiều điều kiện (MSSV/Tên/Lớp).
        /// Điều kiện nào để trống sẽ được bỏ qua (kết hợp AND các điều kiện có nhập).
        /// </summary>
        public List<SinhVien> TimKiem(string? mssv, string? ten, string? lop)
        {
            List<SinhVien> ketQua = new List<SinhVien>();
            foreach (SinhVien sv in DanhSach)
            {
                bool hopLe = true;

                if (!string.IsNullOrWhiteSpace(mssv) &&
                    sv.MSSV.IndexOf(mssv, StringComparison.OrdinalIgnoreCase) < 0)
                    hopLe = false;

                if (hopLe && !string.IsNullOrWhiteSpace(ten) &&
                    sv.HoTen.IndexOf(ten, StringComparison.OrdinalIgnoreCase) < 0)
                    hopLe = false;

                if (hopLe && !string.IsNullOrWhiteSpace(lop) &&
                    sv.Lop.IndexOf(lop, StringComparison.OrdinalIgnoreCase) < 0)
                    hopLe = false;

                if (hopLe) ketQua.Add(sv);
            }
            return ketQua;
        }
    }
}

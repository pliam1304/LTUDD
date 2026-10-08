using System;
using System.Collections.Generic;
using System.IO;

namespace QuanLySinhVien_ChuDe3
{
    /// <summary>
    /// Danh mục TOÀN BỘ các môn học có thể đăng ký (độc lập với từng sinh viên).
    /// - Danh mục luôn hiển thị đầy đủ trên CheckedListBox.
    /// - Mỗi sinh viên chỉ lưu danh sách tên các môn đã đăng ký (SinhVien.MonDangKy);
    ///   khi chọn sinh viên, form chỉ việc tích / bỏ tích các môn tương ứng.
    /// - Danh mục được lưu trong monhoc.txt (mỗi dòng 1 môn) để việc thêm / xóa môn
    ///   bằng ContextMenu không bị mất khi mở lại chương trình.
    /// </summary>
    public class DanhMucMonHoc
    {
        /// <summary>8 môn theo giao diện mẫu ở trang 58 của tài liệu.</summary>
        public static readonly string[] MonMacDinh =
        {
            "Mạng máy tính",
            "Hệ điều hành",
            "Lập trình CSDL",
            "Lập trình mạng",
            "Đồ án cơ sở",
            "Phương pháp NCKH",
            "Lập trình trên thiết bị di động",
            "An toàn và bảo mật hệ thống"
        };

        private readonly List<string> ds = new List<string>();
        private readonly string duongDan;

        public DanhMucMonHoc(string duongDan)
        {
            this.duongDan = duongDan;
        }

        public IReadOnlyList<string> DanhSach => ds;

        /// <summary>
        /// Nạp danh mục: nếu đã có monhoc.txt thì dùng đúng nội dung file đó
        /// (để môn đã xóa không tự "sống lại"); nếu chưa có thì dùng 8 môn mặc định.
        /// </summary>
        public void Nap()
        {
            ds.Clear();
            if (File.Exists(duongDan))
            {
                foreach (string dong in File.ReadAllLines(duongDan))
                    ThemKhongLuu(dong);
            }
            else
            {
                foreach (string mon in MonMacDinh)
                    ThemKhongLuu(mon);
            }
        }

        public bool TonTai(string tenMon)
        {
            string ten = tenMon.Trim();
            return ds.Exists(m => string.Equals(m, ten, StringComparison.OrdinalIgnoreCase));
        }

        private bool ThemKhongLuu(string? tenMon)
        {
            if (string.IsNullOrWhiteSpace(tenMon)) return false;
            string ten = tenMon.Trim();
            if (TonTai(ten)) return false;
            ds.Add(ten);
            return true;
        }

        /// <summary>Thêm môn mới vào danh mục. Trả về false nếu môn đã có.</summary>
        public bool Them(string tenMon)
        {
            if (!ThemKhongLuu(tenMon)) return false;
            Luu();
            return true;
        }

        /// <summary>Xóa môn khỏi danh mục. Trả về false nếu không có môn này.</summary>
        public bool Xoa(string tenMon)
        {
            string ten = tenMon.Trim();
            int n = ds.RemoveAll(m => string.Equals(m, ten, StringComparison.OrdinalIgnoreCase));
            if (n == 0) return false;
            Luu();
            return true;
        }

        /// <summary>
        /// Bổ sung vào danh mục những môn mà sinh viên đã đăng ký nhưng chưa có trong
        /// danh mục (ví dụ khi mở một tập tin sinh viên khác) để không có môn nào bị "mất".
        /// </summary>
        public bool GopTuSinhVien(IEnumerable<SinhVien> dsSinhVien)
        {
            bool thayDoi = false;
            foreach (SinhVien sv in dsSinhVien)
                foreach (string mon in sv.MonDangKy)
                    if (ThemKhongLuu(mon)) thayDoi = true;

            if (thayDoi) Luu();
            return thayDoi;
        }

        public void Luu()
        {
            try
            {
                File.WriteAllLines(duongDan, ds);
            }
            catch (IOException) { /* không ghi được thì danh mục vẫn dùng bình thường trong phiên làm việc */ }
            catch (UnauthorizedAccessException) { }
        }
    }
}

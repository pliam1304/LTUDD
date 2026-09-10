using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace QuanLySinhVien_ChuDe3
{
    /// <summary>
    /// Đọc/ghi danh sách sinh viên dạng tập tin văn bản (students.txt).
    /// Mỗi dòng là 1 sinh viên, các trường phân tách bằng Tab,
    /// riêng danh sách môn đăng ký phân tách bằng dấu phẩy.
    /// </summary>
    public class SinhVienTxtIO : ISinhVienIO
    {
        public List<SinhVien> Doc(string duongDan)
        {
            List<SinhVien> ds = new List<SinhVien>();
            if (!File.Exists(duongDan)) return ds;

            foreach (string dong in File.ReadAllLines(duongDan))
            {
                if (string.IsNullOrWhiteSpace(dong)) continue;
                string[] s = dong.Split('\t');
                if (s.Length < 8) continue;

                SinhVien sv = new SinhVien
                {
                    MSSV = s[0],
                    HoTen = s[1],
                    Lop = s[2],
                    CMND = s[3],
                    SDT = s[4],
                    DiaChi = s[5],
                    GioiTinh = s[6] == "Nam"
                };

                if (DateTime.TryParseExact(s[7], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ns))
                    sv.NgaySinh = ns;

                if (s.Length >= 9 && !string.IsNullOrWhiteSpace(s[8]))
                    sv.MonDangKy = new List<string>(s[8].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries));

                ds.Add(sv);
            }
            return ds;
        }

        public void Ghi(string duongDan, List<SinhVien> danhSach)
        {
            List<string> lines = new List<string>();
            foreach (SinhVien sv in danhSach)
            {
                string mon = string.Join(",", sv.MonDangKy);
                lines.Add(string.Join("\t",
                    sv.MSSV, sv.HoTen, sv.Lop, sv.CMND, sv.SDT, sv.DiaChi,
                    sv.GioiTinh ? "Nam" : "Nữ", sv.NgaySinh.ToString("dd/MM/yyyy"), mon));
            }
            File.WriteAllLines(duongDan, lines);
        }
    }
}

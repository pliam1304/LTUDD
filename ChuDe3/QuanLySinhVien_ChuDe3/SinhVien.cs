using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace QuanLySinhVien_ChuDe3
{
    /// <summary>
    /// Lớp Student (SinhVien): mô hình dữ liệu dùng chung cho cả 3 định dạng
    /// tập tin (txt / xml / json). Vì XmlSerializer yêu cầu constructor không
    /// tham số và các property public có get/set nên lớp được thiết kế theo
    /// đúng ràng buộc đó.
    /// </summary>
    [Serializable]
    public class SinhVien
    {
        public string MSSV { get; set; } = "";
        public string HoTen { get; set; } = "";
        public string Lop { get; set; } = "";
        public string CMND { get; set; } = "";
        public string SDT { get; set; } = "";
        public string DiaChi { get; set; } = "";
        public DateTime NgaySinh { get; set; } = DateTime.Now;
        public bool GioiTinh { get; set; } = true; // true = Nam, false = Nữ

        // Danh sách môn học sinh viên đăng ký
        [XmlArray("MonDangKy")]
        [XmlArrayItem("Mon")]
        public List<string> MonDangKy { get; set; } = new List<string>();

        public SinhVien() { }

        public SinhVien(string mssv, string hoTen, string lop, string cmnd, string sdt,
                         string diaChi, DateTime ngaySinh, bool gioiTinh, List<string> monDangKy)
        {
            MSSV = mssv;
            HoTen = hoTen;
            Lop = lop;
            CMND = cmnd;
            SDT = sdt;
            DiaChi = diaChi;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            MonDangKy = monDangKy ?? new List<string>();
        }

        /// <summary>
        /// Kiểm tra định dạng MSSV theo yêu cầu bài tập 3:
        /// AABBCCC - AA: 2 số cuối năm nhập học (suy ra từ Lớp),
        /// BB = "10" (mã khoa CNTT), CCC: số thứ tự bất kỳ.
        /// </summary>
        public static bool KiemTraDinhDangMSSV(string mssv, string lop, out string loiMoTa)
        {
            loiMoTa = "";
            if (string.IsNullOrWhiteSpace(mssv) || mssv.Length != 7 || !IsAllDigit(mssv))
            {
                loiMoTa = "MSSV phải gồm đúng 7 chữ số!";
                return false;
            }

            string namNhapHoc = LayNamTuLop(lop);
            if (string.IsNullOrEmpty(namNhapHoc))
            {
                loiMoTa = "Không xác định được năm nhập học từ Lớp!";
                return false;
            }

            string aa = mssv.Substring(0, 2);
            string bb = mssv.Substring(2, 2);

            if (aa != namNhapHoc)
            {
                loiMoTa = $"2 số đầu MSSV phải là '{namNhapHoc}' (năm nhập học theo lớp {lop})!";
                return false;
            }
            if (bb != "10")
            {
                loiMoTa = "2 số tiếp theo của MSSV phải là '10' (mã khoa CNTT)!";
                return false;
            }
            return true;
        }

        // Lớp có dạng "K21", "K22"... -> năm nhập học lấy 2 số sau ký tự K
        public static string LayNamTuLop(string lop)
        {
            if (string.IsNullOrWhiteSpace(lop)) return "";
            string digits = new string(Array.FindAll(lop.ToCharArray(), char.IsDigit));
            if (digits.Length >= 2) return digits.Substring(digits.Length - 2, 2);
            return "";
        }

        public static bool IsAllDigit(string s)
        {
            foreach (char c in s)
                if (!char.IsDigit(c)) return false;
            return true;
        }

        public override string ToString()
        {
            return $"{MSSV}\t{HoTen}\t{Lop}";
        }
    }
}

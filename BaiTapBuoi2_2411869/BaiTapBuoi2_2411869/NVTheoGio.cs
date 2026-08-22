using System;

namespace BaiTapBuoi2_2411869
{
    // ================= Yêu cầu 1 =================
    // Lớp NVTheoGio: nhân viên làm việc theo giờ, kế thừa từ NhanVien
    public class NVTheoGio : NhanVien
    {
        // ---- Properties ----
        public int HoursWorkedInMonth { get; set; } // tương ứng SoGioLNTrongThang
        public int PayPerHour { get; set; }          // tương ứng TienCong1Gio

        // ---- Constructor ----
        public NVTheoGio(string maNV, string hoTen, int soGio, int tienCong)
            : base(maNV, hoTen)
        {
            HoursWorkedInMonth = soGio;
            PayPerHour = tienCong;
        }

        // Yêu cầu 1: Lương theo giờ = số giờ làm việc * tiền công mỗi giờ
        public override int TinhLuongThang()
        {
            return HoursWorkedInMonth * PayPerHour;
        }

        // Yêu cầu 1: Xuất thông tin nhân viên theo giờ
        public override void XuatThongTin()
        {
            Console.WriteLine(
                "[NV Theo Gio] Ma NV: " + EmployeeId + " Ho ten: " + FullName +
                " So gio lam: " + HoursWorkedInMonth + " Tien cong/gio: " + PayPerHour.ToString("N0") +
                " Luong thang: " + TinhLuongThang().ToString("N0") + " d");
        }
    }
}

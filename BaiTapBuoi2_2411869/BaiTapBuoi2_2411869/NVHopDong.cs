using System;

namespace BaiTapBuoi2_2411869
{
    // ================= Yêu cầu 1 =================
    // Lớp NVHopDong: nhân viên hợp đồng, kế thừa từ NhanVien
    public class NVHopDong : NhanVien
    {
        // Lương cơ bản cố định = 1.800.000 đồng (theo đề bài)
        private const int LUONG_CO_BAN = 1800000;

        // ---- Properties ----
        public float SalaryCoefficient { get; set; } // tương ứng HeSoLuong

        // ---- Constructor ----
        public NVHopDong(string maNV, string hoTen, float heSoLuong)
            : base(maNV, hoTen)
        {
            SalaryCoefficient = heSoLuong;
        }

        // Yêu cầu 1: Lương HĐ = hệ số lương * lương cơ bản
        public override int TinhLuongThang()
        {
            return (int)(SalaryCoefficient * LUONG_CO_BAN);
        }

        // Yêu cầu 1: Xuất thông tin nhân viên hợp đồng
        public override void XuatThongTin()
        {
            Console.WriteLine(
                "[NV Hop Dong] Ma NV: " + EmployeeId + " Ho ten: " + FullName +
                " He so luong: " + SalaryCoefficient + " Luong thang: " + TinhLuongThang().ToString("N0") + " d");
        }
    }
}

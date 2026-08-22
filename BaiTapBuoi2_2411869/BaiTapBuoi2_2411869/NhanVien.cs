using System;

namespace BaiTapBuoi2_2411869
{
    // ================= Yêu cầu 1 =================
    // Lớp trừu tượng (Abstract Class) NhanVien: lớp cha chung cho
    // NVHopDong và NVTheoGio. Cài đặt interface ITinhLuong.
    public abstract class NhanVien : ITinhLuong
    {
        // ---- Properties (biến đặt tên tiếng Anh) ----
        public string EmployeeId { get; set; }   // tương ứng MaNV
        public string FullName { get; set; }     // tương ứng HoTen

        // ---- Constructor ----
        public NhanVien(string maNV, string hoTen)
        {
            EmployeeId = maNV;
            FullName = hoTen;
        }

        // Phương thức trừu tượng: mỗi loại nhân viên tự cài đặt công thức lương riêng
        public abstract int TinhLuongThang();

        // Phương thức trừu tượng: mỗi loại nhân viên tự cài đặt cách xuất thông tin riêng
        public abstract void XuatThongTin();
    }
}

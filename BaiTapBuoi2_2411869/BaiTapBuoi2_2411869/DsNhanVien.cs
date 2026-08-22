using System;
using System.Collections.Generic;

namespace BaiTapBuoi2_2411869
{
    // ================= Yêu cầu 2 =================
    // Lớp DsNhanVien: quản lý danh sách nhân viên (chứa cả NVHopDong và NVTheoGio)
    public class DsNhanVien
    {
        // ---- Fields ----
        private List<NhanVien> employeeList; // tương ứng dsNhanVien : List<NhanVien>

        // ---- Constructor ----
        public DsNhanVien()
        {
            employeeList = new List<NhanVien>();
        }

        // Cho phép truy cập số lượng nhân viên hiện có (tiện dùng ở WinForm)
        public int Count
        {
            get { return employeeList.Count; }
        }

        // Cho phép lấy 1 nhân viên theo chỉ số (tiện dùng ở WinForm)
        public NhanVien GetAt(int index)
        {
            return employeeList[index];
        }

        // ================= Yêu cầu 2 =================
        // Thêm một nhân viên bất kỳ (NVHopDong hoặc NVTheoGio) vào danh sách
        public void ThemNV(NhanVien nv)
        {
            employeeList.Add(nv);
        }

        // ================= Yêu cầu 3 =================
        // Nhập danh sách cố định gồm 2 nhân viên hợp đồng và 2 nhân viên theo giờ
        public void NhapCoDinh()
        {
            employeeList.Add(new NVHopDong("HD01", "Nguyen Van A", 3.5f));
            employeeList.Add(new NVHopDong("HD02", "Tran Thi B", 4.0f));
            employeeList.Add(new NVTheoGio("TG01", "Le Van C", 160, 50000));
            employeeList.Add(new NVTheoGio("TG02", "Pham Thi D", 180, 45000));
        }

        // ================= Yêu cầu 4 =================
        // Xuất toàn bộ danh sách nhân viên ra màn hình
        public void XuatDanhSach()
        {
            if (employeeList.Count == 0)
            {
                Console.WriteLine("Danh sach rong.");
                return;
            }
            foreach (NhanVien nv in employeeList)
            {
                nv.XuatThongTin();
            }
        }

        // ================= Yêu cầu 5 =================
        // Tìm nhân viên theo tên
        // LƯU Ý: không dùng LINQ, không dùng phương thức có sẵn của List
        public DsNhanVien TimNVTheoTen(string ten)
        {
            DsNhanVien result = new DsNhanVien();
            for (int i = 0; i < employeeList.Count; i++)
            {
                if (string.Equals(employeeList[i].FullName, ten, StringComparison.OrdinalIgnoreCase))
                {
                    result.ThemNV(employeeList[i]);
                }
            }
            return result;
        }

        // ================= Yêu cầu 6 =================
        // Tìm (các) nhân viên theo giờ làm nhiều giờ nhất trong danh sách
        // LƯU Ý: không dùng LINQ, không dùng phương thức có sẵn của List
        public DsNhanVien TimNVLamNhieuGioNhat()
        {
            DsNhanVien result = new DsNhanVien();
            int maxHours = -1;

            for (int i = 0; i < employeeList.Count; i++)
            {
                NVTheoGio nvTheoGio = employeeList[i] as NVTheoGio;
                if (nvTheoGio != null && nvTheoGio.HoursWorkedInMonth > maxHours)
                {
                    maxHours = nvTheoGio.HoursWorkedInMonth;
                }
            }

            for (int i = 0; i < employeeList.Count; i++)
            {
                NVTheoGio nvTheoGio2 = employeeList[i] as NVTheoGio;
                if (nvTheoGio2 != null && nvTheoGio2.HoursWorkedInMonth == maxHours)
                {
                    result.ThemNV(employeeList[i]);
                }
            }

            return result;
        }

        // ================= Yêu cầu 7 =================
        // Lấy danh sách nhân viên hợp đồng và sắp xếp GIẢM DẦN theo lương
        // LƯU Ý: không dùng LINQ, không dùng phương thức có sẵn của List (Sort, OrderBy,...)
        // -> tự cài đặt thuật toán Bubble Sort thủ công
        public DsNhanVien LayDSHDTGSapXepTangTheoLuong()
        {
            DsNhanVien result = new DsNhanVien();

            for (int i = 0; i < employeeList.Count; i++)
            {
                if (employeeList[i] is NVHopDong)
                {
                    result.ThemNV(employeeList[i]);
                }
            }

            List<NhanVien> temp = result.employeeList;
            for (int i = 0; i < temp.Count - 1; i++)
            {
                for (int j = 0; j < temp.Count - 1 - i; j++)
                {
                    if (temp[j].TinhLuongThang() < temp[j + 1].TinhLuongThang())
                    {
                        NhanVien tam = temp[j];
                        temp[j] = temp[j + 1];
                        temp[j + 1] = tam;
                    }
                }
            }

            return result;
        }
    }
}

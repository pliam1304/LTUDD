using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapBuoi2_2411869
{
    // ================= Yêu cầu 1 =================
    // Interface ITinhLuong: định nghĩa hợp đồng tính lương tháng
    // mà mọi loại nhân viên (NhanVien) đều phải cài đặt.
    public interface ITinhLuong
    {
        int TinhLuongThang();
    }
}

using System.Collections.Generic;

namespace QuanLySinhVien_ChuDe3
{
    /// <summary>
    /// Giao diện chung cho việc đọc/ghi danh sách sinh viên,
    /// cho phép chương trình hỗ trợ nhiều định dạng tập tin
    /// (txt / xml / json) mà không cần thay đổi logic ở nơi khác gọi tới.
    /// </summary>
    public interface ISinhVienIO
    {
        List<SinhVien> Doc(string duongDan);
        void Ghi(string duongDan, List<SinhVien> danhSach);
    }

    public enum LoaiTapTin
    {
        Txt,
        Xml,
        Json
    }

    public static class SinhVienIOFactory
    {
        public static ISinhVienIO TaoDoiTuong(LoaiTapTin loai)
        {
            return loai switch
            {
                LoaiTapTin.Xml => new SinhVienXmlIO(),
                LoaiTapTin.Json => new SinhVienJsonIO(),
                _ => new SinhVienTxtIO(),
            };
        }

        public static LoaiTapTin TuDuoiFile(string duongDan)
        {
            string ext = System.IO.Path.GetExtension(duongDan).ToLower();
            return ext switch
            {
                ".xml" => LoaiTapTin.Xml,
                ".json" => LoaiTapTin.Json,
                _ => LoaiTapTin.Txt,
            };
        }
    }
}

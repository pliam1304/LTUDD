using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace QuanLySinhVien_ChuDe3
{
    /// <summary>
    /// Đọc/ghi danh sách sinh viên dạng XML (students.xml) bằng
    /// XmlSerializer, đúng như phần hướng dẫn "sử dụng lớp
    /// XmlSerializer khi có danh sách đối tượng cần lưu trữ".
    /// </summary>
    public class SinhVienXmlIO : ISinhVienIO
    {
        public List<SinhVien> Doc(string duongDan)
        {
            if (!File.Exists(duongDan)) return new List<SinhVien>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<SinhVien>));
            using FileStream fs = new FileStream(duongDan, FileMode.Open);
            return (List<SinhVien>?)serializer.Deserialize(fs) ?? new List<SinhVien>();
        }

        public void Ghi(string duongDan, List<SinhVien> danhSach)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SinhVien>));
            using FileStream fs = new FileStream(duongDan, FileMode.Create);
            serializer.Serialize(fs, danhSach);
        }
    }
}

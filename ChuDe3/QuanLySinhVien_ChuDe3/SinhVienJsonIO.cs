using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace QuanLySinhVien_ChuDe3
{
    /// <summary>
    /// Đọc/ghi danh sách sinh viên dạng JSON (students.json).
    /// Dùng System.Text.Json (có sẵn trong .NET, không cần cài thêm
    /// Nuget Package) thay cho Newtonsoft.Json trong tài liệu hướng dẫn -
    /// chức năng đọc/ghi JSON hoàn toàn tương đương.
    /// Nếu muốn dùng đúng Newtonsoft.Json như tài liệu, chỉ cần
    /// Install-Package Newtonsoft.Json rồi đổi JsonSerializer.Serialize/
    /// Deserialize sang Newtonsoft.Json.JsonConvert.
    /// </summary>
    public class SinhVienJsonIO : ISinhVienIO
    {
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public List<SinhVien> Doc(string duongDan)
        {
            if (!File.Exists(duongDan)) return new List<SinhVien>();
            string json = File.ReadAllText(duongDan);
            return JsonSerializer.Deserialize<List<SinhVien>>(json, _options) ?? new List<SinhVien>();
        }

        public void Ghi(string duongDan, List<SinhVien> danhSach)
        {
            string json = JsonSerializer.Serialize(danhSach, _options);
            File.WriteAllText(duongDan, json);
        }
    }
}

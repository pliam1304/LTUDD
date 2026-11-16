# TÀI LIỆU HƯỚNG DẪN CHI TIẾT TỪNG BƯỚC - ĐỀ KIỂM TRA SỐ 2
> **Môn:** Phát triển ứng dụng Desktop (WinForms - .NET Framework 4.7.2)  
> **Chủ đề:** Quản lý nhà cung cấp & Hóa đơn nhập hàng (Đọc/Ghi file JSON, TXT, Thiết kế CSDL SQL Server)

---

## 🌟 PHẦN 1: TỔNG HỢP CÁC HÀM ĐỌC/GHI DỮ LIỆU CẦN THIẾT (JSON, XML, EXCEL, TXT, SQL)
*(Phần này được ưu tiên hàng đầu để ôn thi và tra cứu nhanh khi gặp bất kỳ dạng đề nào)*

---

### 1. Đọc và Ghi file JSON (Trực tiếp trong .NET Framework)
- Để dùng trong Visual Studio:
  - Nhấp chuột phải vào mục **References** trong Solution Explorer -> Chọn **Add Reference...**
  - Trong thẻ **Assemblies / Framework**, tìm và tích chọn `System.Web.Extensions` -> bấm **OK**.
- Trong file code `.cs` khai báo:
  ```csharp
  using System.IO;
  using System.Text;
  using System.Web.Script.Serialization;
  ```

#### a) Hàm Đọc file JSON:
```csharp
public static List<T> DocFileJson<T>(string duongDan)
{
    if (!File.Exists(duongDan)) return new List<T>();

    try
    {
        string noiDung = File.ReadAllText(duongDan, Encoding.UTF8);
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        return serializer.Deserialize<List<T>>(noiDung) ?? new List<T>();
    }
    catch (Exception ex)
    {
        MessageBox.Show("Lỗi đọc JSON: " + ex.Message);
        return new List<T>();
    }
}
```

#### b) Hàm Ghi file JSON:
```csharp
public static bool GhiFileJson<T>(string duongDan, List<T> danhSach)
{
    try
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        string noiDung = serializer.Serialize(danhSach);
        File.WriteAllText(duongDan, noiDung, Encoding.UTF8);
        return true;
    }
    catch (Exception ex)
    {
        MessageBox.Show("Lỗi ghi JSON: " + ex.Message);
        return false;
    }
}
```

---

### 2. Đọc và Ghi file XML
Khai báo:
```csharp
using System.IO;
using System.Xml.Serialization;
```

#### a) Hàm Đọc file XML:
```csharp
public static List<T> DocFileXml<T>(string duongDan)
{
    if (!File.Exists(duongDan)) return new List<T>();

    try
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
        using (StreamReader sr = new StreamReader(duongDan))
        {
            return (List<T>)serializer.Deserialize(sr);
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Lỗi đọc XML: " + ex.Message);
        return new List<T>();
    }
}
```

#### b) Hàm Ghi file XML:
```csharp
public static bool GhiFileXml<T>(string duongDan, List<T> danhSach)
{
    try
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
        using (StreamWriter sw = new StreamWriter(duongDan, false, Encoding.UTF8))
        {
            serializer.Serialize(sw, danhSach);
        }
        return true;
    }
    catch (Exception ex)
    {
        MessageBox.Show("Lỗi ghi XML: " + ex.Message);
        return false;
    }
}
```

---

### 3. Đọc và Ghi file Excel (Định dạng CSV UTF-8 mở trực tiếp bằng Excel)
Khai báo:
```csharp
using System.IO;
using System.Text;
```

#### a) Hàm Đọc file Excel CSV:
```csharp
public static List<NhaCungCap> DocFileExcelCsv(string duongDan)
{
    List<NhaCungCap> danhSach = new List<NhaCungCap>();
    if (!File.Exists(duongDan)) return danhSach;

    try
    {
        string[] lines = File.ReadAllLines(duongDan, Encoding.UTF8);
        bool laDongDauTien = true;

        foreach (string rawLine in lines)
        {
            string line = rawLine.Trim();
            if (string.IsNullOrEmpty(line)) continue;

            if (laDongDauTien && (line.StartsWith("Mã") || line.StartsWith("MaNCC")))
            {
                laDongDauTien = false;
                continue;
            }
            laDongDauTien = false;

            char phanCach = line.Contains('\t') ? '\t' : (line.Contains(';') ? ';' : ',');
            string[] cot = line.Split(phanCach);
            if (cot.Length >= 5)
            {
                danhSach.Add(new NhaCungCap(cot[0].Trim(), cot[1].Trim(), cot[2].Trim(), cot[3].Trim(), cot[4].Trim()));
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Lỗi đọc Excel: " + ex.Message);
    }
    return danhSach;
}
```

#### b) Hàm Ghi file Excel CSV:
```csharp
public static bool GhiFileExcelCsv(string duongDan, List<NhaCungCap> danhSach)
{
    try
    {
        using (StreamWriter sw = new StreamWriter(duongDan, false, Encoding.UTF8))
        {
            sw.WriteLine("Mã nhà cc,Tên nhà cung cấp,Địa chỉ,Số ĐT,Mô tả");
            foreach (var ncc in danhSach)
            {
                sw.WriteLine(string.Format("{0},{1},{2},{3},{4}", ncc.MaNCC, ncc.TenNCC, ncc.DiaChi, ncc.SoDT, ncc.MoTa));
            }
        }
        return true;
    }
    catch { return false; }
}
```

---

### 4. Đọc và Ghi file TXT (Dấu `|` hoặc `,`)
Khai báo:
```csharp
using System.IO;
using System.Text;
```

#### a) Đọc file TXT:
```csharp
public static List<NhaCungCap> DocFileTxt(string duongDan)
{
    List<NhaCungCap> list = new List<NhaCungCap>();
    if (!File.Exists(duongDan)) return list;

    string[] lines = File.ReadAllLines(duongDan, Encoding.UTF8);
    foreach (string line in lines)
    {
        if (string.IsNullOrWhiteSpace(line)) continue;
        string[] parts = line.Split('|');
        if (parts.Length >= 5)
        {
            list.Add(new NhaCungCap(parts[0].Trim(), parts[1].Trim(), parts[2].Trim(), parts[3].Trim(), parts[4].Trim()));
        }
    }
    return list;
}
```

#### b) Ghi file TXT:
```csharp
public static bool GhiFileTxt(string duongDan, List<NhaCungCap> list)
{
    try
    {
        using (StreamWriter sw = new StreamWriter(duongDan, false, Encoding.UTF8))
        {
            foreach (var ncc in list)
            {
                sw.WriteLine(string.Format("{0}|{1}|{2}|{3}|{4}", ncc.MaNCC, ncc.TenNCC, ncc.DiaChi, ncc.SoDT, ncc.MoTa));
            }
        }
        return true;
    }
    catch { return false; }
}
```

---

### 5. Đọc và Truy vấn Cơ sở dữ liệu SQL Server (ADO.NET)
Khai báo:
```csharp
using System.Data;
using System.Data.SqlClient;
```

#### a) Đọc dữ liệu ra DataTable:
```csharp
string chuoiKetNoi = "server=.;database=QuanLyNhapHangDB;Integrated Security=true;";

public DataTable LayBangSql(string sql)
{
    DataTable dt = new DataTable();
    using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
    {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
    }
    return dt;
}
```

#### b) Thực thi Thêm / Sửa / Xóa trong SQL Server:
```csharp
public bool ThucThiSql(string sql, SqlParameter[] parameters = null)
{
    using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
    {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
```

---
---

## 📌 PHẦN 2: HƯỚNG DẪN CHI TIẾT TỪNG BƯỚC THỰC HIỆN CÂU 1 (ĐỀ 2)

### Bước 1: Tạo Lớp đối tượng `NhaCungCap.cs`
- **File:** `NhaCungCap.cs`
- **Mục đích:** Lưu trữ thông tin 1 nhà cung cấp.
- **Code:**
```csharp
using System;

namespace BTKTraGK_De2
{
    [Serializable]
    public class NhaCungCap
    {
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string DiaChi { get; set; }
        public string SoDT { get; set; }
        public string MoTa { get; set; }

        public NhaCungCap() { }

        public NhaCungCap(string maNCC, string tenNCC, string diaChi, string soDT, string moTa)
        {
            MaNCC = maNCC;
            TenNCC = tenNCC;
            DiaChi = diaChi;
            SoDT = soDT;
            MoTa = moTa;
        }
    }
}
```

---

### Bước 2: Thiết kế CSDL và tạo dữ liệu mẫu (`QuanLyNhapHang.sql`)
- **Yêu cầu 3 của đề bài (1 điểm):**
```sql
CREATE DATABASE QuanLyNhapHangDB;
GO
USE QuanLyNhapHangDB;
GO

CREATE TABLE NhaCungCap(
    MaNCC NVARCHAR(50) PRIMARY KEY,
    TenNCC NVARCHAR(250) NOT NULL,
    DiaChi NVARCHAR(500) NULL,
    SoDT NVARCHAR(50) NULL,
    MoTa NVARCHAR(1000) NULL
);

CREATE TABLE HoaDonNhap(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    SoHD NVARCHAR(50) NOT NULL,
    NgayNhan SMALLDATETIME DEFAULT GETDATE(),
    MaNCC NVARCHAR(50) FOREIGN KEY REFERENCES NhaCungCap(MaNCC),
    TongTien DECIMAL(18,2) DEFAULT 0,
    GiamGia FLOAT DEFAULT 0,
    PhaiTra DECIMAL(18,2) DEFAULT 0
);

CREATE TABLE ChiTietNhapHang(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    HoaDonID INT FOREIGN KEY REFERENCES HoaDonNhap(ID),
    TenHang NVARCHAR(250) NOT NULL,
    SoLuong INT NOT NULL,
    DonGiaNhap DECIMAL(18,2) NOT NULL,
    ThanhTien DECIMAL(18,2) NOT NULL
);

-- Dữ liệu mẫu
INSERT INTO NhaCungCap VALUES 
(N'NCC01', N'Công ty TNHH Thực phẩm Sạch Đà Lạt', N'12 Nguyễn Văn Cừ, TP. Đà Lạt', N'02633821234', N'Rau củ quả sạch'),
(N'NCC02', N'Công ty CP Thủy hải sản Nha Trang', N'45 Trần Phú, TP. Nha Trang', N'0912345678', N'Hải sản tươi sống');
```

---

### Bước 3: Tạo Lớp Quản lý `QuanLyNhaCungCap.cs`
- **File:** `QuanLyNhaCungCap.cs`
- **Mục đích:** Quản lý danh sách, đọc/ghi JSON, thêm, cập nhật, tìm kiếm.
- **Code:**
```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace BTKTraGK_De2
{
    public class QuanLyNhaCungCap
    {
        public List<NhaCungCap> DanhSach { get; set; }
        private JavaScriptSerializer jsonSerializer;

        public QuanLyNhaCungCap()
        {
            DanhSach = new List<NhaCungCap>();
            jsonSerializer = new JavaScriptSerializer();
        }

        public string SinhMaTuDong()
        {
            int max = 0;
            foreach (var n in DanhSach)
            {
                if (!string.IsNullOrEmpty(n.MaNCC))
                {
                    string so = new string(n.MaNCC.Where(char.IsDigit).ToArray());
                    if (int.TryParse(so, out int val) && val > max) max = val;
                }
            }
            return string.Format("NCC{0:D2}", max + 1);
        }

        public void Them(NhaCungCap ncc)
        {
            if (string.IsNullOrEmpty(ncc.MaNCC)) ncc.MaNCC = SinhMaTuDong();
            DanhSach.Add(ncc);
        }

        public bool CapNhat(NhaCungCap ncc)
        {
            var item = DanhSach.FirstOrDefault(n => n.MaNCC.Equals(ncc.MaNCC, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                item.TenNCC = ncc.TenNCC;
                item.DiaChi = ncc.DiaChi;
                item.SoDT = ncc.SoDT;
                item.MoTa = ncc.MoTa;
                return true;
            }
            return false;
        }

        public List<NhaCungCap> TimKiem(string tuKhoa, bool theoTen)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa)) return new List<NhaCungCap>(DanhSach);
            tuKhoa = tuKhoa.Trim().ToLower();

            if (theoTen)
                return DanhSach.Where(n => !string.IsNullOrEmpty(n.TenNCC) && n.TenNCC.ToLower().Contains(tuKhoa)).ToList();
            else
                return DanhSach.Where(n => !string.IsNullOrEmpty(n.SoDT) && n.SoDT.Contains(tuKhoa)).ToList();
        }

        // Đọc từ file JSON (nếu không có thì đọc TXT)
        public bool DocTuFileJSON(string duongDan)
        {
            if (!File.Exists(duongDan)) return false;
            try
            {
                string json = File.ReadAllText(duongDan, Encoding.UTF8).Trim();
                if (json.StartsWith("[") && json.EndsWith("]"))
                {
                    var list = jsonSerializer.Deserialize<List<NhaCungCap>>(json);
                    if (list != null) { DanhSach = list; return true; }
                }
                return DocTuFileTXT(duongDan);
            }
            catch { return DocTuFileTXT(duongDan); }
        }

        public bool DocTuFileTXT(string duongDan)
        {
            if (!File.Exists(duongDan)) return false;
            try
            {
                DanhSach.Clear();
                string[] lines = File.ReadAllLines(duongDan, Encoding.UTF8);
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    char sep = line.Contains('|') ? '|' : (line.Contains(';') ? ';' : ',');
                    string[] p = line.Split(sep);
                    if (p.Length >= 5) DanhSach.Add(new NhaCungCap(p[0].Trim(), p[1].Trim(), p[2].Trim(), p[3].Trim(), p[4].Trim()));
                }
                return true;
            }
            catch { return false; }
        }

        public bool XuatRaFileJSON(string duongDan, List<NhaCungCap> ds = null)
        {
            try
            {
                string json = jsonSerializer.Serialize(ds ?? DanhSach);
                File.WriteAllText(duongDan, json, Encoding.UTF8);
                return true;
            }
            catch { return false; }
        }
    }
}
```

---

### Bước 4: Thiết kế Form `frmQuanLyNhaCungCap`
- Các Controls cần kéo thả:
  - `txtMaNCC`: TextBox Mã nhà cung cấp
  - `txtTenNCC`: TextBox Tên nhà cung cấp
  - `txtDiaChi`: TextBox Địa chỉ
  - `txtSoDT`: TextBox Số điện thoại
  - `txtMoTa`: TextBox Mô tả (`Multiline = true`)
  - `btnMacDinh`: Button "Mặc định"
  - `btnLuu`: Button "Lưu"
  - `rdTheoTen`: RadioButton "Theo tên" (`Checked = true`)
  - `rdTheoSDT`: RadioButton "Theo SĐT"
  - `txtTimKiem`: TextBox tìm kiếm
  - `dgvNhaCungCap`: DataGridView hiển thị danh sách (`ReadOnly = true`, `SelectionMode = FullRowSelect`, `AllowUserToAddRows = false`)
    - Cột: `colMaNCC`, `colTenNCC`, `colDiaChi`, `colSoDT`, `colMoTa`.
  - `btnXuatJSON`: Button "Xuất JSON".

---

### Bước 5: Viết Code Logic vào file `frmQuanLyNhaCungCap.cs`

#### 1. Sự kiện `Form_Load`:
```csharp
public QuanLyNhaCungCap QLNCC = new QuanLyNhaCungCap();
public string SelectedSupplierName { get; private set; } // Dùng cho Câu 2

private void frmQuanLyNhaCungCap_Load(object sender, EventArgs e)
{
    // Đọc từ file JSON
    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nhacungcap.json");
    if (File.Exists(path))
    {
        QLNCC.DocTuFileJSON(path);
    }
    else
    {
        // Tạo mẫu nếu file chưa có
        QLNCC.Them(new NhaCungCap("NCC01", "Công ty Rau Sạch Đà Lạt", "Đà Lạt", "02633821234", "Rau sạch"));
        QLNCC.Them(new NhaCungCap("NCC02", "Hải Sản Nha Trang", "Nha Trang", "0912345678", "Hải sản tươi sống"));
    }
    HienThiLenBang(QLNCC.DanhSach);
}

private void HienThiLenBang(List<NhaCungCap> ds)
{
    dgvNhaCungCap.DataSource = null;
    dgvNhaCungCap.DataSource = new List<NhaCungCap>(ds);
}
```

#### 2. Xử lý nút "Mặc định" (`btnMacDinh_Click`):
```csharp
private void btnMacDinh_Click(object sender, EventArgs e)
{
    txtMaNCC.Clear();
    txtTenNCC.Clear();
    txtDiaChi.Clear();
    txtSoDT.Clear();
    txtMoTa.Clear();
    txtTimKiem.Clear();
    dgvNhaCungCap.ClearSelection();
    txtTenNCC.Focus();
    HienThiLenBang(QLNCC.DanhSach);
}
```

#### 3. Xử lý click chọn một dòng (`dgvNhaCungCap_CellClick`):
```csharp
private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
{
    if (e.RowIndex >= 0 && e.RowIndex < dgvNhaCungCap.Rows.Count)
    {
        DataGridViewRow row = dgvNhaCungCap.Rows[e.RowIndex];
        txtMaNCC.Text = row.Cells["colMaNCC"].Value?.ToString();
        txtTenNCC.Text = row.Cells["colTenNCC"].Value?.ToString();
        txtDiaChi.Text = row.Cells["colDiaChi"].Value?.ToString();
        txtSoDT.Text = row.Cells["colSoDT"].Value?.ToString();
        txtMoTa.Text = row.Cells["colMoTa"].Value?.ToString();
    }
}
```

#### 4. Xử lý nút "Lưu" (`btnLuu_Click`):
```csharp
private void btnLuu_Click(object sender, EventArgs e)
{
    string ten = txtTenNCC.Text.Trim();
    string diachi = txtDiaChi.Text.Trim();
    string sdt = txtSoDT.Text.Trim();
    string mota = txtMoTa.Text.Trim();
    string ma = txtMaNCC.Text.Trim();

    if (string.IsNullOrEmpty(ten))
    {
        MessageBox.Show("Vui lòng nhập tên nhà cung cấp!");
        return;
    }

    if (!string.IsNullOrEmpty(ma))
    {
        // Cập nhật nhà cung cấp
        NhaCungCap ncc = new NhaCungCap(ma, ten, diachi, sdt, mota);
        QLNCC.CapNhat(ncc);
        MessageBox.Show("Cập nhật nhà cung cấp thành công!");
    }
    else
    {
        // Thêm mới nhà cung cấp
        NhaCungCap ncc = new NhaCungCap("", ten, diachi, sdt, mota);
        QLNCC.Them(ncc);
        txtMaNCC.Text = ncc.MaNCC;
        MessageBox.Show("Thêm mới nhà cung cấp thành công: " + ncc.MaNCC);
    }

    // Tự động lưu lại vào file JSON
    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nhacungcap.json");
    QLNCC.XuatRaFileJSON(path);

    HienThiLenBang(QLNCC.DanhSach);
}
```

#### 5. Xử lý Tìm kiếm (`txtTimKiem_TextChanged`):
```csharp
private void txtTimKiem_TextChanged(object sender, EventArgs e)
{
    string tuKhoa = txtTimKiem.Text.Trim();
    bool theoTen = rdTheoTen.Checked;
    HienThiLenBang(QLNCC.TimKiem(tuKhoa, theoTen));
}
```

#### 6. Xử lý nút "Xuất JSON" (`btnXuatJSON_Click`):
```csharp
private void btnXuatJSON_Click(object sender, EventArgs e)
{
    SaveFileDialog sfd = new SaveFileDialog();
    sfd.Filter = "File JSON (*.json)|*.json";
    sfd.FileName = "nhacungcap.json";
    if (sfd.ShowDialog() == DialogResult.OK)
    {
        QLNCC.XuatRaFileJSON(sfd.FileName, dgvNhaCungCap.DataSource as List<NhaCungCap>);
        MessageBox.Show("Xuất file JSON thành công!");
    }
}
```

#### 7. Xử lý Double-Click chọn nhà cung cấp (Phục vụ Câu 2):
```csharp
private void dgvNhaCungCap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
{
    if (e.RowIndex >= 0)
    {
        SelectedSupplierName = dgvNhaCungCap.Rows[e.RowIndex].Cells["colTenNCC"].Value?.ToString();
        this.DialogResult = DialogResult.OK;
        this.Close(); // Đóng form lại
    }
}
```

---
---

## 📌 PHẦN 3: HƯỚNG DẪN CHI TIẾT TỪNG BƯỚC THỰC HIỆN CÂU 2 (ĐỀ 2)

### Bước 1: Thiết kế Form `frmHoaDonNhapHang`
- Tiêu đề Form: "Quản lý nhập hàng" (Nhãn lớn: **HÓA ĐƠN NHẬP HÀNG**).
- **`dtpNgayNhan`**: DateTimePicker (`Enabled = false`).
- **`txtNhaCungCap`**: TextBox (`ReadOnly = true`).
- **`btnThemNhaCungCap`**: Button text `+`.
- **`dgvChiTietNhapHang`**: DataGridView chi tiết hàng nhập với 4 cột:
  - `colTenHang` (Tên hàng)
  - `colSoLuong` (Số lượng)
  - `colDonGiaNhap` (Đơn giá nhập)
  - `colThanhTien` (Thành tiền - `ReadOnly = true`)
- **`txtTongTien`**: TextBox (`ReadOnly = true`).
- **`nudGiamGia`**: NumericUpDown (`Minimum = 0`, `Maximum = 100`).
- **`txtPhaiTra`**: TextBox (`ReadOnly = true`).
- Các nút: `btnLuu`, `btnHuyHoaDon`, `btnChonHDNhap`.

---

### Bước 2: Viết Code Logic vào file `frmHoaDonNhapHang.cs`

#### 1. Sự kiện `Form_Load`:
```csharp
private void frmHoaDonNhapHang_Load(object sender, EventArgs e)
{
    // Câu 2.1: Ngày nhận không cho phép chọn, chỉ hiển thị ngày hiện tại
    dtpNgayNhan.Value = DateTime.Now;
    dtpNgayNhan.Enabled = false;

    // Dòng mẫu
    dgvChiTietNhapHang.Rows.Add("Xà lách Romaine", 50, "35000", "1750000");
    dgvChiTietNhapHang.Rows.Add("Cà chua bi", 30, "45000", "1350000");
    TinhTongTien();
}
```

#### 2. Xử lý nút `+` mở Form Quản lý nhà cung cấp (`btnThemNhaCungCap_Click`):
```csharp
private void btnThemNhaCungCap_Click(object sender, EventArgs e)
{
    using (frmQuanLyNhaCungCap frm = new frmQuanLyNhaCungCap())
    {
        // Khi double click vào nhà cung cấp, form đó đóng và trả về DialogResult.OK
        if (frm.ShowDialog(this) == DialogResult.OK)
        {
            txtNhaCungCap.Text = frm.SelectedSupplierName;
        }
    }
}
```

#### 3. Tự động tính Thành tiền khi nhập Số lượng hoặc Đơn giá nhập:
```csharp
private void dgvChiTietNhapHang_CellValueChanged(object sender, DataGridViewCellEventArgs e)
{
    if (e.RowIndex < 0) return;
    var row = dgvChiTietNhapHang.Rows[e.RowIndex];

    if (e.ColumnIndex == colSoLuong.Index || e.ColumnIndex == colDonGiaNhap.Index)
    {
        double sl = 0, gia = 0;
        if (row.Cells[colSoLuong.Index].Value != null)
            double.TryParse(row.Cells[colSoLuong.Index].Value.ToString(), out sl);

        if (row.Cells[colDonGiaNhap.Index].Value != null)
        {
            string strGia = row.Cells[colDonGiaNhap.Index].Value.ToString().Replace(",", "").Replace(".", "");
            double.TryParse(strGia, out gia);
        }

        double thanhTien = sl * gia;
        row.Cells[colThanhTien.Index].Value = thanhTien.ToString("N0");
        TinhTongTien();
    }
}
```

#### 4. Logic tính Tổng tiền và Phải trả:
```csharp
private double tongTien = 0;

private void TinhTongTien()
{
    tongTien = 0;
    foreach (DataGridViewRow row in dgvChiTietNhapHang.Rows)
    {
        if (row.IsNewRow) continue;
        if (row.Cells[colThanhTien.Index].Value != null)
        {
            string str = row.Cells[colThanhTien.Index].Value.ToString().Replace(",", "").Replace(".", "");
            if (double.TryParse(str, out double val))
                tongTien += val;
        }
    }

    txtTongTien.Text = tongTien.ToString("N0");
    CapNhatPhaiTra();
}

private void nudGiamGia_ValueChanged(object sender, EventArgs e)
{
    CapNhatPhaiTra();
}

private void CapNhatPhaiTra()
{
    double giamGia = (double)nudGiamGia.Value;
    double phaiTra = tongTien - (tongTien * giamGia / 100.0);
    txtPhaiTra.Text = phaiTra.ToString("N0");
}
```

#### 5. Xử lý nút "Lưu" và "Hủy hóa đơn":
```csharp
private void btnLuu_Click(object sender, EventArgs e)
{
    if (string.IsNullOrWhiteSpace(txtNhaCungCap.Text))
    {
        MessageBox.Show("Vui lòng chọn nhà cung cấp trước khi lưu hóa đơn!");
        btnThemNhaCungCap_Click(sender, e);
        return;
    }

    MessageBox.Show(string.Format("Lưu hóa đơn nhập hàng thành công cho nhà cung cấp '{0}'!\nTổng tiền: {1} VNĐ\nChiết khấu: {2}%\nThực trả: {3} VNĐ",
        txtNhaCungCap.Text, txtTongTien.Text, nudGiamGia.Value, txtPhaiTra.Text));
}

private void btnHuyHoaDon_Click(object sender, EventArgs e)
{
    txtNhaCungCap.Clear();
    dgvChiTietNhapHang.Rows.Clear();
    nudGiamGia.Value = 0;
    txtTongTien.Text = "0";
    txtPhaiTra.Text = "0";
}
```

---
---

## 💡 PHẦN 4: MẸO GHI NHỚ ĐI THI ĐẠT ĐIỂM TỐI ĐA (10/10)
1. **Lớp đối tượng:** Luôn tạo 2 constructor (1 cái rỗng `public KhachHang() { }` và 1 cái đầy đủ tham số) để các bộ Serializer (JSON/XML) không bị lỗi.
2. **DataGridView Naming:** Tuyệt đối không đặt tên cột là `Name` (vì sẽ đè lên thuộc tính `Control.Name` gây lỗi biên dịch CS0029). Luôn đặt `colMaKH`, `colTenKH`, `colSoLuong`...
3. **Liên kết 2 Form:** Muốn form con trả dữ liệu về form cha:
   - Trong Form con: Lưu giá trị vào thuộc tính `public string SelectedName { get; private set; }`, gán `this.DialogResult = DialogResult.OK;` và gọi `this.Close();`.
   - Trong Form cha: Gọi `if (frmCon.ShowDialog(this) == DialogResult.OK) { txtBox.Text = frmCon.SelectedName; }`.
4. **Đọc file an toàn:** Luôn dùng `AppDomain.CurrentDomain.BaseDirectory` kết hợp `Path.Combine` để tìm file dữ liệu cạnh file `.exe`.

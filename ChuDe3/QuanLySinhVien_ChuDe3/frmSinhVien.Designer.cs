namespace QuanLySinhVien_ChuDe3
{
    partial class frmSinhVien
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiTapTin;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoTxt;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoXml;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoJson;
        private System.Windows.Forms.ToolStripMenuItem tsmiLuuThanhTxt;
        private System.Windows.Forms.ToolStripMenuItem tsmiLuuThanhXml;
        private System.Windows.Forms.ToolStripMenuItem tsmiLuuThanhJson;
        private System.Windows.Forms.ToolStripSeparator tsSep1;
        private System.Windows.Forms.ToolStripMenuItem tsmiThoat;

        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.Label lblMSSV;
        private System.Windows.Forms.MaskedTextBox mtxtMSSV;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label lblCMND;
        private System.Windows.Forms.MaskedTextBox mtxtCMND;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.MaskedTextBox mtxtSDT;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.RadioButton rdNam;
        private System.Windows.Forms.RadioButton rdNu;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblMon;
        private System.Windows.Forms.CheckedListBox clbMonDangKy;
        private System.Windows.Forms.ContextMenuStrip cmsMon;
        private System.Windows.Forms.ToolStripMenuItem cmsMonThem;
        private System.Windows.Forms.ToolStripMenuItem cmsMonXoa;

        private System.Windows.Forms.Button btnThemCapNhat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnHienThiTatCa;
        private System.Windows.Forms.Button btnMacDinh;
        private System.Windows.Forms.Button btnThoat;

        private System.Windows.Forms.ListView lvSinhVien;
        private System.Windows.Forms.ColumnHeader chMSSV;
        private System.Windows.Forms.ColumnHeader chHoTen;
        private System.Windows.Forms.ColumnHeader chLop;
        private System.Windows.Forms.ColumnHeader chCMND;
        private System.Windows.Forms.ColumnHeader chSDT;
        private System.Windows.Forms.ColumnHeader chNgaySinh;
        private System.Windows.Forms.ColumnHeader chGioiTinh;
        private System.Windows.Forms.ColumnHeader chDiaChi;
        private System.Windows.Forms.ColumnHeader chMonDangKy;
        private System.Windows.Forms.ContextMenuStrip cmsDanhSach;
        private System.Windows.Forms.ToolStripMenuItem cmsDanhSachXoa;

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslTongSV;
        private System.Windows.Forms.ToolStripStatusLabel tsslFile;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiTapTin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMoTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMoXml = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMoJson = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLuuThanhTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLuuThanhXml = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLuuThanhJson = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiThoat = new System.Windows.Forms.ToolStripMenuItem();

            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.lblMSSV = new System.Windows.Forms.Label();
            this.mtxtMSSV = new System.Windows.Forms.MaskedTextBox();
            this.lblLop = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.lblCMND = new System.Windows.Forms.Label();
            this.mtxtCMND = new System.Windows.Forms.MaskedTextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.mtxtSDT = new System.Windows.Forms.MaskedTextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.rdNam = new System.Windows.Forms.RadioButton();
            this.rdNu = new System.Windows.Forms.RadioButton();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblMon = new System.Windows.Forms.Label();
            this.clbMonDangKy = new System.Windows.Forms.CheckedListBox();
            this.cmsMon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsMonThem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMonXoa = new System.Windows.Forms.ToolStripMenuItem();

            this.btnThemCapNhat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnHienThiTatCa = new System.Windows.Forms.Button();
            this.btnMacDinh = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();

            this.lvSinhVien = new System.Windows.Forms.ListView();
            this.chMSSV = new System.Windows.Forms.ColumnHeader();
            this.chHoTen = new System.Windows.Forms.ColumnHeader();
            this.chLop = new System.Windows.Forms.ColumnHeader();
            this.chCMND = new System.Windows.Forms.ColumnHeader();
            this.chSDT = new System.Windows.Forms.ColumnHeader();
            this.chNgaySinh = new System.Windows.Forms.ColumnHeader();
            this.chGioiTinh = new System.Windows.Forms.ColumnHeader();
            this.chDiaChi = new System.Windows.Forms.ColumnHeader();
            this.chMonDangKy = new System.Windows.Forms.ColumnHeader();
            this.cmsDanhSach = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsDanhSachXoa = new System.Windows.Forms.ToolStripMenuItem();

            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslTongSV = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslFile = new System.Windows.Forms.ToolStripStatusLabel();

            this.menuStrip1.SuspendLayout();
            this.gbThongTin.SuspendLayout();
            this.cmsMon.SuspendLayout();
            this.cmsDanhSach.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            //
            // menuStrip1
            //
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsmiTapTin });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(958, 24);
            this.menuStrip1.TabIndex = 0;
            //
            // tsmiTapTin
            //
            this.tsmiTapTin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.tsmiMoTxt, this.tsmiMoXml, this.tsmiMoJson,
                this.tsmiLuuThanhTxt, this.tsmiLuuThanhXml, this.tsmiLuuThanhJson,
                this.tsSep1, this.tsmiThoat});
            this.tsmiTapTin.Name = "tsmiTapTin";
            this.tsmiTapTin.Size = new System.Drawing.Size(63, 20);
            this.tsmiTapTin.Text = "Tập tin";
            //
            // tsmiMoTxt
            //
            this.tsmiMoTxt.Name = "tsmiMoTxt";
            this.tsmiMoTxt.Text = "Mở tập tin văn bản (*.txt)...";
            this.tsmiMoTxt.Click += new System.EventHandler(this.tsmiMoTxt_Click);
            //
            // tsmiMoXml
            //
            this.tsmiMoXml.Name = "tsmiMoXml";
            this.tsmiMoXml.Text = "Mở tập tin XML (*.xml)...";
            this.tsmiMoXml.Click += new System.EventHandler(this.tsmiMoXml_Click);
            //
            // tsmiMoJson
            //
            this.tsmiMoJson.Name = "tsmiMoJson";
            this.tsmiMoJson.Text = "Mở tập tin JSON (*.json)...";
            this.tsmiMoJson.Click += new System.EventHandler(this.tsmiMoJson_Click);
            //
            // tsmiLuuThanhTxt
            //
            this.tsmiLuuThanhTxt.Name = "tsmiLuuThanhTxt";
            this.tsmiLuuThanhTxt.Text = "Lưu thành tập tin văn bản (*.txt)...";
            this.tsmiLuuThanhTxt.Click += new System.EventHandler(this.tsmiLuuThanhTxt_Click);
            //
            // tsmiLuuThanhXml
            //
            this.tsmiLuuThanhXml.Name = "tsmiLuuThanhXml";
            this.tsmiLuuThanhXml.Text = "Lưu thành tập tin XML (*.xml)...";
            this.tsmiLuuThanhXml.Click += new System.EventHandler(this.tsmiLuuThanhXml_Click);
            //
            // tsmiLuuThanhJson
            //
            this.tsmiLuuThanhJson.Name = "tsmiLuuThanhJson";
            this.tsmiLuuThanhJson.Text = "Lưu thành tập tin JSON (*.json)...";
            this.tsmiLuuThanhJson.Click += new System.EventHandler(this.tsmiLuuThanhJson_Click);
            //
            // tsmiThoat
            //
            this.tsmiThoat.Name = "tsmiThoat";
            this.tsmiThoat.Text = "Thoát";
            this.tsmiThoat.Click += new System.EventHandler(this.btnThoat_Click);
            //
            // gbThongTin
            //
            this.gbThongTin.Controls.Add(this.lblMSSV);
            this.gbThongTin.Controls.Add(this.mtxtMSSV);
            this.gbThongTin.Controls.Add(this.lblLop);
            this.gbThongTin.Controls.Add(this.cboLop);
            this.gbThongTin.Controls.Add(this.lblCMND);
            this.gbThongTin.Controls.Add(this.mtxtCMND);
            this.gbThongTin.Controls.Add(this.lblSDT);
            this.gbThongTin.Controls.Add(this.mtxtSDT);
            this.gbThongTin.Controls.Add(this.lblHoTen);
            this.gbThongTin.Controls.Add(this.txtHoTen);
            this.gbThongTin.Controls.Add(this.lblNgaySinh);
            this.gbThongTin.Controls.Add(this.dtpNgaySinh);
            this.gbThongTin.Controls.Add(this.lblGioiTinh);
            this.gbThongTin.Controls.Add(this.rdNam);
            this.gbThongTin.Controls.Add(this.rdNu);
            this.gbThongTin.Controls.Add(this.lblDiaChi);
            this.gbThongTin.Controls.Add(this.txtDiaChi);
            this.gbThongTin.Controls.Add(this.lblMon);
            this.gbThongTin.Controls.Add(this.clbMonDangKy);
            this.gbThongTin.Controls.Add(this.btnThemCapNhat);
            this.gbThongTin.Controls.Add(this.btnXoa);
            this.gbThongTin.Controls.Add(this.btnTimKiem);
            this.gbThongTin.Controls.Add(this.btnHienThiTatCa);
            this.gbThongTin.Controls.Add(this.btnMacDinh);
            this.gbThongTin.Controls.Add(this.btnThoat);
            this.gbThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right))));
            this.gbThongTin.Location = new System.Drawing.Point(12, 30);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Size = new System.Drawing.Size(934, 262);
            this.gbThongTin.TabIndex = 1;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "Thông tin sinh viên";
            //
            // lblMSSV
            //
            this.lblMSSV.AutoSize = true;
            this.lblMSSV.Location = new System.Drawing.Point(15, 28);
            this.lblMSSV.Name = "lblMSSV";
            this.lblMSSV.Size = new System.Drawing.Size(45, 15);
            this.lblMSSV.TabIndex = 0;
            this.lblMSSV.Text = "MSSV:";
            //
            // mtxtMSSV
            //
            this.mtxtMSSV.Location = new System.Drawing.Point(100, 25);
            this.mtxtMSSV.Mask = "0000000";
            this.mtxtMSSV.Name = "mtxtMSSV";
            this.mtxtMSSV.Size = new System.Drawing.Size(110, 23);
            this.mtxtMSSV.TabIndex = 1;
            //
            // lblLop
            //
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(230, 28);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(33, 15);
            this.lblLop.TabIndex = 2;
            this.lblLop.Text = "Lớp:";
            //
            // cboLop
            //
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Items.AddRange(new object[] { "K21", "K22", "K23", "K24" });
            this.cboLop.Location = new System.Drawing.Point(280, 25);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(90, 23);
            this.cboLop.TabIndex = 3;
            //
            // lblCMND
            //
            this.lblCMND.AutoSize = true;
            this.lblCMND.Location = new System.Drawing.Point(390, 28);
            this.lblCMND.Name = "lblCMND";
            this.lblCMND.Size = new System.Drawing.Size(46, 15);
            this.lblCMND.TabIndex = 4;
            this.lblCMND.Text = "CMND:";
            //
            // mtxtCMND
            //
            this.mtxtCMND.Location = new System.Drawing.Point(450, 25);
            this.mtxtCMND.Mask = "000000000";
            this.mtxtCMND.Name = "mtxtCMND";
            this.mtxtCMND.Size = new System.Drawing.Size(150, 23);
            this.mtxtCMND.TabIndex = 5;
            //
            // lblSDT
            //
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(620, 28);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(34, 15);
            this.lblSDT.TabIndex = 6;
            this.lblSDT.Text = "SĐT:";
            //
            // mtxtSDT
            //
            this.mtxtSDT.Location = new System.Drawing.Point(670, 25);
            this.mtxtSDT.Mask = "0000000000";
            this.mtxtSDT.Name = "mtxtSDT";
            this.mtxtSDT.Size = new System.Drawing.Size(150, 23);
            this.mtxtSDT.TabIndex = 7;
            //
            // lblHoTen
            //
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(15, 61);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(52, 15);
            this.lblHoTen.TabIndex = 8;
            this.lblHoTen.Text = "Họ tên:";
            //
            // txtHoTen
            //
            this.txtHoTen.Location = new System.Drawing.Point(100, 58);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(270, 23);
            this.txtHoTen.TabIndex = 9;
            //
            // lblNgaySinh
            //
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(390, 61);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(65, 15);
            this.lblNgaySinh.TabIndex = 10;
            this.lblNgaySinh.Text = "Ngày sinh:";
            //
            // dtpNgaySinh
            //
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(470, 58);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(130, 23);
            this.dtpNgaySinh.TabIndex = 11;
            //
            // lblGioiTinh
            //
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(620, 61);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(60, 15);
            this.lblGioiTinh.TabIndex = 12;
            this.lblGioiTinh.Text = "Giới tính:";
            //
            // rdNam
            //
            this.rdNam.AutoSize = true;
            this.rdNam.Checked = true;
            this.rdNam.Location = new System.Drawing.Point(690, 59);
            this.rdNam.Name = "rdNam";
            this.rdNam.Size = new System.Drawing.Size(50, 19);
            this.rdNam.TabIndex = 13;
            this.rdNam.TabStop = true;
            this.rdNam.Text = "Nam";
            //
            // rdNu
            //
            this.rdNu.AutoSize = true;
            this.rdNu.Location = new System.Drawing.Point(750, 59);
            this.rdNu.Name = "rdNu";
            this.rdNu.Size = new System.Drawing.Size(41, 19);
            this.rdNu.TabIndex = 14;
            this.rdNu.Text = "Nữ";
            //
            // lblDiaChi
            //
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(15, 94);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(55, 15);
            this.lblDiaChi.TabIndex = 15;
            this.lblDiaChi.Text = "Địa chỉ:";
            //
            // txtDiaChi
            //
            this.txtDiaChi.Location = new System.Drawing.Point(100, 91);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(720, 23);
            this.txtDiaChi.TabIndex = 16;
            //
            // lblMon
            //
            this.lblMon.Location = new System.Drawing.Point(15, 127);
            this.lblMon.Name = "lblMon";
            this.lblMon.Size = new System.Drawing.Size(80, 60);
            this.lblMon.TabIndex = 17;
            this.lblMon.Text = "Môn đăng ký (chuột phải để thêm/xóa môn):";
            //
            // clbMonDangKy
            //
            this.clbMonDangKy.CheckOnClick = true;
            this.clbMonDangKy.ContextMenuStrip = this.cmsMon;
            this.clbMonDangKy.Location = new System.Drawing.Point(100, 127);
            this.clbMonDangKy.Name = "clbMonDangKy";
            this.clbMonDangKy.Size = new System.Drawing.Size(720, 76);
            this.clbMonDangKy.TabIndex = 18;
            //
            // cmsMon
            //
            this.cmsMon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.cmsMonThem, this.cmsMonXoa });
            this.cmsMon.Name = "cmsMon";
            this.cmsMon.Size = new System.Drawing.Size(180, 48);
            //
            // cmsMonThem
            //
            this.cmsMonThem.Name = "cmsMonThem";
            this.cmsMonThem.Text = "Thêm môn...";
            this.cmsMonThem.Click += new System.EventHandler(this.cmsMonThem_Click);
            //
            // cmsMonXoa
            //
            this.cmsMonXoa.Name = "cmsMonXoa";
            this.cmsMonXoa.Text = "Xóa môn đã chọn";
            this.cmsMonXoa.Click += new System.EventHandler(this.cmsMonXoa_Click);
            //
            // btnThemCapNhat
            //
            this.btnThemCapNhat.Location = new System.Drawing.Point(100, 218);
            this.btnThemCapNhat.Name = "btnThemCapNhat";
            this.btnThemCapNhat.Size = new System.Drawing.Size(140, 30);
            this.btnThemCapNhat.TabIndex = 19;
            this.btnThemCapNhat.Text = "Thêm / Cập nhật";
            this.btnThemCapNhat.UseVisualStyleBackColor = true;
            this.btnThemCapNhat.Click += new System.EventHandler(this.btnThemCapNhat_Click);
            //
            // btnXoa
            //
            this.btnXoa.Location = new System.Drawing.Point(250, 218);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 30);
            this.btnXoa.TabIndex = 20;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            //
            // btnTimKiem
            //
            this.btnTimKiem.Location = new System.Drawing.Point(350, 218);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(110, 30);
            this.btnTimKiem.TabIndex = 21;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            //
            // btnHienThiTatCa
            //
            this.btnHienThiTatCa.Location = new System.Drawing.Point(470, 218);
            this.btnHienThiTatCa.Name = "btnHienThiTatCa";
            this.btnHienThiTatCa.Size = new System.Drawing.Size(120, 30);
            this.btnHienThiTatCa.TabIndex = 22;
            this.btnHienThiTatCa.Text = "Hiển thị tất cả";
            this.btnHienThiTatCa.UseVisualStyleBackColor = true;
            this.btnHienThiTatCa.Click += new System.EventHandler(this.btnHienThiTatCa_Click);
            //
            // btnMacDinh
            //
            this.btnMacDinh.Location = new System.Drawing.Point(600, 218);
            this.btnMacDinh.Name = "btnMacDinh";
            this.btnMacDinh.Size = new System.Drawing.Size(100, 30);
            this.btnMacDinh.TabIndex = 23;
            this.btnMacDinh.Text = "Mặc định";
            this.btnMacDinh.UseVisualStyleBackColor = true;
            this.btnMacDinh.Click += new System.EventHandler(this.btnMacDinh_Click);
            //
            // btnThoat
            //
            this.btnThoat.Location = new System.Drawing.Point(710, 218);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 30);
            this.btnThoat.TabIndex = 24;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            //
            // lvSinhVien
            //
            this.lvSinhVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSinhVien.CheckBoxes = true;
            this.lvSinhVien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.chMSSV, this.chHoTen, this.chLop, this.chCMND, this.chSDT,
                this.chNgaySinh, this.chGioiTinh, this.chDiaChi, this.chMonDangKy});
            this.lvSinhVien.ContextMenuStrip = this.cmsDanhSach;
            this.lvSinhVien.FullRowSelect = true;
            this.lvSinhVien.GridLines = true;
            this.lvSinhVien.Location = new System.Drawing.Point(12, 300);
            this.lvSinhVien.Name = "lvSinhVien";
            this.lvSinhVien.Size = new System.Drawing.Size(934, 290);
            this.lvSinhVien.TabIndex = 2;
            this.lvSinhVien.UseCompatibleStateImageBehavior = false;
            this.lvSinhVien.View = System.Windows.Forms.View.Details;
            this.lvSinhVien.SelectedIndexChanged += new System.EventHandler(this.lvSinhVien_SelectedIndexChanged);
            //
            // chMSSV
            //
            this.chMSSV.Text = "MSSV";
            this.chMSSV.Width = 80;
            //
            // chHoTen
            //
            this.chHoTen.Text = "Họ tên";
            this.chHoTen.Width = 140;
            //
            // chLop
            //
            this.chLop.Text = "Lớp";
            this.chLop.Width = 60;
            //
            // chCMND
            //
            this.chCMND.Text = "CMND";
            this.chCMND.Width = 90;
            //
            // chSDT
            //
            this.chSDT.Text = "SĐT";
            this.chSDT.Width = 100;
            //
            // chNgaySinh
            //
            this.chNgaySinh.Text = "Ngày sinh";
            this.chNgaySinh.Width = 90;
            //
            // chGioiTinh
            //
            this.chGioiTinh.Text = "Giới tính";
            this.chGioiTinh.Width = 60;
            //
            // chDiaChi
            //
            this.chDiaChi.Text = "Địa chỉ";
            this.chDiaChi.Width = 140;
            //
            // chMonDangKy
            //
            this.chMonDangKy.Text = "Môn đăng ký";
            this.chMonDangKy.Width = 160;
            //
            // cmsDanhSach
            //
            this.cmsDanhSach.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.cmsDanhSachXoa });
            this.cmsDanhSach.Name = "cmsDanhSach";
            this.cmsDanhSach.Size = new System.Drawing.Size(220, 26);
            //
            // cmsDanhSachXoa
            //
            this.cmsDanhSachXoa.Name = "cmsDanhSachXoa";
            this.cmsDanhSachXoa.Text = "Xóa (các) sinh viên đã tích chọn";
            this.cmsDanhSachXoa.Click += new System.EventHandler(this.cmsDanhSachXoa_Click);
            //
            // statusStrip1
            //
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsslTongSV, this.tsslFile });
            this.statusStrip1.Location = new System.Drawing.Point(0, 628);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(958, 22);
            this.statusStrip1.TabIndex = 3;
            //
            // tsslTongSV
            //
            this.tsslTongSV.Name = "tsslTongSV";
            this.tsslTongSV.Size = new System.Drawing.Size(110, 17);
            this.tsslTongSV.Text = "Tổng số sinh viên: 0";
            //
            // tsslFile
            //
            this.tsslFile.Name = "tsslFile";
            this.tsslFile.Size = new System.Drawing.Size(700, 17);
            this.tsslFile.Spring = true;
            this.tsslFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslFile.Text = "Chưa mở tập tin";
            //
            // frmSinhVien
            //
            this.ClientSize = new System.Drawing.Size(958, 650);
            this.Controls.Add(this.lvSinhVien);
            this.Controls.Add(this.gbThongTin);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.Name = "frmSinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chủ đề 3 - Quản lý sinh viên (đọc/ghi Txt - Xml - Json)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSinhVien_FormClosing);
            this.Load += new System.EventHandler(this.frmSinhVien_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            this.cmsMon.ResumeLayout(false);
            this.cmsDanhSach.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

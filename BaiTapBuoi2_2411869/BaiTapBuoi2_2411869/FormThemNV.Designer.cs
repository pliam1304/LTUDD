namespace BaiTapBuoi2_2411869
{
    partial class FormThemNV
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblLoai = new System.Windows.Forms.Label();
            this.cboLoaiNV = new System.Windows.Forms.ComboBox();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblHeSoLuong = new System.Windows.Forms.Label();
            this.txtHeSoLuong = new System.Windows.Forms.TextBox();
            this.lblSoGio = new System.Windows.Forms.Label();
            this.txtSoGio = new System.Windows.Forms.TextBox();
            this.lblTienCong = new System.Windows.Forms.Label();
            this.txtTienCong = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblLoai
            //
            this.lblLoai.AutoSize = true;
            this.lblLoai.Location = new System.Drawing.Point(20, 20);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(90, 13);
            this.lblLoai.Text = "Loai nhan vien:";
            //
            // cboLoaiNV
            //
            this.cboLoaiNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiNV.FormattingEnabled = true;
            this.cboLoaiNV.Items.AddRange(new object[] {
            "Nhan vien hop dong",
            "Nhan vien theo gio"});
            this.cboLoaiNV.Location = new System.Drawing.Point(150, 17);
            this.cboLoaiNV.Name = "cboLoaiNV";
            this.cboLoaiNV.Size = new System.Drawing.Size(200, 21);
            this.cboLoaiNV.TabIndex = 0;
            this.cboLoaiNV.SelectedIndexChanged += new System.EventHandler(this.cboLoaiNV_SelectedIndexChanged);
            //
            // lblMaNV
            //
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Location = new System.Drawing.Point(20, 60);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(55, 13);
            this.lblMaNV.Text = "Ma NV:";
            //
            // txtMaNV
            //
            this.txtMaNV.Location = new System.Drawing.Point(150, 57);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(200, 20);
            this.txtMaNV.TabIndex = 1;
            //
            // lblHoTen
            //
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(20, 100);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(50, 13);
            this.lblHoTen.Text = "Ho ten:";
            //
            // txtHoTen
            //
            this.txtHoTen.Location = new System.Drawing.Point(150, 97);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(200, 20);
            this.txtHoTen.TabIndex = 2;
            //
            // lblHeSoLuong
            //
            this.lblHeSoLuong.AutoSize = true;
            this.lblHeSoLuong.Location = new System.Drawing.Point(20, 140);
            this.lblHeSoLuong.Name = "lblHeSoLuong";
            this.lblHeSoLuong.Size = new System.Drawing.Size(75, 13);
            this.lblHeSoLuong.Text = "He so luong:";
            //
            // txtHeSoLuong
            //
            this.txtHeSoLuong.Location = new System.Drawing.Point(150, 137);
            this.txtHeSoLuong.Name = "txtHeSoLuong";
            this.txtHeSoLuong.Size = new System.Drawing.Size(200, 20);
            this.txtHeSoLuong.TabIndex = 3;
            //
            // lblSoGio
            //
            this.lblSoGio.AutoSize = true;
            this.lblSoGio.Location = new System.Drawing.Point(20, 140);
            this.lblSoGio.Name = "lblSoGio";
            this.lblSoGio.Size = new System.Drawing.Size(110, 13);
            this.lblSoGio.Text = "So gio lam trong thang:";
            //
            // txtSoGio
            //
            this.txtSoGio.Location = new System.Drawing.Point(150, 137);
            this.txtSoGio.Name = "txtSoGio";
            this.txtSoGio.Size = new System.Drawing.Size(200, 20);
            this.txtSoGio.TabIndex = 4;
            //
            // lblTienCong
            //
            this.lblTienCong.AutoSize = true;
            this.lblTienCong.Location = new System.Drawing.Point(20, 180);
            this.lblTienCong.Name = "lblTienCong";
            this.lblTienCong.Size = new System.Drawing.Size(95, 13);
            this.lblTienCong.Text = "Tien cong 1 gio:";
            //
            // txtTienCong
            //
            this.txtTienCong.Location = new System.Drawing.Point(150, 177);
            this.txtTienCong.Name = "txtTienCong";
            this.txtTienCong.Size = new System.Drawing.Size(200, 20);
            this.txtTienCong.TabIndex = 5;
            //
            // btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(150, 230);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 30);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "Dong y";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(260, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Huy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // FormThemNV
            //
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 281);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtTienCong);
            this.Controls.Add(this.lblTienCong);
            this.Controls.Add(this.txtSoGio);
            this.Controls.Add(this.lblSoGio);
            this.Controls.Add(this.txtHeSoLuong);
            this.Controls.Add(this.lblHeSoLuong);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.lblMaNV);
            this.Controls.Add(this.cboLoaiNV);
            this.Controls.Add(this.lblLoai);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormThemNV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Them nhan vien moi";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.ComboBox cboLoaiNV;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblHeSoLuong;
        private System.Windows.Forms.TextBox txtHeSoLuong;
        private System.Windows.Forms.Label lblSoGio;
        private System.Windows.Forms.TextBox txtSoGio;
        private System.Windows.Forms.Label lblTienCong;
        private System.Windows.Forms.TextBox txtTienCong;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}

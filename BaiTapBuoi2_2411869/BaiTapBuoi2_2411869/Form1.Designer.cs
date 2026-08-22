namespace BaiTapBuoi2_2411869
{
    partial class Form1
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
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.lblTimTen = new System.Windows.Forms.Label();
            this.txtTimTen = new System.Windows.Forms.TextBox();
            this.btnTimTheoTen = new System.Windows.Forms.Button();
            this.btnNhapCoDinh = new System.Windows.Forms.Button();
            this.btnThemNV = new System.Windows.Forms.Button();
            this.btnLamNhieuGioNhat = new System.Windows.Forms.Button();
            this.btnSapXepLuong = new System.Windows.Forms.Button();
            this.btnXuatTatCa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.SuspendLayout();
            //
            // dgvNhanVien
            //
            this.dgvNhanVien.AllowUserToAddRows = false;
            this.dgvNhanVien.AllowUserToDeleteRows = false;
            this.dgvNhanVien.ReadOnly = true;
            this.dgvNhanVien.Location = new System.Drawing.Point(12, 12);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.RowHeadersWidth = 30;
            this.dgvNhanVien.Size = new System.Drawing.Size(760, 350);
            this.dgvNhanVien.TabIndex = 0;
            //
            // lblTimTen
            //
            this.lblTimTen.AutoSize = true;
            this.lblTimTen.Location = new System.Drawing.Point(12, 378);
            this.lblTimTen.Name = "lblTimTen";
            this.lblTimTen.Size = new System.Drawing.Size(70, 13);
            this.lblTimTen.TabIndex = 8;
            this.lblTimTen.Text = "Ten can tim:";
            //
            // txtTimTen
            //
            this.txtTimTen.Location = new System.Drawing.Point(90, 374);
            this.txtTimTen.Name = "txtTimTen";
            this.txtTimTen.Size = new System.Drawing.Size(200, 20);
            this.txtTimTen.TabIndex = 1;
            //
            // btnTimTheoTen
            //
            this.btnTimTheoTen.Location = new System.Drawing.Point(300, 372);
            this.btnTimTheoTen.Name = "btnTimTheoTen";
            this.btnTimTheoTen.Size = new System.Drawing.Size(130, 27);
            this.btnTimTheoTen.TabIndex = 2;
            this.btnTimTheoTen.Text = "Tim theo ten";
            this.btnTimTheoTen.UseVisualStyleBackColor = true;
            this.btnTimTheoTen.Click += new System.EventHandler(this.btnTimTheoTen_Click);
            //
            // btnNhapCoDinh
            //
            this.btnNhapCoDinh.Location = new System.Drawing.Point(12, 410);
            this.btnNhapCoDinh.Name = "btnNhapCoDinh";
            this.btnNhapCoDinh.Size = new System.Drawing.Size(140, 32);
            this.btnNhapCoDinh.TabIndex = 3;
            this.btnNhapCoDinh.Text = "Nhap co dinh";
            this.btnNhapCoDinh.UseVisualStyleBackColor = true;
            this.btnNhapCoDinh.Click += new System.EventHandler(this.btnNhapCoDinh_Click);
            //
            // btnThemNV
            //
            this.btnThemNV.Location = new System.Drawing.Point(160, 410);
            this.btnThemNV.Name = "btnThemNV";
            this.btnThemNV.Size = new System.Drawing.Size(140, 32);
            this.btnThemNV.TabIndex = 4;
            this.btnThemNV.Text = "Them nhan vien";
            this.btnThemNV.UseVisualStyleBackColor = true;
            this.btnThemNV.Click += new System.EventHandler(this.btnThemNV_Click);
            //
            // btnLamNhieuGioNhat
            //
            this.btnLamNhieuGioNhat.Location = new System.Drawing.Point(308, 410);
            this.btnLamNhieuGioNhat.Name = "btnLamNhieuGioNhat";
            this.btnLamNhieuGioNhat.Size = new System.Drawing.Size(160, 32);
            this.btnLamNhieuGioNhat.TabIndex = 5;
            this.btnLamNhieuGioNhat.Text = "NV lam nhieu gio nhat";
            this.btnLamNhieuGioNhat.UseVisualStyleBackColor = true;
            this.btnLamNhieuGioNhat.Click += new System.EventHandler(this.btnLamNhieuGioNhat_Click);
            //
            // btnSapXepLuong
            //
            this.btnSapXepLuong.Location = new System.Drawing.Point(476, 410);
            this.btnSapXepLuong.Name = "btnSapXepLuong";
            this.btnSapXepLuong.Size = new System.Drawing.Size(160, 32);
            this.btnSapXepLuong.TabIndex = 6;
            this.btnSapXepLuong.Text = "Sap xep HD theo luong";
            this.btnSapXepLuong.UseVisualStyleBackColor = true;
            this.btnSapXepLuong.Click += new System.EventHandler(this.btnSapXepLuong_Click);
            //
            // btnXuatTatCa
            //
            this.btnXuatTatCa.Location = new System.Drawing.Point(644, 410);
            this.btnXuatTatCa.Name = "btnXuatTatCa";
            this.btnXuatTatCa.Size = new System.Drawing.Size(128, 32);
            this.btnXuatTatCa.TabIndex = 7;
            this.btnXuatTatCa.Text = "Xuat tat ca";
            this.btnXuatTatCa.UseVisualStyleBackColor = true;
            this.btnXuatTatCa.Click += new System.EventHandler(this.btnXuatTatCa_Click);
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnXuatTatCa);
            this.Controls.Add(this.btnSapXepLuong);
            this.Controls.Add(this.btnLamNhieuGioNhat);
            this.Controls.Add(this.btnThemNV);
            this.Controls.Add(this.btnNhapCoDinh);
            this.Controls.Add(this.btnTimTheoTen);
            this.Controls.Add(this.txtTimTen);
            this.Controls.Add(this.lblTimTen);
            this.Controls.Add(this.dgvNhanVien);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form1";
            this.Text = "Quan Ly Nhan Vien";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.Label lblTimTen;
        private System.Windows.Forms.TextBox txtTimTen;
        private System.Windows.Forms.Button btnTimTheoTen;
        private System.Windows.Forms.Button btnNhapCoDinh;
        private System.Windows.Forms.Button btnThemNV;
        private System.Windows.Forms.Button btnLamNhieuGioNhat;
        private System.Windows.Forms.Button btnSapXepLuong;
        private System.Windows.Forms.Button btnXuatTatCa;
    }
}

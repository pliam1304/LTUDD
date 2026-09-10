namespace QuanLySinhVien_ChuDe3
{
    partial class frmTimKiem
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.Label lblMSSV;
        private System.Windows.Forms.TextBox txtMSSV;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.TextBox txtLop;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnDong;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.lblMSSV = new System.Windows.Forms.Label();
            this.txtMSSV = new System.Windows.Forms.TextBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lblLop = new System.Windows.Forms.Label();
            this.txtLop = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblGhiChu
            //
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.ForeColor = System.Drawing.Color.DimGray;
            this.lblGhiChu.Location = new System.Drawing.Point(20, 15);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(320, 15);
            this.lblGhiChu.TabIndex = 0;
            this.lblGhiChu.Text = "Để trống điều kiện nào thì điều kiện đó sẽ được bỏ qua.";
            //
            // lblMSSV
            //
            this.lblMSSV.AutoSize = true;
            this.lblMSSV.Location = new System.Drawing.Point(20, 50);
            this.lblMSSV.Name = "lblMSSV";
            this.lblMSSV.Size = new System.Drawing.Size(45, 15);
            this.lblMSSV.TabIndex = 1;
            this.lblMSSV.Text = "MSSV:";
            //
            // txtMSSV
            //
            this.txtMSSV.Location = new System.Drawing.Point(110, 47);
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.Size = new System.Drawing.Size(220, 23);
            this.txtMSSV.TabIndex = 2;
            //
            // lblTen
            //
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(20, 85);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(58, 15);
            this.lblTen.TabIndex = 3;
            this.lblTen.Text = "Họ tên:";
            //
            // txtTen
            //
            this.txtTen.Location = new System.Drawing.Point(110, 82);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(220, 23);
            this.txtTen.TabIndex = 4;
            //
            // lblLop
            //
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(20, 120);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(38, 15);
            this.lblLop.TabIndex = 5;
            this.lblLop.Text = "Lớp:";
            //
            // txtLop
            //
            this.txtLop.Location = new System.Drawing.Point(110, 117);
            this.txtLop.Name = "txtLop";
            this.txtLop.Size = new System.Drawing.Size(220, 23);
            this.txtLop.TabIndex = 6;
            //
            // btnTim
            //
            this.btnTim.Location = new System.Drawing.Point(150, 160);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(85, 27);
            this.btnTim.TabIndex = 7;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            //
            // btnDong
            //
            this.btnDong.Location = new System.Drawing.Point(245, 160);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(85, 27);
            this.btnDong.TabIndex = 8;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            //
            // frmTimKiem
            //
            this.AcceptButton = this.btnTim;
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(354, 204);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.txtLop);
            this.Controls.Add(this.lblLop);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.txtMSSV);
            this.Controls.Add(this.lblMSSV);
            this.Controls.Add(this.lblGhiChu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTimKiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tìm kiếm sinh viên";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

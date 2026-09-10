namespace QuanLySinhVien_ChuDe3
{
    partial class frmThemMon
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnHuy;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTenMon = new System.Windows.Forms.Label();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTenMon
            //
            this.lblTenMon.AutoSize = true;
            this.lblTenMon.Location = new System.Drawing.Point(20, 22);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(76, 15);
            this.lblTenMon.TabIndex = 0;
            this.lblTenMon.Text = "Tên môn học:";
            //
            // txtTenMon
            //
            this.txtTenMon.Location = new System.Drawing.Point(110, 19);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(220, 23);
            this.txtTenMon.TabIndex = 1;
            //
            // btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(150, 55);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(85, 27);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Đồng ý";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            //
            // btnHuy
            //
            this.btnHuy.Location = new System.Drawing.Point(245, 55);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(85, 27);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            //
            // frmThemMon
            //
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(354, 101);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtTenMon);
            this.Controls.Add(this.lblTenMon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThemMon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm môn học";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

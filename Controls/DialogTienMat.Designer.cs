namespace QLLT.Controls
{
    partial class DialogTienMat
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.TextBox txtTien;
        private System.Windows.Forms.TableLayoutPanel tblKeys;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnNhap;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblCaption = new System.Windows.Forms.Label();
            this.txtTien = new System.Windows.Forms.TextBox();
            this.tblKeys = new System.Windows.Forms.TableLayoutPanel();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnNhap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DialogTienMat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 460);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogTienMat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhập tiền";
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(16, 14);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(200, 23);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "Số tiền:";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTien
            // 
            this.txtTien.Location = new System.Drawing.Point(16, 40);
            this.txtTien.Name = "txtTien";
            this.txtTien.ReadOnly = true;
            this.txtTien.Size = new System.Drawing.Size(326, 23);
            this.txtTien.TabIndex = 1;
            this.txtTien.Text = "0";
            this.txtTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tblKeys
            // 
            this.tblKeys.ColumnCount = 3;
            this.tblKeys.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tblKeys.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tblKeys.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tblKeys.Location = new System.Drawing.Point(16, 76);
            this.tblKeys.Name = "tblKeys";
            this.tblKeys.RowCount = 4;
            this.tblKeys.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblKeys.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblKeys.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblKeys.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblKeys.Size = new System.Drawing.Size(326, 300);
            this.tblKeys.TabIndex = 2;
            // 
            // ==== Buttons 1..9,0 (tạo trực tiếp, không helper) ====
            // 
            System.Windows.Forms.Padding pad = new System.Windows.Forms.Padding(6);
            System.Windows.Forms.DockStyle dock = System.Windows.Forms.DockStyle.Fill;
            System.Windows.Forms.FlatStyle flat = System.Windows.Forms.FlatStyle.Flat;

            this.btn1.Text = "1"; this.btn1.Tag = "1"; this.btn1.Dock = dock; this.btn1.Margin = pad; this.btn1.FlatStyle = flat; this.btn1.Click += new System.EventHandler(this.btnNum_Click);
            this.btn2.Text = "2"; this.btn2.Tag = "2"; this.btn2.Dock = dock; this.btn2.Margin = pad; this.btn2.FlatStyle = flat; this.btn2.Click += new System.EventHandler(this.btnNum_Click);
            this.btn3.Text = "3"; this.btn3.Tag = "3"; this.btn3.Dock = dock; this.btn3.Margin = pad; this.btn3.FlatStyle = flat; this.btn3.Click += new System.EventHandler(this.btnNum_Click);
            this.btn4.Text = "4"; this.btn4.Tag = "4"; this.btn4.Dock = dock; this.btn4.Margin = pad; this.btn4.FlatStyle = flat; this.btn4.Click += new System.EventHandler(this.btnNum_Click);
            this.btn5.Text = "5"; this.btn5.Tag = "5"; this.btn5.Dock = dock; this.btn5.Margin = pad; this.btn5.FlatStyle = flat; this.btn5.Click += new System.EventHandler(this.btnNum_Click);
            this.btn6.Text = "6"; this.btn6.Tag = "6"; this.btn6.Dock = dock; this.btn6.Margin = pad; this.btn6.FlatStyle = flat; this.btn6.Click += new System.EventHandler(this.btnNum_Click);
            this.btn7.Text = "7"; this.btn7.Tag = "7"; this.btn7.Dock = dock; this.btn7.Margin = pad; this.btn7.FlatStyle = flat; this.btn7.Click += new System.EventHandler(this.btnNum_Click);
            this.btn8.Text = "8"; this.btn8.Tag = "8"; this.btn8.Dock = dock; this.btn8.Margin = pad; this.btn8.FlatStyle = flat; this.btn8.Click += new System.EventHandler(this.btnNum_Click);
            this.btn9.Text = "9"; this.btn9.Tag = "9"; this.btn9.Dock = dock; this.btn9.Margin = pad; this.btn9.FlatStyle = flat; this.btn9.Click += new System.EventHandler(this.btnNum_Click);
            this.btn0.Text = "0"; this.btn0.Tag = "0"; this.btn0.Dock = dock; this.btn0.Margin = pad; this.btn0.FlatStyle = flat; this.btn0.Click += new System.EventHandler(this.btnNum_Click);

            this.tblKeys.Controls.Add(this.btn1, 0, 0);
            this.tblKeys.Controls.Add(this.btn2, 1, 0);
            this.tblKeys.Controls.Add(this.btn3, 2, 0);
            this.tblKeys.Controls.Add(this.btn4, 0, 1);
            this.tblKeys.Controls.Add(this.btn5, 1, 1);
            this.tblKeys.Controls.Add(this.btn6, 2, 1);
            this.tblKeys.Controls.Add(this.btn7, 0, 2);
            this.tblKeys.Controls.Add(this.btn8, 1, 2);
            this.tblKeys.Controls.Add(this.btn9, 2, 2);
            this.tblKeys.Controls.Add(this.btn0, 1, 3);
            // 
            // btnBack
            // 
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(16, 388);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 32);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Xóa";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(128, 388);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 32);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Xóa toàn bộ";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnNhap
            // 
            this.btnNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhap.Location = new System.Drawing.Point(256, 388);
            this.btnNhap.Name = "btnNhap";
            this.btnNhap.Size = new System.Drawing.Size(86, 32);
            this.btnNhap.TabIndex = 5;
            this.btnNhap.Text = "Nhập";
            this.btnNhap.UseVisualStyleBackColor = true;
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click);
            this.AcceptButton = this.btnNhap;
            // 
            // add controls
            // 
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.txtTien);
            this.Controls.Add(this.tblKeys);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnNhap);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

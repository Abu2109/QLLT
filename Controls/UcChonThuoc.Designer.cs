using System.Windows.Forms;

namespace QLLT.Controls
{
    partial class UcChonThuoc
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader;
        private Label lbCat;
        private Button btnCatPrev;
        private Button btnCatNext;
        private FlowLayoutPanel flpCategories; // chứa 3 nút danh mục
        private Label lbPage;
        private TableLayoutPanel tblGrid;      // 3x4 = 12 nút sản phẩm
        private FlowLayoutPanel flpPager;      // nút trang

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lbCat = new System.Windows.Forms.Label();
            this.btnCatPrev = new System.Windows.Forms.Button();
            this.btnCatNext = new System.Windows.Forms.Button();
            this.flpCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.lbPage = new System.Windows.Forms.Label();
            this.tblGrid = new System.Windows.Forms.TableLayoutPanel();
            this.flpPager = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lbCat);
            this.pnlHeader.Controls.Add(this.btnCatPrev);
            this.pnlHeader.Controls.Add(this.btnCatNext);
            this.pnlHeader.Controls.Add(this.flpCategories);
            this.pnlHeader.Controls.Add(this.lbPage);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(6);
            this.pnlHeader.Size = new System.Drawing.Size(704, 48);
            this.pnlHeader.TabIndex = 0;
            // 
            // lbCat
            // 
            this.lbCat.AutoSize = true;
            this.lbCat.Location = new System.Drawing.Point(8, 8);
            this.lbCat.Name = "lbCat";
            this.lbCat.Size = new System.Drawing.Size(70, 16);
            this.lbCat.TabIndex = 0;
            this.lbCat.Text = "Danh mục:";
            // 
            // btnCatPrev
            // 
            this.btnCatPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCatPrev.Location = new System.Drawing.Point(618, 18);
            this.btnCatPrev.Name = "btnCatPrev";
            this.btnCatPrev.Size = new System.Drawing.Size(36, 24);
            this.btnCatPrev.TabIndex = 3;
            this.btnCatPrev.Text = "<";
            this.btnCatPrev.UseVisualStyleBackColor = true;
            // 
            // btnCatNext
            // 
            this.btnCatNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCatNext.Location = new System.Drawing.Point(660, 18);
            this.btnCatNext.Name = "btnCatNext";
            this.btnCatNext.Size = new System.Drawing.Size(36, 24);
            this.btnCatNext.TabIndex = 4;
            this.btnCatNext.Text = ">";
            this.btnCatNext.UseVisualStyleBackColor = true;
            // 
            // flpCategories
            // 
            this.flpCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpCategories.Location = new System.Drawing.Point(6, 22);
            this.flpCategories.Margin = new System.Windows.Forms.Padding(0);
            this.flpCategories.Name = "flpCategories";
            this.flpCategories.Size = new System.Drawing.Size(606, 24);
            this.flpCategories.TabIndex = 1;
            // 
            // lbPage
            // 
            this.lbPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPage.AutoSize = true;
            this.lbPage.Location = new System.Drawing.Point(618, 4);
            this.lbPage.Name = "lbPage";
            this.lbPage.Size = new System.Drawing.Size(56, 16);
            this.lbPage.TabIndex = 2;
            this.lbPage.Text = "Trang: 1";
            // 
            // tblGrid
            // 
            this.tblGrid.ColumnCount = 3;
            this.tblGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tblGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tblGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tblGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblGrid.Location = new System.Drawing.Point(0, 48);
            this.tblGrid.Name = "tblGrid";
            this.tblGrid.RowCount = 4;
            this.tblGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblGrid.Size = new System.Drawing.Size(704, 396);
            this.tblGrid.TabIndex = 5;
            // 
            // flpPager
            // 
            this.flpPager.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpPager.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpPager.Location = new System.Drawing.Point(0, 444);
            this.flpPager.Name = "flpPager";
            this.flpPager.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.flpPager.Size = new System.Drawing.Size(704, 36);
            this.flpPager.TabIndex = 6;
            // 
            // UcChonThuoc
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tblGrid);
            this.Controls.Add(this.flpPager);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UcChonThuoc";
            this.Size = new System.Drawing.Size(704, 480);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}

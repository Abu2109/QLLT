using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QLLT.Forms
{
    public partial class FrmKiemTraThuoc : Form
    {
        // ĐỔI nếu máy/DB khác
        private readonly string _connStr =
            @"Data Source=LAPTOP-2M0DQDG7\SQLEXPRESS;Initial Catalog=HospitalDB;Integrated Security=True;TrustServerCertificate=True";

        private const string PLACEHOLDER = "Nhập tên thuốc hoặc mã thuốc…";

        public FrmKiemTraThuoc()
        {
            InitializeComponent();
        }

        private void FrmKiemTraThuoc_Load(object sender, EventArgs e)
        {
            SetPlaceholder(true);
            LoadGrid(null);   // nạp top 100 ban đầu
        }

        #region Placeholder helper
        private void SetPlaceholder(bool on)
        {
            if (on)
            {
                txtKeyword.ForeColor = Color.Gray;
                txtKeyword.Text = PLACEHOLDER;
            }
            else
            {
                if (txtKeyword.Text == PLACEHOLDER) txtKeyword.Text = string.Empty;
                txtKeyword.ForeColor = SystemColors.WindowText;
            }
        }

        private void txtKeyword_Enter(object sender, EventArgs e)
        {
            if (txtKeyword.Text == PLACEHOLDER) SetPlaceholder(false);
        }

        private void txtKeyword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKeyword.Text)) SetPlaceholder(true);
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var kw = txtKeyword.Text.Trim();
            if (kw == PLACEHOLDER) kw = string.Empty;
            LoadGrid(kw);
        }

        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearch.PerformClick();
            }
        }

        private void LoadGrid(string keyword)
        {
            try
            {
                using (var cn = new SqlConnection(_connStr))
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT TOP (100)
                               MaThuoc      AS [Mã],
                               TenThuoc     AS [Tên thuốc],
                               DonViTinh    AS [ĐVT],
                               SoLuongTon   AS [Tồn kho],
                               GiaThuoc     AS [Đơn giá]
                        FROM dbo.Thuoc WITH (NOLOCK)
                        /**where**/
                        ORDER BY TenThuoc";

                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        cmd.CommandText = cmd.CommandText.Replace("/**where**/",
                            "WHERE TenThuoc LIKE @kw OR CONVERT(varchar(50), MaThuoc) LIKE @kw");
                        cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    }
                    else
                    {
                        cmd.CommandText = cmd.CommandText.Replace("/**where**/", "");
                    }

                    var da = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);

                    dgvStock.DataSource = dt;
                    FormatGrid();
                    lblCount.Text = $"Kết quả: {dt.Rows.Count}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được dữ liệu.\n" + ex.Message,
                    "Kiểm tra thuốc", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            if (dgvStock.Columns.Count == 0) return;

            dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            if (dgvStock.Columns.Contains("Tên thuốc"))
                dgvStock.Columns["Tên thuốc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            if (dgvStock.Columns.Contains("Đơn giá"))
                dgvStock.Columns["Đơn giá"].DefaultCellStyle.Format = "N0";

            if (dgvStock.Columns.Contains("Tồn kho"))
                dgvStock.Columns["Tồn kho"].DefaultCellStyle.Format = "N0";
        }

        private void dgvStock_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dgvStock.Rows.Count; i++)
                dgvStock.Rows[i].HeaderCell.Value = (i + 1).ToString();

            dgvStock.AutoResizeRowHeadersWidth(
                DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void dgvStock_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvStock.Columns.Contains("Tên thuốc"))
            {
                var text = Convert.ToString(
                    dgvStock.Rows[e.RowIndex].Cells["Tên thuốc"].Value);
                if (!string.IsNullOrEmpty(text))
                {
                    try { Clipboard.SetText(text); } catch { }
                    toolTip1.Show("Đã copy tên thuốc", this, 1000);
                }
            }
        }
    }
}

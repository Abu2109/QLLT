using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLLT.DTOs; // CartItem

namespace QLLT.Controls
{
    public partial class UcChonThuoc : UserControl
    {
        // Fired khi user click 1 sản phẩm
        public event Action<CartItem> ItemChosen;

        private readonly List<string> _cats = new List<string>
        { "Thuốc ho", "Hạ sốt", "Kháng sinh", "Dạ dày", "Dị ứng", "Vitamin" };

        // dữ liệu mẫu theo danh mục
        private readonly Dictionary<string, List<CartItem>> _data =
            new Dictionary<string, List<CartItem>>();

        private int _catIndex = 0;
        private int _pageIndex = 0;
        private const int _pageSize = 12; // 3 cột x 4 hàng

        public UcChonThuoc()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            BuildFakeData();
            WireHeader();
            RenderHeader();
            RenderGrid();
        }

        // ========= fake data =========
        private void BuildFakeData()
        {
            var rnd = new Random(7);

            Action<string, int, int, int, int, string> addCat =
                (cat, baseCode, count, pmin, pmax, dvt) =>
                {
                    var list = new List<CartItem>();
                    for (int i = 1; i <= count; i++)
                    {
                        var price = rnd.Next(pmin, pmax + 1) * 1000;
                        //  ThuocId, MaThuoc, TenThuoc, DonViTinh, DonGia, GhiChu, SoLuong
                        list.Add(new CartItem(
                            baseCode + i, 52000 + baseCode + i,
                            cat + " " + i, dvt, price, null, 1));
                    }
                    _data[cat] = list;
                };

            addCat("Thuốc ho", 1000, 36, 15, 35, "Viên");
            addCat("Hạ sốt", 2000, 28, 10, 25, "Viên");
            addCat("Kháng sinh", 3000, 40, 20, 60, "Viên");
            addCat("Dạ dày", 4000, 24, 25, 55, "Viên");
            addCat("Dị ứng", 5000, 20, 18, 45, "Viên");
            addCat("Vitamin", 6000, 32, 8, 30, "Viên");
        }

        // ========= helpers =========
        private string CurrentCategory { get { return _cats[_catIndex]; } }

        private List<CartItem> CurrentList()
        {
            List<CartItem> l;
            if (_data.TryGetValue(CurrentCategory, out l)) return l;
            return new List<CartItem>();
        }

        private void WireHeader()
        {
            btnCatPrev.Click += delegate
            {
                if (_catIndex > 0)
                {
                    _catIndex--;
                    _pageIndex = 0;
                    RenderHeader();
                    RenderGrid();
                }
            };
            btnCatNext.Click += delegate
            {
                if (_catIndex < _cats.Count - 1)
                {
                    _catIndex++;
                    _pageIndex = 0;
                    RenderHeader();
                    RenderGrid();
                }
            };
        }

        private void RenderHeader()
        {
            flpCategories.SuspendLayout();
            flpCategories.Controls.Clear();

            // hiển thị 3 nút xung quanh _catIndex (nếu có)
            int from = Math.Max(0, _catIndex - 1);
            int to = Math.Min(_cats.Count - 1, _catIndex + 1);
            for (int i = from; i <= to; i++)
            {
                var b = new Button();
                b.Text = _cats[i];
                b.Height = 28;
                b.Width = 120;
                b.Margin = new Padding(6, 4, 0, 4);
                b.Tag = i;
                if (i == _catIndex) b.Font = new Font(b.Font, FontStyle.Bold);
                b.Click += delegate (object s, EventArgs e)
                {
                    _catIndex = (int)((Button)s).Tag;
                    _pageIndex = 0;
                    RenderHeader();
                    RenderGrid();
                };
                flpCategories.Controls.Add(b);
            }

            lbCat.Text = "Danh mục: " + CurrentCategory;
            lbPage.Text = "Trang: " + (_pageIndex + 1);

            btnCatPrev.Enabled = _catIndex > 0;
            btnCatNext.Enabled = _catIndex < _cats.Count - 1;

            flpCategories.ResumeLayout();
        }

        private void RenderGrid()
        {
            tblGrid.SuspendLayout();
            tblGrid.Controls.Clear();

            // khởi tạo 12 button trống
            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    var btn = new Button();
                    btn.Dock = DockStyle.Fill;
                    btn.Margin = new Padding(12);
                    btn.BackColor = Color.AliceBlue;
                    btn.Tag = null;
                    btn.Click += OnDrugClick;
                    tblGrid.Controls.Add(btn, c, r);
                }
            }

            var list = CurrentList();
            int start = _pageIndex * _pageSize;

            for (int i = 0; i < _pageSize; i++)
            {
                var ctrl = tblGrid.Controls[i] as Button;
                int k = start + i;
                if (k < list.Count)
                {
                    var it = list[k];
                    ctrl.Tag = it;
                    ctrl.Enabled = true;
                    ctrl.Text = it.TenThuoc + Environment.NewLine + it.MaThuoc;
                }
                else
                {
                    ctrl.Tag = null;
                    ctrl.Enabled = false;
                    ctrl.Text = "";
                }
            }

            // pager
            flpPager.Controls.Clear();

            var btnPrev = new Button();
            btnPrev.Text = "<";
            btnPrev.Width = 36; btnPrev.Height = 26;
            btnPrev.Enabled = (_pageIndex > 0);
            btnPrev.Click += delegate { _pageIndex--; RenderHeader(); RenderGrid(); };

            var lb = new Label();
            lb.AutoSize = true;
            lb.Text = " " + (_pageIndex + 1) + " ";
            lb.Margin = new Padding(6, 6, 6, 6);

            var btnNext = new Button();
            btnNext.Text = ">";
            btnNext.Width = 36; btnNext.Height = 26;
            btnNext.Enabled = (start + _pageSize < list.Count);
            btnNext.Click += delegate { _pageIndex++; RenderHeader(); RenderGrid(); };

            // FlowDirection RightToLeft -> add theo thứ tự: Next, Label, Prev
            flpPager.Controls.Add(btnNext);
            flpPager.Controls.Add(lb);
            flpPager.Controls.Add(btnPrev);

            lbPage.Text = "Trang: " + (_pageIndex + 1);
            tblGrid.ResumeLayout();
        }

        private void OnDrugClick(object sender, EventArgs e)
        {
            var b = sender as Button;
            if (b == null || b.Tag == null) return;

            var it = (CartItem)b.Tag;

            // Mặc định SL = 1; nếu bạn có form nhập SL thì mở ra
            int qty = AskQuantity(1);
            if (qty <= 0) return;

            var add = new CartItem(it.ThuocId, it.MaThuoc, it.TenThuoc,
                                   it.DonViTinh, it.DonGia, null, qty);

            if (ItemChosen != null) ItemChosen(add);
        }

        private int AskQuantity(int current)
        {
            // Nếu bạn CHƯA có DialogNhapSoLuong: trả luôn current (1)
            // return current;

            // Nếu đã có DialogNhapSoLuong, bật form để nhập số
            try
            {
                using (Form f = new DialogNhapSoLuong())
                {
                    try
                    {
                        var p = f.GetType().GetProperty("Quantity") ?? f.GetType().GetProperty("SoLuong");
                        if (p != null && p.CanWrite) p.SetValue(f, current, null);
                    }
                    catch { }

                    if (f.ShowDialog(this) != DialogResult.OK)
                        return 0;

                    try
                    {
                        var p = f.GetType().GetProperty("Quantity") ?? f.GetType().GetProperty("SoLuong");
                        if (p != null)
                        {
                            object v = p.GetValue(f, null);
                            int x;
                            if (v is int) return (int)v;
                            if (int.TryParse(Convert.ToString(v), out x)) return x;
                        }
                    }
                    catch { }

                    NumericUpDown nud = FindNud(f.Controls);
                    if (nud != null) return (int)nud.Value;
                }
            }
            catch
            {
                // fallback nếu không có DialogNhapSoLuong
                return current;
            }
            return current;
        }

        private NumericUpDown FindNud(Control.ControlCollection col)
        {
            foreach (Control c in col)
            {
                var n = c as NumericUpDown;
                if (n != null) return n;
                if (c.HasChildren)
                {
                    var k = FindNud(c.Controls);
                    if (k != null) return k;
                }
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppThuVien
{
    public partial class ThemSach : Form
    {
        QuanLyThuVienEntities db = new QuanLyThuVienEntities();
        public ThemSach()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var rs = new MuonSach
            {
                MaSach = txtMa.Text,
                TenSach = txtTen.Text,
                SoLuong = int.Parse(txtSL.Text),
                LoaiSach = cbbLoai.Text,
                TacGia = txtTG.Text
            };
            db.MuonSaches.Add(rs);
            db.SaveChanges();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ThemSach_Load(object sender, EventArgs e)
        {
            var lst = db.LoaiSaches.ToList();
            foreach (var item in lst)
            {
                cbbLoai.Items.Add(new { Text = item.LoaiSach1, Value = "1" });
            }

            cbbLoai.DisplayMember = "Text";
            cbbLoai.ValueMember = "Value";
        }
    }
}

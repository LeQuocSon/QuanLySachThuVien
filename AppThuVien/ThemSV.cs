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
    public partial class ThemSV : Form
    {
        QuanLyThuVienEntities db = new QuanLyThuVienEntities();
        public ThemSV()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var rs = new SinhVien
            {
                Hoten = txtName.Text,
                MSSV = txtMSSV.Text,
                Khoa = cbbKhoa.Text,
            };
            db.SinhViens.Add(rs);
            db.SaveChanges();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ThemSV_Load_1(object sender, EventArgs e)
        {
            var lst = db.Khoas.ToList();
            foreach (var item in lst)
            {
                cbbKhoa.Items.Add(new { Text = item.TenKhoa, Value = "1" });
            }

            cbbKhoa.DisplayMember = "Text";
            cbbKhoa.ValueMember = "Value";
        }
    }
}

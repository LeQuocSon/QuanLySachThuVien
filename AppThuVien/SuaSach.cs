using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppThuVien
{
    public partial class SuaSach : Form
    {
        QuanLyThuVienEntities db = new QuanLyThuVienEntities();
        private string ID;
        public SuaSach(string id)
        {
            this.ID = id;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var result = db.MuonSaches.Find(ID);
            result.TenSach = txtTen.Text;
            result.SoLuong = int.Parse(txtSL.Text);
            result.LoaiSach = cbbLoai.Text;
            result.TacGia = txtTG.Text;
            db.Entry(result).State = EntityState.Modified;
            db.SaveChanges();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SuaSach_Load(object sender, EventArgs e)
        {
            var rs = db.MuonSaches.Find(ID);
            txtMa.Text = rs.MaSach;
            txtTen.Text = rs.TenSach;
            txtSL.Text = rs.SoLuong.ToString();
            cbbLoai.Text = rs.LoaiSach;
            txtTG.Text = rs.TacGia;

            var lst = db.LoaiSaches.ToList();
            foreach (var item in lst)
            {
                cbbLoai.Items.Add(new { Text = item.TenSach, Value = "1" });
            }

            cbbLoai.DisplayMember = "Text";
            cbbLoai.ValueMember = "Value";

            txtMa.Enabled = false;
        }
    }
}

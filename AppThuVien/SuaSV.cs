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
    public partial class SuaSV : Form
    {
        QuanLyThuVienEntities db = new QuanLyThuVienEntities();
        private int ID;
        public SuaSV(int id)
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var result = db.SinhViens.Find(ID);
            result.Hoten = txtName.Text;
            result.MSSV = txtMSSV.Text;
            result.Khoa = cbbKhoa.Text;
            db.Entry(result).State = EntityState.Modified;
            db.SaveChanges();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SuaSV_Load(object sender, EventArgs e)
        {
            var result = db.SinhViens.Find(ID);
            txtName.Text = result.Hoten;
            txtMSSV.Text = result.MSSV;
            cbbKhoa.Text = result.Khoa;

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

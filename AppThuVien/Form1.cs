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
    public partial class Form1 : Form
    {
        QuanLyThuVienEntities db = new QuanLyThuVienEntities();
        public Form1()
        {
            InitializeComponent();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                SuaSV frm = new SuaSV(id);
                frm.ShowDialog();
                load();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSV frm = new ThemSV();
            frm.ShowDialog();
            load();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            load();
        }

        public void load()
        {
            QuanLyThuVienEntities db = new QuanLyThuVienEntities();
            var lst = db.SinhViens.ToList();
            string test = lst.FirstOrDefault().MSSV;
            dataGridView1.DataSource = lst;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Họ tên";
            dataGridView1.Columns[2].HeaderText = "MSSV";
            dataGridView1.Columns[3].HeaderText = "Khoa";

            dataGridView1.Columns[3].Width = 120;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                var result = db.SinhViens.Find(id);
                db.SinhViens.Remove(result);
                db.SaveChanges();
                load();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnmuon_Click(object sender, EventArgs e)
        {
            ThuVien frm = new ThuVien();
            frm.ShowDialog();
        }

    }
}

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
        public Form1()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
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
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnmuon_Click(object sender, EventArgs e)
        {
            
        }

    }
}

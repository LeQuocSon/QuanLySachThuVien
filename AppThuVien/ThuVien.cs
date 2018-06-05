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
    public partial class ThuVien : Form
    {
        QuanLyThuVienEntities db = new QuanLyThuVienEntities();
        public ThuVien()
        {
            InitializeComponent();
        }
        private void loadsach()
        {
            QuanLyThuVienEntities db = new QuanLyThuVienEntities();
            var lst = db.MuonSaches.ToList();
            dataGridView1.DataSource = lst;

            dataGridView1.Columns[0].HeaderText = "Mã Sách";
            dataGridView1.Columns[1].HeaderText = "Tên sách";
            dataGridView1.Columns[2].HeaderText = "Số lượng";
            dataGridView1.Columns[3].HeaderText = "Loại sách";
            dataGridView1.Columns[4].HeaderText = "Tác giả";
        }
        private void ThuVien_Load(object sender, EventArgs e)
        {
            loadsach();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemSach frm = new ThemSach();
            frm.ShowDialog();
            loadsach();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                var rs = db.MuonSaches.Find(id);
                db.MuonSaches.Remove(rs);
                db.SaveChanges();
                loadsach();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                SuaSach frm = new SuaSach(id);
                frm.ShowDialog();
                loadsach();
            }
        }
    }
}

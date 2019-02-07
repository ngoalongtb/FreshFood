using FreshFood.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreshFood.Screen
{
    public partial class CategoryForm : Form
    {
        private BindingSource bds = new BindingSource();
        private AppDB db = new AppDB();

        public CategoryForm()
        {
            InitializeComponent();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            LoadDtgv();
            dtgv.DataSource = bds;
            ChangeHeader();
            LoadDataBinding();
        }

        public void LoadDtgv()
        {
            bds.DataSource = db.Categories.Select(x => new { x.Id, x.Name }).ToList();
        }
        public void ChangeHeader()
        {
            dtgv.Columns["Id"].HeaderText = "Mã danh mục";
            dtgv.Columns["Name"].HeaderText = "Tên danh mục";
        }
        public void LoadDataBinding()
        {
            txtId.DataBindings.Add("Text", dtgv.DataSource, "Id", true, DataSourceUpdateMode.Never);
            txtTen.DataBindings.Add("Text", dtgv.DataSource, "Name", true, DataSourceUpdateMode.Never);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                Category category = db.Categories.Find(int.Parse(txtId.Text));
                category.Name = txtTen.Text;
                db.SaveChanges();
                MessageBox.Show("Cập nhật thành công");
                LoadDtgv();
            }
            catch (Exception)
            {
                MessageBox.Show("Cập nhật không thành công. Vui lòng kiểm tra lại");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.Name = txtTen.Text;

            try
            {
                db.Categories.Add(category);
                db.SaveChanges();
                MessageBox.Show("Thêm mới thành công");
                LoadDtgv();
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm mới không thành công. Vui lòng kiểm tra lại");
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa",
                                     "Xác nhận!!",
                                     MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {


                try
                {
                    Category category = db.Categories.Find(int.Parse(txtId.Text));
                    db.Categories.Remove(category);
                    db.SaveChanges();
                    MessageBox.Show("Xóa thành công");
                    LoadDtgv();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể xóa");
                }
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadDtgv();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            bds.DataSource = db.Categories.Where(x => x.Name.Contains(txtTimKiem.Text) || x.Id.ToString().Contains(txtTimKiem.Text)).Select(x => new { x.Id, x.Name }).ToList();
        }

    }
}

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
    public partial class ProductForm : Form
    {
        private BindingSource bds = new BindingSource();
        private AppDB db = new AppDB();
        private void ProductForm_Load(object sender, EventArgs e)
        {
            LoadDtgv();
            dtgv.DataSource = bds;
            ChangeHeader();
            LoadDataBinding();
        }
        public void LoadDtgv()
        {
            bds.DataSource = db.Products.Select(x => new { x.Id, x.Name, x.Image, x.Description, x.CategoryId, x.Price, x.ExpirationDays, x.SupplierId , x.Category, x.Supplier }).ToList();
        }
        public void ChangeHeader()
        {
            dtgv.Columns["Id"].HeaderText = "Mã sản phẩm";
            dtgv.Columns["Name"].HeaderText = "Tên sản phẩm";
            dtgv.Columns["Image"].HeaderText = "Hình ảnh";
            dtgv.Columns["Description"].HeaderText = "Mô tả";
            dtgv.Columns["CategoryId"].HeaderText = "Mã danh mục";
            dtgv.Columns["Price"].HeaderText = "Giá";
            dtgv.Columns["SupplierId"].HeaderText = "Mã nhà cung cấp";
            dtgv.Columns["Category"].HeaderText = "Danh mục";
            dtgv.Columns["Supplier"].HeaderText = "Nhà cung cấp";
        }
        public void LoadDataBinding()
        {
            txtMa.DataBindings.Add("Text", dtgv.DataSource, "Id", true, DataSourceUpdateMode.Never);
            txtTen.DataBindings.Add("Text", dtgv.DataSource, "Name", true, DataSourceUpdateMode.Never);
        }
        public ProductForm()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

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
                    Product product = db.Products.Find(int.Parse(txtMa.Text));
                    db.Products.Remove(product);
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

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = db.Products.Find(int.Parse(txtMa.Text));
                product.Name = txtTen.Text;
                product.Image = txtImage.Text;
                product.Description = txtDescription.Text;
                product.CategoryId = int.Parse(txtCategoryId.Text);
                product.Price = double.Parse(txtPrice.Text);
                product.ExpirationDays = int.Parse(dtpkHanSuDung.Text);
                db.SaveChanges();
                MessageBox.Show("Cập nhật thành công");
                LoadDtgv();
            }
            catch (Exception)
            {
                MessageBox.Show("Cập nhật không thành công. Vui lòng kiểm tra lại");
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadDtgv();
        }

    }
}

using FreshFood.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
        private OpenFileDialog open = new OpenFileDialog();
        private void ProductForm_Load(object sender, EventArgs e)
        {
            LoadDtgv();
            dtgv.DataSource = bds;
            LoadMore();
            ChangeHeader();
            LoadDataBinding();
        }
        public void LoadDtgv()
        {
            bds.DataSource = db.Products.Select(x => new { x.Id, x.Name, x.Image, x.Description, CategoryName = x.Category.Name, x.Price, x.ExpirationDays, SupplierName = x.Supplier.Name, x }).ToList();
        }
        public void ChangeHeader()
        {
            dtgv.Columns["Id"].HeaderText = "Mã sản phẩm";
            dtgv.Columns["Name"].HeaderText = "Tên sản phẩm";
            dtgv.Columns["Image"].HeaderText = "Hình ảnh";
            dtgv.Columns["Description"].HeaderText = "Mô tả";
            dtgv.Columns["Price"].HeaderText = "Giá";
            dtgv.Columns["CategoryName"].HeaderText = "Danh mục";
            dtgv.Columns["SupplierName"].HeaderText = "Nhà cung cấp";
            dtgv.Columns["ExpirationDays"].HeaderText = "Hạn sử dụng";
        }
        public void LoadDataBinding()
        {
            txtMa.DataBindings.Add("Text", dtgv.DataSource, "Id", true, DataSourceUpdateMode.Never);
            txtTen.DataBindings.Add("Text", dtgv.DataSource, "Name", true, DataSourceUpdateMode.Never);
            txtPrice.DataBindings.Add("Text", dtgv.DataSource, "Price", true, DataSourceUpdateMode.Never);
            txtHanSuDung.DataBindings.Add("Text", dtgv.DataSource, "ExpirationDays", true, DataSourceUpdateMode.Never);

            cbxDanhMuc.DataBindings.Add("SelectedValue", dtgv.DataSource, "x.CategoryId", true, DataSourceUpdateMode.Never);
            cbxNhaCungCap.DataBindings.Add("SelectedValue", dtgv.DataSource, "x.SupplierId", true, DataSourceUpdateMode.Never);
        }
        public void LoadMore()
        {
            cbxDanhMuc.DataSource = db.Categories.ToList();
            cbxDanhMuc.DisplayMember = "Name";
            cbxDanhMuc.ValueMember = "Id";

            cbxNhaCungCap.DataSource = db.Suppliers.ToList();
            cbxNhaCungCap.DisplayMember = "Name";
            cbxNhaCungCap.ValueMember = "Id";
        }

        public void HideColumn()
        {
            dtgv.Columns["x"].Visible = false;
        }

        public ProductForm()
        {
            InitializeComponent();
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
            try
            {
                Product product = new Product();
                product.Name = txtTen.Text;
                product.Image = ConvertImageToBinary(Image.FromFile(open.FileName));
                product.Description = txtDescription.Text;
                product.CategoryId = (int)cbxDanhMuc.SelectedValue;
                product.SupplierId = (int)cbxNhaCungCap.SelectedValue;
                product.Price = txtPrice.Text;
                product.ExpirationDays = int.Parse(txtHanSuDung.Text);
                db.Products.Add(product);
                db.SaveChanges();
                MessageBox.Show("Tạo mới thành công");
                LoadDtgv();
            }
            catch (Exception)
            {
                MessageBox.Show("Tạo mới không thành công. Vui lòng kiểm tra lại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = db.Products.Find(int.Parse(txtMa.Text));
                product.Name = txtTen.Text;
                product.Image = ConvertImageToBinary(Image.FromFile(open.FileName));
                product.Description = txtDescription.Text;
                product.CategoryId = (int)cbxDanhMuc.SelectedValue;
                product.SupplierId = (int)cbxNhaCungCap.SelectedValue;
                product.Price = txtPrice.Text;
                product.ExpirationDays = int.Parse(txtHanSuDung.Text);
                db.SaveChanges();
                MessageBox.Show("Cập nhật thành công");
                LoadDtgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật không thành công. Vui lòng kiểm tra lại");
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadDtgv();
        }

        byte[] ConvertImageToBinary(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            open.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pnImage.BackgroundImage = Image.FromFile(open.FileName);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            bds.DataSource = db.Products.Where(x => x.Name.Contains(txtTimKiem.Text) || x.Id.ToString().Contains(txtTimKiem.Text)).Select(x => new { x.Id, x.Name, x.Image, x.Description, CategoryName = x.Category.Name, x.Price, x.ExpirationDays, SupplierName = x.Supplier.Name, x }).ToList();
        }
    }
}

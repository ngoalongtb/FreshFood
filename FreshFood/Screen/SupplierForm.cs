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
    public partial class SupplierForm : Form
    {
        private BindingSource bds = new BindingSource();
        private AppDB db = new AppDB();

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            LoadDtgv();
            dtgv.DataSource = bds;
            ChangeHeader();
            LoadDataBinding();
        }
        
        public void LoadDtgv()
        {
            bds.DataSource = db.Suppliers.Select(x => new { x.Id, x.Name, x.PhoneNumber, x.Email, x.Description }).ToList();
        }
        public void ChangeHeader()
        {
            dtgv.Columns["Id"].HeaderText = "Mã nhà cung cấp";
            dtgv.Columns["Name"].HeaderText = "Tên Nhà cung cấp";
            dtgv.Columns["PhoneNumber"].HeaderText = "Số điện Thoại";
            dtgv.Columns["Email"].HeaderText = "Địa chỉ Email";
            dtgv.Columns["Description"].HeaderText = "Mô tả";
        }
        public void LoadDataBinding()
        {
            txtMa.DataBindings.Add("Text", dtgv.DataSource, "Id", true, DataSourceUpdateMode.Never);
            txtTen.DataBindings.Add("Text", dtgv.DataSource, "Name", true, DataSourceUpdateMode.Never);
        }
        public SupplierForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();
            supplier.Name = txtTen.Text;
            supplier.PhoneNumber = txtPhoneNumber.Text;
            supplier.Email = txtEmail.Text;
            supplier.Description = txtDescription.Text;
            //customer.Username = txtUserName.Text;

            try
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();
                MessageBox.Show("Thêm mới thành công");
                LoadDtgv();
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm mới không thành công. Vui lòng kiểm tra lại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                Supplier supplier = db.Suppliers.Find(int.Parse(txtMa.Text));
                supplier.Name = txtTen.Text;
                supplier.PhoneNumber = txtPhoneNumber.Text;
                supplier.Email = txtEmail.Text;
                supplier.Description = txtDescription.Text;
                db.SaveChanges();
                MessageBox.Show("Cập nhật thành công");
                LoadDtgv();
            }
            catch (Exception)
            {
                MessageBox.Show("Cập nhật không thành công. Vui lòng kiểm tra lại");
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
                    //Customer customer = db.Customers.Find(int.Parse(txtMa.Text));
                    //db.Customers.Remove(customer);
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
            bds.DataSource = db.Suppliers.Where(x => x.Name.Contains(txtTimKiem.Text) || x.Id.ToString().Contains(txtTimKiem.Text)).Select(x => new { x.Id, x.Name, x.PhoneNumber, x.Email, x.Description }).ToList();
        }
    }
}

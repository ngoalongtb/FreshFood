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
    public partial class CustomerForm : Form
    {
        private BindingSource bds = new BindingSource();
        private AppDB db = new AppDB();

        public void LoadDtgv()
        {
            bds.DataSource = db.Customers.Select(x => new { x.Id, x.Name, x.PhoneNumber, x.Email, x.Description, x.Username }).ToList();
        }
        public void ChangeHeader()
        {
            dtgv.Columns["Id"].HeaderText = "Mã khách hàng";
            dtgv.Columns["Name"].HeaderText = "Tên khách hàng";
            dtgv.Columns["PhoneNumber"].HeaderText = "Số điện Thoại";
            dtgv.Columns["Email"].HeaderText = "Địa chỉ Email";
            dtgv.Columns["Description"].HeaderText = "Mô tả";
            dtgv.Columns["Username"].HeaderText = "Tên người dùng";
        }
        public void LoadDataBinding()
        {
            txtMa.DataBindings.Add("Text", dtgv.DataSource, "Id", true, DataSourceUpdateMode.Never);
            txtTenKhachHang.DataBindings.Add("Text", dtgv.DataSource, "Name", true, DataSourceUpdateMode.Never);
            txtPhoneNumber.DataBindings.Add("Text", dtgv.DataSource, "PhoneNumber", true, DataSourceUpdateMode.Never);
            txtemail.DataBindings.Add("Text", dtgv.DataSource, "Email", true, DataSourceUpdateMode.Never);
            txtUser.DataBindings.Add("Text", dtgv.DataSource, "Username", true, DataSourceUpdateMode.Never);
            txtDescription.DataBindings.Add("Text", dtgv.DataSource, "Description", true, DataSourceUpdateMode.Never);

        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            LoadDtgv();
            dtgv.DataSource = bds;
            ChangeHeader();
            LoadDataBinding();
        }
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.Name = txtTenKhachHang.Text;
            customer.PhoneNumber = txtPhoneNumber.Text;
            customer.Email = txtemail.Text;
            customer.Description = txtDescription.Text;

            User user = new User();
            user.Username = txtUser.Text;
            user.Password = "12345";
            customer.User = user;
            try
            {
                db.Customers.Add(customer);
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
                Customer customer = db.Customers.Find(int.Parse(txtMa.Text));
                customer.Name = txtTenKhachHang.Text;
                customer.PhoneNumber = txtPhoneNumber.Text;
                customer.Email = txtemail.Text;
                customer.Description = txtDescription.Text;
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
                    Customer customer = db.Customers.Find(int.Parse(txtMa.Text));
                    db.Customers.Remove(customer);
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
            bds.DataSource = db.Customers.Where(x => x.Name.Contains(txtTimKiem.Text) || x.Id.ToString().Contains(txtTimKiem.Text)).Select(x => new { x.Id, x.Name, x.PhoneNumber, x.Email, x.Description, x.Username }).ToList();
        }
    }
}

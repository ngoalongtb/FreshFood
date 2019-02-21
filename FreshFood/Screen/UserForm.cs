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
    public partial class UserForm : Form
    {
        private BindingSource bds = new BindingSource();
        private AppDB db = new AppDB();

        public void LoadDtgv()
        {
            bds.DataSource = db.Users.Select(x => new { x.Username, x.PhoneNumber, x.Email, x.Fullname, x.BirthDate }).ToList();
        }
        public void ChangeHeader()
        {
            dtgv.Columns["Username"].HeaderText = "Tên người dùng";
            //dtgv.Columns["UserType"].HeaderText = "Loại tài khoản";
            dtgv.Columns["Fullname"].HeaderText = "Tên đầy đủ";
            dtgv.Columns["BirthDate"].HeaderText = "Ngày sinh";
            dtgv.Columns["Email"].HeaderText = "Địa chỉ email";
            dtgv.Columns["PhoneNumber"].HeaderText = "Số điện thoại";

        }
        public void LoadDataBinding()
        {
            txtTen.DataBindings.Add("Text", dtgv.DataSource, "Username", true, DataSourceUpdateMode.Never);
            txtPassword.DataBindings.Add("Text", dtgv.DataSource, "password", true, DataSourceUpdateMode.Never);
        }
        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            LoadDtgv();
            dtgv.DataSource = bds;
            ChangeHeader();
            LoadDataBinding();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpkNgaySinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            User user = db.Users.Find(int.Parse(txtTen.Text));
            user.Username = txtTen.Text;
            user.Password = txtPassword.Text;
            user.UserType = int.Parse(txtUserType.Text);
            user.Fullname = txtFullName.Text;
            user.BirthDate = dtpkNgaySinh.Value;
            user.Email = txtEmail.Text;
            user.PhoneNumber = txtPhoneNumber.Text;
            db.SaveChanges();
            //customer.Username = txtUserName.Text;

            try
            {
                db.Users.Add(user);
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
                User user = db.Users.Find(int.Parse(txtTen.Text));
                user.Username = txtTen.Text;
                user.Password = txtPassword.Text;
                user.UserType = int.Parse(txtUserType.Text);
                user.Fullname = txtFullName.Text;
                user.BirthDate = dtpkNgaySinh.Value;
                user.Email = txtEmail.Text;
                user.PhoneNumber = txtPhoneNumber.Text;
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
                    Customer customer = db.Customers.Find(int.Parse(txtTen.Text));
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
    }
}

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
            bds.DataSource = db.Users.Select(x => new { x.Username, x.PhoneNumber, x.Email, x.Fullname, x.BirthDate, UserType = x.UserType == 0? "Admin": "Customer" }).ToList();
        }
        public void ChangeHeader()
        {
            dtgv.Columns["Username"].HeaderText = "Tên người dùng";
            dtgv.Columns["UserType"].HeaderText = "Loại tài khoản";
            dtgv.Columns["Fullname"].HeaderText = "Tên đầy đủ";
            dtgv.Columns["BirthDate"].HeaderText = "Ngày sinh";
            dtgv.Columns["Email"].HeaderText = "Địa chỉ email";
            dtgv.Columns["PhoneNumber"].HeaderText = "Số điện thoại";
        }
        public void LoadDataBinding()
        {
            txtTen.DataBindings.Add("Text", dtgv.DataSource, "Username", true, DataSourceUpdateMode.Never);
            cbxUserType.DataBindings.Add("Text", dtgv.DataSource, "UserType", true, DataSourceUpdateMode.Never);
            txtFullName.DataBindings.Add("Text", dtgv.DataSource, "Fullname", true, DataSourceUpdateMode.Never);
            dtpkNgaySinh.DataBindings.Add("Value", dtgv.DataSource, "BirthDate", true, DataSourceUpdateMode.Never);
            txtEmail.DataBindings.Add("Text", dtgv.DataSource, "Email", true, DataSourceUpdateMode.Never);
            txtPhoneNumber.DataBindings.Add("Text", dtgv.DataSource, "PhoneNumber", true, DataSourceUpdateMode.Never);
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User();
                user.Username = txtTen.Text;
                user.Password = txtPassword.Text;
                user.UserType = cbxUserType.Text == "Admin" ? 1 : 0;
                user.Fullname = txtFullName.Text;
                user.BirthDate = dtpkNgaySinh.Value;
                user.Email = txtEmail.Text;
                user.PhoneNumber = txtPhoneNumber.Text;
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
                User user = db.Users.Find(txtTen.Text);
                user.Password = txtPassword.Text;
                user.UserType = cbxUserType.Text == "Admin" ? 1 : 0;
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
                    User user = db.Users.Find(txtTen.Text);
                    db.Users.Remove(user);
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
            bds.DataSource = db.Users.Where(x => x.Username.Contains(txtTimKiem.Text) || x.Fullname.ToString().Contains(txtTimKiem.Text)).Select(x => new { x.Username, x.PhoneNumber, x.Email, x.Fullname, x.BirthDate, UserType = x.UserType == 0 ? "Admin" : "Customer" }).ToList();
        }
    }
}

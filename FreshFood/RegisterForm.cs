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

namespace FreshFood
{
    public partial class RegisterForm : Form
    {
        private AppDB db = new AppDB();
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void lblClose_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Tên đăng nhập không được để trống");
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Mật khẩu không được để trống");
                return;
            }
            if (txtPassword.Text != txtRePassword.Text)
            {
                MessageBox.Show("Mật khẩu không khớp");
                return;
            }
            try
            {
                User user = new User();
                user.Password = txtPassword.Text;
                user.Username = txtUsername.Text;
                user.UserType = 0;

                db.Users.Add(user);
                db.SaveChanges();
                MessageBox.Show("Đăng ký thành công");
            }
            catch (Exception)
            {
                MessageBox.Show("Tài khoản đã tồn tại");
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

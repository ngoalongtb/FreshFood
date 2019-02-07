using FreshFood.AppCode;
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
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        private AppDB db = new AppDB();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var loginQuery = db.Users.Where(x => x.Username == txtUsername.Text && x.Password == txtPassword.Text);
            if (loginQuery.Count() > 0)
            {
                this.Hide();
                User loginAccount = loginQuery.First();
                Session.LoginAccount = loginAccount;
                ManagerForm f = new ManagerForm();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác. Vui lòng kiểm tra lại!!!");
            }
        }

        private void linkLabel1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            new RegisterForm().ShowDialog();
            this.Show();
        }
    }
}

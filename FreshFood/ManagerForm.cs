using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using FreshFood.AppCode;
using FreshFood.Screen;

namespace FreshFood
{
    public partial class ManagerForm : DevExpress.XtraBars.Ribbon.RibbonForm, Triggerable
    {
        public ManagerForm()
        {
            InitializeComponent();
            Trigger(ScreenName.HOME);
            AppState.ManagerForm = this;
            //string tenLoaiTaiKhoan = Session.LoginAccount.LoaiTaiKhoan.TenLoaiTaiKhoan;
            //if (tenLoaiTaiKhoan.Equals(Commons.Manager, StringComparison.CurrentCultureIgnoreCase))
            //{
            //    //btnDangKy.Enabled = false;
            //    //btnTaiKhoan.Enabled = false;
            //    //btnLoaiTaiKhoan.Enabled = false;
            //    //btnDangKyOnline.Enabled = false;
            //}
            //if (tenLoaiTaiKhoan.Equals(Commons.Admin, StringComparison.CurrentCultureIgnoreCase))
            //{
            //    btnDangKy.Enabled = false;
            //    btnHopDong.Enabled = false;
            //    btnDanhMuc.Enabled = false;
            //    btnDichVu.Enabled = false;
            //    btnThongKeTheoDichVu.Enabled = false;
            //    btnThongKeTheoKhachHang.Enabled = false;
            //    btnThongKeTheoNhanVien.Enabled = false;
            //    btnDangKyOnline.Enabled = false;
            //}
            //if (tenLoaiTaiKhoan.Equals(Commons.Staff, StringComparison.CurrentCultureIgnoreCase))
            //{
            //    //btnTaiKhoan.Enabled = false;
            //    btnDanhMuc.Enabled = false;
            //    btnDichVu.Enabled = false;
            //    btnLoaiTaiKhoan.Enabled = false;
            //    btnThongKeTheoDichVu.Enabled = false;
            //    btnThongKeTheoKhachHang.Enabled = false;
            //    btnThongKeTheoNhanVien.Enabled = false;
            //    btnDangKyOnline.Enabled = false;
            //}
            //if (tenLoaiTaiKhoan.Equals(Commons.Customer, StringComparison.CurrentCultureIgnoreCase))
            //{
            //    btnTaiKhoan.Enabled = false;
            //    btnDanhMuc.Enabled = false;
            //    //btnDichVu.Enabled = false;
            //    btnDangKy.Enabled = false;
            //    btnHopDong.Enabled = false;
            //    btnLoaiTaiKhoan.Enabled = false;
            //    btnThongKeTheoDichVu.Enabled = false;
            //    btnThongKeTheoKhachHang.Enabled = false;
            //    btnThongKeTheoNhanVien.Enabled = false;
            //}
        }

        public void Trigger()
        {
            throw new NotImplementedException();
        }

        public void Trigger(string screen)
        {
            Form form = null;

            switch (screen)
            {
                case ScreenName.HOME:
                    form = new HomeForm();
                    break;
                case ScreenName.CATEGORY:
                    form = new CategoryForm();
                    break;
                case ScreenName.USER_INFO:
                    form = new UserInfoForm();
                    break;
                case ScreenName.CUSTOMER:
                    form = new CustomerForm();
                    break;
                case ScreenName.SUPPLIER:
                    form = new SupplierForm();
                    break;
                case ScreenName.PRODUCT:
                    form = new ProductForm();
                    break;
                case ScreenName.USER:
                    form = new UserForm();
                    break;
                case ScreenName.STUDENT:
                    form = new StudentForm();
                    break;
                default:
                    break;
            }

            form.MdiParent = this;
            form.Show();
        }

        public void Trigger(string screen, object data)
        {
            throw new NotImplementedException();
        }

        private void btnHome_ItemClick(object sender, ItemClickEventArgs e)
        {
            Trigger(ScreenName.HOME);
        }

        private void btnUserInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            Trigger(ScreenName.USER_INFO);
        }

        private void btnCustomer_ItemClick(object sender, ItemClickEventArgs e)
        {
            Trigger(ScreenName.CUSTOMER);
        }

        private void btnSupplier_ItemClick(object sender, ItemClickEventArgs e)
        {
            Trigger(ScreenName.SUPPLIER);
        }

        private void btnCategory_ItemClick(object sender, ItemClickEventArgs e)
        {
            Trigger(ScreenName.CATEGORY);
        }

        private void btnUser_ItemClick(object sender, ItemClickEventArgs e)
        {
            Trigger(ScreenName.USER);
        }

        private void btnStudent_ItemClick(object sender, ItemClickEventArgs e)
        {
            Trigger(ScreenName.STUDENT);
        }

        private void btnProduct_ItemClick(object sender, ItemClickEventArgs e)
        {
            Trigger(ScreenName.PRODUCT);
        }

        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
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

namespace FreshFood.Screen
{
    public partial class OrderForm : Form
    {
        private BindingSource bds = new BindingSource();
        private AppDB db = new AppDB();

        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            LoadDtgv();
            dtgv.DataSource = bds;
            ChangeHeader();
            LoadDataBinding();
            HideColumn();
        }

        private void HideColumn()
        {
            //dtgv.Columns["x"].Visible = false;
            //dtgv.Columns["Image"].Visible = false;
        }

        public void LoadDataBinding()
        {
            lblMaDonHang.DataBindings.Add("Text", dtgv.DataSource, "Id", true, DataSourceUpdateMode.Never);
            lblTenKhachHang.DataBindings.Add("Text", dtgv.DataSource, "Name", true, DataSourceUpdateMode.Never);
            lblSoDienThoai.DataBindings.Add("Text", dtgv.DataSource, "PhoneNumber", true, DataSourceUpdateMode.Never);
            lblDiaChi.DataBindings.Add("Text", dtgv.DataSource, "Address", true, DataSourceUpdateMode.Never);
            lblTrangThai.DataBindings.Add("Text", dtgv.DataSource, "Status", true, DataSourceUpdateMode.Never);
        }

        public void LoadDtgv()
        {
            User loginUser = Session.LoginAccount;
            if (loginUser.Customers.Count == 0)
            {
                bds.DataSource = db.SellOrders.Select(x => new { x.Id, x.Date, x.Customer.Name, x.Address, x.PhoneNumber, x.Status }).ToList();
            } else
            {
                bds.DataSource = db.SellOrders.Where(x => x.CustomerId == loginUser.Customers.SingleOrDefault().Id).Select(x => new { x.Id, x.Date, x.Customer.Name, x.Address, x.PhoneNumber, x.Status }).ToList();
            }
        }

        public void ChangeHeader()
        {
            dtgv.Columns["Id"].HeaderText = "Mã đơn hàng";
            dtgv.Columns["Name"].HeaderText = "Tên đơn hàng";
            dtgv.Columns["Date"].HeaderText = "Ngày đặt hàng";
            dtgv.Columns["Address"].HeaderText = "Địa chỉ";
            dtgv.Columns["PhoneNumber"].HeaderText = "Số điện thoại";
            dtgv.Columns["Status"].HeaderText = "Trạng thái";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            User loginUser = Session.LoginAccount;
            if (loginUser.Customers.Count == 0)
            {
                MessageBox.Show("Bạn không phải là khách hàng");
                bds.DataSource = db.SellOrders.Where(x => x.CustomerId == loginUser.Customers.SingleOrDefault().Id).Where(x => x.Customer.Name.Contains(txtTimKiem.Text) || x.Address.Contains(txtTimKiem.Text)).Select(x => new { x.Id, x.Date, x.Customer.Name, x.Address, x.PhoneNumber, x.Status }).ToList();
            }
            else
            {
                bds.DataSource = db.SellOrders.Where(x => x.Customer.Name.Contains(txtTimKiem.Text) || x.Address.Contains(txtTimKiem.Text)).Select(x => new { x.Id, x.Date, x.Customer.Name, x.Address, x.PhoneNumber, x.Status }).ToList();
            }
            
        }

        
    }
}

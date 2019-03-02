using FreshFood.AppCode;
using FreshFood.Components;
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
    public partial class CartForm : Form
    {
        private AppDB db = new AppDB();
        public CartForm()
        {
            InitializeComponent();
            LoadCart();
            LoadCustomerInfo();
        }

        private void LoadCustomerInfo()
        {
            User loginUser = Session.LoginAccount;
            if (loginUser.Customers.Count == 0)
            {
                MessageBox.Show("Bạn không phải là khách hàng");
                return;
            }

            txtDiaChi.Text = loginUser.Customers.SingleOrDefault().Address;
            txtSoDienThoai.Text = loginUser.Customers.SingleOrDefault().PhoneNumber;
        }

        public void LoadCart()
        {
            pnCart.Controls.Clear();
            pnCart.Controls.Add(new CartHeaderUC());
            double totalPrice = 0;
            foreach (var orderDetail in Session.Cart.SellOrderDetails)
            {
                CartRowUC cartRowUC = new CartRowUC(orderDetail);
                cartRowUC.btnDelete.Click += BtnDelete_Click;
                cartRowUC.btnMinus.Click += BtnDelete_Click;
                cartRowUC.btnPlus.Click += BtnDelete_Click;
                pnCart.Controls.Add(cartRowUC);
                totalPrice += orderDetail.Price.Value * orderDetail.Quantity.Value;
            }
            lblTotalPrice.Text = totalPrice.ToString();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            LoadCart();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            try
            {
                User loginUser = Session.LoginAccount;

                SellOrder sellOrder = new SellOrder();
                sellOrder.Address = txtDiaChi.Text;
                sellOrder.PhoneNumber = txtSoDienThoai.Text;
                sellOrder.Status = "Đang xử lý";
                sellOrder.Date = DateTime.Now;

                if (loginUser.Customers.Count == 0)
                {
                    MessageBox.Show("Bạn không phải là khách hàng");
                    return;
                }

                sellOrder.CustomerId = loginUser.Customers.SingleOrDefault().Id;

                foreach (var item in Session.Cart.SellOrderDetails)
                {
                    SellOrderDetail sellOrderDetail = new SellOrderDetail();
                    sellOrderDetail.Price = item.Price;
                    sellOrderDetail.Quantity = item.Quantity;
                    sellOrderDetail.ProductId = item.Product.Id;
                    sellOrder.SellOrderDetails.Add(sellOrderDetail);
                }
                //sellOrder.SellOrderDetails = Session.Cart.SellOrderDetails;

                db.SellOrders.Add(sellOrder);
                    db.SaveChanges();
                    Session.Cart = new SellOrder();
                    LoadCart();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể đặt hàng. Vui lòng liên hệ quản trị viên");
            }
        }
    }
}

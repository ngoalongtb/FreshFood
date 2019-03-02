using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FreshFood.EF;
using FreshFood.AppCode;
using System.Text.RegularExpressions;

namespace FreshFood.Components
{
    public partial class CartRowUC : UserControl
    {
        private SellOrderDetail orderDetail;
        public CartRowUC()
        {
            InitializeComponent();
        }
        public CartRowUC(SellOrderDetail orderDetail)
        {
            InitializeComponent();
            this.OrderDetail = orderDetail;
        }

        public SellOrderDetail OrderDetail {
            get
            {
                return orderDetail;
            }
            set
            {
                lblProductName.Text = value.Product.Name;
                lblPrice.Text = value.Product.Price;
                value.Price = int.Parse(Regex.Replace(value.Product.Price, "[^0-9]", ""));
                lblTotalPrice.Text = value.Price * value.Quantity + "";
                txtQuantity.Value = value.Quantity.Value;
                if (value.Product.Image != null)
                {
                    pnImage.BackgroundImage = Utils.ConvertBinaryToImage(value.Product.Image);
                }

                orderDetail = value;
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if(txtQuantity.Value > 0)
            {
                txtQuantity.Value--;
                var found = Session.Cart.SellOrderDetails.SingleOrDefault(x => x.Product.Id == this.orderDetail.Product.Id);
                found.Quantity = (int) txtQuantity.Value;
                lblTotalPrice.Text = found.Price * found.Quantity + "";
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            txtQuantity.Value++;
            var found = Session.Cart.SellOrderDetails.SingleOrDefault(x => x.Product.Id == this.orderDetail.Product.Id);
            found.Quantity = (int)txtQuantity.Value;
            lblTotalPrice.Text = found.Price * found.Quantity + "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var found = Session.Cart.SellOrderDetails.SingleOrDefault(x => x.Product.Id == this.orderDetail.Product.Id);
            if(found != null)
            {
                Session.Cart.SellOrderDetails.Remove(found);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FreshFood.AppCode;
using FreshFood.EF;
using System.Text.RegularExpressions;

namespace FreshFood.Components
{
    public partial class ProductUC : UserControl
    {
        private Product product;

        public ProductUC()
        {
            InitializeComponent();
        }
        public ProductUC(Product product)
        {
            InitializeComponent();
            this.Product = product;
        }

        public Product Product {
            get {
                return product;
            }
            set {
                lblName.Text = value.Name;
                lblPrice.Text = value.Price;
                if(value.Image == null)
                {
                    pnImage.BackgroundImage = Utils.ConvertBinaryToImage(value.Image);
                }
                product = value;
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            SellOrderDetail orderDetail = Session.Cart.SellOrderDetails.SingleOrDefault(x => x.ProductId == product.Id);
            if(orderDetail == null)
            {
                orderDetail = new SellOrderDetail();
                orderDetail.Quantity = 1;
                orderDetail.Product = this.product;

                Session.Cart.SellOrderDetails.Add(orderDetail);
            }
            else
            {
                orderDetail.Quantity += 1;
            }
            MessageBox.Show("Đã thêm vào giỏ hàng");
        }
    }
}

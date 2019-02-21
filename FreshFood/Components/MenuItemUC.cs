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

namespace FreshFood.Components
{
    public partial class MenuItemUC : UserControl
    {
        private Category category;
        public MenuItemUC(Category category)
        {
            InitializeComponent();
            lbl.Text = category.Name;
        }

        public Category Category {
            get {
                return category;
            }
            set
            {
                category = value;
            }
        }

        private void MenuItemUC_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(235, 238, 245);
        }

        private void MenuItemUC_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }
    }
}

namespace FreshFood.Components
{
    partial class MenuItemUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl = new System.Windows.Forms.Label();
            this.pnImage = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.lbl.Location = new System.Drawing.Point(27, 9);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(52, 17);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "label1";
            this.lbl.MouseHover += new System.EventHandler(this.MenuItemUC_MouseHover);
            // 
            // pnImage
            // 
            this.pnImage.BackgroundImage = global::FreshFood.Properties.Resources.leaf_icon_16;
            this.pnImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnImage.Location = new System.Drawing.Point(3, 1);
            this.pnImage.Name = "pnImage";
            this.pnImage.Size = new System.Drawing.Size(24, 27);
            this.pnImage.TabIndex = 0;
            this.pnImage.MouseHover += new System.EventHandler(this.MenuItemUC_MouseHover);
            // 
            // MenuItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.pnImage);
            this.Name = "MenuItemUC";
            this.Size = new System.Drawing.Size(193, 30);
            this.MouseLeave += new System.EventHandler(this.MenuItemUC_MouseLeave);
            this.MouseHover += new System.EventHandler(this.MenuItemUC_MouseHover);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel pnImage;
        public System.Windows.Forms.Label lbl;
    }
}


namespace ProjectNhom
{
    partial class FormCart
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbShopPhone = new System.Windows.Forms.Label();
            this.btnCart = new System.Windows.Forms.Label();
            this.lbCheckout = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.lbShopPhone);
            this.panel1.Location = new System.Drawing.Point(-2, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 81);
            this.panel1.TabIndex = 23;
            // 
            // lbShopPhone
            // 
            this.lbShopPhone.AutoSize = true;
            this.lbShopPhone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbShopPhone.ForeColor = System.Drawing.Color.White;
            this.lbShopPhone.Location = new System.Drawing.Point(32, 22);
            this.lbShopPhone.Name = "lbShopPhone";
            this.lbShopPhone.Size = new System.Drawing.Size(78, 13);
            this.lbShopPhone.TabIndex = 2;
            this.lbShopPhone.Text = "SHOP PHONE";
            this.lbShopPhone.Click += new System.EventHandler(this.lbShopPhone_Click);
            // 
            // btnCart
            // 
            this.btnCart.AutoSize = true;
            this.btnCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCart.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnCart.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnCart.Location = new System.Drawing.Point(785, 98);
            this.btnCart.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(88, 27);
            this.btnCart.TabIndex = 25;
            this.btnCart.Text = "Total = ";
            // 
            // lbCheckout
            // 
            this.lbCheckout.BackColor = System.Drawing.Color.DodgerBlue;
            this.lbCheckout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbCheckout.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCheckout.ForeColor = System.Drawing.Color.Transparent;
            this.lbCheckout.Location = new System.Drawing.Point(786, 143);
            this.lbCheckout.Name = "lbCheckout";
            this.lbCheckout.Size = new System.Drawing.Size(94, 30);
            this.lbCheckout.TabIndex = 24;
            this.lbCheckout.Text = "Checkout";
            this.lbCheckout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbCheckout.Click += new System.EventHandler(this.lbCheckout_Click);
            // 
            // FormCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1137, 574);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCart);
            this.Controls.Add(this.lbCheckout);
            this.Name = "FormCart";
            this.Text = "FormCart";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCart_FormClosed);
            this.Load += new System.EventHandler(this.FormCart_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbShopPhone;
        private System.Windows.Forms.Label btnCart;
        private System.Windows.Forms.Label lbCheckout;
    }
}
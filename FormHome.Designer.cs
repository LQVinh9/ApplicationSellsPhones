
namespace ProjectNhom
{
    partial class FormHome
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
            this.btnCart = new System.Windows.Forms.Label();
            this.lbLogout = new System.Windows.Forms.Label();
            this.lbViewOrder = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Label();
            this.lbShopPhone = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnHistory = new System.Windows.Forms.Label();
            this.imageBGCategory = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBGCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btnHistory);
            this.panel1.Controls.Add(this.btnCart);
            this.panel1.Controls.Add(this.lbLogout);
            this.panel1.Controls.Add(this.lbViewOrder);
            this.panel1.Controls.Add(this.btnInsert);
            this.panel1.Controls.Add(this.lbShopPhone);
            this.panel1.Location = new System.Drawing.Point(-8, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1496, 56);
            this.panel1.TabIndex = 3;
            // 
            // btnCart
            // 
            this.btnCart.AutoSize = true;
            this.btnCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCart.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnCart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCart.Location = new System.Drawing.Point(429, 26);
            this.btnCart.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(53, 27);
            this.btnCart.TabIndex = 8;
            this.btnCart.Text = "Cart";
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);
            // 
            // lbLogout
            // 
            this.lbLogout.AutoSize = true;
            this.lbLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbLogout.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogout.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbLogout.Location = new System.Drawing.Point(315, 26);
            this.lbLogout.Name = "lbLogout";
            this.lbLogout.Size = new System.Drawing.Size(71, 27);
            this.lbLogout.TabIndex = 3;
            this.lbLogout.Text = "Logout";
            this.lbLogout.Click += new System.EventHandler(this.lbLogout_Click);
            // 
            // lbViewOrder
            // 
            this.lbViewOrder.AutoSize = true;
            this.lbViewOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbViewOrder.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbViewOrder.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbViewOrder.Location = new System.Drawing.Point(521, 26);
            this.lbViewOrder.Name = "lbViewOrder";
            this.lbViewOrder.Size = new System.Drawing.Size(112, 27);
            this.lbViewOrder.TabIndex = 2;
            this.lbViewOrder.Text = "View order";
            this.lbViewOrder.Click += new System.EventHandler(this.lbViewOrder_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.AutoSize = true;
            this.btnInsert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsert.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnInsert.Location = new System.Drawing.Point(421, 26);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(70, 27);
            this.btnInsert.TabIndex = 1;
            this.btnInsert.Text = "Insert";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // lbShopPhone
            // 
            this.lbShopPhone.AutoSize = true;
            this.lbShopPhone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbShopPhone.ForeColor = System.Drawing.Color.White;
            this.lbShopPhone.Location = new System.Drawing.Point(67, 20);
            this.lbShopPhone.Name = "lbShopPhone";
            this.lbShopPhone.Size = new System.Drawing.Size(78, 13);
            this.lbShopPhone.TabIndex = 0;
            this.lbShopPhone.Text = "SHOP PHONE";
            this.lbShopPhone.Click += new System.EventHandler(this.lbShopPhone_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(133, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "CATEGORY";
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = true;
            this.btnSearch.BackColor = System.Drawing.Color.DimGray;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearch.Location = new System.Drawing.Point(188, 509);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(77, 27);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(80, 509);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(96, 26);
            this.txtSearch.TabIndex = 6;
            // 
            // btnHistory
            // 
            this.btnHistory.AutoSize = true;
            this.btnHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistory.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnHistory.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnHistory.Location = new System.Drawing.Point(521, 26);
            this.btnHistory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(80, 27);
            this.btnHistory.TabIndex = 8;
            this.btnHistory.Text = "History";
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // imageBGCategory
            // 
            this.imageBGCategory.Image = global::ProjectNhom.Properties.Resources.pngfind_com_simple_border_png_192556;
            this.imageBGCategory.Location = new System.Drawing.Point(47, 93);
            this.imageBGCategory.Name = "imageBGCategory";
            this.imageBGCategory.Size = new System.Drawing.Size(251, 389);
            this.imageBGCategory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBGCategory.TabIndex = 4;
            this.imageBGCategory.TabStop = false;
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1483, 729);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.imageBGCategory);
            this.Controls.Add(this.panel1);
            this.Name = "FormHome";
            this.Text = "Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormHome_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBGCategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbShopPhone;
        private System.Windows.Forms.PictureBox imageBGCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label btnInsert;
        private System.Windows.Forms.Label lbViewOrder;
        private System.Windows.Forms.Label lbLogout;
        private System.Windows.Forms.Label btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label btnCart;
        private System.Windows.Forms.Label btnHistory;
    }
}


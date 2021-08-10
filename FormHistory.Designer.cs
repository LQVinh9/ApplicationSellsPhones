
namespace ProjectNhom
{
    partial class FormHistory
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
            this.lbTotal = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.Label();
            this.lbQuantity = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            this.lbProductName = new System.Windows.Forms.Label();
            this.lbPicture = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.lbShopPhone);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 81);
            this.panel1.TabIndex = 8;
            // 
            // lbShopPhone
            // 
            this.lbShopPhone.AutoSize = true;
            this.lbShopPhone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbShopPhone.ForeColor = System.Drawing.Color.White;
            this.lbShopPhone.Location = new System.Drawing.Point(32, 24);
            this.lbShopPhone.Name = "lbShopPhone";
            this.lbShopPhone.Size = new System.Drawing.Size(78, 13);
            this.lbShopPhone.TabIndex = 2;
            this.lbShopPhone.Text = "SHOP PHONE";
            this.lbShopPhone.Click += new System.EventHandler(this.lbShopPhone_Click);
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbTotal.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lbTotal.Location = new System.Drawing.Point(1245, 109);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(60, 27);
            this.lbTotal.TabIndex = 14;
            this.lbTotal.Text = "Total";
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.Cursor = System.Windows.Forms.Cursors.Default;
            this.Price.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Price.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.Price.Location = new System.Drawing.Point(1055, 109);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(57, 27);
            this.Price.TabIndex = 13;
            this.Price.Text = "Price";
            // 
            // lbQuantity
            // 
            this.lbQuantity.AutoSize = true;
            this.lbQuantity.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbQuantity.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuantity.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lbQuantity.Location = new System.Drawing.Point(828, 109);
            this.lbQuantity.Name = "lbQuantity";
            this.lbQuantity.Size = new System.Drawing.Size(94, 27);
            this.lbQuantity.TabIndex = 12;
            this.lbQuantity.Text = "Quantity";
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbDate.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDate.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lbDate.Location = new System.Drawing.Point(655, 109);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(57, 27);
            this.lbDate.TabIndex = 11;
            this.lbDate.Text = "Date";
            // 
            // lbProductName
            // 
            this.lbProductName.AutoSize = true;
            this.lbProductName.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbProductName.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProductName.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lbProductName.Location = new System.Drawing.Point(279, 109);
            this.lbProductName.Name = "lbProductName";
            this.lbProductName.Size = new System.Drawing.Size(141, 27);
            this.lbProductName.TabIndex = 10;
            this.lbProductName.Text = "Product Name";
            // 
            // lbPicture
            // 
            this.lbPicture.AutoSize = true;
            this.lbPicture.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbPicture.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPicture.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lbPicture.Location = new System.Drawing.Point(117, 109);
            this.lbPicture.Name = "lbPicture";
            this.lbPicture.Size = new System.Drawing.Size(76, 27);
            this.lbPicture.TabIndex = 9;
            this.lbPicture.Text = "Picture";
            // 
            // FormHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1301, 602);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.lbQuantity);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.lbProductName);
            this.Controls.Add(this.lbPicture);
            this.Name = "FormHistory";
            this.Text = "FormHistory";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormHistory_FormClosed);
            this.Load += new System.EventHandler(this.FormHistory_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbShopPhone;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.Label lbQuantity;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Label lbProductName;
        private System.Windows.Forms.Label lbPicture;
    }
}
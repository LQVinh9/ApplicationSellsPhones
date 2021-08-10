
namespace ProjectNhom
{
    partial class FormDescription
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
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.lbShopPhone);
            this.panel1.Location = new System.Drawing.Point(-8, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1496, 56);
            this.panel1.TabIndex = 6;
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
            // FormDescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1459, 617);
            this.Controls.Add(this.panel1);
            this.Name = "FormDescription";
            this.Text = "Description";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDescription_FormClosed);
            this.Load += new System.EventHandler(this.FormDescription_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbShopPhone;
    }
}
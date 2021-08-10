using ProjectNhom.dao;
using ProjectNhom.dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectNhom
{
    public partial class FormHistory : Form
    {
        Thread th;
        public string userID { get; set; }

        static List<OrderDetail> listOD = new List<OrderDetail>();
        public FormHistory()
        {
            InitializeComponent();
        }

        public void initForm()
        {
            panel1.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 10, 80);
            lbShopPhone.Font = new Font("Comic Sans MS", 20, FontStyle.Bold);
        }

        private void FormHistory_Load(object sender, EventArgs e)
        {
            initForm();

            CartDao cartDao = new CartDao();
            listOD = cartDao.displayAllOrderDetail(userID);

            if (listOD != null)
            {
                for (int i = 0; i < listOD.Count; i++)
                {
                    printOrderDetail(listOD[i], 150 + (i * 200));
                }
            }
            else
            {
                MessageBox.Show("Empty!!!", "Warning");
            }
        }

        private void openFormHome(string id)
        {
            Application.Run(new FormHome() { 
                categoryID = id,
                userID = userID
            });
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream mStream = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(mStream);
            }
        }
        private void printOrderDetail(OrderDetail od, int location)
        {
            //Picture
            PictureBox pictureBox;
            pictureBox = new PictureBox()
            {
                Name = "Picture" + od.productID,
                Location = new Point(100, location),
                Size = new Size(100, 100),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            Image imgFirst = byteArrayToImage(od.image);
            pictureBox.Image = imgFirst;
            Controls.Add(pictureBox);

            //lbProductName
            Label lbProductName;
            lbProductName = new Label()
            {
                Name = "lbProductName" + od.productID,
                Text = od.productName,
                Font = new Font("Helvetica", 15, FontStyle.Bold),
                Location = new Point(250, location + 30),
                Size = new Size(280, 30)
            };
            Controls.Add(lbProductName);

            //lbDate
            Label lbDate;
            lbDate = new Label()
            {
                Name = "lbDate" + od.productID,
                Text = od.date,
                Font = new Font("Helvetica", 15, FontStyle.Bold),
                Location = new Point(550, location + 30),
                Size = new Size(250, 30)
            };
            Controls.Add(lbDate);

            //lbQuantity
            Label lbQuantity;
            lbQuantity = new Label()
            {
                Name = "lbQuantity" + od.productID,
                Text = od.quantity.ToString(),
                Font = new Font("Helvetica", 15, FontStyle.Bold),
                Location = new Point(850, location + 30),
                Size = new Size(50, 30)
            };
            Controls.Add(lbQuantity);

            //lbX
            Label lbX;
            lbX = new Label()
            {
                Name = "lbX" + od.productID,
                Text = "x",
                Font = new Font("Helvetica", 15, FontStyle.Bold),
                Location = new Point(950, location + 30),
                Size = new Size(30, 30)
            };
            Controls.Add(lbX);

            //lbPrice
            Label lbPrice;
            lbPrice = new Label()
            {
                Name = "lbPrice" + od.productID,
                Text = od.price.ToString(),
                Font = new Font("Helvetica", 15, FontStyle.Bold),
                Location = new Point(1030, location + 30),
                Size = new Size(150, 30)
            };
            Controls.Add(lbPrice);

            //lbTotal
            Label lbTotal;
            lbTotal = new Label()
            {
                Name = "lbTotal" + od.productID,
                Text = (od.quantity * od.price).ToString(),
                Font = new Font("Helvetica", 15, FontStyle.Bold),
                Location = new Point(1230, location + 30),
                Size = new Size(150, 30)
            };
            Controls.Add(lbTotal);
        }

        private void lbShopPhone_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(() => openFormHome("AL"));
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void FormHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

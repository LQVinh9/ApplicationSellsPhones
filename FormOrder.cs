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
    public partial class FormOrder : Form
    {
        Thread th;

        public string userID { get; set; }

        OrderDetailDao orderDetailDao = new OrderDetailDao();
        ProductDao productDao = new ProductDao();
        UserDao userDao = new UserDao();
        OrderDao orderDao = new OrderDao();

        public FormOrder()
        {
            InitializeComponent();
        }

        public void initForm()
        {
            FormHome form = new FormHome();
            panel1.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 20, 80);
            lbShopPhone.Font = new Font("Comic Sans MS", 20, FontStyle.Bold);
        }

        private void printOrderDetail(OrderDetail orderDetail,User user, int location)
        {
            Product product = productDao.getProductByID(orderDetail.productID);

            //Picture
            PictureBox pictureBox;
            pictureBox = new PictureBox()
            {
                Name = "Picture"+ orderDetail.productID,
                Location = new Point(100, location),
                Size = new Size(120, 120),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            Image imgFirst = byteArrayToImage(product.image);
            pictureBox.Image = imgFirst;
            Controls.Add(pictureBox);

            //productName
            Label productName;
            productName = new Label()
            {
                Name = "lbProductName" + orderDetail.productID,
                Text = product.productName,
                Font = new Font("Helvetica", 15, FontStyle.Regular),
                Location = new Point(230, location+30),
                Size = new Size(300, 30)
            };
            Controls.Add(productName);

            //price
            Label price;
            price = new Label()
            {
                Name = "lbPrice" + orderDetail.productID,
                Text = String.Format("{0:###,###,###}", orderDetail.price) + "₫",
                Font = new Font("Helvetica", 15, FontStyle.Bold),
                Location = new Point(550, location+30),
                Size = new Size(150, 20)
            };
            Controls.Add(price);

            //quantity
            Label lbQuantity;
            lbQuantity = new Label()
            {
                Name = "lbQuantity" + orderDetail.productID,
                Text = orderDetail.quantity.ToString(),
                Font = new Font("Helvetica", 15, FontStyle.Bold),
                Location = new Point(750, location + 30),
                Size = new Size(50, 20)
            };
            Controls.Add(lbQuantity);

            //total
            Label lbTotal;
            lbTotal = new Label()
            {
                Name = "lbTotal" + orderDetail.productID,
                Text = String.Format("{0:###,###,###}", (orderDetail.price*orderDetail.quantity)) + "₫",
                Font = new Font("Helvetica", 15, FontStyle.Bold),
                Location = new Point(850, location + 30),
                Size = new Size(150, 20)
            };
            Controls.Add(lbTotal);

            //UserName
            Label lbUserName;
            lbUserName = new Label()
            {
                Name = "lbUserName" + orderDetail.productID,
                Text = user.userName,
                Font = new Font("Helvetica", 15, FontStyle.Bold),
                Location = new Point(1100, location + 30),
                Size = new Size(250, 40)
            };
            Controls.Add(lbUserName);

            //SDT
            Label lbSDT;
            lbSDT = new Label()
            {
                Name = "lbSDT" + orderDetail.productID,
                Text = user.phone,
                Font = new Font("Helvetica", 15, FontStyle.Bold),
                Location = new Point(1400, location + 30),
                Size = new Size(150, 40)
            };
            Controls.Add(lbSDT);

            //Address
            Label lbAddress;
            lbAddress = new Label()
            {
                Name = "lbAddress" + orderDetail.productID,
                Text = user.address,
                Font = new Font("Helvetica", 15, FontStyle.Bold),
                Location = new Point(1600, location + 30),
                Size = new Size(200, 100)
            };
            Controls.Add(lbAddress);
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream mStream = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(mStream);
            }
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            initForm();

            List<OrderDetail> listOrderDetails = orderDetailDao.getAllOrderDetail();

            Console.WriteLine(listOrderDetails.Count);

            for (int i=0; i<listOrderDetails.Count; i++)
            {
                Order order = orderDao.getOrderByID(listOrderDetails[i].orderID);
                User user = userDao.getUserByID(order.userID);
                printOrderDetail(listOrderDetails[i],user, 200 + (i * 130));
            }
        }

        private void lbShopPhone_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(() => openFormHome("AL"));
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void openFormHome(string id)
        {
            Application.Run(new FormHome() {
                categoryID = id,
                userID = userID
            });
        }

        private void FormOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void FormOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

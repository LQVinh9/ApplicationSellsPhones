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
    public partial class FormCart : Form
    {
        Thread th;
        public Product product { get; set; }

        public string userID { get; set; }

        static List<ProductInCart> listPic = new List<ProductInCart>();

        Random rnd = new Random();

        Label lbTotal;

        public void initForm()
        {
            panel1.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 10, 80);
            lbShopPhone.Font = new Font("Comic Sans MS", 20, FontStyle.Bold);
        }

        public FormCart()
        {
            InitializeComponent();
        }

        private void FormCart_Load(object sender, EventArgs e)
        {
            initForm();

            if (product != null)
            {
                if (listPic != null)
                {
                    bool check = false;
                    for (int i = 0; i < listPic.Count; i++)
                    {
                        if (product.productID.Equals(listPic[i].product.productID))
                        {
                            listPic[i].quantity++;
                            check = true;
                        }
                    }
                    if (check == false)
                    {
                        ProductInCart pic = new ProductInCart(product, 1, product.price);
                        listPic.Add(pic);
                    }
                }
                else
                {
                    ProductInCart pic = new ProductInCart(product, 1, product.price);
                    listPic.Add(pic);
                }
            }

            for (int i = 0; i < listPic.Count; i++)
            {
                printProduct(listPic[i], 100 + (i * 150));
            }

            //lbTotal
            lbTotal = new Label()
            {
                Name = "lbTotal",
                Text = "",
                Font = new Font("Helvetica", 15, FontStyle.Bold),
                Location = new Point(900, 100),
                ForeColor = Color.DodgerBlue,
                Size = new Size(300, 30)
            };
            Controls.Add(lbTotal);
            tinhTotal();
        }

        private void printProduct(ProductInCart pic, int location)
        {
            //Delete
            Label lbDelete;
            lbDelete = new Label()
            {
                Name = "lbDelete" + pic.product.productID,
                Text = "X",
                Font = new Font("Helvetica", 15, FontStyle.Bold),
                BackColor = Color.DarkRed,
                Location = new Point(50, location + 33),
                Cursor = Cursors.Hand,
                ForeColor = Color.White,
                Size = new Size(20, 20)
            };
            lbDelete.Click += new EventHandler(delegate (Object o, EventArgs a)
            {
                listPic.Remove(pic);
                tinhTotal();

                this.Close();
                th = new Thread(() => openFormCart(null));
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            });
            Controls.Add(lbDelete);

            //Picture
            PictureBox pictureBox;
            pictureBox = new PictureBox()
            {
                Name = "Picture" + pic.product.productID,
                Location = new Point(100, location),
                Size = new Size(100, 100),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            Image imgFirst = byteArrayToImage(pic.product.image);
            pictureBox.Image = imgFirst;
            Controls.Add(pictureBox);

            //productName
            Label productName;
            productName = new Label()
            {
                Name = "Name" + pic.product.productID,
                Text = pic.product.productName,
                Font = new Font("Helvetica", 15, FontStyle.Bold),
                Location = new Point(250, location),
                ForeColor = Color.DodgerBlue,
                Size = new Size(300, 30)
            };
            Controls.Add(productName);

            //Price
            Label lbPrice;
            lbPrice = new Label()
            {
                Name = "Price" + pic.product.productID,
                Text = " X   " + pic.product.price.ToString(),
                Font = new Font("Helvetica", 14, FontStyle.Regular),
                Location = new Point(370, location + 52),
                Size = new Size(150, 30)
            };
            Controls.Add(lbPrice);

            //Price Total of 1 SP
            Label lbPriceTotalDetail;
            lbPriceTotalDetail = new Label()
            {
                Name = "PriceTotal" + pic.product.productID,
                Text = "   =   " + (pic.product.price * pic.quantity).ToString(),
                Font = new Font("Helvetica", 14, FontStyle.Regular),
                Location = new Point(520, location + 52),
                Size = new Size(300, 30)
            };
            Controls.Add(lbPriceTotalDetail);

            //Combobox quantity
            ComboBox comboBox;
            comboBox = new ComboBox()
            {
                Name = "Combobox" + pic.product.productID,
                Font = new Font("Helvetica", 12, FontStyle.Regular),
                Location = new Point(250, location + 50),
                Size = new Size(100, 100),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            for (int i = 1; i <= pic.product.quantity; i++)
            {
                comboBox.Items.Add(i);
            }
            comboBox.SelectedIndex = pic.quantity - 1;
            comboBox.SelectedIndexChanged += new EventHandler(delegate (Object o, EventArgs a)
            {
                listPic.Where(w => w == pic).ToList().ForEach(s => s.quantity = int.Parse(comboBox.SelectedItem.ToString()));
                lbPriceTotalDetail.Text = "   =   " + (pic.product.price * int.Parse(comboBox.SelectedItem.ToString())).ToString();
                tinhTotal();
            });
            Controls.Add(comboBox);
        }

        private void tinhTotal()
        {
            double sum = 0;
            foreach (ProductInCart pic in listPic)
            {
                sum += pic.quantity * pic.price;
            }
            lbTotal.Text = sum.ToString();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream mStream = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(mStream);
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

        private void openFormCart(Product product)
        {
            Application.Run(new FormCart() {
                product = product,
                userID = userID
            });
        }

        CartDao cartDao = new CartDao();
        ProductDao productDao = new ProductDao();

        private void lbCheckout_Click(object sender, EventArgs e)
        {
            if (listPic.Count != 0)
            {
                string orderID;
                do
                {
                    orderID = rnd.Next(99999).ToString();
                } while (cartDao.getOrderByID(orderID) != null);
                string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                Order order = new Order(orderID, date, double.Parse(lbTotal.Text), userID);
                cartDao.addNewOrder(order);

                for (int i = 0; i < listPic.Count; i++)
                {
                    string orderDetailID;
                    do
                    {
                        orderDetailID = rnd.Next(99999).ToString();
                    } while (cartDao.getOrderDetailByID(orderDetailID) != null);
                    double price = listPic[i].price;
                    int quantity = listPic[i].quantity;
                    string productID = listPic[i].product.productID;
                    OrderDetail orderDetail = new OrderDetail(orderDetailID, price, quantity, orderID, productID);
                    cartDao.addNewOrderDetail(orderDetail);

                    productDao.updateQuantityOfProduct(productID, listPic[i].product.quantity - quantity);
                }

                MessageBox.Show("Checkout Successfully!!", "Success");

                listPic.Clear();
                this.Close();
                th = new Thread(() => openFormHome("AL"));
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                MessageBox.Show("Empty!!", "Warning");
            }
        }

        private void FormCart_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

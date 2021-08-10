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
    public partial class FormDescription : Form
    {
        Thread th;
        public string productID { get; set; }

        public string userID { get; set; }
        public string roleID { get; set; }

        public FormDescription()
        {
            InitializeComponent();
        }

        public void initForm()
        {
            FormHome form = new FormHome();
            panel1.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 10, 80);
            lbShopPhone.Font = new Font("Comic Sans MS", 20, FontStyle.Bold);
            UserDao userDao = new UserDao();
            roleID = userDao.getUserByID(userID).roleID;
        }

        public void showProduct(Product product, int index)
        {
            createPicture(product.image, index.ToString(), 400, 100, product.productID);

            PictureBox picture = this.Controls[index.ToString()] as PictureBox;

            //productName
            Label productName;
            productName = new Label()
            {
                Name = "lbProductName" + index.ToString(),
                Text = product.productName,
                Font = new Font("Helvetica", 15, FontStyle.Bold),
                Location = new Point(picture.Right + 50, picture.Top + 10),
                ForeColor = Color.DodgerBlue,
                Cursor = Cursors.Hand,
                Size = new Size(300, 30)
            };
            Controls.Add(productName);

            //price
            Label price;
            price = new Label()
            {
                Name = "lbPrice" + index.ToString(),
                Text = String.Format("{0:###,###,###}", product.price) + "₫",
                Font = new Font("Helvetica", 15, FontStyle.Bold),
                Location = new Point(picture.Right + 50, picture.Top + 50),
                Size = new Size(300, 20)
            };
            Controls.Add(price);

            //price
            Label shortDescription;
            shortDescription = new Label()
            {
                Name = "lbShortDescription" + index.ToString(),
                Text = "◦  " + product.shortDescription.Replace(". ", "\n◦  "),
                Font = new Font("Helvetica", 12, FontStyle.Regular),
                Location = new Point(picture.Right + 50, picture.Top + 90),
                Size = new Size(400, 100)
            };
            Controls.Add(shortDescription);

            if (roleID != null && roleID.Equals("C"))
            {
                //Add to cart
                Label lbAddCart;
                lbAddCart = new Label()
                {
                    Name = "lbAddCart" + index.ToString(),
                    Text = "✚ ADD TO CARD",
                    Font = new Font("Helvetica", 12, FontStyle.Bold),
                    Location = new Point(picture.Right + 50, picture.Top + 200),
                    ForeColor = Color.White,
                    BackColor = Color.LightSeaGreen,
                    Cursor = Cursors.Hand,
                    Size = new Size(150, 40),
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                lbAddCart.Click += new EventHandler(delegate (Object o, EventArgs a)
                {

                    lbAddCart.Focus();
                    string message = "Add successfully!!!";
                    string title = "Success";
                    MessageBox.Show(message, title);

                    this.Close();
                    th = new Thread(() => openFormCart(product));
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                });
                Controls.Add(lbAddCart);
            }
            else if (roleID != null && roleID.Equals("A"))
            {
                //Update
                Label lbUpdate;
                lbUpdate = new Label()
                {
                    Name = "lbUpdate" + index.ToString(),
                    Text = "Update",
                    Font = new Font("Helvetica", 12, FontStyle.Bold),
                    Location = new Point(picture.Right + 50, picture.Top + 200),
                    ForeColor = Color.White,
                    BackColor = Color.LightSeaGreen,
                    Cursor = Cursors.Hand,
                    Size = new Size(100, 40),
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                lbUpdate.Click += new EventHandler(delegate (Object o, EventArgs a)
                {
                    this.Close();
                    th = new Thread(() => openFormUpdate(product));
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                });
                Controls.Add(lbUpdate);

                //Delete
                if (product.status.Equals("True"))
                {
                    Label lbDelete;
                    lbDelete = new Label()
                    {
                        Name = "lbDelete" + index.ToString(),
                        Text = "Delete",
                        Font = new Font("Helvetica", 12, FontStyle.Bold),
                        Location = new Point(picture.Right + 180, picture.Top + 200),
                        ForeColor = Color.White,
                        BackColor = Color.Firebrick,
                        Cursor = Cursors.Hand,
                        Size = new Size(100, 40),
                        AutoSize = false,
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    lbDelete.Click += new EventHandler(delegate (Object o, EventArgs a)
                    {
                        ProductDao productDao = new ProductDao();
                        productDao.deleteProduct(product.productID);

                        this.Close();
                        th = new Thread(() => openFormHome(null));
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                    });
                    Controls.Add(lbDelete);
                }
            }
        }

        private void openFormCart(Product product)
        {
            Application.Run(new FormCart()
            {
                product = product,
                userID = userID
            });
        }

        private void openFormUpdate(Product p)
        {
            Application.Run(new FormUpdate() { 
                product = p,
                userID = userID
            });
        }

        public void createPicture(byte[] image, string name, int x, int y, string productID)
        {
            PictureBox pictureBox;
            pictureBox = new PictureBox()
            {
                Name = name,
                Location = new Point(x, y),
                Cursor = Cursors.Hand,
                Size = new Size(250, 250),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            Image imgFirst = byteArrayToImage(image);
            pictureBox.Image = imgFirst;
            Controls.Add(pictureBox);
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream mStream = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(mStream);
            }
        }

        public void showDescription(string id)
        {
            DescriptionDao descriptionDao = new DescriptionDao();
            List<Description> listDescription = descriptionDao.getDescriptionByProductID(id);

            PictureBox picture = this.Controls["0"] as PictureBox;
            int location = 400;

            foreach (Description description in listDescription)
            {
                if (description.type.Equals("Title"))
                {
                    Label title;
                    title = new Label()
                    {
                        Name = description.descriptionID,
                        Text = description.title,
                        Font = new Font("Helvetica", 14, FontStyle.Bold),
                        Location = new Point(400, location),
                        MaximumSize = new Size(700, 0),
                        AutoSize = true
                    };
                    Controls.Add(title);

                    Label label = this.Controls[description.descriptionID] as Label;
                    location = label.Bottom + 20;
                } else if (description.type.Equals("Text"))
                {
                    Label text;
                    text = new Label()
                    {
                        Name = description.descriptionID,
                        Text = description.contents,
                        Font = new Font("Helvetica", 12, FontStyle.Regular),
                        Location = new Point(400, location),
                        MaximumSize = new Size(700, 0),
                        AutoSize =true
                    };
                    Controls.Add(text);

                    Label label = this.Controls[description.descriptionID] as Label;
                    location = label.Bottom + 20;
                } else if (description.type.Equals("Image"))
                {
                    PictureBox pictureBox;
                    pictureBox = new PictureBox()
                    {
                        Name = description.descriptionID,
                        Location = new Point(400, location),
                        Cursor = Cursors.Hand,
                        Size = new Size(700, 467),
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    Image imgFirst = byteArrayToImage(description.image);
                    pictureBox.Image = imgFirst;
                    Controls.Add(pictureBox);

                    PictureBox pic = this.Controls[description.descriptionID] as PictureBox;
                    location = pic.Bottom + 20;
                }
            }
        }

        private void FormDescription_Load(object sender, EventArgs e)
        {
            initForm();
            ProductDao productDao = new ProductDao();
            Product product = productDao.getProductByID(productID);
            showProduct(product, 0);

            showDescription(productID);
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

        private void FormDescription_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

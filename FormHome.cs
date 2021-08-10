using ProjectNhom.dao;
using ProjectNhom.dto;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ProjectNhom
{
    public partial class FormHome : Form
    {

        Thread th;

        public FormHome()
        {
            InitializeComponent();
        }

        public string categoryID { get; set; }

        public string userID { get; set; }

        //public string userID;
        public string roleID;

        public string word { get; set; }

        public void initForm()
        {
            UserDao userDao = new UserDao();
            roleID = userDao.getUserByID(userID).roleID;

            FormHome form = new FormHome();
            panel1.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 10, 80);
            lbShopPhone.Font = new Font("Comic Sans MS", 20, FontStyle.Bold);
            if (roleID != null && roleID.Equals("C"))
            {
                btnInsert.Visible = false;
                lbViewOrder.Visible = false;
            }
            if (roleID != null && roleID.Equals("A"))
            {
                btnCart.Visible = false;
                btnHistory.Visible = false;
            }

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
            pictureBox.Click += new EventHandler(delegate (Object o, EventArgs a)
            {
                this.Close();
                th = new Thread(() => openFormDescription(productID));
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            });
            Image imgFirst = byteArrayToImage(image);
            pictureBox.Image = imgFirst;
            Controls.Add(pictureBox);
        }
        private void openFormDescription(string id)
        {
            Application.Run(new FormDescription() { 
                productID = id,
                userID = userID
            });
        }

        public void showProduct(Product product, int index)
        {
            if (index == 0)
            {
                createPicture(product.image, index.ToString(), 400, 100, product.productID);
            }
            else
            {
                PictureBox pictureBoxBefore = this.Controls[(index - 1).ToString()] as PictureBox;
                createPicture(product.image, index.ToString(), 400, pictureBoxBefore.Bottom + 40, product.productID);
            }

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
            productName.Click += new EventHandler(delegate (Object o, EventArgs a)
            {
                this.Close();
                th = new Thread(() => openFormDescription(product.productID));
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            });
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
                //Tram Add to cart
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

        private void openFormUpdate(Product p)
        {
            Application.Run(new FormUpdate() { 
                product = p,
                userID = userID
            });
        }

        public void showCategory(Category category, int index)
        {
            Label categoryName;
            categoryName = new Label()
            {
                Name = category.categoryID,
                Text = category.categoryName,
                Font = new Font("Helvetica", 15, FontStyle.Bold),
                Location = new Point(100, 155 + index * 60),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(65, 144, 255),
                Cursor = Cursors.Hand,
                Size = new Size(150, 40),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter
            };
            categoryName.Click += new EventHandler(delegate (Object o, EventArgs a)
            {
                this.Close();
                th = new Thread(() => openFormHome(categoryName.Name));
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            });
            Controls.Add(categoryName);
        }

        private void openFormHome(string id)
        {
            Application.Run(new FormHome() { 
                categoryID = id,
                userID = userID
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initForm();

            CategoryDao categoryDao = new CategoryDao();
            List<Category> listCategory = categoryDao.getAllCategory();

            Category category = new Category("AL", "All");
            showCategory(category, 0);

            for (int i = 0; i < listCategory.Count; i++)
            {
                showCategory(listCategory[i], i + 1);
            }

            imageBGCategory.SendToBack();

            ProductDao productDao = new ProductDao();
            List<Product> listProduct;
            if (categoryID == null)
            {
                listProduct = productDao.getAllProduct();
            }
            else
            {
                if (categoryID.Equals("AL"))
                {
                    listProduct = productDao.getAllProduct();
                }
                else
                {
                    listProduct = productDao.getAllProductByCategory(categoryID);
                }
            }

            //Tram
            //Search
            if (word != null)
            {
                if (word.Trim().Length == 0)
                {
                    string message = "Can't be blank!!!";
                    string title = "Error";
                    MessageBox.Show(message, title);
                }
                else
                {
                    if (productDao.searchProductByName(word) == null)
                    {
                        string message = "Not found!!!";
                        string title = "Error";
                        MessageBox.Show(message, title);
                    }
                    else listProduct = productDao.searchProductByName(word);
                }
            }

            for (int i = 0; i < listProduct.Count; i++)
            {
                showProduct(listProduct[i], i);
            }
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream mStream = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(mStream);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(() => openFormInsert());
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void openFormInsert()
        {
            Application.Run(new FormInsert()
            {
                userID = userID
            });
        }

        private void lbShopPhone_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(() => openFormHome("AL"));
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void lbViewOrder_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(() => openFormOrder(userID));
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void openFormOrder(string userID)
        {
            Application.Run(new FormOrder()
            {
                userID = userID
            });
        }

        private void FormHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lbLogout_Click(object sender, EventArgs e)
        {
            userID = null;

            this.Close();
            th = new Thread(() => openFormLogin());
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void openFormLogin()
        {
            Application.Run(new FormLogin());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string wordSearch = txtSearch.Text;
            this.Close();
            th = new Thread(() => openFormHomeSearch(wordSearch));
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void openFormHomeSearch(string words)
        {
            Application.Run(new FormHome() {
                word = words,
                userID = userID
            });
        }

        //Tram
        private void btnCart_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(() => openFormCart(null));
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        //Tram open form cart
        private void openFormCart(Product product)
        {
            Application.Run(new FormCart() { 
                product = product,
                userID = userID
            });
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(() => openFormHistory(userID));
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        //Tram open form history
        private void openFormHistory(string userID)
        {
            Application.Run(new FormHistory() { userID = userID });
        }
    }
}

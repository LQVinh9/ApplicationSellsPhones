using ProjectNhom.dao;
using ProjectNhom.dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectNhom
{
    public partial class FormUpdate : Form
    {
        public Product product { get; set; }

        public string userID { get; set; }

        Thread th;
        Random rnd = new Random();

        static int tab = 0;
        string status = "";
        TextBox txtBoxBefore;
        PictureBox pictureBoxBefore;
        int location = 525;

        List<string> list = new List<string>() { "" };

        public FormUpdate()
        {
            InitializeComponent();
        }

        public void initForm()
        {
            FormHome form = new FormHome();
            panel1.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 20, 80);
            lbShopPhone.Font = new Font("Comic Sans MS", 20, FontStyle.Bold);
            //label1.Click += delegate { label1.Text = "Clicked"; };

            txtProductID.Enabled = false;

            txtProductID.Text = product.productID;
            txtProductName.Text = product.productName;
            txtPrice.Text = product.price.ToString();
            txtQuantity.Text = product.quantity.ToString();
            txtShortDescription.Text = product.shortDescription;
            if (product.status.Equals("True"))
            {
                rbStatusTrue.Checked = true;
            } else if (product.status.Equals("False"))
            {
                rbStatusFalse.Checked = true;
            }

            string choose="";
            CategoryDao categoryDao = new CategoryDao();
            List<Category> listCategory = categoryDao.getAllCategory();
            foreach (Category category in listCategory)
            {
                cbxCategory.Items.Add(category.categoryID + "-" + category.categoryName);
                if (category.categoryID.Equals(product.categoryID)) choose = category.categoryID + "-" + category.categoryName;
            }
            cbxCategory.SelectedItem = choose;

            Image imgFirst = byteArrayToImage(product.image);
            imageAvatar.Image = imgFirst;

            DescriptionDao descriptionDao = new DescriptionDao();
            List<Description> listDescription = descriptionDao.getDescriptionByProductID(product.productID);
            foreach (Description description in listDescription)
            {
                if (description.type.Equals("Title"))
                {
                    tab++;
                    status = "Title";

                    TextBox txtTitle = new TextBox()
                    {
                        Name = status + "-" + tab.ToString(),
                        Text = description.title,
                        Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold),
                        Size = new Size(400, 26),
                        Location = new Point(130, location + 10)
                    };
                    Controls.Add(txtTitle);
                    list.Add(txtTitle.Name);

                    showPictureClose(txtTitle.Name);

                    TextBox txt = this.Controls[status + "-" + tab.ToString()] as TextBox;
                    location = txt.Bottom;
                } else if (description.type.Equals("Text"))
                {
                    tab++;
                    status = "Text";

                    TextBox txtText = new TextBox()
                    {
                        Name = status + "-" + tab.ToString(),
                        Text = description.contents,
                        Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular),
                        Size = new Size(400, 100),
                        Location = new Point(130, location + 10),
                        Multiline = true
                    };
                    txtText.ScrollBars = ScrollBars.Both;
                    Controls.Add(txtText);
                    list.Add(txtText.Name);

                    showPictureClose(txtText.Name);

                    TextBox txt = this.Controls[status + "-" + tab.ToString()] as TextBox;
                    location = txt.Bottom;
                } else if (description.type.Equals("Image"))
                {
                    tab++;
                    status = "Image";

                    Image img = byteArrayToImage(description.image);

                    PictureBox pictureBox = new PictureBox()
                    {
                        Name = status + "-" + tab.ToString(),
                        Image = img,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Size = new Size(400, 267),
                        Location = new Point(130, location + 10)
                    };
                    Controls.Add(pictureBox);
                    list.Add(pictureBox.Name);

                    showPictureClose(pictureBox.Name);

                    Label lbUpload;
                    lbUpload = new Label()
                    {
                        Name = "U" + pictureBox.Name,
                        Text = "Upload",
                        Font = new Font("Helvetica", 12, FontStyle.Bold),
                        Location = new Point(550, location + 120),
                        ForeColor = Color.White,
                        BackColor = Color.FromArgb(65, 144, 255),
                        Cursor = Cursors.Hand,
                        Size = new Size(94, 30),
                        AutoSize = false,
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    lbUpload.Click += new EventHandler(delegate (Object o, EventArgs a)
                    {
                        string imageLocation = "";
                        try
                        {
                            OpenFileDialog dialog = new OpenFileDialog();
                            dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
                            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                imageLocation = dialog.FileName;

                                byte[] buffer = File.ReadAllBytes(dialog.FileName);

                                pictureBox.ImageLocation = imageLocation;

                                lbUpload.Focus();
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                    Controls.Add(lbUpload);

                    PictureBox pic = this.Controls[status + "-" + tab.ToString()] as PictureBox;
                    location = pic.Bottom;
                }
                panelDescription.Location = new Point(100, location + 10);
            }
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream mStream = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(mStream);
            }
        }

        private void FormUpdate_Load(object sender, EventArgs e)
        {
            initForm();
        }

        private void lbShopPhone_Click(object sender, EventArgs e)
        {
            resetValue();
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

        private void lbUpload_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;

                    byte[] buffer = File.ReadAllBytes(dialog.FileName);
                    imageAvatar.ImageLocation = imageLocation;

                    lbUpload.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        public void setLocation()
        {
            if (tab != 0)
            {
                if (status.Equals("Title") || status.Equals("Text"))
                {
                    txtBoxBefore = this.Controls[status + "-" + tab.ToString()] as TextBox;
                    location = txtBoxBefore.Bottom;
                }
                else if (status.Equals("Image"))
                {
                    pictureBoxBefore = this.Controls[status + "-" + tab.ToString()] as PictureBox;
                    location = pictureBoxBefore.Bottom;
                }
            }
            else
            {
                location = 525;
            }
        }

        public void moveItemUp(int index, int size)
        {
            for (int i = index; i < list.Count - 1; i++)
            {
                string type = "";
                type = list[i + 1].Split('-')[0].ToString();
                if (type.Equals("Title") || type.Equals("Text"))
                {
                    TextBox txt = this.Controls[type + "-" + (i + 1).ToString()] as TextBox;
                    txt.Location = new Point(txt.Left, txt.Top - size);
                    txt.Name = type + "-" + i.ToString();
                    PictureBox pictureClose = this.Controls["#" + type + "-" + (i + 1).ToString()] as PictureBox;
                    pictureClose.Location = new Point(pictureClose.Left, pictureClose.Top - size);
                    pictureClose.Name = "#" + type + "-" + i.ToString();

                    if (i == list.Count - 2)
                    {
                        status = type;
                    }
                }
                else if (type.Equals("Image"))
                {
                    PictureBox picture = this.Controls[type + "-" + (i + 1).ToString()] as PictureBox;
                    picture.Location = new Point(picture.Left, picture.Top - size);
                    picture.Name = type + "-" + i.ToString();
                    Label lbUpdatePicture = this.Controls["U" + type + "-" + (i + 1).ToString()] as Label;
                    lbUpdatePicture.Location = new Point(lbUpdatePicture.Left, lbUpdatePicture.Top - size);
                    lbUpdatePicture.Name = "U" + type + "-" + i.ToString();
                    PictureBox pictureClose = this.Controls["#" + type + "-" + (i + 1).ToString()] as PictureBox;
                    pictureClose.Location = new Point(pictureClose.Left, pictureClose.Top - size);
                    pictureClose.Name = "#" + type + "-" + i.ToString();

                    if (i == list.Count - 2)
                    {
                        status = type;
                    }
                }
                list[i] = type + "-" + i.ToString();
            }
            list.RemoveAt(list.Count - 1);
        }

        public void showPictureClose(string name)
        {
            string dir = Path.GetDirectoryName(Application.ExecutablePath);
            dir = dir.Substring(0, dir.Length - 10);
            string filename = Path.Combine(dir, @"Image\close.png");

            PictureBox pictureClose = new PictureBox()
            {
                Name = "#" + name,
                Image = Image.FromFile(filename),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Cursor = Cursors.Hand,
                Size = new Size(20, 20),
                Location = new Point(50, location + 13)
            };
            pictureClose.Click += new EventHandler(delegate (Object o, EventArgs a)
            {
                string nameItem = pictureClose.Name.Substring(1, pictureClose.Name.Length - 1);
                string[] listSplit = nameItem.Split('-');
                string subName = listSplit[0];
                int subIndex = Int32.Parse(listSplit[1]);

                if (subName.Equals("Title") || subName.Equals("Text"))
                {
                    TextBox txt = this.Controls[nameItem] as TextBox;
                    Controls.Remove(txt);
                    Controls.Remove(pictureClose);


                    if (subName.Equals("Title"))
                    {
                        if (subIndex != tab)
                        {
                            moveItemUp(subIndex, 36);
                        }
                        else
                        {
                            status = list[tab - 1].Split('-')[0];
                            list.RemoveAt(tab);
                        }
                        panelDescription.Location = new Point(100, panelDescription.Top - 36);
                    }
                    else if (subName.Equals("Text"))
                    {
                        if (subIndex != tab)
                        {
                            moveItemUp(subIndex, 110);
                        }
                        else
                        {
                            status = list[tab - 1].Split('-')[0];
                            list.RemoveAt(tab);
                        }
                        panelDescription.Location = new Point(100, panelDescription.Top - 110);
                    }

                }
                else if (subName.Equals("Image"))
                {
                    PictureBox picture = this.Controls[nameItem] as PictureBox;
                    Label lbUploadPicture = this.Controls["U" + nameItem] as Label;
                    Controls.Remove(picture);
                    Controls.Remove(pictureClose);
                    Controls.Remove(lbUploadPicture);

                    if (subIndex != tab)
                    {
                        moveItemUp(subIndex, 277);
                    }
                    else
                    {
                        status = list[tab - 1].Split('-')[0];
                        list.RemoveAt(tab);
                    }
                    panelDescription.Location = new Point(100, panelDescription.Top - 277);
                }
                panelDescription.Focus();
                tab--;
            });
            Controls.Add(pictureClose);
        }

        private void lbTitle_Click(object sender, EventArgs e)
        {
            panelDescription.Focus();
            FormInsert form = new FormInsert();
            setLocation();

            tab++;
            status = "Title";

            TextBox txtTitle = new TextBox()
            {
                Name = status + "-" + tab.ToString(),
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold),
                Size = new Size(400, 26),
                Location = new Point(130, location + 10)
            };
            Controls.Add(txtTitle);
            list.Add(txtTitle.Name);

            showPictureClose(txtTitle.Name);

            panelDescription.Location = new Point(100, txtTitle.Bottom);
            panelDescription.Focus();
        }

        private void lbText_Click(object sender, EventArgs e)
        {
            panelDescription.Focus();
            FormInsert form = new FormInsert();
            setLocation();

            tab++;
            status = "Text";

            TextBox txtText = new TextBox()
            {
                Name = status + "-" + tab.ToString(),
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular),
                Multiline = true,
                Size = new Size(400, 100),
                Location = new Point(130, location + 10)
            };
            Controls.Add(txtText);
            list.Add(txtText.Name);

            showPictureClose(txtText.Name);

            panelDescription.Location = new Point(100, txtText.Bottom);
            panelDescription.Focus();
        }

        private void lbImage_Click(object sender, EventArgs e)
        {
            panelDescription.Focus();
            FormInsert form = new FormInsert();
            setLocation();

            tab++;
            status = "Image";

            string dir = Path.GetDirectoryName(Application.ExecutablePath);
            dir = dir.Substring(0, dir.Length - 10);
            string filename = Path.Combine(dir, @"Image\pictureDes1.png");

            PictureBox pictureBox = new PictureBox()
            {
                Name = status + "-" + tab.ToString(),
                Image = Image.FromFile(filename),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(400, 267),
                Location = new Point(130, location + 10)
            };
            Controls.Add(pictureBox);
            list.Add(pictureBox.Name);

            showPictureClose(pictureBox.Name);

            Label lbUpload;
            lbUpload = new Label()
            {
                Name = "U" + pictureBox.Name,
                Text = "Upload",
                Font = new Font("Helvetica", 12, FontStyle.Bold),
                Location = new Point(550, location + 120),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(65, 144, 255),
                Cursor = Cursors.Hand,
                Size = new Size(94, 30),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter
            };
            lbUpload.Click += new EventHandler(delegate (Object o, EventArgs a)
            {
                string imageLocation = "";
                try
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
                    if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        imageLocation = dialog.FileName;

                        byte[] buffer = File.ReadAllBytes(dialog.FileName);
                        pictureBox.ImageLocation = imageLocation;

                        lbUpload.Focus();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
            Controls.Add(lbUpload);

            panelDescription.Location = new Point(100, pictureBox.Bottom);
            panelDescription.Focus();
        }

        private void lbSubmit_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            bool check = true;
            string error = "";
            ProductDao productDao = new ProductDao();

            string productID = txtProductID.Text.Trim();

            string productName = txtProductName.Text.Trim();
            if (productName.Length == 0)
            {
                error += "Product name not null!\n";
                check = false;
            }


            double price = 0;
            try
            {
                if (txtPrice.Text.Trim().Length == 0)
                {
                    error += "Price not null!\n";
                    check = false;
                }
                else
                {
                    price = Double.Parse(txtPrice.Text);
                }
            }
            catch (Exception ex)
            {
                error += "Price must double!\n";
                check = false;
            }

            int quantity = 0;
            try
            {
                if (txtQuantity.Text.Trim().Length == 0)
                {
                    error += "Quantity not null!\n";
                    check = false;
                }
                else
                {
                    quantity = Int32.Parse(txtQuantity.Text);
                }
            }
            catch (Exception ex)
            {
                error += "Quantity must int!\n";
                check = false;
            }

            string shortDescription = txtShortDescription.Text.Trim();
            if (shortDescription.Length == 0)
            {
                error += "Short description not null!\n";
                check = false;
            }

            PictureBox imageAvatar = this.Controls["imageAvatar"] as PictureBox;
            ImageConverter converterAvatar = new ImageConverter();

            Bitmap bitmap = new Bitmap(imageAvatar.Image);
            Image resultImage = (Image)bitmap;

            byte[] image = (byte[])converterAvatar.ConvertTo(resultImage, typeof(byte[]));

            string status = "";
            if (rbStatusTrue.Checked) status = "True";
            else if (rbStatusFalse.Checked) status = "False";
            string categoryID = cbxCategory.Text.Split('-')[0];

            if (check == true)
            {
                Product product = new Product(productID, productName, price, quantity, shortDescription, image, status, categoryID);
                productDao.updateProduct(product);

                DescriptionDao descriptionDao = new DescriptionDao();

                descriptionDao.deleteDescriptionOfProduct(product.productID);

                for (int i = 1; i < list.Count; i++)
                {
                    string subName = list[i].Split('-')[0];
                    int subIndex = Int32.Parse(list[i].Split('-')[1]);

                    int number = 0;
                    do
                    {
                        number = rnd.Next(999999);
                    } while (descriptionDao.getDescriptionByID(number.ToString()) != null);
                    if (subName.Equals("Title"))
                    {
                        TextBox txt = this.Controls[list[i]] as TextBox;
                        Description description = new Description(number.ToString(), i, subName, txt.Text, null, null, productID);
                        descriptionDao.addNewDescription(description);
                    }
                    else if (subName.Equals("Text"))
                    {
                        TextBox txt = this.Controls[list[i]] as TextBox;
                        Description description = new Description(number.ToString(), i, subName, null, txt.Text, null, productID);
                        descriptionDao.addNewDescription(description);
                    }
                    else if (subName.Equals("Image"))
                    {
                        PictureBox picture = this.Controls[list[i]] as PictureBox;
                        ImageConverter converter = new ImageConverter();

                        Bitmap bit = new Bitmap(picture.Image);
                        Image imageResult = (Image)bit;
                        byte[] buffer = (byte[])converter.ConvertTo(imageResult, typeof(byte[]));
                        Description description = new Description(number.ToString(), i, subName, null, null, buffer, productID);
                        descriptionDao.addNewDescription(description);
                    }
                }
                Cursor.Current = Cursors.Default;
                string message = "          UPDATE SUCCESSFUL!!    ";
                string title = "Title";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons);

                resetValue();
                this.Close();
                th = new Thread(() => openFormDescription(productID));
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                string message = "Lỗi nhập liệu:\n\n" + error;
                string title = "Lỗi rồi nè :))";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }
        }

        private void openFormDescription(string id)
        {
            Application.Run(new FormDescription() {
                productID = id,
                userID = userID
            });
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            resetValue();
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

        public void resetValue()
        {
            tab = 0;
            status = "";
            txtBoxBefore = null;
            pictureBoxBefore = null;
            location = 525;
            list = new List<string>() { "" };
        }

        private void FormUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void FormUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

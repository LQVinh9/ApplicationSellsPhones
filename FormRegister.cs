using ProjectNhom.dao;
using ProjectNhom.dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectNhom
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //Đảm bảo đầy đủ thông tin và mk = confirm
            if (txtFullName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập vào họ tên.");
                txtFullName.Focus();//đưa con trỏ chuột về lại
            }
            else if (txtPhone.Text.Trim().Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập vào số điện thoại.");
                txtPhone.Focus();
            }
            else if (txtAddress.Text.Trim().Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập vào địa chỉ.");
                txtAddress.Focus();
            }
            else if (txtUserID.Text.Trim().Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập vào tên đăng nhập.");
                txtUserID.Focus();
            }
            else if (txtPassword.Text.Trim().Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập vào mật khẩu.");
                txtPassword.Focus();
            }
            else if (txtConfirm.Text.Trim().Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập lại mật khẩu.");
                txtConfirm.Focus();
            }
            else if (txtPassword.Text != txtConfirm.Text)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu phải giống nhau");
                txtConfirm.Focus();
                txtConfirm.SelectAll();
            }

            //KT MK hợp lệ đúng định dạng
            else
            {
                User user = new User(txtUserID.Text, txtFullName.Text, txtPassword.Text, txtAddress.Text, txtPhone.Text);

                if (user.checkFormatPassword() == true)
                {
                    UserDao userDao = new UserDao();
                    userDao.addNewUser(user);

                    MessageBox.Show("Đăng kí tài khoản thành công" + "\nTên: " + user.formatName()
                        + "\nPhone: " + txtPhone.Text
                        + "\nAddress: " + txtAddress.Text
                        + "\nUser Name: " + txtUserID.Text);


                    this.Hide();

                    FormLogin formLogin = new FormLogin();
                    formLogin.Show();
                }
                else
                {
                    MessageBox.Show("Mật khẩu sai định dạng");
                }
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Chỉ được nhập số
            //Không phải số -> ko cho nhập
            //Số && nút Xóa thì ok
            if (!Char.IsDigit(e.KeyChar) && (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Chỉ cho phép nhập chữ & space & delete
            if (!Char.IsLetter(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && (Keys)e.KeyChar != Keys.Space)
            {
                e.Handled = true;
            }

            //Chuẩn hóa trực tiếp họ tên
            if (txtFullName.Text == "")
            {
                if ((Keys)e.KeyChar == Keys.Space)
                {
                    e.Handled = true;
                }

                //Gõ kí tự in thường => In HOA
                if (Char.IsLower(e.KeyChar))
                {
                    e.Handled = true;

                    char c = e.KeyChar;
                    txtFullName.Text = c.ToString().ToUpper();
                    txtFullName.Select(txtFullName.Text.Length, 1);
                }
            }
            else //Đã có dữ liệu 
            {
                if (txtFullName.Text[txtFullName.Text.Length - 1] != ' ') //TH kí tự cc KHONG là khoảng trắng VD:THANH NHI
                {
                    if (Char.IsUpper(e.KeyChar))
                    {
                        e.Handled = true;

                        char c = e.KeyChar;
                        txtFullName.Text += c.ToString().ToLower(); // += vì nó đã có sẵn chuỗi trc đó rồi
                        txtFullName.Select(txtFullName.Text.Length, 1); //Cho trỏ chuột select về cuối
                    }
                }
                else if (txtFullName.Text[txtFullName.Text.Length - 1] == ' ') //TH kí tự cc là khoảng trắng
                {
                    if ((Keys)e.KeyChar == Keys.Space)
                    {
                        e.Handled = true;
                    }

                    if (Char.IsLower(e.KeyChar))
                    {
                        e.Handled = true;

                        char c = e.KeyChar;
                        txtFullName.Text += c.ToString().ToUpper(); // += vì nó đã có sẵn chuỗi trc đó rồi
                        txtFullName.Select(txtFullName.Text.Length, 1); //Cho trỏ chuột select về cuối
                    }
                }
            }
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {

        }

        private void FormRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void FormRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

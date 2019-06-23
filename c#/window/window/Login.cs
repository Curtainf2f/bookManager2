using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace window
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.loginB_Click(sender, e);
            }
        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                this.loginB_Click(sender, e); 
            }
        }

        private void loginB_Click(object sender, EventArgs e)
        {
            try
            {
                LinkedList<string> col = new LinkedList<string>();
                LinkedList<object> data = new LinkedList<object>();
                col.AddLast("username"); data.AddLast(username.Text);
                col.AddLast("pwd"); data.AddLast(password.Text);
                if (Database.haveData("users", col, data))
                {
                    MessageBox.Show("登陆成功");
                    User user = new User(username.Text, this);
                    user.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误");
                }
            }catch(Exception ec){
                MessageBox.Show(ec.Message);
            }
        }

        private void adminB_Click(object sender, EventArgs e)
        {
            try
            {
                LinkedList<string> col = new LinkedList<string>();
                LinkedList<object> data = new LinkedList<object>();
                col.AddLast("username"); data.AddLast(username.Text);
                col.AddLast("pwd"); data.AddLast(password.Text);
                if (Database.haveData("admins", col, data))
                {
                    MessageBox.Show("登陆成功");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误");
                }
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void regB_Click(object sender, EventArgs e)
        {
            Reg reg = new Reg();
            reg.Show();
        }
    }
}

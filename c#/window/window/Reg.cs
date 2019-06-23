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
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }


        private void username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.regB_Click(sender, e);
            }
        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.regB_Click(sender, e);
            }
        }

        private void confirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.regB_Click(sender, e);
            }
        }

        private void regB_Click(object sender, EventArgs e)
        {
            try
            {
                if (!password.Text.Equals(confirmPassword.Text))
                    throw new Exception("密码与确认密码不匹配");
                if (username.Text.Equals(""))
                    throw new Exception("用户名不能为空");
                if (password.Text.Equals(""))
                    throw new Exception("密码不能为空");
                LinkedList<string> col = new LinkedList<string>();
                LinkedList<object> data = new LinkedList<object>();
                col.AddLast("username"); data.AddLast(username.Text);
                if (Database.haveData("users", col, data))
                    throw new Exception("用户名已存在");
                data.AddLast(password.Text);
                data.AddLast("null");
                Database.insert("users", data);
                MessageBox.Show("注册成功");
                this.Dispose();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void resetB_Click(object sender, EventArgs e)
        {
            try
            {
                username.Text = "";
                password.Text = "";
                confirmPassword.Text = "";
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

    }
}

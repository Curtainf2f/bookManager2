using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
                    Admin admin = new Admin();
                    admin.Show();
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

        private void Button1_Click(object sender, EventArgs e) {
            try {
                string sql = "select * from users where userCard = '" + cardCode.Text + "'";
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (!rd.Read() || cardCode.Text.Equals("")) {
                        throw new Exception("无效的磁卡");
                    }
                    MessageBox.Show("登陆成功");
                    User user = new User(rd["username"].ToString(), this);
                    user.Show();
                    this.Hide();
                }
            } catch (Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }

        private void ReturnB_Click(object sender, EventArgs e) {
            try {
                string sql = "delete from borrow where barCode = " + barCode.Text;
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    if (cmd.ExecuteNonQuery() > 0) {
                        MessageBox.Show("归还成功");
                    } else {
                        throw new Exception("已借出书中不存在该书");
                    }
                }
            } catch (Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }

        private void BarCode_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.ReturnB_Click(sender, e);
            }
        }

        private void CardCode_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Button1_Click(sender, e);
            }
        }
    }
}

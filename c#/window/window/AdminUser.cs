using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace window {
    public partial class AdminUser : Form {
        private string username;
        private int readerId;
        public AdminUser(string username) {
            InitializeComponent();
            this.username = username;
        }
        private void AdminUser_Load(object sender, EventArgs e) {
            getReaderId();
            if(readerId == -1) {
                button3.Visible = false;
                name.ReadOnly = true;
                age.ReadOnly = true;
                phone.ReadOnly = true;
                dept.ReadOnly = true;
            }
            readerTypesLoad();
            InfoLoad();
        }
        private void Button3_Click(object sender, EventArgs e) {
            panel1.Visible = true;
        }

        private void Button10_Click(object sender, EventArgs e) {
            try {
                LinkedList<string> col = new LinkedList<string>();
                LinkedList<object> data = new LinkedList<object>();
                col.AddLast("pwd"); data.AddLast(password.Text);
                string sql = Database.update("users", col, data);
                sql += " where username = " + Database.process(username);
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
                }
                if(readerId != -1) {
                    col.Clear();
                    data.Clear();
                    col.AddLast("name"); data.AddLast(name.Text);
                    col.AddLast("sex"); data.AddLast(sex.Text);
                    col.AddLast("age"); data.AddLast(Convert.ToInt32(age.Text));
                    col.AddLast("phone"); data.AddLast(phone.Text);
                    col.AddLast("dept"); data.AddLast(dept.Text);
                    col.AddLast("readerTypeId"); data.AddLast(typeName.SelectedIndex + 1);
                    sql = Database.update("readers", col, data);
                    sql += " where readerId = " + readerId;
                    using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                        cn.Open();
                        SqlCommand cmd = new SqlCommand(sql, cn);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("修改成功");
            } catch(Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }

        private void Button1_Click(object sender, EventArgs e) {
            InfoLoad();
        }
        private void readerTypesLoad() {
            ArrayList list = new ArrayList();
            string sql = "select typeName from readerTypes";
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows) {
                    list.Add(dr[0].ToString().Trim());
                }
                typeName.DataSource = list;
            }
        }
        private void getReaderId() {
            string sql = "select readerId from users where username = " + Database.process(username);
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                if (rd["readerId"].ToString().Equals("")) {
                    readerId = -1;
                    return;
                }
                readerId = Convert.ToInt32(rd["readerId"].ToString());
            }
        }

        private void InfoLoad() {
            string sql = "select * from users where username = " + Database.process(username);
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                usernameT.Text = rd["username"].ToString();
                password.Text = rd["pwd"].ToString();
                userCard.Text = rd["userCard"].ToString();
            }
            if(readerId != -1) {
                sql = "select * from readers where readerId = " + readerId;
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataReader rd = cmd.ExecuteReader();
                    rd.Read();
                    name.Text = rd["name"].ToString();
                    idCard.Text = rd["idCard"].ToString();
                    typeName.SelectedIndex = Convert.ToInt32(rd["readerTypeId"].ToString()) - 1;
                    sex.Text = rd["sex"].ToString();
                    age.Text = rd["age"].ToString();
                    phone.Text = rd["phone"].ToString();
                    dept.Text = rd["dept"].ToString();
                    regDate.Text = rd["regDate"].ToString();
                }
            }
        }

        private void Dept_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Button10_Click(sender, e);
            }
        }

        private void Button4_Click(object sender, EventArgs e) {
            try {
                string sql = "exec changeUser '" + idCard.Text + "','" + newUsername.Text + "','" + newPassword.Text + "'";
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
                }
                username = newUsername.Text;
                InfoLoad();
                panel1.Visible = false;
                newPassword.Text = "";
                newUsername.Text = "";
                MessageBox.Show("换号成功");
            } catch (Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }

        private void NewPassword_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Button4_Click(sender, e);
            }
        }
    }
}

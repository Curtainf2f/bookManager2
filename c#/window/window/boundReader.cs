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
    public partial class BoundReader : Form {
        private string username;
        private Login loginWin;
        public BoundReader(string username, Login loginWin) {
            InitializeComponent();
            this.username = username;
            this.loginWin = loginWin;
        }

        private void Button1_Click(object sender, EventArgs e) {
            try {
                string sql = "exec boundReader '"+username+"', "+ (type.SelectedIndex + 1).ToString() +", '" + idCard.Text +"', '"+ readerName.Text +"', '" + sex.Text + "', " + age.Text + ", '" + tel.Text + "', '"+ dept.Text +"'";
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("绑定成功");
                    loginWin.Show();
                    this.Dispose();
                }
            } catch(Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }

        private void BoundReader_Load(object sender, EventArgs e) {
            ReaderTypeLoad();
            SexLoad();
        }
        private void ReaderTypeLoad() {
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
                type.DataSource = list;
            }
        }
        private void SexLoad() {
            ArrayList list = new ArrayList();
            list.Add("男");
            list.Add("女");
            sex.DataSource = list;
        }

        private void BoundReader_FormClosing(object sender, FormClosingEventArgs e) {
            loginWin.Show();
            this.Dispose();
        }

        private void IdCard_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Button1_Click(sender, e);
            }
        }

        private void ReaderName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Button1_Click(sender, e);
            }
        }

        private void Age_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Button1_Click(sender, e);
            }
        }

        private void Tel_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Button1_Click(sender, e);
            }
        }

        private void Dept_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Button1_Click(sender, e);
            }
        }
    }
}

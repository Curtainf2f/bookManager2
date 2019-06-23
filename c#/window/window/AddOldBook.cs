using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace window {
    public partial class AddOldBook : Form {
        public AddOldBook() {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e) {
            try {
                string sql = "exec addBook '" + ISBN.Text + "'";
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    int t = Convert.ToInt32(items.Text);
                    for(int i = 0; i < t; i++) {
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("添加成功");
                this.Dispose();
            } catch(Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }

        private void Items_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Button1_Click(sender, e);
            }
        }
    }
}

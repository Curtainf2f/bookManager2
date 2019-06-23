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
    public partial class AddNewBook : Form {
        public AddNewBook() {
            InitializeComponent();
        }

        private void AddNewBook_Load(object sender, EventArgs e) {
            ArrayList list = new ArrayList();
            string sql = "select typeName from bookTypes";
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

        private void Button1_Click(object sender, EventArgs e) {
            LinkedList<string> col = new LinkedList<string>();
            LinkedList<object> data = new LinkedList<object>();
            col.AddLast("ISBN");
            col.AddLast("bookTypeId");
            col.AddLast("name");
            col.AddLast("author");
            col.AddLast("publisher");
            col.AddLast("publishTime");
            col.AddLast("price");
            data.AddLast(ISBN.Text);
            data.AddLast(typeName.SelectedIndex + 1);
            data.AddLast(name.Text);
            data.AddLast(author.Text);
            data.AddLast(publisher.Text);
            data.AddLast(publishTime.Text);
            data.AddLast(Convert.ToDouble(price.Text));
            Database.insert("bookItem", col, data);
            string sql = "exec addBook '" + ISBN.Text + "'";
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                int t = Convert.ToInt32(items.Text);
                for (int i = 0; i < t; i++) {
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("添加成功");
            this.Dispose();
        }
    }
}

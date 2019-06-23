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
    public partial class AdminReaderType : Form {
        public AdminReaderType() {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e) {
            try {
                string sql = "exec addReaderType '" + typeName.Text + "'," + Items.Text + "," + Times.Text;
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                    cn.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
                }
            } catch(Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }

        private void Button2_Click(object sender, EventArgs e) {
            try {
                string sql = "select readerTypeId, typeName 类型名称, bookCanBorrow 可借阅本数, bookTimeCanBorrow 可借阅时长 from readerTypes";
                LinkedList<string> col = new LinkedList<string>();
                LinkedList<object> data = new LinkedList<object>();
                if (!typeName.Text.Equals("")) {
                    col.AddLast("typeName");
                    data.AddLast(typeName.Text);
                }
                if (!Items.Text.Equals("")) {
                    col.AddLast("bookCanBorrow");
                    data.AddLast(Convert.ToInt32(Items.Text));
                }
                if (!Times.Text.Equals("")) {
                    col.AddLast("bookTimeCanBorrow");
                    data.AddLast(Convert.ToInt32(Times.Text));
                }
                sql += Database.getSearch(col, data);
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                    cn.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0].Copy();
                    this.dataGridView1.DataSource = dt;
                    this.dataGridView1.Columns[0].Visible = false;
                    this.dataGridView1.Refresh();
                }
            } catch (Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            try {
                string sql = "delete from readerTypes where readerTypeId = " + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                    cn.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
                }
                Button2_Click(sender, e);
            } catch (Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }
    }
}

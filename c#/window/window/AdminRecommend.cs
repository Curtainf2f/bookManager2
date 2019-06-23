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
    public partial class AdminRecommend : Form {
        public AdminRecommend() {
            InitializeComponent();
        }

        private void DataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.ColumnIndex == 7) {
                    string sql = "update recommend set recommendStatus = '" + dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "' where ISBN = '" + dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString() + "'";
                    using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                        cn.Open();
                        SqlCommand cmd = new SqlCommand(sql, cn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("修改成功");
                    }
                } else if (e.ColumnIndex == 8) {
                    string sql = "update recommend set remarks = '" + dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "' where ISBN = '" + dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString() + "'";
                    using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                        cn.Open();
                        SqlCommand cmd = new SqlCommand(sql, cn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("修改成功");
                    }
                } else {
                    AdminRecommend_Load(sender, e);
                    MessageBox.Show("只能修改状态和备注");
                }
            } catch(Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }

        private void AdminRecommend_Load(object sender, EventArgs e) {
            string sql = "select users.username 用户名, readers.name 读者姓名, ISBN, bookName 书名, author 作者, publish 出版社, recommendDate 荐阅日期, recommendStatus 当前状态, remarks 管理员备注";
            sql += " from recommend left join readers on readers.readerId = recommend.readerId left join users on users.readerId = readers.readerId order by recommendDate desc";
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                cn.Open();
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                this.dataGridView3.DataSource = dt;
                this.dataGridView3.Refresh();
            }
        }
    }
}

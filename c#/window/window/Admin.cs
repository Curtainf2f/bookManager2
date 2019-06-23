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
    public partial class Admin : Form {
        public Admin() {
            InitializeComponent();
        }
        private void Admin_Load(object sender, EventArgs e) {
            ReaderType2Load();
            bookTypeLoad();
            sex2.SelectedIndex = 0;
        }
        //用户管理
        private void Username_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.UserSearch_Click(sender, e);
            }
        }
        private void ReaderName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.UserSearch_Click(sender, e);
            }
        }
        private void IdCard_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.UserSearch_Click(sender, e);
            }
        }
        private void UserSearch_Click(object sender, EventArgs e) {
            try {
                string sql = "select users.username 用户名, users.pwd 密码, readerTypes.typeName 读者类型, readers.name 读者姓名, readers.idCard 身份证号, readers.sex 性别, readers.age 年龄, readers.phone 电话, readers.dept 系别, readers.regDate 注册时间 from users left join readers on users.readerId = readers.readerId left join readerTypes on readers.readerTypeId = readerTypes.readerTypeId";
                LinkedList<string> col = new LinkedList<string>();
                LinkedList<object> data = new LinkedList<object>();
                if (!username.Text.Equals("")) {
                    col.AddLast("users.username");
                    data.AddLast(username.Text);
                }
                if (!readerName.Text.Equals("")) {
                    col.AddLast("readers.name");
                    data.AddLast(readerName.Text);
                }
                if (!idCard.Text.Equals("")) {
                    col.AddLast("readers.idCard");
                    data.AddLast(idCard.Text);
                }
                if (!dept.Text.Equals("")) {
                    col.AddLast("readers.dept");
                    data.AddLast(dept.Text);
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
                    this.dataGridView1.Refresh();
                }
            } catch (Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e) {
            Application.Exit();
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            try {
                string username = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                AdminUser admin = new AdminUser(username);
                admin.Show();
            } catch (Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }
        //读者
        private void ReaderType2Load() {
            ArrayList list = new ArrayList();
            string sql = "select typeName from readerTypes";
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                list.Add("全部");
                foreach (DataRow dr in dt.Rows) {
                    list.Add(dr[0].ToString().Trim());
                }
                readerType2.DataSource = list;
            }
        }
        private void Button6_Click(object sender, EventArgs e) {
            try {
                string sql = "select users.username 用户名, users.pwd 密码, readerTypes.typeName 读者类型, readers.name 读者姓名, readers.idCard 身份证号, readers.sex 性别, readers.age 年龄, readers.phone 电话, readers.dept 系别, readers.regDate 注册时间 from users left join readers on users.readerId = readers.readerId left join readerTypes on readers.readerTypeId = readerTypes.readerTypeId";
                LinkedList<string> col = new LinkedList<string>();
                LinkedList<object> data = new LinkedList<object>();
                if (!readerName2.Text.Equals("")) {
                    col.AddLast("readers.name");
                    data.AddLast(readerName2.Text);
                }
                if (!idCard2.Text.Equals("")) {
                    col.AddLast("readers.idCard");
                    data.AddLast(idCard2.Text);
                }
                if (!dept2.Text.Equals("")) {
                    col.AddLast("readers.dept");
                    data.AddLast(dept2.Text);
                }
                if (!readerType2.Text.Equals("全部")) {
                    col.AddLast("readerTypes.typeName");
                    data.AddLast(readerType2.Text);
                }
                if (!sex2.Text.Equals("全部")) {
                    col.AddLast("readers.sex");
                    data.AddLast(sex2.Text);
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
                    this.dataGridView2.DataSource = dt;
                    this.dataGridView2.Refresh();
                }
            } catch (Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }

        private void Dept2_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Button6_Click(sender, e);
            }
        }

        private void DataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            try {
                string username = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                AdminUser admin = new AdminUser(username);
                admin.Show();
            } catch (Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }

        private void Button7_Click(object sender, EventArgs e) {
            AdminReaderType a = new AdminReaderType();
            a.Show();
        }

        // 图书管理
        private void bookTypeLoad() {
            ArrayList list = new ArrayList();
            string sql = "select typeName from bookTypes";
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                list.Add("全部");
                foreach (DataRow dr in dt.Rows) {
                    list.Add(dr[0].ToString().Trim());
                }
                bookType.DataSource = list;
            }
        }
        private void Button1_Click(object sender, EventArgs e) {
            try {
                LinkedList<string> col = new LinkedList<string>();
                LinkedList<object> data = new LinkedList<object>();
                if (!ISBN.Text.Equals("")) {
                    col.AddLast("bookItem.ISBN");
                    data.AddLast(ISBN.Text);
                }
                if (!author.Text.Equals("")) {
                    col.AddLast("bookItem.author");
                    data.AddLast(author.Text);
                }
                if (!publisher.Text.Equals("")) {
                    col.AddLast("bookItem.publisher");
                    data.AddLast(publisher.Text);
                }
                if (!bookName.Text.Equals("")) {
                    col.AddLast("bookItem.name");
                    data.AddLast(bookName.Text);
                }
                if (!bookType.Text.Equals("全部")) {
                    col.AddLast("bookTypes.typeName");
                    data.AddLast(bookType.Text);
                }
                string sql = "select top 1000 bookItem.ISBN, row_number() over (order by borrowTimes desc) 排名, bookTypes.typeName 书本类型, bookItem.name 书名, bookItem.author 作者, bookItem.publisher 出版社, borrowTimes 借阅册次, inventory 库存, isBorrowed 已被借阅";
                sql += " from bookItem left join bookTypes on bookItem.bookTypeId = bookTypes.bookTypeId";
                sql += Database.getSearch(col, data);
                sql += " order by 借阅册次 desc";
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
            } catch (Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }

        private void BookName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Button1_Click(sender, e);
            }
        }
        private void DataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            try {
                BookInfo b = new BookInfo(-1, dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString());
                b.Show();
            } catch (Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }




        // 当前借阅
        private void Button4_Click(object sender, EventArgs e) {
            try {
                string sql = "select ISBN from books where barCode = " + barCode4.Text;
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                    cn.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataReader rd = cmd.ExecuteReader();
                    rd.Read();
                    BookInfo b = new BookInfo(-1, rd["ISBN"].ToString());
                    b.Show();
                }
            } catch (Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }

        private void Button14_Click(object sender, EventArgs e) {
            try {
                string sql = "select users.username 用户名, readers.name 读者姓名, borrow.barCode 条形码, borrow.borrowTime 借阅时间, borrow.borrowTime + dbo.getReaderCanBorrowTimes(readers.readerId) 最晚归还时间";
                sql += " from borrow left join readers on readers.readerId = borrow.readerId left join users on readers.readerId = users.readerId";
                LinkedList<string> col = new LinkedList<string>();
                LinkedList<object> data = new LinkedList<object>();
                if (!username4.Text.Equals("")) {
                    col.AddLast("users.username");
                    data.AddLast(username4.Text);
                }
                if (!readerName4.Text.Equals("")) {
                    col.AddLast("readers.name");
                    data.AddLast(readerName4.Text);
                }
                if (!barCode4.Text.Equals("")) {
                    col.AddLast("borrow.barCode");
                    data.AddLast(barCode4.Text);
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
                    this.dataGridView4.DataSource = dt;
                    this.dataGridView4.Refresh();
                }
            } catch (Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }

        private void Button3_Click(object sender, EventArgs e) {
            AddOldBook a = new AddOldBook();
            a.Show();
        }

        private void Button2_Click(object sender, EventArgs e) {
            AddNewBook a = new AddNewBook();
            a.Show();
        }

        private void Button8_Click(object sender, EventArgs e) {
            AdminBookType a = new AdminBookType();
            a.Show();
        }

        private void Button12_Click(object sender, EventArgs e) {
            AdminRecommend a = new AdminRecommend();
            a.Show();
        }

        private void Button5_Click(object sender, EventArgs e) {
            try {
                string sql = "select ISBN from books where barCode = " + barCode5.Text;
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                    cn.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataReader rd = cmd.ExecuteReader();
                    rd.Read();
                    BookInfo b = new BookInfo(-1, rd["ISBN"].ToString());
                    b.Show();
                }
            } catch (Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }

        private void Button9_Click(object sender, EventArgs e) {
            try {
                string sql = "select users.username 用户名, readers.name 读者姓名, borrowLog.barCode 条形码, borrowLog.borrowTime 借阅时间, borrowLog.returnTime 归还时间, fine 罚金, remarks 管理员备注, paymented 是否缴费";
                sql += " from borrowLog left join readers on readers.readerId = borrowLog.readerId left join users on readers.readerId = users.readerId";
                LinkedList<string> col = new LinkedList<string>();
                LinkedList<object> data = new LinkedList<object>();
                if (!username5.Text.Equals("")) {
                    col.AddLast("users.username");
                    data.AddLast(username4.Text);
                }
                if (!readerName5.Text.Equals("")) {
                    col.AddLast("readers.name");
                    data.AddLast(readerName4.Text);
                }
                if (!barCode5.Text.Equals("")) {
                    col.AddLast("borrowLog.barCode");
                    data.AddLast(barCode4.Text);
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
                    this.dataGridView5.DataSource = dt;
                    this.dataGridView5.Refresh();
                }
            } catch (Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }

        private void DataGridView5_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.ColumnIndex == 5) {
                    string sql = "update borrowLog set fine = " + dataGridView5.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    sql += " where barCode = " + dataGridView5.Rows[e.RowIndex].Cells[2].Value.ToString();
                    sql += " and borrowTime = '" + dataGridView5.Rows[e.RowIndex].Cells[3].Value.ToString() + "'";
                    sql += " and returnTime = '" + dataGridView5.Rows[e.RowIndex].Cells[4].Value.ToString() + "'";
                    using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                        cn.Open();
                        SqlCommand cmd = new SqlCommand(sql, cn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("修改成功");
                    }
                } else if (e.ColumnIndex == 6) {
                    string sql = "update borrowLog set remarks = '" + dataGridView5.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "'";
                    sql += " where barCode = " + dataGridView5.Rows[e.RowIndex].Cells[2].Value.ToString();
                    sql += " and borrowTime = '" + dataGridView5.Rows[e.RowIndex].Cells[3].Value.ToString() + "'";
                    sql += " and returnTime = '" + dataGridView5.Rows[e.RowIndex].Cells[4].Value.ToString() + "'";
                    using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                        cn.Open();
                        SqlCommand cmd = new SqlCommand(sql, cn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("修改成功");
                    }
                } else if (e.ColumnIndex == 7) {
                    string sql = "update borrowLog set paymented = '" + dataGridView5.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "'";
                    sql += " where barCode = " + dataGridView5.Rows[e.RowIndex].Cells[2].Value.ToString();
                    sql += " and borrowTime = '" + dataGridView5.Rows[e.RowIndex].Cells[3].Value.ToString() + "'";
                    sql += " and returnTime = '" + dataGridView5.Rows[e.RowIndex].Cells[4].Value.ToString() + "'";
                    using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                        cn.Open();
                        SqlCommand cmd = new SqlCommand(sql, cn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("修改成功");
                    }
                } else {
                    MessageBox.Show("不可修改");
                }
            } catch(Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }
    }
}

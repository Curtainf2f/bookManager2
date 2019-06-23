using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace window
{
    public partial class User : Form
    {
        private string username;
        private int readerId;
        Login loginWin;
        public User(string username, Login loginWin)
        {
            InitializeComponent();
            this.username = username;
            this.loginWin = loginWin;
        }
        private void User_Load(object sender, EventArgs e) {
            userWelComeLoad();
            if(readerId == -1) {
                MessageBox.Show("请绑定读者信息");
                BoundReader boundReader = new BoundReader(username, loginWin);
                boundReader.Show();
                this.Dispose();
                return;
            }
            bookType_Load();
            canBorrowLoad();
            HotBooksLoad();
            recommendLoad();
            FineInfo_Click(sender, e);
            if (dataGridView2.RowCount > 1) {
                MessageBox.Show("您有书即将到期");
            }
            NowBorrow_Click(sender, e);
            InfoLoad();
            fineLoad();
        }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e) {
            TabControl1_TabIndexChanged(sender, e);
        }
        private void TabControl1_TabIndexChanged(object sender, EventArgs e) {
            canBorrowLoad();
            if (tabControl1.SelectedIndex == 0) {
                HotBooksLoad();
            }else if(tabControl1.SelectedIndex == 1) {
                NowBorrow_Click(sender, e);
            }else if(tabControl1.SelectedIndex == 2) {
                recommendLoad();
            } else if(tabControl1.SelectedIndex == 3) {
                InfoLoad();
            } else if(tabControl1.SelectedIndex == 4) {
                fineLoad();
            }
        }
        private void User_Activated(object sender, EventArgs e) {
            TabControl1_TabIndexChanged(sender, e);
        }
        private void canBorrowLoad() {
            string sql = "select count(*) from borrow where readerId = " + readerId;
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                canBorrow.Text = "当前借阅(" + rd[0].ToString() + ")/最大借阅(";
            }
            sql = "select dbo.getReaderCanBorrowItem(" + readerId +")";
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                canBorrow.Text += rd[0].ToString() + ")";
            }

        }
        // 借阅
        private void ISBN_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Button1_Click(sender, e);
            }
        }
        private void Author_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Button1_Click(sender, e);
            }
        }
        private void Publisher_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Button1_Click(sender, e);
            }
        }
        private void BookName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Button1_Click(sender, e);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try{
                LinkedList<string> col = new LinkedList<string>();
                LinkedList<object> data = new LinkedList<object>();
                HotBooksLoad();
            }catch(Exception ec){
                MessageBox.Show(ec.Message);
            }
        }
        public void HotBooksLoad()
        {
            DataSet ds = new DataSet();
            string sql = "select top 100 bookItem.ISBN, row_number() over (order by borrowTimes desc) 排名, bookTypes.typeName 书本类型, bookItem.name 书名, bookItem.author 作者, bookItem.publisher 出版社, borrowTimes 借阅册次, inventory 库存, isBorrowed 已被借阅";
            sql += " from bookItem left join bookTypes on bookItem.bookTypeId = bookTypes.bookTypeId order by 借阅册次 desc";
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                this.dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                this.dataGridView1.Refresh();
            }
        }
        private void User_FormClosing(object sender, FormClosingEventArgs e) {
            Application.Exit();
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.RowIndex < 0) return;
                string ISBN = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                BookInfo bookinfo = new BookInfo(readerId, ISBN);
                bookinfo.Show();
            } catch (Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }
        private void userWelComeLoad() {
            string sql = "select readers.name, readers.readerId from users left join readers on users.readerId = readers.readerId where username = '" + username + "'";
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                userWelcome.Text += rd["name"].ToString();
                if (rd["readerId"].ToString().Equals("")) {
                    readerId = -1;
                    return;
                }
                readerId = Convert.ToInt32(rd["readerId"].ToString());
            }
            userWelcome.Text += " 注销";
            userWelcome.LinkArea = new LinkArea(userWelcome.Text.Length - 2, 2);
        }

        private void bookType_Load() {
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

        private void UserWelcome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            loginWin.Show();
            this.Dispose();
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
                    this.dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Visible = false;
                    this.dataGridView1.Refresh();
                }
            } catch (Exception ec) {
                MessageBox.Show(ec.Message);
            }

        }

        // 归还
        private void BarCode_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.ReturnBook_Click(sender, e);
            }
        }
        private void NowBorrow_Click(object sender, EventArgs e) {
            try {
                string sql = "select * from borrowInfo";
                sql += " where readerId = " + readerId;
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                    cn.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0].Copy();
                    this.dataGridView2.DataSource = dt;
                    this.dataGridView2.Columns[0].Visible = false;
                    this.dataGridView2.Refresh();
                }
            } catch(Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }

        private void OverTime_Click(object sender, EventArgs e) {
            try {
                string sql = "select * from borrowInfo";
                sql += " where readerId = " + readerId + " and 是否超时 = '已超时'";
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                    cn.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0].Copy();
                    this.dataGridView2.DataSource = dt;
                    this.dataGridView2.Columns[0].Visible = false;
                    this.dataGridView2.Refresh();
                }
            }catch(Exception ec) {
                MessageBox.Show(ec.Message);
            }

        }

        private void BorrowLog_Click(object sender, EventArgs e) {
            try {
                string sql = "select borrowLog.readerId, borrowLog.barCode 条形码, books.ISBN, bookItem.name 书名, bookItem.author 作者, bookItem.publisher 出版社, ";
                sql += "borrowLog.borrowTime 借出时间, borrowLog.returnTime 归还时间, borrowLog.fine 罚金, ";
                sql += "borrowLog.remarks 管理员备注, borrowLog.paymented 是否缴费 from borrowLog left join books on books.barCode = borrowLog.barCode left join bookItem on bookItem.ISBN = books.ISBN";
                sql += " where borrowLog.readerId = " + readerId;
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                    cn.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0].Copy();
                    this.dataGridView2.DataSource = dt;
                    this.dataGridView2.Columns[0].Visible = false;
                    this.dataGridView2.Refresh();
                }
            }catch(Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }

        private void FineInfo_Click(object sender, EventArgs e) {
            try {
                string sql = "select borrow.readerId, borrow.barCode 条形码, books.ISBN, bookItem.name 书名, bookItem.author 作者, bookItem.publisher 出版社, borrow.borrowTime 借阅时间, borrow.borrowTime + dbo.getReaderCanBorrowTimes(borrow.readerId) 最晚归还时间";
                sql += " from borrow left join books on borrow.barCode = books.barCode left join bookItem on books.ISBN = bookItem.ISBN";
                sql += " where datediff(day, borrow.borrowTime +dbo.getReaderCanBorrowTimes(borrow.readerId), getdate()) <= 3";
                sql += " and readerId = " + readerId;
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                    cn.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0].Copy();
                    this.dataGridView2.DataSource = dt;
                    this.dataGridView2.Columns[0].Visible = false;
                    this.dataGridView2.Refresh();
                }
            } catch(Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }

        private void ReturnBook_Click(object sender, EventArgs e) {
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
            } catch(Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }
        //读者荐阅
        // select ISBN, bookName 书名, author 作者, publish 出版社, recommendDate 推荐日期, recommendStatus 推荐状态, remarks 管理员备注 from recommend order by recommendDate desc
        private void recommendLoad() {
            try {
                string sql = "select ISBN, bookName 书名, author 作者, publish 出版社, recommendDate 推荐日期, recommendStatus 推荐状态, remarks 管理员备注 from recommend order by recommendDate desc";
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

        private void RecommendAuthor_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Recommend_Click(sender, e);
            }
        }
        private void RecommendName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Recommend_Click(sender, e);
            }
        }
        private void RecommendPublisher_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Recommend_Click(sender, e);
            }
        }
        private void RecommendISBN_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Recommend_Click(sender, e);
            }
        }
        private void Recommend_Click(object sender, EventArgs e) {
            try {
                LinkedList<string> col = new LinkedList<string>();
                LinkedList<object> data = new LinkedList<object>();
                col.AddLast("readerId"); data.AddLast(readerId);
                if (!recommendISBN.Text.Equals("")) {
                    col.AddLast("ISBN");
                    data.AddLast(recommendISBN.Text);
                }
                if (!recommendAuthor.Text.Equals("")) {
                    col.AddLast("author");
                    data.AddLast(recommendAuthor.Text);
                }
                if (!recommendName.Text.Equals("")) {
                    col.AddLast("bookName");
                    data.AddLast(recommendName.Text);
                }
                if (!recommendPublisher.Text.Equals("")) {
                    col.AddLast("publish");
                    data.AddLast(recommendPublisher.Text);
                }
                col.AddLast("recommendDate"); data.AddLast("getdate()");
                col.AddLast("recommendStatus"); data.AddLast("待处理");
                Database.insert("recommend", col, data);
                recommendLoad();
            } catch (Exception ec){
                MessageBox.Show(ec.Message);
            }
        }

        private void ResetRecommend_Click(object sender, EventArgs e) {
            recommendISBN.Text = recommendAuthor.Text = recommendName.Text = recommendPublisher.Text = "";
        }

        // 个人信息
        private void ReturnMoney_Click(object sender, EventArgs e) {
            tabControl1.SelectTab(4);
        }
        private void InfoLoad() {
            string sql = "select * from readers where readerId = " + readerId;
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                infoAge.Text = rd["age"].ToString();
                infoDate.Text = rd["regDate"].ToString();
                infoDept.Text = rd["dept"].ToString();
                infoIdCard.Text = rd["idCard"].ToString();
                infoName.Text = rd["name"].ToString();
                infoSex.Text = rd["sex"].ToString();
                infoTel.Text = rd["phone"].ToString();
            }
            sql = "select typeName from readers left join readerTypes on readers.readerTypeId = readerTypes.readerTypeId where readerId = " + readerId;
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                infoType.Text = rd["typeName"].ToString();
            }
            sql = "select userCard from users where username = '" + username + "'";
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                infoCard.Text = rd["userCard"].ToString();
            }
            sql = "select sum(fine) from borrowLog where paymented = '未缴费' and readerId = " + readerId;
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                infoFine.Text = rd[0].ToString();
            }
        }

        // 还款
        private void fineLoad() {
            try {
                string sql = "select sum(fine) from borrowLog where paymented = '未缴费' and readerId = " + readerId;
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataReader rd = cmd.ExecuteReader();
                    rd.Read();
                    fineSum.Text = rd[0].ToString();
                }
                sql = "select readerId, barCode 条形码, borrowTime 借出时间, returnTime 归还时间, fine 罚金, remarks 管理员备注 from borrowLog where paymented = '未缴费'";
                sql += " and readerId = " + readerId;
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                    cn.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0].Copy();
                    this.dataGridView4.DataSource = dt;
                    this.dataGridView4.Columns[0].Visible = false;
                    this.dataGridView4.Refresh();
                }
            } catch (Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }
        private void ReturnFine_Click(object sender, EventArgs e) {
            ReturnFineWin re = new ReturnFineWin(readerId);
            re.Show();
        }
    }
}

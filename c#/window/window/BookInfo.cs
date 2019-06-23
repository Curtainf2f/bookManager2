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

namespace window {
    public partial class BookInfo : Form {
        private string ISBN;
        private int readerId;
        private void BookInfo_Load(object sender, EventArgs e) {
            bookTypeLoad();
            string sql = "select ISBN, bookTypes.typeName, name, author, publisher, publishTime, price from bookItem left join bookTypes on bookItem.bookTypeId = bookTypes.bookTypeId where ISBN = " + ISBN;
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                ISBNL.Text = rd["ISBN"].ToString();
                bookType.Text = rd["typeName"].ToString();
                bookName.Text = rd["name"].ToString();
                author.Text = rd["author"].ToString();
                publisher.Text = rd["publisher"].ToString();
                publishTime.Text = rd["publishTime"].ToString();
                price.Text = rd["price"].ToString();
            }
            booksLoad();
            if (readerId == -1) {
                button1.Visible = true;
                button2.Visible = true;
                label8.Visible = false;
                bookName.ReadOnly = false;
                author.ReadOnly = false;
                publisher.ReadOnly = false;
                publishTime.ReadOnly = false;
                price.ReadOnly = false;
            }

        }
        public void booksLoad() {
            DataSet ds = new DataSet();
            string sql = "select barCode 条形码, borrowStatus 借阅状态 from books where ISBN = " + ISBN;
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                this.dataGridView1.DataSource = dt;
                this.dataGridView1.Refresh();
            }
        }
        public void bookTypeLoad() {
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
                bookType.DataSource = list;
            }
        }
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if(readerId != -1) {
                    string sql = "insert into borrow values (" + readerId + "," + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + ",getdate())";
                    using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                        cn.Open();
                        SqlCommand cmd = new SqlCommand(sql, cn);
                        cmd.ExecuteNonQuery();
                    }
                    DataSet ds = new DataSet();
                    sql = "select barCode 条形码, borrowStatus 借阅状态 from books where ISBN = " + ISBN;
                    using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                        cn.Open();
                        SqlCommand cmd = new SqlCommand(sql, cn);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dt = new DataTable();
                        dt = ds.Tables[0].Copy();
                        this.dataGridView1.DataSource = dt;
                        this.dataGridView1.Refresh();
                    }
                }
            } catch(Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }

        public BookInfo(int readerId, string ISBN) {
            InitializeComponent();
            this.readerId = readerId;
            this.ISBN = ISBN;
        }

        private void Button1_Click(object sender, EventArgs e) {
            try {
                LinkedList<string> col = new LinkedList<string>();
                LinkedList<object> data = new LinkedList<object>();
                col.AddLast("bookTypeId"); data.AddLast(bookType.SelectedIndex + 1);
                col.AddLast("name"); data.AddLast(bookName.Text);
                col.AddLast("author"); data.AddLast(author.Text);
                col.AddLast("publisher"); data.AddLast(publisher.Text);
                col.AddLast("publishTime"); data.AddLast(publishTime.Text);
                col.AddLast("price"); data.AddLast(Convert.ToDouble(price.Text));
                string sql = Database.update("bookItem", col, data);
                sql += " where ISBN = " + Database.process(ISBN);
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("修改成功");
            } catch (Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }

        private void Button2_Click(object sender, EventArgs e) {
            BookInfo_Load(sender, e);
        }

        private void ISBNL_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Button1_Click(sender, e);
            }
        }
    }
}

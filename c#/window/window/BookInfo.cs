using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace window {
    public partial class BookInfo : Form {
        private string ISBN;
        private int readerId;
        private void BookInfo_Load(object sender, EventArgs e) {
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

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            try {
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
            } catch(Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }

        public BookInfo(int readerId, string ISBN) {
            InitializeComponent();
            this.readerId = readerId;
            this.ISBN = ISBN;
        }
    }
}

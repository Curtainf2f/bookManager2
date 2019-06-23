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
    public partial class ReturnFineWin : Form {
        private int readerId;
        public ReturnFineWin(int readerId) {
            InitializeComponent();
            this.readerId = readerId;
        }
        private void PictureBox1_Click(object sender, EventArgs e) {
            try {
                string sql = "update borrowLog set paymented = '已缴费' where readerId = " + readerId;
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString)) {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    if (cmd.ExecuteNonQuery() > 0) {
                        MessageBox.Show("缴费成功");
                    }
                    this.Dispose();
                }
            } catch (Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }
    }
}

namespace window
{
    partial class User
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.bookType = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.publisher = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.author = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bookName = new System.Windows.Forms.TextBox();
            this.ISBN = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.borrowLog = new System.Windows.Forms.Button();
            this.nowBorrow = new System.Windows.Forms.Button();
            this.returnBook = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.barCode = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.userWelcome = new System.Windows.Forms.LinkLabel();
            this.overTime = new System.Windows.Forms.Button();
            this.fineInfo = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.canBorrow = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.recommendISBN = new System.Windows.Forms.TextBox();
            this.recommendName = new System.Windows.Forms.TextBox();
            this.recommendAuthor = new System.Windows.Forms.TextBox();
            this.recommendPublisher = new System.Windows.Forms.TextBox();
            this.recommend = new System.Windows.Forms.Button();
            this.resetRecommend = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Font = new System.Drawing.Font("幼圆", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(12, 9);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(984, 708);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage1.BackgroundImage")));
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(976, 670);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "借阅";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Silver;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(358, 191);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(3);
            this.label7.Size = new System.Drawing.Size(210, 32);
            this.label7.TabIndex = 2;
            this.label7.Text = "双击查看书本信息";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 226);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(923, 435);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.bookType);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.publisher);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.author);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.bookName);
            this.panel1.Controls.Add(this.ISBN);
            this.panel1.Location = new System.Drawing.Point(95, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 182);
            this.panel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(377, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(346, 24);
            this.label6.TabIndex = 17;
            this.label6.Text = "请注意，搜索结果只显示1000条";
            // 
            // bookType
            // 
            this.bookType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bookType.FormattingEnabled = true;
            this.bookType.Location = new System.Drawing.Point(136, 46);
            this.bookType.Name = "bookType";
            this.bookType.Size = new System.Drawing.Size(211, 32);
            this.bookType.TabIndex = 16;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(387, 136);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 35);
            this.button2.TabIndex = 15;
            this.button2.Text = "显示热门";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(228, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 35);
            this.button1.TabIndex = 14;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(412, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "出版社:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(436, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "作者:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "书名:";
            // 
            // publisher
            // 
            this.publisher.Location = new System.Drawing.Point(512, 53);
            this.publisher.Name = "publisher";
            this.publisher.Size = new System.Drawing.Size(211, 34);
            this.publisher.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "书本类型:";
            // 
            // author
            // 
            this.author.Location = new System.Drawing.Point(512, 13);
            this.author.Name = "author";
            this.author.Size = new System.Drawing.Size(211, 34);
            this.author.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "ISBN:";
            // 
            // bookName
            // 
            this.bookName.Location = new System.Drawing.Point(136, 86);
            this.bookName.Name = "bookName";
            this.bookName.Size = new System.Drawing.Size(211, 34);
            this.bookName.TabIndex = 5;
            // 
            // ISBN
            // 
            this.ISBN.Location = new System.Drawing.Point(136, 6);
            this.ISBN.Name = "ISBN";
            this.ISBN.Size = new System.Drawing.Size(211, 34);
            this.ISBN.TabIndex = 1;
            this.ISBN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ISBN_KeyDown);
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage2.BackgroundImage")));
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(976, 670);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "归还";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.fineInfo);
            this.panel2.Controls.Add(this.overTime);
            this.panel2.Controls.Add(this.borrowLog);
            this.panel2.Controls.Add(this.nowBorrow);
            this.panel2.Controls.Add(this.returnBook);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.barCode);
            this.panel2.Location = new System.Drawing.Point(193, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(585, 144);
            this.panel2.TabIndex = 1;
            // 
            // borrowLog
            // 
            this.borrowLog.Location = new System.Drawing.Point(327, 59);
            this.borrowLog.Name = "borrowLog";
            this.borrowLog.Size = new System.Drawing.Size(236, 34);
            this.borrowLog.TabIndex = 4;
            this.borrowLog.Text = "显示历史借阅情况";
            this.borrowLog.UseVisualStyleBackColor = true;
            this.borrowLog.Click += new System.EventHandler(this.BorrowLog_Click);
            // 
            // nowBorrow
            // 
            this.nowBorrow.Location = new System.Drawing.Point(22, 59);
            this.nowBorrow.Name = "nowBorrow";
            this.nowBorrow.Size = new System.Drawing.Size(221, 34);
            this.nowBorrow.TabIndex = 3;
            this.nowBorrow.Text = "显示当前借阅情况";
            this.nowBorrow.UseVisualStyleBackColor = true;
            this.nowBorrow.Click += new System.EventHandler(this.NowBorrow_Click);
            // 
            // returnBook
            // 
            this.returnBook.Location = new System.Drawing.Point(455, 7);
            this.returnBook.Name = "returnBook";
            this.returnBook.Size = new System.Drawing.Size(108, 34);
            this.returnBook.TabIndex = 2;
            this.returnBook.Text = "归还";
            this.returnBook.UseVisualStyleBackColor = true;
            this.returnBook.Click += new System.EventHandler(this.ReturnBook_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 24);
            this.label8.TabIndex = 1;
            this.label8.Text = "条形码:";
            // 
            // barCode
            // 
            this.barCode.Location = new System.Drawing.Point(118, 7);
            this.barCode.Name = "barCode";
            this.barCode.Size = new System.Drawing.Size(331, 34);
            this.barCode.TabIndex = 0;
            this.barCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BarCode_KeyDown);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 156);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(964, 505);
            this.dataGridView2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage3.BackgroundImage")));
            this.tabPage3.Controls.Add(this.dataGridView3);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(976, 670);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "读者荐购";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage4.BackgroundImage")));
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(976, 670);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "个人信息";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // userWelcome
            // 
            this.userWelcome.AutoSize = true;
            this.userWelcome.Font = new System.Drawing.Font("幼圆", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userWelcome.Location = new System.Drawing.Point(756, 9);
            this.userWelcome.Name = "userWelcome";
            this.userWelcome.Size = new System.Drawing.Size(94, 24);
            this.userWelcome.TabIndex = 1;
            this.userWelcome.TabStop = true;
            this.userWelcome.Text = "欢迎您,";
            this.userWelcome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.UserWelcome_LinkClicked);
            // 
            // overTime
            // 
            this.overTime.Location = new System.Drawing.Point(22, 99);
            this.overTime.Name = "overTime";
            this.overTime.Size = new System.Drawing.Size(221, 34);
            this.overTime.TabIndex = 5;
            this.overTime.Text = "超期催还";
            this.overTime.UseVisualStyleBackColor = true;
            this.overTime.Click += new System.EventHandler(this.OverTime_Click);
            // 
            // fineInfo
            // 
            this.fineInfo.Location = new System.Drawing.Point(327, 99);
            this.fineInfo.Name = "fineInfo";
            this.fineInfo.Size = new System.Drawing.Size(236, 34);
            this.fineInfo.TabIndex = 6;
            this.fineInfo.Text = "显示历史未缴费罚金";
            this.fineInfo.UseVisualStyleBackColor = true;
            this.fineInfo.Click += new System.EventHandler(this.FineInfo_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 24);
            this.label9.TabIndex = 2;
            this.label9.Text = "label9";
            // 
            // canBorrow
            // 
            this.canBorrow.AutoSize = true;
            this.canBorrow.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.canBorrow.Location = new System.Drawing.Point(512, 9);
            this.canBorrow.Name = "canBorrow";
            this.canBorrow.Size = new System.Drawing.Size(0, 19);
            this.canBorrow.TabIndex = 2;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 34);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(976, 670);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "超期欠款";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.resetRecommend);
            this.panel3.Controls.Add(this.recommend);
            this.panel3.Controls.Add(this.recommendPublisher);
            this.panel3.Controls.Add(this.recommendAuthor);
            this.panel3.Controls.Add(this.recommendName);
            this.panel3.Controls.Add(this.recommendISBN);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(83, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(765, 178);
            this.panel3.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(229, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(322, 24);
            this.label10.TabIndex = 0;
            this.label10.Text = "荐购前请先确认是否存在馆藏";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(71, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 24);
            this.label11.TabIndex = 1;
            this.label11.Text = "*ISBN:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(71, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 24);
            this.label12.TabIndex = 2;
            this.label12.Text = "*书名:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(436, 51);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 24);
            this.label13.TabIndex = 3;
            this.label13.Text = "*作者:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(424, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 24);
            this.label14.TabIndex = 6;
            this.label14.Text = "出版社:";
            // 
            // recommendISBN
            // 
            this.recommendISBN.Location = new System.Drawing.Point(159, 48);
            this.recommendISBN.Name = "recommendISBN";
            this.recommendISBN.Size = new System.Drawing.Size(216, 34);
            this.recommendISBN.TabIndex = 7;
            // 
            // recommendName
            // 
            this.recommendName.Location = new System.Drawing.Point(159, 88);
            this.recommendName.Name = "recommendName";
            this.recommendName.Size = new System.Drawing.Size(216, 34);
            this.recommendName.TabIndex = 8;
            // 
            // recommendAuthor
            // 
            this.recommendAuthor.Location = new System.Drawing.Point(524, 48);
            this.recommendAuthor.Name = "recommendAuthor";
            this.recommendAuthor.Size = new System.Drawing.Size(216, 34);
            this.recommendAuthor.TabIndex = 9;
            // 
            // recommendPublisher
            // 
            this.recommendPublisher.Location = new System.Drawing.Point(524, 88);
            this.recommendPublisher.Name = "recommendPublisher";
            this.recommendPublisher.Size = new System.Drawing.Size(216, 34);
            this.recommendPublisher.TabIndex = 10;
            // 
            // recommend
            // 
            this.recommend.Location = new System.Drawing.Point(233, 128);
            this.recommend.Name = "recommend";
            this.recommend.Size = new System.Drawing.Size(119, 36);
            this.recommend.TabIndex = 11;
            this.recommend.Text = "推荐";
            this.recommend.UseVisualStyleBackColor = true;
            // 
            // resetRecommend
            // 
            this.resetRecommend.Location = new System.Drawing.Point(432, 128);
            this.resetRecommend.Name = "resetRecommend";
            this.resetRecommend.Size = new System.Drawing.Size(119, 36);
            this.resetRecommend.TabIndex = 12;
            this.resetRecommend.Text = "重置";
            this.resetRecommend.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(6, 200);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 23;
            this.dataGridView3.Size = new System.Drawing.Size(964, 464);
            this.dataGridView3.TabIndex = 1;
            // 
            // User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.canBorrow);
            this.Controls.Add(this.userWelcome);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "User";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图书管理系统";
            this.Activated += new System.EventHandler(this.User_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.User_FormClosing);
            this.Load += new System.EventHandler(this.User_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox bookName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ISBN;
        private System.Windows.Forms.TextBox author;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox publisher;
        private System.Windows.Forms.ComboBox bookType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.LinkLabel userWelcome;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button borrowLog;
        private System.Windows.Forms.Button nowBorrow;
        private System.Windows.Forms.Button returnBook;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox barCode;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button overTime;
        private System.Windows.Forms.Button fineInfo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label canBorrow;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button resetRecommend;
        private System.Windows.Forms.Button recommend;
        private System.Windows.Forms.TextBox recommendPublisher;
        private System.Windows.Forms.TextBox recommendAuthor;
        private System.Windows.Forms.TextBox recommendName;
        private System.Windows.Forms.TextBox recommendISBN;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridView3;
    }
}
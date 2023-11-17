namespace PC.Windows.mainPC.상품관리 {
    partial class Product_Management {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.grid_main = new System.Windows.Forms.DataGridView();
            this.gridselectDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pcategoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ppriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplaySet = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.p_name = new System.Data.DataColumn();
            this.p_price = new System.Data.DataColumn();
            this.p_category = new System.Data.DataColumn();
            this.dataColumn1 = new System.Data.DataColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.cbox_datailcategory = new System.Windows.Forms.ComboBox();
            this.panel17 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tbox_name = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.tbox_price = new System.Windows.Forms.TextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.tbox_memo = new System.Windows.Forms.RichTextBox();
            this.panel15 = new System.Windows.Forms.Panel();
            this.btn_picture = new System.Windows.Forms.Button();
            this.pbox_picture = new System.Windows.Forms.PictureBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this.btn_modifyclose = new System.Windows.Forms.Button();
            this.btn_modifysave = new System.Windows.Forms.Button();
            this.btn_modify = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbox_seed = new System.Windows.Forms.TextBox();
            this.cbox_category = new System.Windows.Forms.ComboBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplaySet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel16.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_picture)).BeginInit();
            this.panel13.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(711, 514);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.panel12);
            this.panel4.Controls.Add(this.grid_main);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(295, 44);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(3);
            this.panel4.Size = new System.Drawing.Size(416, 470);
            this.panel4.TabIndex = 2;
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.btn_add);
            this.panel12.Controls.Add(this.btn_close);
            this.panel12.Controls.Add(this.btn_delete);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel12.Location = new System.Drawing.Point(3, 421);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(408, 44);
            this.panel12.TabIndex = 2;
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.Black;
            this.btn_add.ForeColor = System.Drawing.Color.Yellow;
            this.btn_add.Location = new System.Drawing.Point(17, 7);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(89, 31);
            this.btn_add.TabIndex = 1;
            this.btn_add.Text = "추가";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Black;
            this.btn_close.ForeColor = System.Drawing.Color.Yellow;
            this.btn_close.Location = new System.Drawing.Point(310, 7);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(86, 31);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "닫기";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.Black;
            this.btn_delete.ForeColor = System.Drawing.Color.Yellow;
            this.btn_delete.Location = new System.Drawing.Point(162, 7);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(86, 31);
            this.btn_delete.TabIndex = 1;
            this.btn_delete.Text = "삭제";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // grid_main
            // 
            this.grid_main.AllowUserToAddRows = false;
            this.grid_main.AllowUserToDeleteRows = false;
            this.grid_main.AllowUserToResizeColumns = false;
            this.grid_main.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Yellow;
            this.grid_main.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_main.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_main.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grid_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid_main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridselectDataGridViewCheckBoxColumn,
            this.pcategoryDataGridViewTextBoxColumn,
            this.pnameDataGridViewTextBoxColumn,
            this.ppriceDataGridViewTextBoxColumn});
            this.grid_main.DataMember = "product_info";
            this.grid_main.DataSource = this.DisplaySet;
            this.grid_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_main.Location = new System.Drawing.Point(3, 3);
            this.grid_main.MultiSelect = false;
            this.grid_main.Name = "grid_main";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_main.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid_main.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Yellow;
            this.grid_main.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grid_main.RowTemplate.Height = 23;
            this.grid_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_main.Size = new System.Drawing.Size(408, 462);
            this.grid_main.TabIndex = 1;
            this.grid_main.SelectionChanged += new System.EventHandler(this.grid_main_SelectionChanged);
            // 
            // gridselectDataGridViewCheckBoxColumn
            // 
            this.gridselectDataGridViewCheckBoxColumn.DataPropertyName = "grid_select";
            this.gridselectDataGridViewCheckBoxColumn.HeaderText = "선택";
            this.gridselectDataGridViewCheckBoxColumn.Name = "gridselectDataGridViewCheckBoxColumn";
            this.gridselectDataGridViewCheckBoxColumn.Width = 60;
            // 
            // pcategoryDataGridViewTextBoxColumn
            // 
            this.pcategoryDataGridViewTextBoxColumn.DataPropertyName = "p_category";
            this.pcategoryDataGridViewTextBoxColumn.HeaderText = "종류";
            this.pcategoryDataGridViewTextBoxColumn.Name = "pcategoryDataGridViewTextBoxColumn";
            this.pcategoryDataGridViewTextBoxColumn.ReadOnly = true;
            this.pcategoryDataGridViewTextBoxColumn.Width = 80;
            // 
            // pnameDataGridViewTextBoxColumn
            // 
            this.pnameDataGridViewTextBoxColumn.DataPropertyName = "p_name";
            this.pnameDataGridViewTextBoxColumn.HeaderText = "상품명";
            this.pnameDataGridViewTextBoxColumn.Name = "pnameDataGridViewTextBoxColumn";
            this.pnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.pnameDataGridViewTextBoxColumn.Width = 180;
            // 
            // ppriceDataGridViewTextBoxColumn
            // 
            this.ppriceDataGridViewTextBoxColumn.DataPropertyName = "p_price";
            this.ppriceDataGridViewTextBoxColumn.HeaderText = "가격";
            this.ppriceDataGridViewTextBoxColumn.Name = "ppriceDataGridViewTextBoxColumn";
            this.ppriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.ppriceDataGridViewTextBoxColumn.Width = 80;
            // 
            // DisplaySet
            // 
            this.DisplaySet.DataSetName = "NewDataSet";
            this.DisplaySet.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.p_name,
            this.p_price,
            this.p_category,
            this.dataColumn1});
            this.dataTable1.TableName = "product_info";
            // 
            // p_name
            // 
            this.p_name.AllowDBNull = false;
            this.p_name.ColumnName = "p_name";
            // 
            // p_price
            // 
            this.p_price.ColumnName = "p_price";
            // 
            // p_category
            // 
            this.p_category.Caption = "p_category";
            this.p_category.ColumnName = "p_category";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "grid_select";
            this.dataColumn1.DataType = typeof(bool);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel16);
            this.panel3.Controls.Add(this.panel15);
            this.panel3.Controls.Add(this.panel13);
            this.panel3.Controls.Add(this.panel11);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 44);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(295, 470);
            this.panel3.TabIndex = 1;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.tableLayoutPanel1);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel16.Location = new System.Drawing.Point(0, 266);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(293, 155);
            this.panel16.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.87625F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.12375F));
            this.tableLayoutPanel1.Controls.Add(this.panel18, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel17, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel8, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel9, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel10, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel14, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(293, 155);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.cbox_datailcategory);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel18.Location = new System.Drawing.Point(103, 4);
            this.panel18.Name = "panel18";
            this.panel18.Padding = new System.Windows.Forms.Padding(1);
            this.panel18.Size = new System.Drawing.Size(186, 19);
            this.panel18.TabIndex = 7;
            // 
            // cbox_datailcategory
            // 
            this.cbox_datailcategory.BackColor = System.Drawing.Color.White;
            this.cbox_datailcategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbox_datailcategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_datailcategory.Enabled = false;
            this.cbox_datailcategory.FormattingEnabled = true;
            this.cbox_datailcategory.Items.AddRange(new object[] {
            "음료",
            "과자",
            "라면",
            "기타"});
            this.cbox_datailcategory.Location = new System.Drawing.Point(1, 1);
            this.cbox_datailcategory.Name = "cbox_datailcategory";
            this.cbox_datailcategory.Size = new System.Drawing.Size(184, 20);
            this.cbox_datailcategory.TabIndex = 6;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.label8);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel17.Location = new System.Drawing.Point(4, 4);
            this.panel17.Name = "panel17";
            this.panel17.Padding = new System.Windows.Forms.Padding(3);
            this.panel17.Size = new System.Drawing.Size(92, 19);
            this.panel17.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(3, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "카테고리";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(4, 30);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(3);
            this.panel6.Size = new System.Drawing.Size(92, 19);
            this.panel6.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "상품명";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.tbox_name);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(103, 30);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(1);
            this.panel7.Size = new System.Drawing.Size(186, 19);
            this.panel7.TabIndex = 1;
            // 
            // tbox_name
            // 
            this.tbox_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbox_name.Location = new System.Drawing.Point(1, 1);
            this.tbox_name.Name = "tbox_name";
            this.tbox_name.ReadOnly = true;
            this.tbox_name.Size = new System.Drawing.Size(184, 21);
            this.tbox_name.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label3);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(4, 56);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(3);
            this.panel8.Size = new System.Drawing.Size(92, 19);
            this.panel8.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "가격";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.tbox_price);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(103, 56);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(1);
            this.panel9.Size = new System.Drawing.Size(186, 19);
            this.panel9.TabIndex = 3;
            // 
            // tbox_price
            // 
            this.tbox_price.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbox_price.Location = new System.Drawing.Point(1, 1);
            this.tbox_price.Name = "tbox_price";
            this.tbox_price.ReadOnly = true;
            this.tbox_price.Size = new System.Drawing.Size(184, 21);
            this.tbox_price.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.label4);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(4, 82);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(3);
            this.panel10.Size = new System.Drawing.Size(92, 69);
            this.panel10.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 63);
            this.label4.TabIndex = 0;
            this.label4.Text = "메모";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.tbox_memo);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(103, 82);
            this.panel14.Name = "panel14";
            this.panel14.Padding = new System.Windows.Forms.Padding(1);
            this.panel14.Size = new System.Drawing.Size(186, 69);
            this.panel14.TabIndex = 5;
            // 
            // tbox_memo
            // 
            this.tbox_memo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbox_memo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbox_memo.Location = new System.Drawing.Point(1, 1);
            this.tbox_memo.Name = "tbox_memo";
            this.tbox_memo.ReadOnly = true;
            this.tbox_memo.Size = new System.Drawing.Size(184, 67);
            this.tbox_memo.TabIndex = 0;
            this.tbox_memo.Text = "";
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.btn_picture);
            this.panel15.Controls.Add(this.pbox_picture);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(0, 34);
            this.panel15.Name = "panel15";
            this.panel15.Padding = new System.Windows.Forms.Padding(3);
            this.panel15.Size = new System.Drawing.Size(293, 232);
            this.panel15.TabIndex = 6;
            // 
            // btn_picture
            // 
            this.btn_picture.BackColor = System.Drawing.Color.Black;
            this.btn_picture.Enabled = false;
            this.btn_picture.ForeColor = System.Drawing.Color.Yellow;
            this.btn_picture.Location = new System.Drawing.Point(223, 6);
            this.btn_picture.Name = "btn_picture";
            this.btn_picture.Size = new System.Drawing.Size(66, 23);
            this.btn_picture.TabIndex = 5;
            this.btn_picture.Text = "파일";
            this.btn_picture.UseVisualStyleBackColor = false;
            this.btn_picture.Click += new System.EventHandler(this.btn_picture_Click);
            // 
            // pbox_picture
            // 
            this.pbox_picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbox_picture.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbox_picture.Enabled = false;
            this.pbox_picture.Location = new System.Drawing.Point(3, 3);
            this.pbox_picture.Name = "pbox_picture";
            this.pbox_picture.Size = new System.Drawing.Size(214, 226);
            this.pbox_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_picture.TabIndex = 4;
            this.pbox_picture.TabStop = false;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.btn_modifyclose);
            this.panel13.Controls.Add(this.btn_modifysave);
            this.panel13.Controls.Add(this.btn_modify);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel13.Location = new System.Drawing.Point(0, 421);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(293, 47);
            this.panel13.TabIndex = 4;
            // 
            // btn_modifyclose
            // 
            this.btn_modifyclose.BackColor = System.Drawing.Color.Black;
            this.btn_modifyclose.ForeColor = System.Drawing.Color.Yellow;
            this.btn_modifyclose.Location = new System.Drawing.Point(197, 8);
            this.btn_modifyclose.Name = "btn_modifyclose";
            this.btn_modifyclose.Size = new System.Drawing.Size(91, 31);
            this.btn_modifyclose.TabIndex = 1;
            this.btn_modifyclose.Text = "취소";
            this.btn_modifyclose.UseVisualStyleBackColor = false;
            this.btn_modifyclose.Click += new System.EventHandler(this.btn_modifyclose_Click);
            // 
            // btn_modifysave
            // 
            this.btn_modifysave.BackColor = System.Drawing.Color.Black;
            this.btn_modifysave.Enabled = false;
            this.btn_modifysave.ForeColor = System.Drawing.Color.Yellow;
            this.btn_modifysave.Location = new System.Drawing.Point(101, 8);
            this.btn_modifysave.Name = "btn_modifysave";
            this.btn_modifysave.Size = new System.Drawing.Size(91, 31);
            this.btn_modifysave.TabIndex = 0;
            this.btn_modifysave.Text = "저장";
            this.btn_modifysave.UseVisualStyleBackColor = false;
            this.btn_modifysave.Click += new System.EventHandler(this.btn_modifysave_Click);
            // 
            // btn_modify
            // 
            this.btn_modify.BackColor = System.Drawing.Color.Black;
            this.btn_modify.ForeColor = System.Drawing.Color.Yellow;
            this.btn_modify.Location = new System.Drawing.Point(4, 8);
            this.btn_modify.Name = "btn_modify";
            this.btn_modify.Size = new System.Drawing.Size(91, 31);
            this.btn_modify.TabIndex = 0;
            this.btn_modify.Text = "수정";
            this.btn_modify.UseVisualStyleBackColor = false;
            this.btn_modify.Click += new System.EventHandler(this.btn_modify_Click);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.label6);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(3);
            this.panel11.Size = new System.Drawing.Size(293, 34);
            this.panel11.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.DimGray;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(287, 28);
            this.label6.TabIndex = 1;
            this.label6.Text = "상품정보";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.tbox_seed);
            this.panel2.Controls.Add(this.cbox_category);
            this.panel2.Controls.Add(this.btn_search);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(711, 44);
            this.panel2.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(433, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "상품명";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(306, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "종류";
            // 
            // tbox_seed
            // 
            this.tbox_seed.Location = new System.Drawing.Point(477, 13);
            this.tbox_seed.Name = "tbox_seed";
            this.tbox_seed.Size = new System.Drawing.Size(131, 21);
            this.tbox_seed.TabIndex = 6;
            // 
            // cbox_category
            // 
            this.cbox_category.BackColor = System.Drawing.Color.White;
            this.cbox_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_category.FormattingEnabled = true;
            this.cbox_category.Items.AddRange(new object[] {
            "전체",
            "음료",
            "과자",
            "라면",
            "기타"});
            this.cbox_category.Location = new System.Drawing.Point(341, 13);
            this.cbox_category.Name = "cbox_category";
            this.cbox_category.Size = new System.Drawing.Size(86, 20);
            this.cbox_category.TabIndex = 5;
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.Color.Black;
            this.btn_search.ForeColor = System.Drawing.Color.Yellow;
            this.btn_search.Location = new System.Drawing.Point(621, 7);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 32);
            this.btn_search.TabIndex = 0;
            this.btn_search.Text = "조회";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(3);
            this.panel5.Size = new System.Drawing.Size(295, 44);
            this.panel5.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "상품관리";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Product_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(711, 514);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Product_Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "상품관리";
            this.Load += new System.EventHandler(this.Product_Management_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplaySet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_picture)).EndInit();
            this.panel13.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.DataGridView grid_main;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.PictureBox pbox_picture;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button btn_modify;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbox_seed;
        private System.Windows.Forms.ComboBox cbox_category;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Data.DataSet DisplaySet;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn p_name;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox tbox_name;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TextBox tbox_price;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.RichTextBox tbox_memo;
        private System.Windows.Forms.Button btn_close;
        private System.Data.DataColumn p_price;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_modifyclose;
        private System.Windows.Forms.Button btn_modifysave;
        private System.Windows.Forms.Button btn_picture;
        private System.Windows.Forms.ComboBox cbox_datailcategory;
        private System.Data.DataColumn p_category;
        private System.Data.DataColumn dataColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridselectDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcategoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ppriceDataGridViewTextBoxColumn;
    }
}
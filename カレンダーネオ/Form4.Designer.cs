
namespace カレンダーネオ
{
    partial class Form4
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbMonth4 = new System.Windows.Forms.ComboBox();
            this.cmbDay4 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbHeart4 = new System.Windows.Forms.ComboBox();
            this.pctHeart4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cmbBody4 = new System.Windows.Forms.ComboBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.btnAdd4 = new System.Windows.Forms.Button();
            this.lblNumber = new System.Windows.Forms.Label();
            this.cmbNumber = new System.Windows.Forms.ComboBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblYear = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctHeart4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView1.Location = new System.Drawing.Point(12, 106);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(972, 354);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // cmbMonth4
            // 
            this.cmbMonth4.AutoCompleteCustomSource.AddRange(new string[] {
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "1",
            "2",
            "3"});
            this.cmbMonth4.DropDownHeight = 600;
            this.cmbMonth4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth4.Font = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbMonth4.FormattingEnabled = true;
            this.cmbMonth4.IntegralHeight = false;
            this.cmbMonth4.Items.AddRange(new object[] {
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "1",
            "2",
            "3"});
            this.cmbMonth4.Location = new System.Drawing.Point(326, 13);
            this.cmbMonth4.Name = "cmbMonth4";
            this.cmbMonth4.Size = new System.Drawing.Size(104, 45);
            this.cmbMonth4.TabIndex = 14;
            this.cmbMonth4.SelectedIndexChanged += new System.EventHandler(this.cmbMonth4_SelectedIndexChanged);
            // 
            // cmbDay4
            // 
            this.cmbDay4.DropDownHeight = 600;
            this.cmbDay4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDay4.Font = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbDay4.FormattingEnabled = true;
            this.cmbDay4.IntegralHeight = false;
            this.cmbDay4.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.cmbDay4.Location = new System.Drawing.Point(480, 13);
            this.cmbDay4.Name = "cmbDay4";
            this.cmbDay4.Size = new System.Drawing.Size(104, 45);
            this.cmbDay4.TabIndex = 15;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(12, 62);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(422, 37);
            this.textBox1.TabIndex = 16;
            // 
            // cmbHeart4
            // 
            this.cmbHeart4.AutoCompleteCustomSource.AddRange(new string[] {
            "なし",
            "1",
            "2",
            "3"});
            this.cmbHeart4.DropDownHeight = 600;
            this.cmbHeart4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHeart4.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbHeart4.FormattingEnabled = true;
            this.cmbHeart4.IntegralHeight = false;
            this.cmbHeart4.Items.AddRange(new object[] {
            "なし",
            "弱",
            "中",
            "強"});
            this.cmbHeart4.Location = new System.Drawing.Point(498, 60);
            this.cmbHeart4.Name = "cmbHeart4";
            this.cmbHeart4.Size = new System.Drawing.Size(172, 38);
            this.cmbHeart4.TabIndex = 17;
            // 
            // pctHeart4
            // 
            this.pctHeart4.Image = global::カレンダーネオ.Properties.Resources._23094613;
            this.pctHeart4.Location = new System.Drawing.Point(441, 55);
            this.pctHeart4.Name = "pctHeart4";
            this.pctHeart4.Size = new System.Drawing.Size(51, 45);
            this.pctHeart4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctHeart4.TabIndex = 18;
            this.pctHeart4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::カレンダーネオ.Properties.Resources._23127739;
            this.pictureBox2.Location = new System.Drawing.Point(676, 55);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(51, 45);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // cmbBody4
            // 
            this.cmbBody4.AutoCompleteCustomSource.AddRange(new string[] {
            "なし",
            "1",
            "2",
            "3"});
            this.cmbBody4.DropDownHeight = 600;
            this.cmbBody4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBody4.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbBody4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbBody4.FormattingEnabled = true;
            this.cmbBody4.IntegralHeight = false;
            this.cmbBody4.Items.AddRange(new object[] {
            "なし",
            "弱",
            "中",
            "強"});
            this.cmbBody4.Location = new System.Drawing.Point(733, 62);
            this.cmbBody4.Name = "cmbBody4";
            this.cmbBody4.Size = new System.Drawing.Size(158, 38);
            this.cmbBody4.TabIndex = 20;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMonth.Location = new System.Drawing.Point(436, 22);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(43, 30);
            this.lblMonth.TabIndex = 21;
            this.lblMonth.Text = "月";
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDay.Location = new System.Drawing.Point(590, 22);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(43, 30);
            this.lblDay.TabIndex = 22;
            this.lblDay.Text = "日";
            // 
            // btnAdd4
            // 
            this.btnAdd4.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnAdd4.Location = new System.Drawing.Point(801, 10);
            this.btnAdd4.Name = "btnAdd4";
            this.btnAdd4.Size = new System.Drawing.Size(90, 48);
            this.btnAdd4.TabIndex = 29;
            this.btnAdd4.Text = "更新";
            this.btnAdd4.UseVisualStyleBackColor = true;
            this.btnAdd4.Click += new System.EventHandler(this.btnAdd4_Click);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblNumber.Location = new System.Drawing.Point(7, 22);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(53, 30);
            this.lblNumber.TabIndex = 30;
            this.lblNumber.Text = "No.";
            // 
            // cmbNumber
            // 
            this.cmbNumber.AutoCompleteCustomSource.AddRange(new string[] {
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "1",
            "2",
            "3"});
            this.cmbNumber.DropDownHeight = 600;
            this.cmbNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNumber.Font = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbNumber.FormattingEnabled = true;
            this.cmbNumber.IntegralHeight = false;
            this.cmbNumber.Location = new System.Drawing.Point(57, 13);
            this.cmbNumber.Name = "cmbNumber";
            this.cmbNumber.Size = new System.Drawing.Size(104, 45);
            this.cmbNumber.TabIndex = 31;
            this.cmbNumber.SelectedIndexChanged += new System.EventHandler(this.cmbNumber_SelectedIndexChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCreate.Location = new System.Drawing.Point(639, 10);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(156, 48);
            this.btnCreate.TabIndex = 32;
            this.btnCreate.Text = "新規作成";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDelete.Location = new System.Drawing.Point(897, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 48);
            this.btnDelete.TabIndex = 33;
            this.btnDelete.Text = "削除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(897, 61);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 42);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblYear.Location = new System.Drawing.Point(277, 22);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(43, 30);
            this.lblYear.TabIndex = 36;
            this.lblYear.Text = "年";
            // 
            // cmbYear
            // 
            this.cmbYear.AutoCompleteCustomSource.AddRange(new string[] {
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "1",
            "2",
            "3"});
            this.cmbYear.DropDownHeight = 600;
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.IntegralHeight = false;
            this.cmbYear.Items.AddRange(new object[] {
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030",
            "2031",
            "2032"});
            this.cmbYear.Location = new System.Drawing.Point(167, 17);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(104, 41);
            this.cmbYear.TabIndex = 35;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 472);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.cmbNumber);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.btnAdd4);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.cmbBody4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pctHeart4);
            this.Controls.Add(this.cmbHeart4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cmbDay4);
            this.Controls.Add(this.cmbMonth4);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctHeart4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.ComboBox cmbMonth4;
        public System.Windows.Forms.ComboBox cmbDay4;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.ComboBox cmbHeart4;
        private System.Windows.Forms.PictureBox pctHeart4;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.ComboBox cmbBody4;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Button btnAdd4;
        private System.Windows.Forms.Label lblNumber;
        public System.Windows.Forms.ComboBox cmbNumber;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblYear;
        public System.Windows.Forms.ComboBox cmbYear;
    }
}
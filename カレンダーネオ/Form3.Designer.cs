
namespace カレンダーネオ
{
    partial class Form3
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chrFatigueBody = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.pctChangeHeart = new System.Windows.Forms.PictureBox();
            this.cmbMonth3 = new System.Windows.Forms.ComboBox();
            this.lblMonth3 = new System.Windows.Forms.Label();
            this.lblYear3 = new System.Windows.Forms.Label();
            this.cmbYear3 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chrFatigueBody)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctChangeHeart)).BeginInit();
            this.SuspendLayout();
            // 
            // chrFatigueBody
            // 
            chartArea2.Name = "ChartArea1";
            this.chrFatigueBody.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chrFatigueBody.Legends.Add(legend2);
            this.chrFatigueBody.Location = new System.Drawing.Point(13, 13);
            this.chrFatigueBody.Name = "chrFatigueBody";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chrFatigueBody.Series.Add(series2);
            this.chrFatigueBody.Size = new System.Drawing.Size(1130, 441);
            this.chrFatigueBody.TabIndex = 0;
            this.chrFatigueBody.Text = "chart1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(1002, 460);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 98);
            this.button1.TabIndex = 2;
            this.button1.Text = "閉じる";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pctChangeHeart
            // 
            this.pctChangeHeart.Image = global::カレンダーネオ.Properties.Resources._23094613;
            this.pctChangeHeart.Location = new System.Drawing.Point(13, 460);
            this.pctChangeHeart.Name = "pctChangeHeart";
            this.pctChangeHeart.Size = new System.Drawing.Size(130, 98);
            this.pctChangeHeart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctChangeHeart.TabIndex = 3;
            this.pctChangeHeart.TabStop = false;
            this.pctChangeHeart.Click += new System.EventHandler(this.pctChangeHeart_Click);
            this.pctChangeHeart.MouseLeave += new System.EventHandler(this.pctChangeHeart_MouseLeave);
            this.pctChangeHeart.MouseHover += new System.EventHandler(this.pctChangeHeart_MouseHover);
            // 
            // cmbMonth3
            // 
            this.cmbMonth3.AutoCompleteCustomSource.AddRange(new string[] {
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
            this.cmbMonth3.DropDownHeight = 600;
            this.cmbMonth3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth3.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbMonth3.FormattingEnabled = true;
            this.cmbMonth3.IntegralHeight = false;
            this.cmbMonth3.Items.AddRange(new object[] {
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
            this.cmbMonth3.Location = new System.Drawing.Point(815, 470);
            this.cmbMonth3.Name = "cmbMonth3";
            this.cmbMonth3.Size = new System.Drawing.Size(121, 88);
            this.cmbMonth3.TabIndex = 15;
            this.cmbMonth3.SelectedIndexChanged += new System.EventHandler(this.cmbMonth3_SelectedIndexChanged);
            // 
            // lblMonth3
            // 
            this.lblMonth3.AutoSize = true;
            this.lblMonth3.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMonth3.Location = new System.Drawing.Point(939, 518);
            this.lblMonth3.Name = "lblMonth3";
            this.lblMonth3.Size = new System.Drawing.Size(57, 40);
            this.lblMonth3.TabIndex = 14;
            this.lblMonth3.Text = "月";
            // 
            // lblYear3
            // 
            this.lblYear3.AutoSize = true;
            this.lblYear3.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblYear3.Location = new System.Drawing.Point(752, 518);
            this.lblYear3.Name = "lblYear3";
            this.lblYear3.Size = new System.Drawing.Size(57, 40);
            this.lblYear3.TabIndex = 19;
            this.lblYear3.Text = "年";
            // 
            // cmbYear3
            // 
            this.cmbYear3.AutoCompleteCustomSource.AddRange(new string[] {
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
            this.cmbYear3.DropDownHeight = 600;
            this.cmbYear3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear3.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbYear3.FormattingEnabled = true;
            this.cmbYear3.IntegralHeight = false;
            this.cmbYear3.Items.AddRange(new object[] {
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
            this.cmbYear3.Location = new System.Drawing.Point(540, 470);
            this.cmbYear3.Name = "cmbYear3";
            this.cmbYear3.Size = new System.Drawing.Size(206, 88);
            this.cmbYear3.TabIndex = 18;
            this.cmbYear3.SelectedIndexChanged += new System.EventHandler(this.cmbYear3_SelectedIndexChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 570);
            this.Controls.Add(this.lblYear3);
            this.Controls.Add(this.cmbYear3);
            this.Controls.Add(this.cmbMonth3);
            this.Controls.Add(this.lblMonth3);
            this.Controls.Add(this.pctChangeHeart);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chrFatigueBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.chrFatigueBody)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctChangeHeart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chrFatigueBody;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pctChangeHeart;
        public System.Windows.Forms.ComboBox cmbMonth3;
        private System.Windows.Forms.Label lblMonth3;
        private System.Windows.Forms.Label lblYear3;
        public System.Windows.Forms.ComboBox cmbYear3;
    }
}
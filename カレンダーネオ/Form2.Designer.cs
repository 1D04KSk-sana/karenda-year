
namespace カレンダーネオ
{
    partial class Form2
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
            this.chrFatigue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.pctChangeBody = new System.Windows.Forms.PictureBox();
            this.cmbMonth2 = new System.Windows.Forms.ComboBox();
            this.lblMonth2 = new System.Windows.Forms.Label();
            this.cmbYear2 = new System.Windows.Forms.ComboBox();
            this.lblYear2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chrFatigue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctChangeBody)).BeginInit();
            this.SuspendLayout();
            // 
            // chrFatigue
            // 
            chartArea2.Name = "ChartArea1";
            this.chrFatigue.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chrFatigue.Legends.Add(legend2);
            this.chrFatigue.Location = new System.Drawing.Point(12, 12);
            this.chrFatigue.Name = "chrFatigue";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chrFatigue.Series.Add(series2);
            this.chrFatigue.Size = new System.Drawing.Size(1130, 441);
            this.chrFatigue.TabIndex = 0;
            this.chrFatigue.Text = "chart1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(1001, 459);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 99);
            this.button1.TabIndex = 1;
            this.button1.Text = "閉じる";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pctChangeBody
            // 
            this.pctChangeBody.Image = global::カレンダーネオ.Properties.Resources._23127739;
            this.pctChangeBody.Location = new System.Drawing.Point(12, 459);
            this.pctChangeBody.Name = "pctChangeBody";
            this.pctChangeBody.Size = new System.Drawing.Size(130, 98);
            this.pctChangeBody.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctChangeBody.TabIndex = 2;
            this.pctChangeBody.TabStop = false;
            this.pctChangeBody.Click += new System.EventHandler(this.pctChangeBody_Click);
            this.pctChangeBody.MouseLeave += new System.EventHandler(this.pctChangeBody_MouseLeave);
            this.pctChangeBody.MouseHover += new System.EventHandler(this.pctChangeBody_MouseHover);
            // 
            // cmbMonth2
            // 
            this.cmbMonth2.AutoCompleteCustomSource.AddRange(new string[] {
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
            this.cmbMonth2.DropDownHeight = 600;
            this.cmbMonth2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth2.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbMonth2.FormattingEnabled = true;
            this.cmbMonth2.IntegralHeight = false;
            this.cmbMonth2.Items.AddRange(new object[] {
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
            this.cmbMonth2.Location = new System.Drawing.Point(810, 469);
            this.cmbMonth2.Name = "cmbMonth2";
            this.cmbMonth2.Size = new System.Drawing.Size(121, 88);
            this.cmbMonth2.TabIndex = 14;
            this.cmbMonth2.SelectedIndexChanged += new System.EventHandler(this.cmbMonth2_SelectedIndexChanged);
            // 
            // lblMonth2
            // 
            this.lblMonth2.AutoSize = true;
            this.lblMonth2.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMonth2.Location = new System.Drawing.Point(937, 517);
            this.lblMonth2.Name = "lblMonth2";
            this.lblMonth2.Size = new System.Drawing.Size(57, 40);
            this.lblMonth2.TabIndex = 15;
            this.lblMonth2.Text = "月";
            // 
            // cmbYear2
            // 
            this.cmbYear2.AutoCompleteCustomSource.AddRange(new string[] {
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
            this.cmbYear2.DropDownHeight = 600;
            this.cmbYear2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear2.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbYear2.FormattingEnabled = true;
            this.cmbYear2.IntegralHeight = false;
            this.cmbYear2.Items.AddRange(new object[] {
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
            this.cmbYear2.Location = new System.Drawing.Point(535, 469);
            this.cmbYear2.Name = "cmbYear2";
            this.cmbYear2.Size = new System.Drawing.Size(206, 88);
            this.cmbYear2.TabIndex = 16;
            this.cmbYear2.SelectedIndexChanged += new System.EventHandler(this.cmbYear2_SelectedIndexChanged);
            // 
            // lblYear2
            // 
            this.lblYear2.AutoSize = true;
            this.lblYear2.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblYear2.Location = new System.Drawing.Point(747, 517);
            this.lblYear2.Name = "lblYear2";
            this.lblYear2.Size = new System.Drawing.Size(57, 40);
            this.lblYear2.TabIndex = 17;
            this.lblYear2.Text = "年";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 570);
            this.Controls.Add(this.lblYear2);
            this.Controls.Add(this.cmbYear2);
            this.Controls.Add(this.lblMonth2);
            this.Controls.Add(this.cmbMonth2);
            this.Controls.Add(this.pctChangeBody);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chrFatigue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.chrFatigue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctChangeBody)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chrFatigue;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pctChangeBody;
        public System.Windows.Forms.ComboBox cmbMonth2;
        private System.Windows.Forms.Label lblMonth2;
        public System.Windows.Forms.ComboBox cmbYear2;
        private System.Windows.Forms.Label lblYear2;
    }
}
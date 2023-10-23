namespace WindowsFormsApp1.MarketingDepartment
{
    partial class SExpandPlan
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.区域 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.省份 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.市 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.区县 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.业务员人数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.到位月份 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.二二年签单目标 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.二二年出货目标 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 390);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.区域,
            this.省份,
            this.市,
            this.区县,
            this.业务员人数,
            this.到位月份,
            this.二二年签单目标,
            this.二二年出货目标,
            this.备注});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(775, 390);
            this.dataGridView1.TabIndex = 0;
            // 
            // 区域
            // 
            this.区域.HeaderText = "区域";
            this.区域.Name = "区域";
            // 
            // 省份
            // 
            this.省份.HeaderText = "省份";
            this.省份.Name = "省份";
            // 
            // 市
            // 
            this.市.HeaderText = "市";
            this.市.Name = "市";
            // 
            // 区县
            // 
            this.区县.HeaderText = "区县";
            this.区县.Name = "区县";
            // 
            // 业务员人数
            // 
            this.业务员人数.HeaderText = "业务员人数";
            this.业务员人数.Name = "业务员人数";
            // 
            // 到位月份
            // 
            this.到位月份.HeaderText = "到位月份";
            this.到位月份.Name = "到位月份";
            // 
            // 二二年签单目标
            // 
            this.二二年签单目标.HeaderText = "二二年签单目标";
            this.二二年签单目标.Name = "二二年签单目标";
            // 
            // 二二年出货目标
            // 
            this.二二年出货目标.HeaderText = "二二年出货目标";
            this.二二年出货目标.Name = "二二年出货目标";
            // 
            // 备注
            // 
            this.备注.HeaderText = "备注";
            this.备注.Name = "备注";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(713, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "保 存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SExpandPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "SExpandPlan";
            this.Text = "SExpandPlan";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 区域;
        private System.Windows.Forms.DataGridViewTextBoxColumn 省份;
        private System.Windows.Forms.DataGridViewTextBoxColumn 市;
        private System.Windows.Forms.DataGridViewTextBoxColumn 区县;
        private System.Windows.Forms.DataGridViewTextBoxColumn 业务员人数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 到位月份;
        private System.Windows.Forms.DataGridViewTextBoxColumn 二二年签单目标;
        private System.Windows.Forms.DataGridViewTextBoxColumn 二二年出货目标;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注;
    }
}
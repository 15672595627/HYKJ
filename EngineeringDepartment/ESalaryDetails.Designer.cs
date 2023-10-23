namespace WindowsFormsApp1.EngineeringDepartment
{
    partial class ESalaryDetails
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
            this.button1 = new System.Windows.Forms.Button();
            this.十一月 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.十月 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.九月 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.八月 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.七月 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.六月 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.五月 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.四月 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.三月 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.二月 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.一月 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.总金额 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.总人数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.部门 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.十二月 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(713, 407);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "保 存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 十一月
            // 
            this.十一月.HeaderText = "十一月";
            this.十一月.Name = "十一月";
            // 
            // 十月
            // 
            this.十月.HeaderText = "十月";
            this.十月.Name = "十月";
            // 
            // 九月
            // 
            this.九月.HeaderText = "九月";
            this.九月.Name = "九月";
            // 
            // 八月
            // 
            this.八月.HeaderText = "八月";
            this.八月.Name = "八月";
            // 
            // 七月
            // 
            this.七月.HeaderText = "七月";
            this.七月.Name = "七月";
            // 
            // 六月
            // 
            this.六月.HeaderText = "六月";
            this.六月.Name = "六月";
            // 
            // 五月
            // 
            this.五月.HeaderText = "五月";
            this.五月.Name = "五月";
            // 
            // 四月
            // 
            this.四月.HeaderText = "四月";
            this.四月.Name = "四月";
            // 
            // 三月
            // 
            this.三月.HeaderText = "三月";
            this.三月.Name = "三月";
            // 
            // 二月
            // 
            this.二月.HeaderText = "二月";
            this.二月.Name = "二月";
            // 
            // 一月
            // 
            this.一月.HeaderText = "一月";
            this.一月.Name = "一月";
            // 
            // 总金额
            // 
            this.总金额.HeaderText = "总金额";
            this.总金额.Name = "总金额";
            this.总金额.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.总金额.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 总人数
            // 
            this.总人数.HeaderText = "总人数";
            this.总人数.Name = "总人数";
            this.总人数.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.总人数.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 部门
            // 
            this.部门.HeaderText = "部门";
            this.部门.Items.AddRange(new object[] {
            "销售部",
            "生产部",
            "仓储部",
            "PMC",
            "品质部",
            "设备部",
            "采购部",
            "市场部",
            "总经办",
            "人事行政部",
            "财务部",
            "设计部",
            "客服部",
            "工程部"});
            this.部门.Name = "部门";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.部门,
            this.总人数,
            this.总金额,
            this.一月,
            this.二月,
            this.三月,
            this.四月,
            this.五月,
            this.六月,
            this.七月,
            this.八月,
            this.九月,
            this.十月,
            this.十一月,
            this.十二月});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(775, 388);
            this.dataGridView1.TabIndex = 0;
            // 
            // 十二月
            // 
            this.十二月.HeaderText = "十二月";
            this.十二月.Name = "十二月";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 388);
            this.panel1.TabIndex = 2;
            // 
            // ESalaryDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "ESalaryDetails";
            this.Text = "ESalaryDetails";
            this.Load += new System.EventHandler(this.ESalaryDetails_Load);
            this.SizeChanged += new System.EventHandler(this.ESalaryDetails_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 十一月;
        private System.Windows.Forms.DataGridViewTextBoxColumn 十月;
        private System.Windows.Forms.DataGridViewTextBoxColumn 九月;
        private System.Windows.Forms.DataGridViewTextBoxColumn 八月;
        private System.Windows.Forms.DataGridViewTextBoxColumn 七月;
        private System.Windows.Forms.DataGridViewTextBoxColumn 六月;
        private System.Windows.Forms.DataGridViewTextBoxColumn 五月;
        private System.Windows.Forms.DataGridViewTextBoxColumn 四月;
        private System.Windows.Forms.DataGridViewTextBoxColumn 三月;
        private System.Windows.Forms.DataGridViewTextBoxColumn 二月;
        private System.Windows.Forms.DataGridViewTextBoxColumn 一月;
        private System.Windows.Forms.DataGridViewTextBoxColumn 总金额;
        private System.Windows.Forms.DataGridViewTextBoxColumn 总人数;
        private System.Windows.Forms.DataGridViewComboBoxColumn 部门;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 十二月;
        private System.Windows.Forms.Panel panel1;
    }
}
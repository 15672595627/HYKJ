
namespace WindowsFormsApp1.Order
{
    partial class OrderServiceList
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.CKZT = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.QJ = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.HTBH = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.YWY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CKLB = new System.Windows.Forms.ComboBox();
            this.RQ1 = new System.Windows.Forms.DateTimePicker();
            this.RQ = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SHZT = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GSMC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GDY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SX = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.收款单修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.收款单保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.批量审核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.审核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.反审核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.发货申请ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.批量发货申请ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel1.Controls.Add(this.CKZT);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.QJ);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.HTBH);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.YWY);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.CKLB);
            this.splitContainer1.Panel1.Controls.Add(this.RQ1);
            this.splitContainer1.Panel1.Controls.Add(this.RQ);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.SHZT);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.GSMC);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.GDY);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.SX);
            this.splitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1225, 663);
            this.splitContainer1.SplitterDistance = 73;
            this.splitContainer1.TabIndex = 0;
            // 
            // CKZT
            // 
            this.CKZT.FormattingEnabled = true;
            this.CKZT.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.CKZT.Location = new System.Drawing.Point(965, 39);
            this.CKZT.Name = "CKZT";
            this.CKZT.Size = new System.Drawing.Size(95, 20);
            this.CKZT.TabIndex = 78;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(962, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 21);
            this.label10.TabIndex = 77;
            this.label10.Text = "出库状态";
            // 
            // QJ
            // 
            this.QJ.Location = new System.Drawing.Point(865, 39);
            this.QJ.Name = "QJ";
            this.QJ.Size = new System.Drawing.Size(94, 21);
            this.QJ.TabIndex = 76;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(883, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 21);
            this.label9.TabIndex = 75;
            this.label9.Text = "期间";
            // 
            // HTBH
            // 
            this.HTBH.Location = new System.Drawing.Point(336, 40);
            this.HTBH.Name = "HTBH";
            this.HTBH.Size = new System.Drawing.Size(100, 21);
            this.HTBH.TabIndex = 74;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(338, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 21);
            this.label8.TabIndex = 73;
            this.label8.Text = "合同编号";
            // 
            // YWY
            // 
            this.YWY.Location = new System.Drawing.Point(551, 40);
            this.YWY.Name = "YWY";
            this.YWY.Size = new System.Drawing.Size(100, 21);
            this.YWY.TabIndex = 72;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(562, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 21);
            this.label3.TabIndex = 71;
            this.label3.Text = "业务员";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(22, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 21);
            this.label7.TabIndex = 69;
            this.label7.Text = "查看类别";
            // 
            // CKLB
            // 
            this.CKLB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CKLB.FormattingEnabled = true;
            this.CKLB.Items.AddRange(new object[] {
            "销售订单主数据",
            "销售订单详细数据",
            "收款单"});
            this.CKLB.Location = new System.Drawing.Point(14, 41);
            this.CKLB.Name = "CKLB";
            this.CKLB.Size = new System.Drawing.Size(106, 20);
            this.CKLB.TabIndex = 70;
            // 
            // RQ1
            // 
            this.RQ1.CustomFormat = "yyyy-MM-dd";
            this.RQ1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.RQ1.Location = new System.Drawing.Point(234, 40);
            this.RQ1.Name = "RQ1";
            this.RQ1.Size = new System.Drawing.Size(94, 21);
            this.RQ1.TabIndex = 26;
            this.RQ1.Value = new System.DateTime(2023, 6, 10, 0, 0, 0, 0);
            // 
            // RQ
            // 
            this.RQ.CustomFormat = "yyyy-MM-dd";
            this.RQ.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.RQ.Location = new System.Drawing.Point(126, 41);
            this.RQ.Name = "RQ";
            this.RQ.Size = new System.Drawing.Size(98, 21);
            this.RQ.TabIndex = 25;
            this.RQ.Value = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(230, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 21);
            this.label5.TabIndex = 24;
            this.label5.Text = "结束时间";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(126, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 21);
            this.label6.TabIndex = 23;
            this.label6.Text = "开始时间";
            // 
            // SHZT
            // 
            this.SHZT.FormattingEnabled = true;
            this.SHZT.Items.AddRange(new object[] {
            "已审核",
            "未审核"});
            this.SHZT.Location = new System.Drawing.Point(765, 40);
            this.SHZT.Name = "SHZT";
            this.SHZT.Size = new System.Drawing.Size(94, 20);
            this.SHZT.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(761, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 21);
            this.label4.TabIndex = 21;
            this.label4.Text = "审核状态";
            // 
            // GSMC
            // 
            this.GSMC.Location = new System.Drawing.Point(657, 40);
            this.GSMC.Name = "GSMC";
            this.GSMC.Size = new System.Drawing.Size(100, 21);
            this.GSMC.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(657, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 21);
            this.label2.TabIndex = 17;
            this.label2.Text = "公司名称";
            // 
            // GDY
            // 
            this.GDY.Location = new System.Drawing.Point(441, 40);
            this.GDY.Name = "GDY";
            this.GDY.Size = new System.Drawing.Size(103, 21);
            this.GDY.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(456, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "跟单员";
            // 
            // SX
            // 
            this.SX.Font = new System.Drawing.Font("楷体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SX.Location = new System.Drawing.Point(1102, 12);
            this.SX.Name = "SX";
            this.SX.Size = new System.Drawing.Size(111, 44);
            this.SX.TabIndex = 0;
            this.SX.Text = "筛选";
            this.SX.UseVisualStyleBackColor = true;
            this.SX.Click += new System.EventHandler(this.SX_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1225, 586);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.收款单修改ToolStripMenuItem,
            this.收款单保存ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.批量审核ToolStripMenuItem,
            this.审核ToolStripMenuItem,
            this.反审核ToolStripMenuItem,
            this.导出ToolStripMenuItem,
            this.发货申请ToolStripMenuItem,
            this.批量发货申请ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 202);
            // 
            // 收款单修改ToolStripMenuItem
            // 
            this.收款单修改ToolStripMenuItem.Name = "收款单修改ToolStripMenuItem";
            this.收款单修改ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.收款单修改ToolStripMenuItem.Text = "收款单修改";
            this.收款单修改ToolStripMenuItem.Click += new System.EventHandler(this.收款单修改ToolStripMenuItem_Click);
            // 
            // 收款单保存ToolStripMenuItem
            // 
            this.收款单保存ToolStripMenuItem.Name = "收款单保存ToolStripMenuItem";
            this.收款单保存ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.收款单保存ToolStripMenuItem.Text = "收款单保存";
            this.收款单保存ToolStripMenuItem.Click += new System.EventHandler(this.收款单保存ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 批量审核ToolStripMenuItem
            // 
            this.批量审核ToolStripMenuItem.Name = "批量审核ToolStripMenuItem";
            this.批量审核ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.批量审核ToolStripMenuItem.Text = "批量审核";
            this.批量审核ToolStripMenuItem.Click += new System.EventHandler(this.批量审核ToolStripMenuItem_Click);
            // 
            // 审核ToolStripMenuItem
            // 
            this.审核ToolStripMenuItem.Name = "审核ToolStripMenuItem";
            this.审核ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.审核ToolStripMenuItem.Text = "审核";
            this.审核ToolStripMenuItem.Click += new System.EventHandler(this.审核ToolStripMenuItem_Click);
            // 
            // 反审核ToolStripMenuItem
            // 
            this.反审核ToolStripMenuItem.Name = "反审核ToolStripMenuItem";
            this.反审核ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.反审核ToolStripMenuItem.Text = "反审核";
            this.反审核ToolStripMenuItem.Click += new System.EventHandler(this.反审核ToolStripMenuItem_Click);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.导出ToolStripMenuItem.Text = "导出";
            this.导出ToolStripMenuItem.Click += new System.EventHandler(this.导出ToolStripMenuItem_Click);
            // 
            // 发货申请ToolStripMenuItem
            // 
            this.发货申请ToolStripMenuItem.Name = "发货申请ToolStripMenuItem";
            this.发货申请ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.发货申请ToolStripMenuItem.Text = "发货申请";
            this.发货申请ToolStripMenuItem.Click += new System.EventHandler(this.发货申请ToolStripMenuItem_Click);
            // 
            // 批量发货申请ToolStripMenuItem
            // 
            this.批量发货申请ToolStripMenuItem.Name = "批量发货申请ToolStripMenuItem";
            this.批量发货申请ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.批量发货申请ToolStripMenuItem.Text = "批量发货申请";
            this.批量发货申请ToolStripMenuItem.Click += new System.EventHandler(this.批量发货申请ToolStripMenuItem_Click);
            // 
            // OrderServiceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1225, 663);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "OrderServiceList";
            this.Text = "Orderservicelist";
            this.Load += new System.EventHandler(this.OrderServiceList_Load);
            this.SizeChanged += new System.EventHandler(this.OrderServiceList_SizeChanged);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button SX;
        private System.Windows.Forms.DateTimePicker RQ1;
        private System.Windows.Forms.DateTimePicker RQ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox SHZT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox GSMC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox GDY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CKLB;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 收款单修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 审核ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 反审核ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.TextBox YWY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem 批量审核ToolStripMenuItem;
        private System.Windows.Forms.TextBox HTBH;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox QJ;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripMenuItem 收款单保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 发货申请ToolStripMenuItem;
        private System.Windows.Forms.ComboBox CKZT;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripMenuItem 批量发货申请ToolStripMenuItem;
    }
}
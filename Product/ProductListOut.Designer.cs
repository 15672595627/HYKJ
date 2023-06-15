namespace WindowsFormsApp1.Product
{
    partial class ProductListOut
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.XZL = new System.Windows.Forms.Button();
            this.JZ1 = new System.Windows.Forms.Button();
            this.JZ = new System.Windows.Forms.Button();
            this.CK = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BC = new System.Windows.Forms.Button();
            this.RQ1 = new System.Windows.Forms.DateTimePicker();
            this.RQ = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ZT = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GSMC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.HTBH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SX = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.审核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.批量审核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.反审核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.财务审核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.财务反审核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.XZL);
            this.splitContainer1.Panel1.Controls.Add(this.JZ1);
            this.splitContainer1.Panel1.Controls.Add(this.JZ);
            this.splitContainer1.Panel1.Controls.Add(this.CK);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.BC);
            this.splitContainer1.Panel1.Controls.Add(this.RQ1);
            this.splitContainer1.Panel1.Controls.Add(this.RQ);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.ZT);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.GSMC);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.HTBH);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.SX);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1233, 663);
            this.splitContainer1.SplitterDistance = 84;
            this.splitContainer1.TabIndex = 0;
            // 
            // XZL
            // 
            this.XZL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.XZL.Location = new System.Drawing.Point(5, 3);
            this.XZL.Name = "XZL";
            this.XZL.Size = new System.Drawing.Size(21, 78);
            this.XZL.TabIndex = 87;
            this.XZL.Text = "选择列";
            this.XZL.UseVisualStyleBackColor = true;
            this.XZL.Click += new System.EventHandler(this.XZL_Click);
            // 
            // JZ1
            // 
            this.JZ1.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.JZ1.ForeColor = System.Drawing.Color.Red;
            this.JZ1.Location = new System.Drawing.Point(907, 18);
            this.JZ1.Name = "JZ1";
            this.JZ1.Size = new System.Drawing.Size(73, 52);
            this.JZ1.TabIndex = 86;
            this.JZ1.Text = "结转出货";
            this.JZ1.UseVisualStyleBackColor = true;
            this.JZ1.Click += new System.EventHandler(this.JZ1_Click);
            // 
            // JZ
            // 
            this.JZ.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.JZ.ForeColor = System.Drawing.Color.Red;
            this.JZ.Location = new System.Drawing.Point(690, 18);
            this.JZ.Name = "JZ";
            this.JZ.Size = new System.Drawing.Size(211, 52);
            this.JZ.TabIndex = 85;
            this.JZ.Text = "结转成本金额";
            this.JZ.UseVisualStyleBackColor = true;
            this.JZ.Click += new System.EventHandler(this.JZ_Click);
            // 
            // CK
            // 
            this.CK.FormattingEnabled = true;
            this.CK.Items.AddRange(new object[] {
            "一线成品仓",
            "二线成品仓",
            "三线成品仓"});
            this.CK.Location = new System.Drawing.Point(584, 44);
            this.CK.Name = "CK";
            this.CK.Size = new System.Drawing.Size(100, 20);
            this.CK.TabIndex = 84;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(607, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 21);
            this.label3.TabIndex = 83;
            this.label3.Text = "仓库";
            // 
            // BC
            // 
            this.BC.Enabled = false;
            this.BC.Font = new System.Drawing.Font("楷体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BC.Location = new System.Drawing.Point(1112, 19);
            this.BC.Name = "BC";
            this.BC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BC.Size = new System.Drawing.Size(107, 46);
            this.BC.TabIndex = 82;
            this.BC.Text = "保存";
            this.BC.UseVisualStyleBackColor = true;
            this.BC.Click += new System.EventHandler(this.BC_Click);
            // 
            // RQ1
            // 
            this.RQ1.CustomFormat = "yyyy-MM-dd";
            this.RQ1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.RQ1.Location = new System.Drawing.Point(140, 44);
            this.RQ1.Name = "RQ1";
            this.RQ1.Size = new System.Drawing.Size(104, 21);
            this.RQ1.TabIndex = 81;
            // 
            // RQ
            // 
            this.RQ.CustomFormat = "yyyy-MM-dd";
            this.RQ.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.RQ.Location = new System.Drawing.Point(30, 44);
            this.RQ.Name = "RQ";
            this.RQ.Size = new System.Drawing.Size(104, 21);
            this.RQ.TabIndex = 80;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(145, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 21);
            this.label5.TabIndex = 79;
            this.label5.Text = "结束时间";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(32, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 21);
            this.label6.TabIndex = 78;
            this.label6.Text = "开始时间";
            // 
            // ZT
            // 
            this.ZT.FormattingEnabled = true;
            this.ZT.Items.AddRange(new object[] {
            "已入库",
            "已出库"});
            this.ZT.Location = new System.Drawing.Point(467, 44);
            this.ZT.Name = "ZT";
            this.ZT.Size = new System.Drawing.Size(100, 20);
            this.ZT.TabIndex = 77;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(488, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 21);
            this.label4.TabIndex = 76;
            this.label4.Text = "状态";
            // 
            // GSMC
            // 
            this.GSMC.Location = new System.Drawing.Point(356, 44);
            this.GSMC.Name = "GSMC";
            this.GSMC.Size = new System.Drawing.Size(100, 21);
            this.GSMC.TabIndex = 75;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(357, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 21);
            this.label2.TabIndex = 74;
            this.label2.Text = "公司名称";
            // 
            // HTBH
            // 
            this.HTBH.Location = new System.Drawing.Point(250, 44);
            this.HTBH.Name = "HTBH";
            this.HTBH.Size = new System.Drawing.Size(100, 21);
            this.HTBH.TabIndex = 73;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(253, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 21);
            this.label1.TabIndex = 72;
            this.label1.Text = "合同编号";
            // 
            // SX
            // 
            this.SX.Font = new System.Drawing.Font("楷体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SX.Location = new System.Drawing.Point(995, 18);
            this.SX.Name = "SX";
            this.SX.Size = new System.Drawing.Size(111, 52);
            this.SX.TabIndex = 71;
            this.SX.Text = "筛选";
            this.SX.UseVisualStyleBackColor = true;
            this.SX.Click += new System.EventHandler(this.SX_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1233, 575);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.审核ToolStripMenuItem,
            this.批量审核ToolStripMenuItem,
            this.反审核ToolStripMenuItem,
            this.财务审核ToolStripMenuItem,
            this.财务反审核ToolStripMenuItem,
            this.修改ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.粘贴ToolStripMenuItem,
            this.导出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 202);
            // 
            // 审核ToolStripMenuItem
            // 
            this.审核ToolStripMenuItem.Name = "审核ToolStripMenuItem";
            this.审核ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.审核ToolStripMenuItem.Text = "审核";
            this.审核ToolStripMenuItem.Click += new System.EventHandler(this.审核ToolStripMenuItem_Click);
            // 
            // 批量审核ToolStripMenuItem
            // 
            this.批量审核ToolStripMenuItem.Name = "批量审核ToolStripMenuItem";
            this.批量审核ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.批量审核ToolStripMenuItem.Text = "批量审核";
            this.批量审核ToolStripMenuItem.Click += new System.EventHandler(this.批量审核ToolStripMenuItem_Click);
            // 
            // 反审核ToolStripMenuItem
            // 
            this.反审核ToolStripMenuItem.Name = "反审核ToolStripMenuItem";
            this.反审核ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.反审核ToolStripMenuItem.Text = "反审核";
            this.反审核ToolStripMenuItem.Click += new System.EventHandler(this.反审核ToolStripMenuItem_Click);
            // 
            // 财务审核ToolStripMenuItem
            // 
            this.财务审核ToolStripMenuItem.Name = "财务审核ToolStripMenuItem";
            this.财务审核ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.财务审核ToolStripMenuItem.Text = "财务审核";
            this.财务审核ToolStripMenuItem.Click += new System.EventHandler(this.财务审核ToolStripMenuItem_Click);
            // 
            // 财务反审核ToolStripMenuItem
            // 
            this.财务反审核ToolStripMenuItem.Name = "财务反审核ToolStripMenuItem";
            this.财务反审核ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.财务反审核ToolStripMenuItem.Text = "财务反审核";
            this.财务反审核ToolStripMenuItem.Click += new System.EventHandler(this.财务反审核ToolStripMenuItem_Click);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.修改ToolStripMenuItem.Text = "修改";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Enabled = false;
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.Enabled = false;
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            this.粘贴ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.粘贴ToolStripMenuItem.Text = "粘贴";
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.导出ToolStripMenuItem.Text = "导出";
            this.导出ToolStripMenuItem.Click += new System.EventHandler(this.导出ToolStripMenuItem_Click);
            // 
            // ProductListOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1233, 663);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ProductListOut";
            this.Text = "ProductListOut";
            this.Load += new System.EventHandler(this.ProductListOut_Load);
            this.SizeChanged += new System.EventHandler(this.ProductListOut_SizeChanged);
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
        private System.Windows.Forms.Button BC;
        private System.Windows.Forms.DateTimePicker RQ1;
        private System.Windows.Forms.DateTimePicker RQ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ZT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox GSMC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox HTBH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SX;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox CK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 审核ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 财务审核ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 反审核ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 财务反审核ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.Button JZ;
        private System.Windows.Forms.Button JZ1;
        private System.Windows.Forms.ToolStripMenuItem 批量审核ToolStripMenuItem;
        private System.Windows.Forms.Button XZL;
    }
}
namespace WindowsFormsApp1.Desgin
{
    partial class CheckAllList
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
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JSRQ = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.KSRQ = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHtbh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.插入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.批量审核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtNorms = new System.Windows.Forms.TextBox();
            this.txtlb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtClmc = new System.Windows.Forms.TextBox();
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.审核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lable4 = new System.Windows.Forms.Label();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.反审核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GSMC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BC = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SX = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.打开ToolStripMenuItem.Text = "打开图片";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Enabled = false;
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            // 
            // JSRQ
            // 
            this.JSRQ.CustomFormat = "yyyy-MM-dd";
            this.JSRQ.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.JSRQ.Location = new System.Drawing.Point(154, 36);
            this.JSRQ.Name = "JSRQ";
            this.JSRQ.Size = new System.Drawing.Size(115, 21);
            this.JSRQ.TabIndex = 55;
            this.JSRQ.ValueChanged += new System.EventHandler(this.JSRQ_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(161, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 21);
            this.label4.TabIndex = 54;
            this.label4.Text = "结束日期";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // KSRQ
            // 
            this.KSRQ.CustomFormat = "yyyy-MM-dd";
            this.KSRQ.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.KSRQ.Location = new System.Drawing.Point(12, 36);
            this.KSRQ.Name = "KSRQ";
            this.KSRQ.Size = new System.Drawing.Size(124, 21);
            this.KSRQ.TabIndex = 53;
            this.KSRQ.Value = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            this.KSRQ.ValueChanged += new System.EventHandler(this.KSRQ_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(25, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 21);
            this.label6.TabIndex = 52;
            this.label6.Text = "开始日期";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtHtbh
            // 
            this.txtHtbh.Location = new System.Drawing.Point(285, 36);
            this.txtHtbh.Name = "txtHtbh";
            this.txtHtbh.Size = new System.Drawing.Size(133, 21);
            this.txtHtbh.TabIndex = 18;
            this.txtHtbh.TextChanged += new System.EventHandler(this.txtHtbh_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(314, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "合同编号";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // 插入ToolStripMenuItem
            // 
            this.插入ToolStripMenuItem.Enabled = false;
            this.插入ToolStripMenuItem.Name = "插入ToolStripMenuItem";
            this.插入ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.插入ToolStripMenuItem.Text = "插入";
            // 
            // 批量审核ToolStripMenuItem
            // 
            this.批量审核ToolStripMenuItem.Enabled = false;
            this.批量审核ToolStripMenuItem.Name = "批量审核ToolStripMenuItem";
            this.批量审核ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.批量审核ToolStripMenuItem.Text = "批量审核";
            // 
            // txtNorms
            // 
            this.txtNorms.Location = new System.Drawing.Point(434, 36);
            this.txtNorms.Name = "txtNorms";
            this.txtNorms.Size = new System.Drawing.Size(128, 21);
            this.txtNorms.TabIndex = 16;
            this.txtNorms.TextChanged += new System.EventHandler(this.txtNorms_TextChanged);
            // 
            // txtlb
            // 
            this.txtlb.Location = new System.Drawing.Point(921, 36);
            this.txtlb.Name = "txtlb";
            this.txtlb.Size = new System.Drawing.Size(119, 21);
            this.txtlb.TabIndex = 15;
            this.txtlb.TextChanged += new System.EventHandler(this.txtlb_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(932, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "材料类别";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtClmc
            // 
            this.txtClmc.Location = new System.Drawing.Point(754, 35);
            this.txtClmc.Name = "txtClmc";
            this.txtClmc.Size = new System.Drawing.Size(133, 21);
            this.txtClmc.TabIndex = 12;
            this.txtClmc.TextChanged += new System.EventHandler(this.txtClmc_TextChanged);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.修改ToolStripMenuItem.Text = "修改";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click);
            // 
            // 审核ToolStripMenuItem
            // 
            this.审核ToolStripMenuItem.Enabled = false;
            this.审核ToolStripMenuItem.Name = "审核ToolStripMenuItem";
            this.审核ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.审核ToolStripMenuItem.Text = "审核";
            // 
            // lable4
            // 
            this.lable4.AutoSize = true;
            this.lable4.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lable4.Location = new System.Drawing.Point(448, 10);
            this.lable4.Name = "lable4";
            this.lable4.Size = new System.Drawing.Size(89, 20);
            this.lable4.TabIndex = 14;
            this.lable4.Text = "材料规格";
            this.lable4.Click += new System.EventHandler(this.lable4_Click);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.导出ToolStripMenuItem.Text = "导出";
            this.导出ToolStripMenuItem.Click += new System.EventHandler(this.导出ToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(766, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 21);
            this.label5.TabIndex = 11;
            this.label5.Text = "材料名称";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1388, 543);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.修改ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.插入ToolStripMenuItem,
            this.批量审核ToolStripMenuItem,
            this.审核ToolStripMenuItem,
            this.反审核ToolStripMenuItem,
            this.导出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 180);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 反审核ToolStripMenuItem
            // 
            this.反审核ToolStripMenuItem.Enabled = false;
            this.反审核ToolStripMenuItem.Name = "反审核ToolStripMenuItem";
            this.反审核ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.反审核ToolStripMenuItem.Text = "反审核";
            // 
            // GSMC
            // 
            this.GSMC.Location = new System.Drawing.Point(591, 35);
            this.GSMC.Name = "GSMC";
            this.GSMC.Size = new System.Drawing.Size(133, 21);
            this.GSMC.TabIndex = 6;
            this.GSMC.TextChanged += new System.EventHandler(this.GSMC_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(619, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "客户名";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // BC
            // 
            this.BC.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BC.Location = new System.Drawing.Point(1191, 11);
            this.BC.Name = "BC";
            this.BC.Size = new System.Drawing.Size(95, 46);
            this.BC.TabIndex = 1;
            this.BC.Text = "保存";
            this.BC.UseVisualStyleBackColor = true;
            this.BC.Click += new System.EventHandler(this.BC_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.JSRQ);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.KSRQ);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.txtHtbh);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txtNorms);
            this.splitContainer1.Panel1.Controls.Add(this.txtlb);
            this.splitContainer1.Panel1.Controls.Add(this.lable4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtClmc);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.GSMC);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.BC);
            this.splitContainer1.Panel1.Controls.Add(this.SX);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1388, 614);
            this.splitContainer1.SplitterDistance = 67;
            this.splitContainer1.TabIndex = 2;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // SX
            // 
            this.SX.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SX.Location = new System.Drawing.Point(1069, 11);
            this.SX.Name = "SX";
            this.SX.Size = new System.Drawing.Size(95, 46);
            this.SX.TabIndex = 0;
            this.SX.Text = "筛选";
            this.SX.UseVisualStyleBackColor = true;
            this.SX.Click += new System.EventHandler(this.SX_Click);
            // 
            // CheckAllList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1388, 614);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CheckAllList";
            this.Text = "CheckAllList";
            this.Load += new System.EventHandler(this.CheckAllList_Load);
            this.SizeChanged += new System.EventHandler(this.CheckAllList_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker JSRQ;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker KSRQ;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHtbh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 插入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 批量审核ToolStripMenuItem;
        private System.Windows.Forms.TextBox txtNorms;
        private System.Windows.Forms.TextBox txtlb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtClmc;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 审核ToolStripMenuItem;
        private System.Windows.Forms.Label lable4;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 反审核ToolStripMenuItem;
        private System.Windows.Forms.TextBox GSMC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BC;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button SX;
    }
}
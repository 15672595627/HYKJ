namespace WindowsFormsApp1.Desgin
{
    partial class GroupListDetial
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
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtNorms = new System.Windows.Forms.TextBox();
            this.txtlb = new System.Windows.Forms.TextBox();
            this.lable4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCcpf = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BC = new System.Windows.Forms.Button();
            this.审核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.批量审核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.插入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SX = new System.Windows.Forms.Button();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.反审核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.导出ToolStripMenuItem.Text = "导出";
            this.导出ToolStripMenuItem.Click += new System.EventHandler(this.导出ToolStripMenuItem_Click);
            // 
            // txtNorms
            // 
            this.txtNorms.Location = new System.Drawing.Point(153, 37);
            this.txtNorms.Name = "txtNorms";
            this.txtNorms.Size = new System.Drawing.Size(128, 21);
            this.txtNorms.TabIndex = 16;
            // 
            // txtlb
            // 
            this.txtlb.Location = new System.Drawing.Point(12, 36);
            this.txtlb.Name = "txtlb";
            this.txtlb.Size = new System.Drawing.Size(119, 21);
            this.txtlb.TabIndex = 15;
            // 
            // lable4
            // 
            this.lable4.AutoSize = true;
            this.lable4.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lable4.Location = new System.Drawing.Point(174, 11);
            this.lable4.Name = "lable4";
            this.lable4.Size = new System.Drawing.Size(89, 20);
            this.lable4.TabIndex = 14;
            this.lable4.Text = "材料规格";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(24, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "材料类别";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(477, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(133, 21);
            this.txtName.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(493, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 21);
            this.label5.TabIndex = 11;
            this.label5.Text = "材料名称";
            // 
            // txtCcpf
            // 
            this.txtCcpf.Location = new System.Drawing.Point(313, 36);
            this.txtCcpf.Name = "txtCcpf";
            this.txtCcpf.Size = new System.Drawing.Size(133, 21);
            this.txtCcpf.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(329, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "尺寸喷粉";
            // 
            // BC
            // 
            this.BC.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BC.Location = new System.Drawing.Point(982, 11);
            this.BC.Name = "BC";
            this.BC.Size = new System.Drawing.Size(95, 46);
            this.BC.TabIndex = 1;
            this.BC.Text = "保存";
            this.BC.UseVisualStyleBackColor = true;
            this.BC.Click += new System.EventHandler(this.BC_Click);
            // 
            // 审核ToolStripMenuItem
            // 
            this.审核ToolStripMenuItem.Enabled = false;
            this.审核ToolStripMenuItem.Name = "审核ToolStripMenuItem";
            this.审核ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.审核ToolStripMenuItem.Text = "审核";
            this.审核ToolStripMenuItem.Click += new System.EventHandler(this.审核ToolStripMenuItem_Click);
            // 
            // 批量审核ToolStripMenuItem
            // 
            this.批量审核ToolStripMenuItem.Enabled = false;
            this.批量审核ToolStripMenuItem.Name = "批量审核ToolStripMenuItem";
            this.批量审核ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.批量审核ToolStripMenuItem.Text = "批量审核";
            // 
            // 插入ToolStripMenuItem
            // 
            this.插入ToolStripMenuItem.Enabled = false;
            this.插入ToolStripMenuItem.Name = "插入ToolStripMenuItem";
            this.插入ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.插入ToolStripMenuItem.Text = "插入";
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Enabled = false;
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // SX
            // 
            this.SX.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SX.Location = new System.Drawing.Point(871, 12);
            this.SX.Name = "SX";
            this.SX.Size = new System.Drawing.Size(95, 46);
            this.SX.TabIndex = 0;
            this.SX.Text = "筛选";
            this.SX.UseVisualStyleBackColor = true;
            this.SX.Click += new System.EventHandler(this.SX_Click);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Enabled = false;
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.打开ToolStripMenuItem.Text = "打开图片";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
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
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.修改ToolStripMenuItem.Text = "修改";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click);
            // 
            // 反审核ToolStripMenuItem
            // 
            this.反审核ToolStripMenuItem.Enabled = false;
            this.反审核ToolStripMenuItem.Name = "反审核ToolStripMenuItem";
            this.反审核ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.反审核ToolStripMenuItem.Text = "反审核";
            this.反审核ToolStripMenuItem.Click += new System.EventHandler(this.反审核ToolStripMenuItem_Click);
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
            this.dataGridView1.Size = new System.Drawing.Size(1108, 666);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            this.splitContainer1.Panel1.Controls.Add(this.txtNorms);
            this.splitContainer1.Panel1.Controls.Add(this.txtlb);
            this.splitContainer1.Panel1.Controls.Add(this.lable4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtName);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.txtCcpf);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.BC);
            this.splitContainer1.Panel1.Controls.Add(this.SX);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1108, 737);
            this.splitContainer1.SplitterDistance = 67;
            this.splitContainer1.TabIndex = 1;
            // 
            // GroupListDetial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 737);
            this.Controls.Add(this.splitContainer1);
            this.Name = "GroupListDetial";
            this.Text = "GroupListDetial";
            this.Load += new System.EventHandler(this.GroupListDetial_Load);
            this.SizeChanged += new System.EventHandler(this.GroupListDetial_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.TextBox txtNorms;
        private System.Windows.Forms.TextBox txtlb;
        private System.Windows.Forms.Label lable4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCcpf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BC;
        private System.Windows.Forms.ToolStripMenuItem 审核ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 批量审核ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 插入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.Button SX;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 反审核ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
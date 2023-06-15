namespace WindowsFormsApp1.Stock
{
    partial class JIT
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
            this.XG = new System.Windows.Forms.Button();
            this.MC = new System.Windows.Forms.TextBox();
            this.ming = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CKLB = new System.Windows.Forms.ComboBox();
            this.BC = new System.Windows.Forms.Button();
            this.SX = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
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
            this.splitContainer1.Panel1.Controls.Add(this.XG);
            this.splitContainer1.Panel1.Controls.Add(this.MC);
            this.splitContainer1.Panel1.Controls.Add(this.ming);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.CKLB);
            this.splitContainer1.Panel1.Controls.Add(this.BC);
            this.splitContainer1.Panel1.Controls.Add(this.SX);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1077, 628);
            this.splitContainer1.SplitterDistance = 111;
            this.splitContainer1.TabIndex = 0;
            // 
            // XG
            // 
            this.XG.Font = new System.Drawing.Font("楷体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XG.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.XG.Location = new System.Drawing.Point(824, 30);
            this.XG.Name = "XG";
            this.XG.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.XG.Size = new System.Drawing.Size(107, 44);
            this.XG.TabIndex = 89;
            this.XG.Text = "修改";
            this.XG.UseVisualStyleBackColor = true;
            this.XG.Click += new System.EventHandler(this.XG_Click);
            // 
            // MC
            // 
            this.MC.Location = new System.Drawing.Point(161, 61);
            this.MC.Name = "MC";
            this.MC.Size = new System.Drawing.Size(100, 21);
            this.MC.TabIndex = 88;
            // 
            // ming
            // 
            this.ming.AutoSize = true;
            this.ming.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ming.Location = new System.Drawing.Point(187, 30);
            this.ming.Name = "ming";
            this.ming.Size = new System.Drawing.Size(54, 21);
            this.ming.TabIndex = 87;
            this.ming.Text = "名称";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(33, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 21);
            this.label7.TabIndex = 85;
            this.label7.Text = "查看类别";
            // 
            // CKLB
            // 
            this.CKLB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CKLB.FormattingEnabled = true;
            this.CKLB.Items.AddRange(new object[] {
            "原材料",
            "产成品"});
            this.CKLB.Location = new System.Drawing.Point(14, 62);
            this.CKLB.Name = "CKLB";
            this.CKLB.Size = new System.Drawing.Size(131, 20);
            this.CKLB.TabIndex = 86;
            // 
            // BC
            // 
            this.BC.Enabled = false;
            this.BC.Font = new System.Drawing.Font("楷体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BC.Location = new System.Drawing.Point(949, 30);
            this.BC.Name = "BC";
            this.BC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BC.Size = new System.Drawing.Size(107, 44);
            this.BC.TabIndex = 84;
            this.BC.Text = "保存";
            this.BC.UseVisualStyleBackColor = true;
            this.BC.Click += new System.EventHandler(this.BC_Click);
            // 
            // SX
            // 
            this.SX.Font = new System.Drawing.Font("楷体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SX.Location = new System.Drawing.Point(689, 30);
            this.SX.Name = "SX";
            this.SX.Size = new System.Drawing.Size(111, 44);
            this.SX.TabIndex = 73;
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
            this.dataGridView1.Size = new System.Drawing.Size(1077, 513);
            this.dataGridView1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.导出ToolStripMenuItem.Text = "导出";
            this.导出ToolStripMenuItem.Click += new System.EventHandler(this.导出ToolStripMenuItem_Click);
            // 
            // JIT
            // 
            this.AcceptButton = this.SX;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 628);
            this.Controls.Add(this.splitContainer1);
            this.Name = "JIT";
            this.Text = "JIT";
            this.Load += new System.EventHandler(this.JIT_Load);
            this.SizeChanged += new System.EventHandler(this.JIT_SizeChanged);
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
        private System.Windows.Forms.TextBox MC;
        private System.Windows.Forms.Label ming;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CKLB;
        private System.Windows.Forms.Button BC;
        private System.Windows.Forms.Button SX;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.Button XG;
    }
}
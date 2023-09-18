namespace WindowsFormsApp1.Stock
{
    partial class addStock
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.物料代码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.物料名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.物料规格 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.助记号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.仓库代码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.仓库名称 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.单位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.重量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.重量单位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.最新进价 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.库存金额 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.库位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(12, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 205);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.物料代码,
            this.物料名称,
            this.物料规格,
            this.助记号,
            this.仓库代码,
            this.仓库名称,
            this.数量,
            this.单位,
            this.重量,
            this.重量单位,
            this.备注,
            this.最新进价,
            this.库存金额,
            this.库位});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(776, 205);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(249, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "添加原材料库存";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 317);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "保 存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 物料代码
            // 
            this.物料代码.HeaderText = "物料代码";
            this.物料代码.Name = "物料代码";
            // 
            // 物料名称
            // 
            this.物料名称.HeaderText = "物料名称";
            this.物料名称.Name = "物料名称";
            // 
            // 物料规格
            // 
            this.物料规格.HeaderText = "物料规格";
            this.物料规格.Name = "物料规格";
            // 
            // 助记号
            // 
            this.助记号.HeaderText = "助记号";
            this.助记号.Name = "助记号";
            // 
            // 仓库代码
            // 
            this.仓库代码.HeaderText = "仓库代码";
            this.仓库代码.Name = "仓库代码";
            // 
            // 仓库名称
            // 
            this.仓库名称.HeaderText = "仓库名称";
            this.仓库名称.Items.AddRange(new object[] {
            "铝型材主材仓",
            "铝型材辅材仓",
            "锌钢主材仓",
            "锌钢辅材仓",
            "包装物仓",
            "色粉仓",
            "零星采购仓",
            "燃料仓",
            "油漆仓",
            "在产品仓",
            "半成品仓",
            "二厂主材仓",
            "二厂零星采购仓"});
            this.仓库名称.Name = "仓库名称";
            // 
            // 数量
            // 
            this.数量.HeaderText = "数量";
            this.数量.Name = "数量";
            // 
            // 单位
            // 
            this.单位.HeaderText = "单位";
            this.单位.Name = "单位";
            // 
            // 重量
            // 
            this.重量.HeaderText = "重量";
            this.重量.Name = "重量";
            // 
            // 重量单位
            // 
            this.重量单位.HeaderText = "重量单位";
            this.重量单位.Name = "重量单位";
            // 
            // 备注
            // 
            this.备注.HeaderText = "备注";
            this.备注.Name = "备注";
            // 
            // 最新进价
            // 
            this.最新进价.HeaderText = "最新进价";
            this.最新进价.Name = "最新进价";
            // 
            // 库存金额
            // 
            this.库存金额.HeaderText = "库存金额";
            this.库存金额.Name = "库存金额";
            // 
            // 库位
            // 
            this.库位.HeaderText = "库位";
            this.库位.Name = "库位";
            // 
            // addStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "addStock";
            this.Text = "addStock";
            this.Load += new System.EventHandler(this.addStock_Load);
            this.SizeChanged += new System.EventHandler(this.addStock_SizeChanged);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 物料代码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 物料名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 物料规格;
        private System.Windows.Forms.DataGridViewTextBoxColumn 助记号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 仓库代码;
        private System.Windows.Forms.DataGridViewComboBoxColumn 仓库名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 单位;
        private System.Windows.Forms.DataGridViewTextBoxColumn 重量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 重量单位;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注;
        private System.Windows.Forms.DataGridViewTextBoxColumn 最新进价;
        private System.Windows.Forms.DataGridViewTextBoxColumn 库存金额;
        private System.Windows.Forms.DataGridViewTextBoxColumn 库位;
    }
}
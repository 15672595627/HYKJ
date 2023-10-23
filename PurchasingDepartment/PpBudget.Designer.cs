﻿namespace WindowsFormsApp1.PurchasingDepartment
{
    partial class PpBudget
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
            this.其他采购计划 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.设备采购计划 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.生产用物料采购计划 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.采购计划 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.产值目标 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.退过账款 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.收前期欠款 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.支付货款 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.本月出货收款 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.回款目标 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出货目标 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.下单目标 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.签单目标 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.职员人均月签单额 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.员工人数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.定金 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 405);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 其他采购计划
            // 
            this.其他采购计划.HeaderText = "其他采购计划";
            this.其他采购计划.Name = "其他采购计划";
            // 
            // 设备采购计划
            // 
            this.设备采购计划.HeaderText = "设备采购计划";
            this.设备采购计划.Name = "设备采购计划";
            // 
            // 生产用物料采购计划
            // 
            this.生产用物料采购计划.HeaderText = "生产用物料采购计划";
            this.生产用物料采购计划.Name = "生产用物料采购计划";
            // 
            // 采购计划
            // 
            this.采购计划.HeaderText = "采购计划";
            this.采购计划.Name = "采购计划";
            // 
            // 产值目标
            // 
            this.产值目标.HeaderText = "产值目标";
            this.产值目标.Name = "产值目标";
            // 
            // 退过账款
            // 
            this.退过账款.HeaderText = "退过账款";
            this.退过账款.Name = "退过账款";
            // 
            // 收前期欠款
            // 
            this.收前期欠款.HeaderText = "收前期欠款";
            this.收前期欠款.Name = "收前期欠款";
            // 
            // 支付货款
            // 
            this.支付货款.HeaderText = "支付货款";
            this.支付货款.Name = "支付货款";
            // 
            // 本月出货收款
            // 
            this.本月出货收款.HeaderText = "本月出货收款";
            this.本月出货收款.Name = "本月出货收款";
            // 
            // 回款目标
            // 
            this.回款目标.HeaderText = "回款目标";
            this.回款目标.Name = "回款目标";
            // 
            // 出货目标
            // 
            this.出货目标.HeaderText = "出货目标";
            this.出货目标.Name = "出货目标";
            // 
            // 下单目标
            // 
            this.下单目标.HeaderText = "下单目标";
            this.下单目标.Name = "下单目标";
            // 
            // 签单目标
            // 
            this.签单目标.HeaderText = "签单目标";
            this.签单目标.Name = "签单目标";
            // 
            // 职员人均月签单额
            // 
            this.职员人均月签单额.HeaderText = "职员人均月签单额";
            this.职员人均月签单额.Name = "职员人均月签单额";
            // 
            // 员工人数
            // 
            this.员工人数.HeaderText = "员工人数";
            this.员工人数.Name = "员工人数";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.员工人数,
            this.职员人均月签单额,
            this.签单目标,
            this.下单目标,
            this.出货目标,
            this.回款目标,
            this.定金,
            this.本月出货收款,
            this.收前期欠款,
            this.退过账款,
            this.产值目标,
            this.采购计划,
            this.生产用物料采购计划,
            this.设备采购计划,
            this.其他采购计划,
            this.支付货款});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(775, 359);
            this.dataGridView1.TabIndex = 0;
            // 
            // 定金
            // 
            this.定金.HeaderText = "定金";
            this.定金.Name = "定金";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(13, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 359);
            this.panel1.TabIndex = 10;
            // 
            // CGBBudget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "CGBBudget";
            this.Text = "CGBBudget";
            this.Load += new System.EventHandler(this.CGBBudget_Load);
            this.SizeChanged += new System.EventHandler(this.CGBBudget_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 其他采购计划;
        private System.Windows.Forms.DataGridViewTextBoxColumn 设备采购计划;
        private System.Windows.Forms.DataGridViewTextBoxColumn 生产用物料采购计划;
        private System.Windows.Forms.DataGridViewTextBoxColumn 采购计划;
        private System.Windows.Forms.DataGridViewTextBoxColumn 产值目标;
        private System.Windows.Forms.DataGridViewTextBoxColumn 退过账款;
        private System.Windows.Forms.DataGridViewTextBoxColumn 收前期欠款;
        private System.Windows.Forms.DataGridViewTextBoxColumn 支付货款;
        private System.Windows.Forms.DataGridViewTextBoxColumn 本月出货收款;
        private System.Windows.Forms.DataGridViewTextBoxColumn 回款目标;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出货目标;
        private System.Windows.Forms.DataGridViewTextBoxColumn 下单目标;
        private System.Windows.Forms.DataGridViewTextBoxColumn 签单目标;
        private System.Windows.Forms.DataGridViewTextBoxColumn 职员人均月签单额;
        private System.Windows.Forms.DataGridViewTextBoxColumn 员工人数;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 定金;
        private System.Windows.Forms.Panel panel1;
    }
}
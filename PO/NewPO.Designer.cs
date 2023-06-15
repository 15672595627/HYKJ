namespace WindowsFormsApp1.PO
{
    partial class NewPO
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
            this.label2 = new System.Windows.Forms.Label();
            this.CGSQ = new System.Windows.Forms.TextBox();
            this.DJBH = new System.Windows.Forms.TextBox();
            this.RQ = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.GYS = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.JQ = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BZ = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.HTBH = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.GSM = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.XMMC = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "采购申请单号";
            // 
            // CGSQ
            // 
            this.CGSQ.Location = new System.Drawing.Point(107, 119);
            this.CGSQ.Name = "CGSQ";
            this.CGSQ.Size = new System.Drawing.Size(138, 21);
            this.CGSQ.TabIndex = 2;
            this.CGSQ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CGSQ_KeyDown);
            this.CGSQ.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CGSQ_MouseDoubleClick);
            // 
            // DJBH
            // 
            this.DJBH.Location = new System.Drawing.Point(757, 12);
            this.DJBH.Name = "DJBH";
            this.DJBH.ReadOnly = true;
            this.DJBH.Size = new System.Drawing.Size(154, 21);
            this.DJBH.TabIndex = 4;
            // 
            // RQ
            // 
            this.RQ.Location = new System.Drawing.Point(757, 55);
            this.RQ.Name = "RQ";
            this.RQ.ReadOnly = true;
            this.RQ.Size = new System.Drawing.Size(154, 21);
            this.RQ.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(674, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "采购订单单号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(698, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "采购日期";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(269, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "采购供应商";
            // 
            // GYS
            // 
            this.GYS.Location = new System.Drawing.Point(340, 119);
            this.GYS.Name = "GYS";
            this.GYS.Size = new System.Drawing.Size(258, 21);
            this.GYS.TabIndex = 8;
            this.GYS.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CGGYS_MouseDoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(641, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "采购交期";
            // 
            // JQ
            // 
            this.JQ.CustomFormat = "yyyy-MM-dd";
            this.JQ.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.JQ.Location = new System.Drawing.Point(700, 119);
            this.JQ.Name = "JQ";
            this.JQ.Size = new System.Drawing.Size(138, 21);
            this.JQ.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(814, 685);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 40);
            this.button1.TabIndex = 14;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(14, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(894, 463);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(888, 443);
            this.dataGridView1.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("楷体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(385, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 35);
            this.label7.TabIndex = 20;
            this.label7.Text = "采购订单";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(665, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "备注";
            // 
            // BZ
            // 
            this.BZ.Location = new System.Drawing.Point(700, 159);
            this.BZ.Name = "BZ";
            this.BZ.Size = new System.Drawing.Size(208, 35);
            this.BZ.TabIndex = 22;
            this.BZ.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 24;
            this.label9.Text = "合同编号";
            // 
            // HTBH
            // 
            this.HTBH.Location = new System.Drawing.Point(107, 162);
            this.HTBH.Name = "HTBH";
            this.HTBH.ReadOnly = true;
            this.HTBH.Size = new System.Drawing.Size(138, 21);
            this.HTBH.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(293, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 26;
            this.label10.Text = "公司名";
            // 
            // GSM
            // 
            this.GSM.Location = new System.Drawing.Point(340, 162);
            this.GSM.Name = "GSM";
            this.GSM.ReadOnly = true;
            this.GSM.Size = new System.Drawing.Size(109, 21);
            this.GSM.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(457, 165);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 28;
            this.label11.Text = "项目名称";
            // 
            // XMMC
            // 
            this.XMMC.Location = new System.Drawing.Point(516, 162);
            this.XMMC.Name = "XMMC";
            this.XMMC.ReadOnly = true;
            this.XMMC.Size = new System.Drawing.Size(143, 21);
            this.XMMC.TabIndex = 27;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(50, 685);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 29;
            this.button2.Text = "打印设置";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(131, 685);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 30;
            this.button3.Text = "打印预览";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(212, 685);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 31;
            this.button4.Text = "打印";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // NewPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 734);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.XMMC);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.GSM);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.HTBH);
            this.Controls.Add(this.BZ);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.JQ);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.GYS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RQ);
            this.Controls.Add(this.DJBH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CGSQ);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "NewPO";
            this.Text = "NewPO";
            this.Load += new System.EventHandler(this.NewPO_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CGSQ;
        private System.Windows.Forms.TextBox DJBH;
        private System.Windows.Forms.TextBox RQ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox GYS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker JQ;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox BZ;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox HTBH;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox GSM;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox XMMC;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}
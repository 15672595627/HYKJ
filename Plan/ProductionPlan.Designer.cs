namespace WindowsFormsApp1.Plan
{
    partial class ProductionPlan
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
            this.CPMC = new System.Windows.Forms.TextBox();
            this.NR = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DJBH = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DJRQ = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GDY = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.GSM = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PQSJBC = new System.Windows.Forms.Button();
            this.JSSJ = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.KSSJ = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.HTBH = new System.Windows.Forms.TextBox();
            this.lable = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.PQR = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.WLZTBC = new System.Windows.Forms.Button();
            this.WLZTBZ = new System.Windows.Forms.RichTextBox();
            this.WLZT = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // CPMC
            // 
            this.CPMC.Location = new System.Drawing.Point(96, 144);
            this.CPMC.Name = "CPMC";
            this.CPMC.ReadOnly = true;
            this.CPMC.Size = new System.Drawing.Size(262, 21);
            this.CPMC.TabIndex = 1;
            // 
            // NR
            // 
            this.NR.Location = new System.Drawing.Point(423, 147);
            this.NR.Name = "NR";
            this.NR.ReadOnly = true;
            this.NR.Size = new System.Drawing.Size(285, 21);
            this.NR.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "产品名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "产品内容";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(589, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "单据编号";
            // 
            // DJBH
            // 
            this.DJBH.Location = new System.Drawing.Point(648, 12);
            this.DJBH.Name = "DJBH";
            this.DJBH.ReadOnly = true;
            this.DJBH.Size = new System.Drawing.Size(140, 21);
            this.DJBH.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(589, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "单据日期";
            // 
            // DJRQ
            // 
            this.DJRQ.Location = new System.Drawing.Point(648, 39);
            this.DJRQ.Name = "DJRQ";
            this.DJRQ.ReadOnly = true;
            this.DJRQ.Size = new System.Drawing.Size(140, 21);
            this.DJRQ.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("楷体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(326, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 29);
            this.label6.TabIndex = 11;
            this.label6.Text = "生产排期单";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(232, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "跟单员";
            // 
            // GDY
            // 
            this.GDY.Location = new System.Drawing.Point(291, 109);
            this.GDY.Name = "GDY";
            this.GDY.ReadOnly = true;
            this.GDY.Size = new System.Drawing.Size(126, 21);
            this.GDY.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(436, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "公司名称";
            // 
            // GSM
            // 
            this.GSM.Location = new System.Drawing.Point(495, 109);
            this.GSM.Name = "GSM";
            this.GSM.ReadOnly = true;
            this.GSM.Size = new System.Drawing.Size(213, 21);
            this.GSM.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PQSJBC);
            this.groupBox1.Controls.Add(this.JSSJ);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.KSSJ);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(12, 282);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 100);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "排期时间";
            // 
            // PQSJBC
            // 
            this.PQSJBC.Location = new System.Drawing.Point(668, 44);
            this.PQSJBC.Name = "PQSJBC";
            this.PQSJBC.Size = new System.Drawing.Size(89, 23);
            this.PQSJBC.TabIndex = 24;
            this.PQSJBC.Text = "排期确认";
            this.PQSJBC.UseVisualStyleBackColor = true;
            this.PQSJBC.Click += new System.EventHandler(this.PQSJBC_Click);
            // 
            // JSSJ
            // 
            this.JSSJ.CustomFormat = "yyyy-MM-dd";
            this.JSSJ.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.JSSJ.Location = new System.Drawing.Point(377, 43);
            this.JSSJ.Name = "JSSJ";
            this.JSSJ.Size = new System.Drawing.Size(126, 21);
            this.JSSJ.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(294, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 22;
            this.label9.Text = "预计完工时间";
            // 
            // KSSJ
            // 
            this.KSSJ.CustomFormat = "yyyy-MM-dd";
            this.KSSJ.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.KSSJ.Location = new System.Drawing.Point(120, 43);
            this.KSSJ.Name = "KSSJ";
            this.KSSJ.Size = new System.Drawing.Size(126, 21);
            this.KSSJ.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "开始生产时间";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5});
            this.statusStrip1.Location = new System.Drawing.Point(0, 401);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel1.Text = "时间";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel2.Text = "登录名：";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel3.Text = "登录名";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel4.Text = "用户组：";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel5.Text = "用户组";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // HTBH
            // 
            this.HTBH.Location = new System.Drawing.Point(96, 108);
            this.HTBH.Name = "HTBH";
            this.HTBH.Size = new System.Drawing.Size(126, 21);
            this.HTBH.TabIndex = 0;
            this.HTBH.TextChanged += new System.EventHandler(this.HTBH_TextChanged);
            this.HTBH.DoubleClick += new System.EventHandler(this.HTBH_DoubleClick);
            // 
            // lable
            // 
            this.lable.AutoSize = true;
            this.lable.Location = new System.Drawing.Point(37, 111);
            this.lable.Name = "lable";
            this.lable.Size = new System.Drawing.Size(53, 12);
            this.lable.TabIndex = 3;
            this.lable.Text = "合同编号";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(601, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 25;
            this.label12.Text = "排期人";
            // 
            // PQR
            // 
            this.PQR.Location = new System.Drawing.Point(648, 66);
            this.PQR.Name = "PQR";
            this.PQR.ReadOnly = true;
            this.PQR.Size = new System.Drawing.Size(140, 21);
            this.PQR.TabIndex = 24;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.WLZTBC);
            this.groupBox4.Controls.Add(this.WLZTBZ);
            this.groupBox4.Controls.Add(this.WLZT);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Location = new System.Drawing.Point(12, 176);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(776, 100);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "物料状态";
            // 
            // WLZTBC
            // 
            this.WLZTBC.Location = new System.Drawing.Point(668, 41);
            this.WLZTBC.Name = "WLZTBC";
            this.WLZTBC.Size = new System.Drawing.Size(89, 23);
            this.WLZTBC.TabIndex = 27;
            this.WLZTBC.Text = "物料状态确认";
            this.WLZTBC.UseVisualStyleBackColor = true;
            this.WLZTBC.Click += new System.EventHandler(this.WLZTBC_Click);
            // 
            // WLZTBZ
            // 
            this.WLZTBZ.Location = new System.Drawing.Point(268, 20);
            this.WLZTBZ.Name = "WLZTBZ";
            this.WLZTBZ.ReadOnly = true;
            this.WLZTBZ.Size = new System.Drawing.Size(362, 65);
            this.WLZTBZ.TabIndex = 26;
            this.WLZTBZ.Text = "";
            // 
            // WLZT
            // 
            this.WLZT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WLZT.FormattingEnabled = true;
            this.WLZT.Items.AddRange(new object[] {
            "物料正常",
            "物料不全"});
            this.WLZT.Location = new System.Drawing.Point(120, 43);
            this.WLZT.Name = "WLZT";
            this.WLZT.Size = new System.Drawing.Size(121, 20);
            this.WLZT.TabIndex = 25;
            this.WLZT.TextChanged += new System.EventHandler(this.WLZT_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(37, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 12);
            this.label14.TabIndex = 20;
            this.label14.Text = "订单物料状态";
            // 
            // ProductionPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 423);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.PQR);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.GSM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GDY);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DJRQ);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DJBH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lable);
            this.Controls.Add(this.NR);
            this.Controls.Add(this.CPMC);
            this.Controls.Add(this.HTBH);
            this.Name = "ProductionPlan";
            this.Text = "生产排期单";
            this.Load += new System.EventHandler(this.ProductionPlan_Load);
            this.SizeChanged += new System.EventHandler(this.ProductionPlan_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox CPMC;
        private System.Windows.Forms.TextBox NR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DJBH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DJRQ;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox GDY;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox GSM;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker JSSJ;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker KSSJ;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button PQSJBC;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.TextBox HTBH;
        private System.Windows.Forms.Label lable;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox PQR;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox WLZT;
        private System.Windows.Forms.Button WLZTBC;
        private System.Windows.Forms.RichTextBox WLZTBZ;
    }
}
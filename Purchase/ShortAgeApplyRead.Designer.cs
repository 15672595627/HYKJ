namespace WindowsFormsApp1.Purchase
{
    partial class ShortAgeApplyRead
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
            this.lable = new System.Windows.Forms.Label();
            this.HTBH = new System.Windows.Forms.TextBox();
            this.KHM = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.RQ = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DDBH = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GYS = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lable
            // 
            this.lable.AutoSize = true;
            this.lable.Location = new System.Drawing.Point(38, 148);
            this.lable.Name = "lable";
            this.lable.Size = new System.Drawing.Size(53, 12);
            this.lable.TabIndex = 0;
            this.lable.Text = "合同编号";
            // 
            // HTBH
            // 
            this.HTBH.Location = new System.Drawing.Point(97, 145);
            this.HTBH.Name = "HTBH";
            this.HTBH.ReadOnly = true;
            this.HTBH.Size = new System.Drawing.Size(138, 21);
            this.HTBH.TabIndex = 1;
            // 
            // KHM
            // 
            this.KHM.Location = new System.Drawing.Point(308, 107);
            this.KHM.Name = "KHM";
            this.KHM.ReadOnly = true;
            this.KHM.Size = new System.Drawing.Size(218, 21);
            this.KHM.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "客户名";
            // 
            // CP
            // 
            this.CP.Location = new System.Drawing.Point(308, 148);
            this.CP.Name = "CP";
            this.CP.ReadOnly = true;
            this.CP.Size = new System.Drawing.Size(218, 21);
            this.CP.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "产品";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(14, 184);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(951, 154);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "主材清单";
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
            this.dataGridView1.Size = new System.Drawing.Size(945, 134);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Location = new System.Drawing.Point(17, 361);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(948, 157);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "配件清单";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 17);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(942, 137);
            this.dataGridView2.TabIndex = 0;
            // 
            // RQ
            // 
            this.RQ.Location = new System.Drawing.Point(831, 39);
            this.RQ.Name = "RQ";
            this.RQ.ReadOnly = true;
            this.RQ.Size = new System.Drawing.Size(134, 21);
            this.RQ.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(772, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "单据日期";
            // 
            // DDBH
            // 
            this.DDBH.Location = new System.Drawing.Point(831, 12);
            this.DDBH.Name = "DDBH";
            this.DDBH.ReadOnly = true;
            this.DDBH.Size = new System.Drawing.Size(134, 21);
            this.DDBH.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(772, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "单据编号";
            // 
            // GYS
            // 
            this.GYS.Location = new System.Drawing.Point(97, 104);
            this.GYS.Name = "GYS";
            this.GYS.ReadOnly = true;
            this.GYS.Size = new System.Drawing.Size(138, 21);
            this.GYS.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "供应商";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("楷体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(290, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(393, 35);
            this.label6.TabIndex = 20;
            this.label6.Text = "采购申请单（BOM缺料）";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.审核成功;
            this.pictureBox1.Location = new System.Drawing.Point(702, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // ShortAgeApplyRead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 625);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.RQ);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DDBH);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GYS);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.KHM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HTBH);
            this.Controls.Add(this.lable);
            this.Name = "ShortAgeApplyRead";
            this.Text = "ShortAgeRead";
            this.Load += new System.EventHandler(this.ShortAgeRead_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lable;
        private System.Windows.Forms.TextBox HTBH;
        private System.Windows.Forms.TextBox KHM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox RQ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DDBH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox GYS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
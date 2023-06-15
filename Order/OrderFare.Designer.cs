namespace WindowsFormsApp1.Order
{
    partial class OrderFare
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.HTBH = new System.Windows.Forms.TextBox();
            this.GSM = new System.Windows.Forms.TextBox();
            this.XMMC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.YF = new System.Windows.Forms.TextBox();
            this.BC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "合同编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "公司名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "项目名称";
            // 
            // HTBH
            // 
            this.HTBH.Location = new System.Drawing.Point(77, 35);
            this.HTBH.Name = "HTBH";
            this.HTBH.ReadOnly = true;
            this.HTBH.Size = new System.Drawing.Size(100, 21);
            this.HTBH.TabIndex = 3;
            // 
            // GSM
            // 
            this.GSM.Location = new System.Drawing.Point(235, 34);
            this.GSM.Name = "GSM";
            this.GSM.ReadOnly = true;
            this.GSM.Size = new System.Drawing.Size(213, 21);
            this.GSM.TabIndex = 4;
            // 
            // XMMC
            // 
            this.XMMC.Location = new System.Drawing.Point(77, 78);
            this.XMMC.Name = "XMMC";
            this.XMMC.ReadOnly = true;
            this.XMMC.Size = new System.Drawing.Size(371, 21);
            this.XMMC.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("楷体", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 56);
            this.label4.TabIndex = 6;
            this.label4.Text = "运费";
            // 
            // YF
            // 
            this.YF.Font = new System.Drawing.Font("楷体", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.YF.Location = new System.Drawing.Point(154, 131);
            this.YF.Name = "YF";
            this.YF.Size = new System.Drawing.Size(294, 71);
            this.YF.TabIndex = 7;
            // 
            // BC
            // 
            this.BC.Font = new System.Drawing.Font("楷体", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BC.Location = new System.Drawing.Point(136, 239);
            this.BC.Name = "BC";
            this.BC.Size = new System.Drawing.Size(207, 70);
            this.BC.TabIndex = 8;
            this.BC.Text = "保存";
            this.BC.UseVisualStyleBackColor = true;
            this.BC.Click += new System.EventHandler(this.BC_Click);
            // 
            // OrderFare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 357);
            this.Controls.Add(this.BC);
            this.Controls.Add(this.YF);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.XMMC);
            this.Controls.Add(this.GSM);
            this.Controls.Add(this.HTBH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "OrderFare";
            this.Text = "运费";
            this.Load += new System.EventHandler(this.OrderFare_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox HTBH;
        private System.Windows.Forms.TextBox GSM;
        private System.Windows.Forms.TextBox XMMC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox YF;
        private System.Windows.Forms.Button BC;
    }
}
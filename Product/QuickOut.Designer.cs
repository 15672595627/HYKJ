namespace WindowsFormsApp1.Product
{
    partial class QuickOut
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
            this.CPMC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NR = new System.Windows.Forms.TextBox();
            this.SL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DW = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FHSL = new System.Windows.Forms.TextBox();
            this.BC = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.FHCK = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "产品名称";
            // 
            // CPMC
            // 
            this.CPMC.Location = new System.Drawing.Point(94, 43);
            this.CPMC.Name = "CPMC";
            this.CPMC.ReadOnly = true;
            this.CPMC.Size = new System.Drawing.Size(205, 21);
            this.CPMC.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "内容";
            // 
            // NR
            // 
            this.NR.Location = new System.Drawing.Point(94, 71);
            this.NR.Name = "NR";
            this.NR.ReadOnly = true;
            this.NR.Size = new System.Drawing.Size(205, 21);
            this.NR.TabIndex = 3;
            // 
            // SL
            // 
            this.SL.Location = new System.Drawing.Point(94, 98);
            this.SL.Name = "SL";
            this.SL.ReadOnly = true;
            this.SL.Size = new System.Drawing.Size(205, 21);
            this.SL.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "数量";
            // 
            // DW
            // 
            this.DW.Location = new System.Drawing.Point(94, 125);
            this.DW.Name = "DW";
            this.DW.ReadOnly = true;
            this.DW.Size = new System.Drawing.Size(205, 21);
            this.DW.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "单位";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "发货数量";
            // 
            // FHSL
            // 
            this.FHSL.Location = new System.Drawing.Point(94, 152);
            this.FHSL.Name = "FHSL";
            this.FHSL.Size = new System.Drawing.Size(205, 21);
            this.FHSL.TabIndex = 9;
            // 
            // BC
            // 
            this.BC.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BC.Location = new System.Drawing.Point(94, 215);
            this.BC.Name = "BC";
            this.BC.Size = new System.Drawing.Size(150, 47);
            this.BC.TabIndex = 10;
            this.BC.Text = "保存";
            this.BC.UseVisualStyleBackColor = true;
            this.BC.Click += new System.EventHandler(this.BC_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "发货数量";
            // 
            // FHCK
            // 
            this.FHCK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FHCK.FormattingEnabled = true;
            this.FHCK.Items.AddRange(new object[] {
            "一线成品仓",
            "二线成品仓",
            "三线成品仓"});
            this.FHCK.Location = new System.Drawing.Point(95, 180);
            this.FHCK.Name = "FHCK";
            this.FHCK.Size = new System.Drawing.Size(204, 20);
            this.FHCK.TabIndex = 12;
            // 
            // QuickOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 274);
            this.Controls.Add(this.FHCK);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BC);
            this.Controls.Add(this.FHSL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DW);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CPMC);
            this.Controls.Add(this.label1);
            this.Name = "QuickOut";
            this.Text = "QuickOut";
            this.Load += new System.EventHandler(this.QuickOut_Load);
            this.SizeChanged += new System.EventHandler(this.QuickOut_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CPMC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NR;
        private System.Windows.Forms.TextBox SL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DW;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox FHSL;
        private System.Windows.Forms.Button BC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox FHCK;
    }
}
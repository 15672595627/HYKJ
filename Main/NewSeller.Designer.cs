namespace WindowsFormsApp1.Main
{
    partial class NewSeller
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
            this.YWY = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.GS = new System.Windows.Forms.ComboBox();
            this.YMB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.NMB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.QY = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "业务员";
            // 
            // YWY
            // 
            this.YWY.Location = new System.Drawing.Point(129, 12);
            this.YWY.Name = "YWY";
            this.YWY.Size = new System.Drawing.Size(121, 21);
            this.YWY.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("楷体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(129, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 40);
            this.button1.TabIndex = 6;
            this.button1.Text = "新增";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "公司";
            // 
            // GS
            // 
            this.GS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GS.FormattingEnabled = true;
            this.GS.Items.AddRange(new object[] {
            "荆州区域",
            "荆州公司",
            "广东区域",
            "网销区",
            "武汉区域",
            "武汉公司",
            "安徽公司"});
            this.GS.Location = new System.Drawing.Point(129, 39);
            this.GS.Name = "GS";
            this.GS.Size = new System.Drawing.Size(121, 20);
            this.GS.TabIndex = 2;
            // 
            // YMB
            // 
            this.YMB.Location = new System.Drawing.Point(129, 92);
            this.YMB.Name = "YMB";
            this.YMB.Size = new System.Drawing.Size(121, 21);
            this.YMB.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "月目标";
            // 
            // NMB
            // 
            this.NMB.Location = new System.Drawing.Point(129, 119);
            this.NMB.Name = "NMB";
            this.NMB.Size = new System.Drawing.Size(121, 21);
            this.NMB.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "年目标";
            // 
            // QY
            // 
            this.QY.Location = new System.Drawing.Point(129, 65);
            this.QY.Name = "QY";
            this.QY.Size = new System.Drawing.Size(121, 21);
            this.QY.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "区域";
            // 
            // NewSeller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 236);
            this.Controls.Add(this.QY);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.NMB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.YMB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.YWY);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "NewSeller";
            this.Text = "新增业务员";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox YWY;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox GS;
        private System.Windows.Forms.TextBox YMB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NMB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox QY;
        private System.Windows.Forms.Label label5;
    }
}
namespace WindowsFormsApp1.Order
{
    partial class Orderxz
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
            this.QD = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FHCK = new System.Windows.Forms.ComboBox();
            this.WL = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // QD
            // 
            this.QD.Location = new System.Drawing.Point(69, 127);
            this.QD.Name = "QD";
            this.QD.Size = new System.Drawing.Size(75, 23);
            this.QD.TabIndex = 0;
            this.QD.Text = "确定";
            this.QD.UseVisualStyleBackColor = true;
            this.QD.Click += new System.EventHandler(this.QD_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "发货仓库";
            // 
            // FHCK
            // 
            this.FHCK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FHCK.FormattingEnabled = true;
            this.FHCK.Items.AddRange(new object[] {
            "一线成品仓",
            "二线成品仓",
            "三线成品仓",
            "仓库"});
            this.FHCK.Location = new System.Drawing.Point(69, 49);
            this.FHCK.Name = "FHCK";
            this.FHCK.Size = new System.Drawing.Size(121, 20);
            this.FHCK.TabIndex = 2;
            // 
            // WL
            // 
            this.WL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WL.FormattingEnabled = true;
            this.WL.Items.AddRange(new object[] {
            "装车",
            "物流",
            "自提"});
            this.WL.Location = new System.Drawing.Point(69, 75);
            this.WL.Name = "WL";
            this.WL.Size = new System.Drawing.Size(121, 20);
            this.WL.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "物流";
            // 
            // Orderxz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 186);
            this.Controls.Add(this.WL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FHCK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.QD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Orderxz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orderxz";
            this.Load += new System.EventHandler(this.Orderxz_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button QD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox FHCK;
        private System.Windows.Forms.ComboBox WL;
        private System.Windows.Forms.Label label2;
    }
}
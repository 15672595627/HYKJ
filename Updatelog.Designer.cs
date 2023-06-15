namespace WindowsFormsApp1
{
    partial class Updatelog
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
            this.GXRZ = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(316, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "更新日志";
            // 
            // GXRZ
            // 
            this.GXRZ.Location = new System.Drawing.Point(38, 65);
            this.GXRZ.Name = "GXRZ";
            this.GXRZ.ReadOnly = true;
            this.GXRZ.Size = new System.Drawing.Size(717, 345);
            this.GXRZ.TabIndex = 1;
            this.GXRZ.Text = "";
            this.GXRZ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GXRZ_KeyDown);
            // 
            // Updatelog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GXRZ);
            this.Controls.Add(this.label1);
            this.Name = "Updatelog";
            this.Text = "Updatelog";
            this.Load += new System.EventHandler(this.Updatelog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox GXRZ;
    }
}
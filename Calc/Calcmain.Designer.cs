namespace WindowsFormsApp1.Calc
{
    partial class Calcmain
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
            this.ucHorizontalList1 = new HZH_Controls.Controls.UCHorizontalList();
            this.SuspendLayout();
            // 
            // ucHorizontalList1
            // 
            this.ucHorizontalList1.DataSource = null;
            this.ucHorizontalList1.IsAutoSelectFirst = true;
            this.ucHorizontalList1.Location = new System.Drawing.Point(12, 12);
            this.ucHorizontalList1.Name = "ucHorizontalList1";
            this.ucHorizontalList1.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucHorizontalList1.SelectedItem = null;
            this.ucHorizontalList1.Size = new System.Drawing.Size(776, 53);
            this.ucHorizontalList1.TabIndex = 0;
            // 
            // Calcmain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ucHorizontalList1);
            this.Name = "Calcmain";
            this.Text = "Calcmain";
            this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCHorizontalList ucHorizontalList1;
    }
}
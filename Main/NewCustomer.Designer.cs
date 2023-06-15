namespace WindowsFormsApp1.Main
{
    partial class NewCustomer
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
            this.button1 = new System.Windows.Forms.Button();
            this.GSMC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.YWY = new System.Windows.Forms.ComboBox();
            this.sellerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hyerpDataSet = new WindowsFormsApp1.hyerpDataSet();
            this.XMMC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.KHLX = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.sellerTableAdapter = new WindowsFormsApp1.hyerpDataSetTableAdapters.SellerTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sellerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyerpDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("楷体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(126, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 40);
            this.button1.TabIndex = 9;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GSMC
            // 
            this.GSMC.Location = new System.Drawing.Point(113, 62);
            this.GSMC.Name = "GSMC";
            this.GSMC.Size = new System.Drawing.Size(181, 21);
            this.GSMC.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "公司名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "业务员";
            // 
            // YWY
            // 
            this.YWY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.YWY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.YWY.DataSource = this.sellerBindingSource;
            this.YWY.DisplayMember = "seller";
            this.YWY.FormattingEnabled = true;
            this.YWY.ItemHeight = 12;
            this.YWY.Location = new System.Drawing.Point(113, 142);
            this.YWY.Name = "YWY";
            this.YWY.Size = new System.Drawing.Size(181, 20);
            this.YWY.TabIndex = 13;
            this.YWY.ValueMember = "seller";
            this.YWY.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.YWY_DrawItem);
            // 
            // sellerBindingSource
            // 
            this.sellerBindingSource.DataMember = "Seller";
            this.sellerBindingSource.DataSource = this.hyerpDataSet;
            // 
            // hyerpDataSet
            // 
            this.hyerpDataSet.DataSetName = "hyerpDataSet";
            this.hyerpDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // XMMC
            // 
            this.XMMC.Location = new System.Drawing.Point(113, 89);
            this.XMMC.Name = "XMMC";
            this.XMMC.Size = new System.Drawing.Size(181, 21);
            this.XMMC.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "项目名称";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "客户类型";
            // 
            // KHLX
            // 
            this.KHLX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KHLX.FormattingEnabled = true;
            this.KHLX.Items.AddRange(new object[] {
            "开发商",
            "个人承包商",
            "门窗墙幕公司",
            "总包",
            "经销商",
            "配套公司",
            "交通设施公司",
            "园林公司",
            "私人客户"});
            this.KHLX.Location = new System.Drawing.Point(114, 116);
            this.KHLX.Name = "KHLX";
            this.KHLX.Size = new System.Drawing.Size(180, 20);
            this.KHLX.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("楷体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(100, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 35);
            this.label4.TabIndex = 22;
            this.label4.Text = "新增客户";
            // 
            // sellerTableAdapter
            // 
            this.sellerTableAdapter.ClearBeforeFill = true;
            // 
            // NewCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 272);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.KHLX);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.XMMC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.YWY);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GSMC);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "NewCustomer";
            this.Text = "新增客户";
            this.Load += new System.EventHandler(this.NewCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sellerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyerpDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox GSMC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox YWY;
        private System.Windows.Forms.TextBox XMMC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox KHLX;
        private System.Windows.Forms.Label label4;
        private hyerpDataSet hyerpDataSet;
        private System.Windows.Forms.BindingSource sellerBindingSource;
        private hyerpDataSetTableAdapters.SellerTableAdapter sellerTableAdapter;
    }
}
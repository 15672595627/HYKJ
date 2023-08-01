using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using WindowsFormsApp1.Class;
using System.Data.Common;

namespace WindowsFormsApp1.Scheduling
{
    public partial class CheckStock : Form
    {
        public CheckStock()
        {
            InitializeComponent();
        }
        public string User { get; set; }
        public string Group { get; set; }

        DataTable dt;
        DataAdapter da;
        
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private void CheckStock_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void CheckStock_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string wlbm = txtWlbm.Text.Trim();
            string wlmc = txtWlmc.Text.Trim();
            string wlgg = txtWlgg.Text.Trim();
            string str = "select [id], [materialsId] as 物料编码, [materialsName] as 物料名称, [specification] as 规格型号, [auxiliarysign] as 助记号, [stockId] as 仓库代码 , [stockName] as 仓库名称, [unitNumber] as 数量, [unit] as 单位, kuwei as 库位,[weight] as 重量, [weightUnit] as 重量单位, [remark] as 备注, [purchasingPrice] as 最新进价, [stockAmount] as 库存金额 from MaterialStock where materialsId like '%" + wlbm + "%' and materialsName like '%"+wlmc+"%' and specification like '%" + wlgg+"%'";
            da = new SqlDataAdapter(str, SQL);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["id"].Visible = false;
        }

        private void txtHtbh_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ContactH contactH = new ContactH();
            contactH.Show();
        }
    }
}

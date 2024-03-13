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
            string str = "select id,orderid as 单据编号,contractid as 合同编号,zs as 数量,date as 日期,desgin as 下单员,company as 客户名,project as 项目名称,color as 颜色,product as 产品,sfyl as 塑粉用量,meters as 米数,clid as 材料ID,clmc as 材料名称,clgg as 材料规格,cllb as 材料类别,ccpf as 尺寸喷粉,zs as 支数,bz as 备注 from [dbo].[DesginBom] where clid like '%" + wlbm + "%' and clmc like '%" + wlmc+ "%' and clgg like '%" + wlgg+ "%'and rkzt = '未入库'";
            da = new SqlDataAdapter(str, SQL);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["id"].Visible = false;
        }

        private void txtHtbh_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ContactH contactH = new ContactH();
            contactH.Show(this);
        }

        private void 下推ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Plan
{
    public partial class PlanList : Form
    {
        public PlanList()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private AutoSizeFormClass asc = new AutoSizeFormClass();

        public string PLL_User { get; set; }
        public string PLL_Group { get; set; }


        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            string rq1 = RQ1.Text.Trim();
            string rq2 = RQ2.Text.Trim();
            string strsql = "select orderid as 单据编号,date as 日期,planner as 排期人,contractid as 合同编号,service as 跟单员,company as 客户名称,product as 产品,nr as 内容,wlzt as 物料状态,wlztbz as 物料备注,planstart as 排期开工时间,planend as 排期结束时间,jjgzt as 金加工状态,jjgztzt as 金加工暂停,ptzt as 喷涂状态,ptztzt as 喷涂暂停 from [dbo].[Plan] where date between '" + rq1 + "' and '" + rq2 + "'";
            SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string djbh = dataGridView1.CurrentRow.Cells["单据编号"].Value.ToString();
            ProductionPlanR planR = new ProductionPlanR();
            planR.PPR_User = PLL_User;
            planR.PPR_Group = PLL_Group;
            planR.PPR_DJBH = djbh;
            planR.Show();
        }

        private void PlanList_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void PlanList_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}

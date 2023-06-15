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

namespace WindowsFormsApp1.Plan
{
    public partial class PlanOrder : Form
    {
        public PlanOrder()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string htbh = dataGridView1.CurrentRow.Cells["合同编号"].Value.ToString();
            string gsm = dataGridView1.CurrentRow.Cells["公司名"].Value.ToString();
            string cpmc = dataGridView1.CurrentRow.Cells["产品"].Value.ToString();
            string nr = dataGridView1.CurrentRow.Cells["内容"].Value.ToString();
            ProductionPlan plan = (ProductionPlan)this.Owner;
            plan.Controls["HTBH"].Text = htbh;
            plan.Controls["GSM"].Text = gsm;
            plan.Controls["CPMC"].Text = cpmc;
            plan.Controls["NR"].Text = nr;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string aa = CP.Text.Trim();
            string bb = GSM.Text.Trim();
            string cc = XMMC.Text.Trim();
            string strsql = "select orderid as 销售订单,contractid as 合同编号,company as 公司名,project as 项目名称,productname as 产品,sub as 内容,quantity as 数量,unit as 单位,price as 单价,meters as 米数,amount as 金额,pmc as 状态 from [dbo].[Order_b] where productname like '%" + aa + "%' and company like '%" + bb + "%'  and project like '%" + cc + "%' and pmc = 'N' and dusting = '喷粉'";
            SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}

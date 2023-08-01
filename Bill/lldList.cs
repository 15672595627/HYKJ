using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Bill
{
    // Token: 0x02000084 RID: 132
    public partial class lldList : Form
    {
        // Token: 0x06000747 RID: 1863 RVA: 0x000FC26A File Offset: 0x000FA46A
        public lldList()
        {
            this.InitializeComponent();
        }

        private SqlDataAdapter da = null;
        private DataTable dt = null;
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private void button1_Click(object sender, EventArgs e)
        {
            string text = this.txtHtbh.Text.Trim();
            string text2 = this.txtlld.Text.Trim();
            string text3 = this.dt1.Text.Trim();
            string text4 = this.dt2.Text.Trim();
            string selectCommandText = string.Concat(new string[]
            {
                "select id, materialRequisitionId as 领料单号 , contactId as 合同编号, orderId as 订单编号 ,company as 客户名称,project as 项目名称,product as 产品,stockName as 仓库,kuwei as 库位 ,materialsId as 物料代码,materialsName as 物料名称,specification as 物料规格,unitNumber as 数量,unit as 单位 ,date as 领料时间,remark as 备注 from linliaodan where contactId like '%",
                text,
                "%' and materialRequisitionId like '%",
                text2,
                "%' and date between '",
                text3,
                "' and '",
                text4,
                "' and state = 'Y' order by date DESC "
            });
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, lldList.SQL);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            this.dataGridView1.DataSource = dataTable;
            this.dataGridView1.Columns["id"].Visible = false;
        }

        private void lldList_Load(object sender, EventArgs e)
        {
            this.asc.controllInitializeSize(this);
        }

        private void lldList_SizeChanged(object sender, EventArgs e)
        {
            this.asc.controlAutoSize(this);
        }

    }
}

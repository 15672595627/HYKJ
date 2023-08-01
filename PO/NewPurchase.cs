using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.PO
{
    // Token: 0x0200002F RID: 47
    public partial class NewPurchase : Form
    {
        // Token: 0x06000246 RID: 582 RVA: 0x0002CF46 File Offset: 0x0002B146
        public NewPurchase()
        {
            this.InitializeComponent();
        }

        // Token: 0x17000055 RID: 85
        // (get) Token: 0x06000247 RID: 583 RVA: 0x0002CF69 File Offset: 0x0002B169
        // (set) Token: 0x06000248 RID: 584 RVA: 0x0002CF71 File Offset: 0x0002B171
        public string User { get; set; }

        // Token: 0x17000056 RID: 86
        // (get) Token: 0x06000249 RID: 585 RVA: 0x0002CF7A File Offset: 0x0002B17A
        // (set) Token: 0x0600024A RID: 586 RVA: 0x0002CF82 File Offset: 0x0002B182
        public string Group { get; set; }

        // Token: 0x0600024B RID: 587 RVA: 0x0002CF8C File Offset: 0x0002B18C
        private void txtGys_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SupplierPO supplierPO = new SupplierPO();
            supplierPO.Show(this);
        }

        // Token: 0x0600024C RID: 588 RVA: 0x0002CFA8 File Offset: 0x0002B1A8
        private void button1_Click(object sender, EventArgs e)
        {
            string selectCommandText = "select id,ddId as 订单编号,contactId as 合同编号,company as 客户, project as 项目,materialsId as 物料代码, materialsName as 物料名称, specification as 规格型号,stockName as 仓库名称 ,unitNumber as 库存数量,unit as 单位,purchaseNumber as 采购数量,kuwei as 库位,weight as 重量,weightUnit as 重量单位,remark as 备注,xtState as 下推状态 from purchaseRequest where  xtState = '已下推'order by Date DESC";
            this.da = new SqlDataAdapter(selectCommandText, NewPurchase.SQL);
            this.dt = new DataTable();
            this.da.Fill(this.dt);
            this.dataGridView1.DataSource = this.dt;
            this.dataGridView1.Columns["id"].Visible = false;
        }

        // Token: 0x04000383 RID: 899
        private SqlDataAdapter da;

        // Token: 0x04000384 RID: 900
        private DataTable dt;

        // Token: 0x04000385 RID: 901
        private AutoSizeFormClass asc = new AutoSizeFormClass();

        // Token: 0x04000386 RID: 902
        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
    }
}

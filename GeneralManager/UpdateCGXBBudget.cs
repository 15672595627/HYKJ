using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.GeneralManager
{
    public partial class UpdateCGXBBudget : Form
    {
        public UpdateCGXBBudget()
        {
            InitializeComponent();
        }
        DataTable dt;
        SqlDataAdapter da;
        public string Username { get; set; }
        public string Group { get; set; }
        public string id { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private void UpdateCGXBBudget_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            string sql = "select id,employee as 员工人数,monthlySigningAmountPerEmployee as 职员人均月签单额,signingTarget as 签单目标,shippingTarget as 出货目标,paymentTarget as 回款目标,deposit as 定金,currentMonthShipmentReceipt as 本月出货收款,collectionEarlyArrears as 收前期欠款,refundAccounts as 退过账款,outputValueTarget as 产值目标,procurementPlanning as 采购计划,productionMaterialProcurementPlan as 生产用物料采购计划,equipmentProcurementPlan as 设备采购计划,otherProcurementPlans as 其他采购计划,payPriceGoods as 支付货款 ,date as 时间 from [dbo].[ZJBcgxys] where id = '" + id + "'and state = 1";
            da = new SqlDataAdapter(sql, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
        }

        private void UpdateCGXBBudget_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommandBuilder SCB = new SqlCommandBuilder(da);
                da.Update(dt);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("保存失败");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "select id,employee as 员工人数,monthlySigningAmountPerEmployee as 职员人均月签单额,signingTarget as 签单目标,shippingTarget as 出货目标,paymentTarget as 回款目标,deposit as 定金,currentMonthShipmentReceipt as 本月出货收款,collectionEarlyArrears as 收前期欠款,refundAccounts as 退过账款,outputValueTarget as 产值目标,procurementPlanning as 采购计划,productionMaterialProcurementPlan as 生产用物料采购计划,equipmentProcurementPlan as 设备采购计划,otherProcurementPlans as 其他采购计划,payPriceGoods as 支付货款 ,date as 时间 from [dbo].[ZJBcgxys] where state = 1";
            da = new SqlDataAdapter(sql, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
        }
    }
}

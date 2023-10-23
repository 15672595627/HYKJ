using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.DesignDepartment
{
    public partial class DUpdateSummaryBudget : Form
    {
        public DUpdateSummaryBudget()
        {
            InitializeComponent();
        }
        DataTable dt;
        SqlDataAdapter da;
        public string id { get; set; }
        public string Username { get; set; }
        public string Group { get; set; }
        public string Iid { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private void DUpdateSummaryBudget_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            string sql = "select [id], [wages] as 工资, [awardRaising] as 提奖, [socialSecurity] as 社保, [accumulationFund] as 公积金, [boardExpenses ] as 伙食费, [benefit] as 福利费, [commercialInsurance] as 商业保险, [educationFund] as 教育基金, [weldingExternalProcessing] as 焊接外加工, [processingFee] as加工费, [officeExpenses] as 办公费, [communicationFee] as 通讯费, [travelExpenses] as 差旅费, [automobileExpenses] as 汽车开支, [lowValueConsumables] as 低值易耗品, [waterAndElectricityExpenses] as 水电费, [gasCost] as 燃气费, [freight] as 运费, [PromotionFee] as 推广费, [costOfOperation] as 业务费, [entertainmentExpenses] as 招待费, [rent] as 房租, [maintenanceCost] as 维修费, [constructionSiteExpenses] as 工地开支, [sample] as 样品, [supplementaryOrde] as 补单, [recruitmentFees] as 招聘费, [interestExpense] as 利息支出, [commission] as 手续费, [taxes] as 税金, [other] as 其他, [date] as 月份, [state] as 状态 from SJBBudget where id = '" + id + "'";
            da = new SqlDataAdapter(sql, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
        }

        private void DUpdateSummaryBudget_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "select [id], [wages] as 工资, [awardRaising] as 提奖, [socialSecurity] as 社保, [accumulationFund] as 公积金, [boardExpenses ] as 伙食费, [benefit] as 福利费, [commercialInsurance] as 商业保险, [educationFund] as 教育基金, [weldingExternalProcessing] as 焊接外加工, [processingFee] as加工费, [officeExpenses] as 办公费, [communicationFee] as 通讯费, [travelExpenses] as 差旅费, [automobileExpenses] as 汽车开支, [lowValueConsumables] as 低值易耗品, [waterAndElectricityExpenses] as 水电费, [gasCost] as 燃气费, [freight] as 运费, [PromotionFee] as 推广费, [costOfOperation] as 业务费, [entertainmentExpenses] as 招待费, [rent] as 房租, [maintenanceCost] as 维修费, [constructionSiteExpenses] as 工地开支, [sample] as 样品, [supplementaryOrde] as 补单, [recruitmentFees] as 招聘费, [interestExpense] as 利息支出, [commission] as 手续费, [taxes] as 税金, [other] as 其他, [date] as 月份, [state] as 状态 from SJBBudget where state = 1";
            da = new SqlDataAdapter(sql, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
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
    }
}

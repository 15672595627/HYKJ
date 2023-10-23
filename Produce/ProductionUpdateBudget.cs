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

namespace WindowsFormsApp1.Produce
{
    public partial class ProductionUpdateBudget : Form
    {
        public ProductionUpdateBudget()
        {
            InitializeComponent();
        }
        public string Username { get; set; }
        public string Group { get; set; }
        public string id { get; set; }
        int Iid;
        int zt;
        string rq;
        DataTable dt;
        SqlDataAdapter da;
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private void ProductionUpdateBudget_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            string sql = "SELECT id,[date] AS 时间, [dayLineNumber] as 白班几条线,[dayDusting] as 白班日喷粉工时,[dayBeforeWorkshopSection] as 白班日前工段工时,[dayBeforeWorkshopSectionNumber] as 白班前工段人数,[dayBeforePieceCount] as 白班前工段计件人数,[dayAfterWorkshopSectionNumber] as 白班后工段人数,[dayAfterPieceCount] as 白班后工段计件人数,[dayTotalNumber] as 白班总人数,[nightLineNumber] as 夜班几条线,[nightDusting] as 夜班日喷粉工时,[nightBeforeWorkshopSection] as 夜班日前工段工时,[nightBeforeWorkshopSectionNumber] as 夜班前工段人数,[nightBeforePieceCount] as 夜班前工段计件人数,[nightAfterWorkshopSectionNumber] as 夜班后工段人数,[nightAfterPieceCount] as 夜班后工段计件人数,[nightTotalNumber] as 夜班总人数,[aDayWarehousingTarget] as 日入库目标,[aDayOutputValueWarehousingTarget] as 日入库产值目标,[mainMaterialCostProfile] as 主料成本,[profiles] as 型材,[accessory] as 配件,[plasticPowder] as 塑粉,[accessories] as 辅料成本,[package] AS 包装,[consumables] AS 消耗品,[baseWages] AS 基本工资,[workOvertimeWages] AS 加班工资,[nightShiftWages] AS 夜班补贴,[pieceRate] AS 计件工资,[welfareMealExpenses] AS 福利餐费,[waterAndElectricityExpenses] AS 水电费,[naturalGas] AS 天然气,[CO2] AS CO2,state as 状态 FROM ProductionWorkshopBudget where id = '" + id + "'";
            da = new SqlDataAdapter(sql, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
        }

        private void ProductionUpdateBudget_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "SELECT id,[date] AS 时间, [dayLineNumber] as 白班几条线,[dayDusting] as 白班日喷粉工时,[dayBeforeWorkshopSection] as 白班日前工段工时,[dayBeforeWorkshopSectionNumber] as 白班前工段人数,[dayBeforePieceCount] as 白班前工段计件人数,[dayAfterWorkshopSectionNumber] as 白班后工段人数,[dayAfterPieceCount] as 白班后工段计件人数,[dayTotalNumber] as 白班总人数,[nightLineNumber] as 夜班几条线,[nightDusting] as 夜班日喷粉工时,[nightBeforeWorkshopSection] as 夜班日前工段工时,[nightBeforeWorkshopSectionNumber] as 夜班前工段人数,[nightBeforePieceCount] as 夜班前工段计件人数,[nightAfterWorkshopSectionNumber] as 夜班后工段人数,[nightAfterPieceCount] as 夜班后工段计件人数,[nightTotalNumber] as 夜班总人数,[aDayWarehousingTarget] as 日入库目标,[aDayOutputValueWarehousingTarget] as 日入库产值目标,[mainMaterialCostProfile] as 主料成本,[profiles] as 型材,[accessory] as 配件,[plasticPowder] as 塑粉,[accessories] as 辅料成本,[package] AS 包装,[consumables] AS 消耗品,[baseWages] AS 基本工资,[workOvertimeWages] AS 加班工资,[nightShiftWages] AS 夜班补贴,[pieceRate] AS 计件工资,[welfareMealExpenses] AS 福利餐费,[waterAndElectricityExpenses] AS 水电费,[naturalGas] AS 天然气,[CO2] AS CO2,state as 状态 FROM ProductionWorkshopBudget where state= 1";
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

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
using System.Windows.Shapes;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Produce
{
    public partial class PBListByYear : Form
    {
        public PBListByYear()
        {
            InitializeComponent();
        }
        public string Username { get; set; }
        public string Group { get; set; }
        DataTable dt;
        SqlDataAdapter da;
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void PBListByYear_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void PBListByYear_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string str = "SELECT CONVERT(VARCHAR(10),YEAR( [date] ),120)as 年,CONVERT(VARCHAR(10),MONTH ( [date] ) ,120)AS 月,SUM ( [dayLineNumber] ) AS 白班几条线,SUM ( [dayDusting] ) AS 白班日喷粉工时,SUM ( [dayBeforeWorkshopSection] ) AS 白班日前工段工时,SUM ( [dayBeforeWorkshopSectionNumber] ) AS 白班前工段人数,SUM ( [dayBeforePieceCount] ) AS 白班前工段计件人数,SUM ( [dayAfterWorkshopSectionNumber] ) AS 白班后工段人数,SUM ( [dayAfterPieceCount] ) AS 白班后工段计件人数,SUM ( [dayTotalNumber] ) AS 白班总人数,SUM ( [nightLineNumber] ) AS 夜班几条线,SUM ( [nightDusting] ) AS 夜班日喷粉工时,SUM ( [nightBeforeWorkshopSection] ) AS 夜班日前工段工时,SUM ( [nightBeforeWorkshopSectionNumber] ) AS 夜班前工段人数,SUM ( [nightBeforePieceCount] ) AS 夜班前工段计件人数,SUM ( [nightAfterWorkshopSectionNumber] ) AS 夜班后工段人数,SUM ( [nightAfterPieceCount] ) AS 夜班后工段计件人数,SUM ( [nightTotalNumber] ) AS 夜班总人数,SUM ( [aDayWarehousingTarget] ) AS 日入库目标,SUM ( [aDayOutputValueWarehousingTarget] ) AS 日入库产值目标,SUM ( [mainMaterialCostProfile] ) AS 主料成本,SUM ( [profiles] ) AS 型材,SUM ( [accessory] ) AS 配件,SUM ( [plasticPowder] ) AS 塑粉,SUM ( [accessories] ) AS 辅料成本,SUM ( [package] ) AS 包装,SUM ( [consumables] ) AS 消耗品,SUM ( [baseWages] ) AS 基本工资,SUM ( [workOvertimeWages] ) AS 加班工资,SUM ( [nightShiftWages] ) AS 夜班补贴,SUM ( [pieceRate] ) AS 计件工资,SUM ( [welfareMealExpenses] ) AS 福利餐费,SUM ( [waterAndElectricityExpenses] ) AS 水电费,SUM ( [naturalGas] ) AS 天然气,SUM ( [CO2] ) AS CO2 FROM ProductionWorkshopBudget WHERE DATE LIKE '%" + dateTimePicker1.Text+"%' GROUP BY YEAR( [date] ),MONTH( [date] ) ORDER BY YEAR( [date] )";
            da = new SqlDataAdapter(str, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            int sum1 = 0;
            decimal sum2 = 0;
            decimal sum3 = 0;
            int sum4 = 0;
            int sum5 = 0;
            int sum6 = 0;
            int sum7 = 0;
            int sum8 = 0;
            int sum9 = 0;
            decimal sum10 = 0;
            decimal sum11 = 0;
            int sum12 = 0;
            int sum13 = 0;
            int sum14 = 0;
            int sum15 = 0;
            int sum16 = 0;
            decimal sum17 = 0;
            decimal sum18 = 0;
            int sum19 = 0;
            int sum20 = 0;
            int sum21 = 0;
            int sum22 = 0;
            int sum23 = 0;
            int sum24 = 0;
            int sum25 = 0;
            decimal sum26 = 0;
            decimal sum27 = 0;
            decimal sum28 = 0;
            decimal sum29 = 0;
            decimal sum30 = 0;
            decimal sum31 = 0;
            decimal sum32 = 0;
            decimal sum33 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum1 += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                sum2 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                sum3 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                sum4 += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                sum5 += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
                sum6 += Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
                sum7 += Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value);
                sum8 += Convert.ToInt32(dataGridView1.Rows[i].Cells[9].Value);
                sum9 += Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value);
                sum10 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[11].Value);
                sum11 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[12].Value);
                sum12 += Convert.ToInt32(dataGridView1.Rows[i].Cells[13].Value);
                sum13 += Convert.ToInt32(dataGridView1.Rows[i].Cells[14].Value);
                sum14 += Convert.ToInt32(dataGridView1.Rows[i].Cells[15].Value);
                sum15 += Convert.ToInt32(dataGridView1.Rows[i].Cells[16].Value);
                sum16 += Convert.ToInt32(dataGridView1.Rows[i].Cells[17].Value);
                sum17 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[18].Value);
                sum18 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[19].Value);
                sum19 += Convert.ToInt32(dataGridView1.Rows[i].Cells[20].Value);
                sum20 += Convert.ToInt32(dataGridView1.Rows[i].Cells[21].Value);
                sum21 += Convert.ToInt32(dataGridView1.Rows[i].Cells[22].Value);
                sum22 += Convert.ToInt32(dataGridView1.Rows[i].Cells[23].Value);
                sum23 += Convert.ToInt32(dataGridView1.Rows[i].Cells[24].Value);
                sum24 += Convert.ToInt32(dataGridView1.Rows[i].Cells[25].Value);
                sum25 += Convert.ToInt32(dataGridView1.Rows[i].Cells[26].Value);
                sum26 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[27].Value);
                sum27 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[28].Value);
                sum28 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[29].Value);
                sum29 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[30].Value);
                sum30 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[31].Value);
                sum31 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[32].Value);
                sum32 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[33].Value);
                sum33 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[34].Value);
            }
            string ssum1 = sum1.ToString();
            string ssum2 = sum2.ToString();
            string ssum3 = sum3.ToString();
            string ssum4 = sum4.ToString();
            string ssum5 = sum5.ToString();
            string ssum6 = sum6.ToString();
            string ssum7 = sum7.ToString();
            string ssum8 = sum8.ToString();
            string ssum9 = sum9.ToString();
            string ssum10 = sum10.ToString();
            string ssum11 = sum11.ToString();
            string ssum12 = sum12.ToString();
            string ssum13 = sum13.ToString();
            string ssum14 = sum14.ToString();
            string ssum15 = sum15.ToString();
            string ssum16 = sum16.ToString();
            string ssum17 = sum17.ToString();
            string ssum18 = sum18.ToString();
            string ssum19 = sum19.ToString();
            string ssum20 = sum20.ToString();
            string ssum21 = sum21.ToString();
            string ssum22 = sum22.ToString();
            string ssum23 = sum23.ToString();
            string ssum24 = sum24.ToString();
            string ssum25 = sum25.ToString();
            string ssum26 = sum26.ToString();
            string ssum27 = sum27.ToString();
            string ssum28 = sum28.ToString();
            string ssum29 = sum29.ToString();
            string ssum30 = sum30.ToString();
            string ssum31 = sum31.ToString();
            string ssum32 = sum32.ToString();
            string ssum33 = sum33.ToString();
            string[] row = { "合计", "", ssum1, ssum2, ssum3, ssum4, ssum5, ssum6, ssum7, ssum8, ssum9, ssum10, ssum11, ssum12, ssum13, ssum14, ssum15, ssum16, ssum17, ssum18, ssum19, ssum20, ssum21, ssum22, ssum23, ssum24, ssum25, ssum26, ssum27, ssum28, ssum29, ssum30, ssum31, ssum32, ssum33 };
            ((DataTable)dataGridView1.DataSource).Rows.Add(row);
        }
    }
}

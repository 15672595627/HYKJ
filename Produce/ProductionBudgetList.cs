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
using WindowsFormsApp1.MarketingDepartment;

namespace WindowsFormsApp1.Produce
{
    public partial class ProductionBudgetList : Form
    {
        public ProductionBudgetList()
        {
            InitializeComponent();
        }
        public string Username { get; set; }
        public string Group { get; set; }
        DataTable dt;
        SqlDataAdapter da;
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private void ProductionBudgetList_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void ProductionBudgetList_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "SELECT id,[date] AS 时间, [dayLineNumber] as 白班几条线,[dayDusting] as 白班日喷粉工时,[dayBeforeWorkshopSection] as 白班日前工段工时,[dayBeforeWorkshopSectionNumber] as 白班前工段人数,[dayBeforePieceCount] as 白班前工段计件人数,[dayAfterWorkshopSectionNumber] as 白班后工段人数,[dayAfterPieceCount] as 白班后工段计件人数,[dayTotalNumber] as 白班总人数,[nightLineNumber] as 夜班几条线,[nightDusting] as 夜班日喷粉工时,[nightBeforeWorkshopSection] as 夜班日前工段工时,[nightBeforeWorkshopSectionNumber] as 夜班前工段人数,[nightBeforePieceCount] as 夜班前工段计件人数,[nightAfterWorkshopSectionNumber] as 夜班后工段人数,[nightAfterPieceCount] as 夜班后工段计件人数,[nightTotalNumber] as 夜班总人数,[aDayWarehousingTarget] as 日入库目标,[aDayOutputValueWarehousingTarget] as 日入库产值目标,[mainMaterialCostProfile] as 主料成本,[profiles] as 型材,[accessory] as 配件,[plasticPowder] as 塑粉,[accessories] as 辅料成本,[package] AS 包装,[consumables] AS 消耗品,[baseWages] AS 基本工资,[workOvertimeWages] AS 加班工资,[nightShiftWages] AS 夜班补贴,[pieceRate] AS 计件工资,[welfareMealExpenses] AS 福利餐费,[waterAndElectricityExpenses] AS 水电费,[naturalGas] AS 天然气,[CO2] AS CO2,state as 状态 FROM ProductionWorkshopBudget where [date] like '%"+dateTimePicker1.Text+"%'";
            da = new SqlDataAdapter(str, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["状态"].Visible = false;
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
            string[] row = { "1", "合计", ssum1, ssum2, ssum3, ssum4, ssum5, ssum6, ssum7, ssum8, ssum9, ssum10, ssum11, ssum12, ssum13, ssum14, ssum15, ssum16, ssum17, ssum18, ssum19, ssum20, ssum21, ssum22, ssum23, ssum24, ssum25, ssum26, ssum27, ssum28, ssum29, ssum30, ssum31, ssum32, ssum33};
            ((DataTable)dataGridView1.DataSource).Rows.Add(row);
        }
        int cot = 0;
        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = "";//可以在这里设置默认文件名
            string saveFileName = "";//文件保存名
            SaveFileDialog saveDialog = new SaveFileDialog();//实例化文件对象
            saveDialog.DefaultExt = "xlsx";//文件默认扩展名
            saveDialog.Filter = "Excel文件|*.xlsx";//获取或设置当前文件名筛选器字符串，该字符串决定对话框的“另存为文件类型”或“文件类型”框中出现的选择内容。
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();//打开保存窗口给你选择路径和设置文件名
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，您的电脑可能未安装Excel");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;//Workbooks代表一个 Microsoft Excel 工作簿
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);//新建一个工作表。 新工作表将成为活动工作表。
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1 
                                                                                                                                  //写入标题             
            for (int i = 0; i < dataGridView1.ColumnCount; i++)//遍历循环获取DataGridView标题
            { worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText; }// worksheet.Cells[1, i + 1]表示工作簿第一行第i+1列，Columns[i].HeaderText表示第i列的表头
                                                                                //写入数值
            for (int r = 0; r < dataGridView1.Rows.Count; r++)//这里表示数据的行标,dataGridView1.Rows.Count表示行数
            {
                for (int i = 0; i < dataGridView1.ColumnCount; i++)//遍历r行的列数
                {
                    worksheet.Cells[r + 2, i + 1] = dataGridView1.Rows[r].Cells[i].Value;//Cells[r + 2, i + 1]表示工作簿从第二行开始第一行保存为表头了，dataGridView1.Rows[r].Cells[i].Value获取列的r行i值
                }
                System.Windows.Forms.Application.DoEvents();//实时更新表格
            }
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            MessageBox.Show(fileName + "资料保存成功", "提示", MessageBoxButtons.OK);//提示保存成功
            if (saveFileName != "")//saveFileName保存文件名不为空
            {
                try
                {
                    workbook.Saved = true;//获取或设置一个值，该值指示工作簿自上次保存以来是否进行了更改
                    workbook.SaveCopyAs(saveFileName);  //fileSaved = true;将工作簿副本保存到文件中，但不修改内存中打开的工作簿                 
                }
                catch (Exception ex)
                {//fileSaved = false;                      
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁  
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string iId = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            ProductionUpdateBudget updateCGXBBudget = new ProductionUpdateBudget
                ();
            updateCGXBBudget.id = iId;
            updateCGXBBudget.Username = Username;
            updateCGXBBudget.Group = Group;
            updateCGXBBudget.ShowDialog();
        }

        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(SQL);
            conn.Open();
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                int m = dataGridView1.SelectedRows[i].Index;
                int id = Convert.ToInt32(dataGridView1.Rows[m].Cells["id"].Value);
                decimal zt = Convert.ToDecimal(dataGridView1.Rows[m].Cells["状态"].Value);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update ProductionWorkshopBudget set  state = -1 where id = '" + id + "'";
                cot = cmd.ExecuteNonQuery();
            }
            if (cot > 0)
            {
                MessageBox.Show("删除成功");
            }
            else
            {
                MessageBox.Show("删除失败");
            }
            conn.Close();
            this.Close();
        }
    }
}
